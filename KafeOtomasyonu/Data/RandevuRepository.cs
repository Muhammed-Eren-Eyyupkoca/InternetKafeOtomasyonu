using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using KafeOtomasyonu.Helpers;
using KafeOtomasyonu.Models;

namespace KafeOtomasyonu.Data
{
    /// <summary>
    /// Randevu veritabanı işlemleri
    /// </summary>
    public class RandevuRepository
    {
        /// <summary>
        /// Yeni randevu ekle
        /// </summary>
        public int Add(Randevu randevu)
        {
            string query = @"INSERT INTO Randevular 
                           (KullaniciID, MasaID, RandevuTarihi, BaslangicSaati, BitisSaati, ToplamSaat, ToplamUcret, Durum)
                           VALUES (@KullaniciID, @MasaID, @RandevuTarihi, @BaslangicSaati, @BitisSaati, @ToplamSaat, @ToplamUcret, @Durum)";

            var parameters = DatabaseHelper.CreateParameters(
                ("@KullaniciID", randevu.KullaniciID),
                ("@MasaID", randevu.MasaID),
                ("@RandevuTarihi", randevu.RandevuTarihi),
                ("@BaslangicSaati", randevu.BaslangicSaati),
                ("@BitisSaati", randevu.BitisSaati),
                ("@ToplamSaat", randevu.ToplamSaat),
                ("@ToplamUcret", randevu.ToplamUcret),
                ("@Durum", randevu.Durum)
            );

            return DatabaseHelper.ExecuteInsertAndGetId(query, parameters);
        }

