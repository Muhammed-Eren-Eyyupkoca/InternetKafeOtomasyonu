using System;
using System.Collections.Generic;
using System.Data;
using KafeOtomasyonu.Helpers;
using KafeOtomasyonu.Models;

namespace KafeOtomasyonu.Data
{
    /// <summary>
    /// Değerlendirme veritabanı işlemleri
    /// </summary>
    public class DegerlendirmeRepository
    {
        /// <summary>
        /// Yeni değerlendirme ekle
        /// </summary>
        public int Add(Degerlendirme degerlendirme)
        {
            string query = @"INSERT INTO Degerlendirmeler 
                           (RandevuID, MasaID, KullaniciID, Puan, Yorum)
                           VALUES (@RandevuID, @MasaID, @KullaniciID, @Puan, @Yorum)";

            var parameters = DatabaseHelper.CreateParameters(
                ("@RandevuID", degerlendirme.RandevuID),
                ("@MasaID", degerlendirme.MasaID),
                ("@KullaniciID", degerlendirme.KullaniciID),
                ("@Puan", degerlendirme.Puan),
                ("@Yorum", degerlendirme.Yorum ?? (object)DBNull.Value)
            );

            return DatabaseHelper.ExecuteInsertAndGetId(query, parameters);
        }

        /// <summary>
        /// Randevu için değerlendirme var mı kontrol et
        /// </summary>
        public bool HasDegerlendirme(int randevuId)
        {
            string query = "SELECT COUNT(*) FROM Degerlendirmeler WHERE RandevuID = @RandevuID";
            var parameters = DatabaseHelper.CreateParameters(("@RandevuID", randevuId));
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        /// <summary>
        /// Masanın tüm değerlendirmelerini getir
        /// </summary>
        public List<Degerlendirme> GetByMasaId(int masaId)
        {
            string query = @"SELECT d.*, k.KullaniciAdi, k.AdSoyad AS KullaniciAdSoyad, m.MasaAdi
                           FROM Degerlendirmeler d
                           INNER JOIN Kullanicilar k ON d.KullaniciID = k.KullaniciID
                           INNER JOIN Masalar m ON d.MasaID = m.MasaID
                           WHERE d.MasaID = @MasaID
                           ORDER BY d.OlusturmaTarihi DESC";

            var parameters = DatabaseHelper.CreateParameters(("@MasaID", masaId));
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            return MapToDegerlendirmeList(dt);
        }

        /// <summary>
        /// Kullanıcının tüm değerlendirmelerini getir
        /// </summary>
        public List<Degerlendirme> GetByKullaniciId(int kullaniciId)
        {
            string query = @"SELECT d.*, k.KullaniciAdi, k.AdSoyad AS KullaniciAdSoyad, m.MasaAdi
                           FROM Degerlendirmeler d
                           INNER JOIN Kullanicilar k ON d.KullaniciID = k.KullaniciID
                           INNER JOIN Masalar m ON d.MasaID = m.MasaID
                           WHERE d.KullaniciID = @KullaniciID
                           ORDER BY d.OlusturmaTarihi DESC";

            var parameters = DatabaseHelper.CreateParameters(("@KullaniciID", kullaniciId));
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            return MapToDegerlendirmeList(dt);
        }

        /// <summary>
        /// Masanın ortalama puanını getir
        /// </summary>
        public decimal GetOrtalamaPuan(int masaId)
        {
            string query = @"SELECT ISNULL(AVG(CAST(Puan AS DECIMAL(10,2))), 0) 
                           FROM Degerlendirmeler 
                           WHERE MasaID = @MasaID";

            var parameters = DatabaseHelper.CreateParameters(("@MasaID", masaId));
            object result = DatabaseHelper.ExecuteScalar(query, parameters);
            
            return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
        }

        /// <summary>
        /// Masanın değerlendirme sayısını getir
        /// </summary>
        public int GetDegerlendirmeSayisi(int masaId)
        {
            string query = "SELECT COUNT(*) FROM Degerlendirmeler WHERE MasaID = @MasaID";
            var parameters = DatabaseHelper.CreateParameters(("@MasaID", masaId));
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
        }

        /// <summary>
        /// Tüm değerlendirmeleri getir (Admin için)
        /// </summary>
        public List<Degerlendirme> GetAll()
        {
            string query = @"SELECT d.*, k.KullaniciAdi, k.AdSoyad AS KullaniciAdSoyad, m.MasaAdi
                           FROM Degerlendirmeler d
                           INNER JOIN Kullanicilar k ON d.KullaniciID = k.KullaniciID
                           INNER JOIN Masalar m ON d.MasaID = m.MasaID
                           ORDER BY d.OlusturmaTarihi DESC";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            return MapToDegerlendirmeList(dt);
        }

        /// <summary>
        /// ID ile değerlendirme getir
        /// </summary>
        public Degerlendirme GetById(int id)
        {
            string query = @"SELECT d.*, k.KullaniciAdi, k.AdSoyad AS KullaniciAdSoyad, m.MasaAdi
                           FROM Degerlendirmeler d
                           INNER JOIN Kullanicilar k ON d.KullaniciID = k.KullaniciID
                           INNER JOIN Masalar m ON d.MasaID = m.MasaID
                           WHERE d.DegerlendirmeID = @DegerlendirmeID";

            var parameters = DatabaseHelper.CreateParameters(("@DegerlendirmeID", id));
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return MapToDegerlendirme(dt.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// Randevu için değerlendirmeyi getir
        /// </summary>
        public Degerlendirme GetByRandevuId(int randevuId)
        {
            string query = @"SELECT d.*, k.KullaniciAdi, k.AdSoyad AS KullaniciAdSoyad, m.MasaAdi
                           FROM Degerlendirmeler d
                           INNER JOIN Kullanicilar k ON d.KullaniciID = k.KullaniciID
                           INNER JOIN Masalar m ON d.MasaID = m.MasaID
                           WHERE d.RandevuID = @RandevuID";

            var parameters = DatabaseHelper.CreateParameters(("@RandevuID", randevuId));
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return MapToDegerlendirme(dt.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// Değerlendirmeyi sil (Admin için)
        /// </summary>
        public void Delete(int degerlendirmeId)
        {
            string query = "DELETE FROM Degerlendirmeler WHERE DegerlendirmeID = @DegerlendirmeID";
            var parameters = DatabaseHelper.CreateParameters(("@DegerlendirmeID", degerlendirmeId));
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// DataTable'dan Degerlendirme listesine dönüştürme
        /// </summary>
        private List<Degerlendirme> MapToDegerlendirmeList(DataTable dt)
        {
            List<Degerlendirme> degerlendirmeler = new List<Degerlendirme>();
            foreach (DataRow row in dt.Rows)
            {
                degerlendirmeler.Add(MapToDegerlendirme(row));
            }
            return degerlendirmeler;
        }

        /// <summary>
        /// DataRow'dan Degerlendirme nesnesine dönüştürme
        /// </summary>
        private Degerlendirme MapToDegerlendirme(DataRow row)
        {
            return new Degerlendirme
            {
                DegerlendirmeID = Convert.ToInt32(row["DegerlendirmeID"]),
                RandevuID = Convert.ToInt32(row["RandevuID"]),
                MasaID = Convert.ToInt32(row["MasaID"]),
                KullaniciID = Convert.ToInt32(row["KullaniciID"]),
                Puan = Convert.ToInt32(row["Puan"]),
                Yorum = row["Yorum"]?.ToString(),
                OlusturmaTarihi = Convert.ToDateTime(row["OlusturmaTarihi"]),
                MasaAdi = row["MasaAdi"]?.ToString(),
                KullaniciAdi = row["KullaniciAdi"]?.ToString(),
                KullaniciAdSoyad = row["KullaniciAdSoyad"]?.ToString()
            };
        }
    }
}