        /// <summary>
        /// Randevu durumunu güncelle
        /// </summary>
        public void UpdateDurum(int randevuId, string durum)
        {
            string query = "UPDATE Randevular SET Durum = @Durum WHERE RandevuID = @RandevuID";
            
            // Duruma göre ek alanları güncelle
            if (durum == "Onaylandi")
            {
                query = "UPDATE Randevular SET Durum = @Durum, OnayTarihi = @Tarih WHERE RandevuID = @RandevuID";
            }
            else if (durum == "Tamamlandi")
            {
                query = "UPDATE Randevular SET Durum = @Durum, TamamlanmaTarihi = @Tarih WHERE RandevuID = @RandevuID";
            }

            var parameters = DatabaseHelper.CreateParameters(
                ("@Durum", durum),
                ("@Tarih", DateTime.Now),
                ("@RandevuID", randevuId)
            );

            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Randevu iptal et
        /// </summary>
        public void IptalEt(int randevuId, string neden = "Kullanıcı tarafından iptal edildi")
        
        {
            string query = @"UPDATE Randevular 
                           SET Durum = 'Iptal', IptalNedeni = @IptalNedeni 
                           WHERE RandevuID = @RandevuID";

            var parameters = DatabaseHelper.CreateParameters(
                ("@IptalNedeni", neden),
                ("@RandevuID", randevuId)
            );

            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Randevu düzenle (tarih ve saat güncelleme)
        /// </summary>
        public void Update(int randevuId, DateTime yeniTarih, TimeSpan yeniBaslangic, TimeSpan yeniBitis, int toplamSaat, decimal toplamUcret)
        {
            string query = @"UPDATE Randevular 
                           SET RandevuTarihi = @RandevuTarihi, 
                               BaslangicSaati = @BaslangicSaati, 
                               BitisSaati = @BitisSaati, 
                               ToplamSaat = @ToplamSaat, 
                               ToplamUcret = @ToplamUcret
                           WHERE RandevuID = @RandevuID";

            var parameters = DatabaseHelper.CreateParameters(
                ("@RandevuTarihi", yeniTarih),
                ("@BaslangicSaati", yeniBaslangic),
                ("@BitisSaati", yeniBitis),
                ("@ToplamSaat", toplamSaat),
                ("@ToplamUcret", toplamUcret),
                ("@RandevuID", randevuId)
            );

            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Randevu nesnesini güncelle
        /// </summary>
        public void Update(Randevu randevu)
        {
            string query = @"UPDATE Randevular 
                           SET MasaID = @MasaID,
                               RandevuTarihi = @RandevuTarihi, 
                               BaslangicSaati = @BaslangicSaati, 
                               BitisSaati = @BitisSaati, 
                               ToplamSaat = @ToplamSaat, 
                               ToplamUcret = @ToplamUcret
                           WHERE RandevuID = @RandevuID";

            var parameters = DatabaseHelper.CreateParameters(
                ("@MasaID", randevu.MasaID),
                ("@RandevuTarihi", randevu.RandevuTarihi),
                ("@BaslangicSaati", randevu.BaslangicSaati),
                ("@BitisSaati", randevu.BitisSaati),
                ("@ToplamSaat", randevu.ToplamSaat),
                ("@ToplamUcret", randevu.ToplamUcret),
                ("@RandevuID", randevu.RandevuID)
            );

            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Randevuyu "Gelmedi" olarak işaretle
        /// </summary>
        public void GelmediOlarakIsaretle(int randevuId)
        {
            UpdateDurum(randevuId, "Gelmedi");
        }

        /// <summary>
        /// Çakışan randevu kontrolü
        /// </summary>
        public bool HasConflict(int masaId, DateTime tarih, TimeSpan baslangic, TimeSpan bitis, int? excludeRandevuId = null)
        {
            string query = @"SELECT COUNT(*) FROM Randevular 
                           WHERE MasaID = @MasaID 
                           AND RandevuTarihi = @RandevuTarihi
                           AND Durum = 'Aktif'
                           AND (@ExcludeID IS NULL OR RandevuID != @ExcludeID)
                           AND (
                               (@Baslangic >= BaslangicSaati AND @Baslangic < BitisSaati)
                               OR (@Bitis > BaslangicSaati AND @Bitis <= BitisSaati)
                               OR (@Baslangic <= BaslangicSaati AND @Bitis >= BitisSaati)
                           )";

            var parameters = DatabaseHelper.CreateParameters(
                ("@MasaID", masaId),
                ("@RandevuTarihi", tarih),
                ("@Baslangic", baslangic),
                ("@Bitis", bitis),
                ("@ExcludeID", excludeRandevuId)
            );

            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        /// <summary>
        /// Kullanıcının randevularını getir
        /// </summary>
        public List<Randevu> GetByKullaniciId(int kullaniciId)
        {
            string query = @"SELECT r.*, k.KullaniciAdi, k.AdSoyad AS KullaniciAdSoyad, m.MasaNo, m.MasaAdi
                           FROM Randevular r
                           INNER JOIN Kullanicilar k ON r.KullaniciID = k.KullaniciID
                           INNER JOIN Masalar m ON r.MasaID = m.MasaID
                           WHERE r.KullaniciID = @KullaniciID
                           ORDER BY r.RandevuTarihi DESC, r.BaslangicSaati DESC";

            var parameters = DatabaseHelper.CreateParameters(("@KullaniciID", kullaniciId));
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            return MapToRandevuList(dt);
        }

        /// <summary>
        /// Masanın randevularını getir
        /// </summary>
        public List<Randevu> GetByMasaId(int masaId, DateTime? tarih = null)
        {
            string query = @"SELECT r.*, k.KullaniciAdi, k.AdSoyad AS KullaniciAdSoyad, m.MasaNo, m.MasaAdi
                           FROM Randevular r
                           INNER JOIN Kullanicilar k ON r.KullaniciID = k.KullaniciID
                           INNER JOIN Masalar m ON r.MasaID = m.MasaID
                           WHERE r.MasaID = @MasaID
                           AND (@Tarih IS NULL OR r.RandevuTarihi = @Tarih)
                           ORDER BY r.RandevuTarihi, r.BaslangicSaati";

            var parameters = DatabaseHelper.CreateParameters(
                ("@MasaID", masaId),
                ("@Tarih", tarih)
            );
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            return MapToRandevuList(dt);
        }

        /// <summary>
        /// Tüm aktif randevuları getir
        /// </summary>
        public List<Randevu> GetAktifRandevular()
        {
            string query = @"SELECT r.*, k.KullaniciAdi, k.AdSoyad AS KullaniciAdSoyad, m.MasaNo, m.MasaAdi
                           FROM Randevular r
                           INNER JOIN Kullanicilar k ON r.KullaniciID = k.KullaniciID
                           INNER JOIN Masalar m ON r.MasaID = m.MasaID
                           WHERE r.Durum IN ('Beklemede', 'Onaylandi')
                           AND r.RandevuTarihi >= CAST(GETDATE() AS DATE)
                           ORDER BY r.RandevuTarihi, r.BaslangicSaati";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            return MapToRandevuList(dt);
        }

        /// <summary>
        /// Tüm randevuları getir (Admin için)
        /// </summary>
        public List<Randevu> GetAll()
        {
            string query = @"SELECT r.*, k.KullaniciAdi, k.AdSoyad AS KullaniciAdSoyad, m.MasaNo, m.MasaAdi
                           FROM Randevular r
                           INNER JOIN Kullanicilar k ON r.KullaniciID = k.KullaniciID
                           INNER JOIN Masalar m ON r.MasaID = m.MasaID
                           ORDER BY r.RandevuTarihi DESC, r.BaslangicSaati DESC";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            return MapToRandevuList(dt);
        }

        /// <summary>
        /// ID ile randevu getir
        /// </summary>
        public Randevu GetById(int id)
        {
            string query = @"SELECT r.*, k.KullaniciAdi, k.AdSoyad AS KullaniciAdSoyad, m.MasaNo, m.MasaAdi
                           FROM Randevular r
                           INNER JOIN Kullanicilar k ON r.KullaniciID = k.KullaniciID
                           INNER JOIN Masalar m ON r.MasaID = m.MasaID
                           WHERE r.RandevuID = @RandevuID";

            var parameters = DatabaseHelper.CreateParameters(("@RandevuID", id));
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return MapToRandevu(dt.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// Kullanıcının "Gelmedi" sayısını getir
        /// </summary>
        public int GetGelmediCount(int kullaniciId)
        {
            string query = @"SELECT COUNT(*) FROM Randevular 
                           WHERE KullaniciID = @KullaniciID AND Durum = 'Gelmedi'";

            var parameters = DatabaseHelper.CreateParameters(("@KullaniciID", kullaniciId));
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
        }

        // ============= İSTATİSTİK METODLARI =============

        /// <summary>
        /// Kullanıcının toplam randevu sayısı
        /// </summary>
        public int GetKullaniciToplamRandevuSayisi(int kullaniciId)
        {
            string query = "SELECT COUNT(*) FROM Randevular WHERE KullaniciID = @KullaniciID";
            var parameters = DatabaseHelper.CreateParameters(("@KullaniciID", kullaniciId));
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
        }

        /// <summary>
        /// Kullanıcının toplam harcaması
        /// </summary>
        public decimal GetKullaniciToplamHarcama(int kullaniciId)
        {
            string query = @"SELECT ISNULL(SUM(ToplamUcret), 0) FROM Randevular 
                           WHERE KullaniciID = @KullaniciID AND Durum IN ('Onaylandi', 'Tamamlandi')";
            var parameters = DatabaseHelper.CreateParameters(("@KullaniciID", kullaniciId));
            var result = DatabaseHelper.ExecuteScalar(query, parameters);
            return result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
        }

        /// <summary>
        /// Kullanıcının en çok kullandığı masa
        /// </summary>
        public (int MasaID, string MasaAdi, int KullanimSayisi) GetKullaniciEnCokKullanilanMasa(int kullaniciId)
        {
            string query = @"SELECT TOP 1 M.MasaID, M.MasaAdi, COUNT(*) as KullanimSayisi
                           FROM Randevular R
                           INNER JOIN Masalar M ON R.MasaID = M.MasaID
                           WHERE R.KullaniciID = @KullaniciID AND R.Durum IN ('Onaylandi', 'Tamamlandi')
                           GROUP BY M.MasaID, M.MasaAdi
                           ORDER BY COUNT(*) DESC";
            
            var parameters = DatabaseHelper.CreateParameters(("@KullaniciID", kullaniciId));
            var dt = DatabaseHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
            {
                return (
                    Convert.ToInt32(dt.Rows[0]["MasaID"]),
                    dt.Rows[0]["MasaAdi"].ToString(),
                    Convert.ToInt32(dt.Rows[0]["KullanimSayisi"])
                );
            }
            return (0, "Henüz kullanım yok", 0);
        }

        /// <summary>
        /// Kullanıcının ortalama kullanım süresi (saat)
        /// </summary>
        public decimal GetKullaniciOrtalamaKullanimSuresi(int kullaniciId)
        {
            string query = @"SELECT ISNULL(AVG(CAST(ToplamSaat AS FLOAT)), 0) FROM Randevular 
                           WHERE KullaniciID = @KullaniciID AND Durum IN ('Onaylandi', 'Tamamlandi')";
            var parameters = DatabaseHelper.CreateParameters(("@KullaniciID", kullaniciId));
            var result = DatabaseHelper.ExecuteScalar(query, parameters);
            return result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
        }

        /// <summary>
        /// Kullanıcının verdiği ortalama puan
        /// </summary>
        public decimal GetKullaniciOrtalamaPuan(int kullaniciId)
        {
            string query = @"SELECT ISNULL(AVG(CAST(Puan AS FLOAT)), 0) FROM Degerlendirmeler 
                           WHERE KullaniciID = @KullaniciID";
            var parameters = DatabaseHelper.CreateParameters(("@KullaniciID", kullaniciId));
            var result = DatabaseHelper.ExecuteScalar(query, parameters);
            return result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
        }

        // ============= ADMİN İSTATİSTİKLERİ =============

        /// <summary>
        /// Tarih aralığına göre toplam gelir
        /// </summary>
        public decimal GetToplamGelir(DateTime baslangic, DateTime bitis)
        {
            string query = @"SELECT ISNULL(SUM(ToplamUcret), 0) FROM Randevular 
                           WHERE RandevuTarihi BETWEEN @Baslangic AND @Bitis 
                           AND Durum IN ('Onaylandi', 'Tamamlandi')";
            var parameters = DatabaseHelper.CreateParameters(
                ("@Baslangic", baslangic),
                ("@Bitis", bitis)
            );
            var result = DatabaseHelper.ExecuteScalar(query, parameters);
            return result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
        }

        /// <summary>
        /// En popüler masalar (kullanım sayısına göre)
        /// </summary>
        public List<(int MasaID, string MasaAdi, int KullanimSayisi, decimal ToplamGelir)> GetEnPopulerMasalar(int topN = 5)
        {
            string query = $@"SELECT TOP {topN} M.MasaID, M.MasaAdi, 
                           COUNT(*) as KullanimSayisi,
                           ISNULL(SUM(R.ToplamUcret), 0) as ToplamGelir
                           FROM Masalar M
                           LEFT JOIN Randevular R ON M.MasaID = R.MasaID 
                           AND R.Durum IN ('Onaylandi', 'Tamamlandi')
                           GROUP BY M.MasaID, M.MasaAdi
                           ORDER BY KullanimSayisi DESC";
            
            var dt = DatabaseHelper.ExecuteQuery(query);
            var liste = new List<(int, string, int, decimal)>();
            
            foreach (DataRow row in dt.Rows)
            {
                liste.Add((
                    Convert.ToInt32(row["MasaID"]),
                    row["MasaAdi"].ToString(),
                    Convert.ToInt32(row["KullanimSayisi"]),
                    Convert.ToDecimal(row["ToplamGelir"])
                ));
            }
            return liste;
        }

        /// <summary>
        /// Aktif kullanıcı sayısı (son 30 gün içinde randevusu olan)
        /// </summary>
        public int GetAktifKullaniciSayisi()
        {
            string query = @"SELECT COUNT(DISTINCT KullaniciID) FROM Randevular 
                           WHERE OlusturmaTarihi >= DATEADD(day, -30, GETDATE())";
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query));
        }

        /// <summary>
        /// Bugünkü randevular
        /// </summary>
        public List<Randevu> GetBugunRandevular()
        {
            string query = @"SELECT R.*, K.KullaniciAdi, K.AdSoyad as KullaniciAdSoyad, 
                           M.MasaNo, M.MasaAdi
                           FROM Randevular R
                           INNER JOIN Kullanicilar K ON R.KullaniciID = K.KullaniciID
                           INNER JOIN Masalar M ON R.MasaID = M.MasaID
                           WHERE CAST(R.RandevuTarihi AS DATE) = CAST(GETDATE() AS DATE)
                           ORDER BY R.BaslangicSaati";
            
            var dt = DatabaseHelper.ExecuteQuery(query);
            return MapToRandevuList(dt);
        }

        /// <summary>
        /// Ortalama doluluk oranı (bugün)
        /// </summary>
        public decimal GetOrtDolulukOrani()
        {
            string query = @"SELECT 
                           CASE 
                               WHEN (SELECT COUNT(*) FROM Masalar WHERE Aktif = 1) = 0 THEN 0
                               ELSE 
                                   CAST(COUNT(DISTINCT R.MasaID) AS FLOAT) / 
                                   (SELECT COUNT(*) FROM Masalar WHERE Aktif = 1) * 100
                           END as DolulukOrani
                           FROM Randevular R
                           WHERE CAST(R.RandevuTarihi AS DATE) = CAST(GETDATE() AS DATE)
                           AND R.Durum IN ('Onaylandi', 'Dolu')";
            
            var result = DatabaseHelper.ExecuteScalar(query);
            return result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
        }

        /// <summary>
        /// DataTable'dan Randevu listesine dönüştürme
        /// </summary>
        private List<Randevu> MapToRandevuList(DataTable dt)
        {
            List<Randevu> randevular = new List<Randevu>();
            foreach (DataRow row in dt.Rows)
            {
                randevular.Add(MapToRandevu(row));
            }
            return randevular;
        }

        /// <summary>
        /// DataRow'dan Randevu nesnesine dönüştürme
        /// </summary>
        private Randevu MapToRandevu(DataRow row)
        {
            return new Randevu
            {
                RandevuID = Convert.ToInt32(row["RandevuID"]),
                KullaniciID = Convert.ToInt32(row["KullaniciID"]),
                MasaID = Convert.ToInt32(row["MasaID"]),
                RandevuTarihi = Convert.ToDateTime(row["RandevuTarihi"]),
                BaslangicSaati = (TimeSpan)row["BaslangicSaati"],
                BitisSaati = (TimeSpan)row["BitisSaati"],
                ToplamSaat = Convert.ToInt32(row["ToplamSaat"]),
                ToplamUcret = Convert.ToDecimal(row["ToplamUcret"]),
                Durum = row["Durum"].ToString(),
                OlusturmaTarihi = Convert.ToDateTime(row["OlusturmaTarihi"]),
                OnayTarihi = row["OnayTarihi"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["OnayTarihi"]),
                TamamlanmaTarihi = row["TamamlanmaTarihi"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["TamamlanmaTarihi"]),
                IptalNedeni = row["IptalNedeni"]?.ToString(),
                KullaniciAdi = row["KullaniciAdi"]?.ToString(),
                KullaniciAdSoyad = row["KullaniciAdSoyad"]?.ToString(),
                MasaNo = Convert.ToInt32(row["MasaNo"]),
                MasaAdi = row["MasaAdi"]?.ToString()
            };
        }
    }
}

