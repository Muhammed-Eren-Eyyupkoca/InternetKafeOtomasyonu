using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using KafeOtomasyonu.Helpers;
using KafeOtomasyonu.Models;

namespace KafeOtomasyonu.Data
{
    /// <summary>
    /// Yorum ve Puan veritabanı işlemleri
    /// </summary>
    public class YorumPuanRepository
    {
        #region Yorum İşlemleri

        /// <summary>
        /// Yeni yorum ekle
        /// </summary>
        public int AddYorum(Yorum yorum)
        {
            string query = @"INSERT INTO Yorumlar 
                           (MasaID, KullaniciID, RandevuID, YorumMetni)
                           VALUES (@MasaID, @KullaniciID, @RandevuID, @YorumMetni)";

            var parameters = DatabaseHelper.CreateParameters(
                ("@MasaID", yorum.MasaID),
                ("@KullaniciID", yorum.KullaniciID),
                ("@RandevuID", yorum.RandevuID),
                ("@YorumMetni", yorum.YorumMetni)
            );

            return DatabaseHelper.ExecuteInsertAndGetId(query, parameters);
        }

        /// <summary>
        /// Masanın yorumlarını getir
        /// </summary>
        public List<Yorum> GetYorumlarByMasaId(int masaId)
        {
            string query = @"SELECT y.*, k.KullaniciAdi, k.AdSoyad AS KullaniciAdSoyad, m.MasaNo, m.MasaAdi
                           FROM Yorumlar y
                           INNER JOIN Kullanicilar k ON y.KullaniciID = k.KullaniciID
                           INNER JOIN Masalar m ON y.MasaID = m.MasaID
                           WHERE y.MasaID = @MasaID AND y.Aktif = 1 AND y.Onaylandi = 1
                           ORDER BY y.YorumTarihi DESC";

            var parameters = DatabaseHelper.CreateParameters(("@MasaID", masaId));
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            List<Yorum> yorumlar = new List<Yorum>();
            foreach (DataRow row in dt.Rows)
            {
                yorumlar.Add(MapToYorum(row));
            }
            return yorumlar;
        }

        /// <summary>
        /// Tüm yorumları getir (Admin için)
        /// </summary>
        public List<Yorum> GetAllYorumlar()
        {
            string query = @"SELECT y.*, k.KullaniciAdi, k.AdSoyad AS KullaniciAdSoyad, m.MasaNo, m.MasaAdi
                           FROM Yorumlar y
                           INNER JOIN Kullanicilar k ON y.KullaniciID = k.KullaniciID
                           INNER JOIN Masalar m ON y.MasaID = m.MasaID
                           ORDER BY y.YorumTarihi DESC";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            List<Yorum> yorumlar = new List<Yorum>();
            foreach (DataRow row in dt.Rows)
            {
                yorumlar.Add(MapToYorum(row));
            }
            return yorumlar;
        }

        /// <summary>
        /// Yorum onayla/reddet
        /// </summary>
        public void UpdateYorumOnay(int yorumId, bool onaylandi)
        {
            string query = "UPDATE Yorumlar SET Onaylandi = @Onaylandi WHERE YorumID = @YorumID";
            var parameters = DatabaseHelper.CreateParameters(
                ("@Onaylandi", onaylandi),
                ("@YorumID", yorumId)
            );
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Yorum sil (soft delete)
        /// </summary>
        public void DeleteYorum(int yorumId)
        {
            string query = "UPDATE Yorumlar SET Aktif = 0 WHERE YorumID = @YorumID";
            var parameters = DatabaseHelper.CreateParameters(("@YorumID", yorumId));
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        #endregion

        #region Puan İşlemleri

        /// <summary>
        /// Yeni puan ekle
        /// </summary>
        public int AddPuan(Puan puan)
        {
            if (!puan.IsValid())
            {
                throw new ArgumentException("Puan 1-5 arasında olmalıdır.");
            }

            string query = @"INSERT INTO Puanlar 
                           (MasaID, KullaniciID, RandevuID, Puan)
                           VALUES (@MasaID, @KullaniciID, @RandevuID, @Puan)";

            var parameters = DatabaseHelper.CreateParameters(
                ("@MasaID", puan.MasaID),
                ("@KullaniciID", puan.KullaniciID),
                ("@RandevuID", puan.RandevuID),
                ("@Puan", puan.PuanDegeri)
            );

            return DatabaseHelper.ExecuteInsertAndGetId(query, parameters);
        }

        /// <summary>
        /// Masanın puan ortalamasını getir
        /// </summary>
        public decimal GetMasaPuanOrtalamasi(int masaId)
        {
            string query = @"SELECT ISNULL(AVG(CAST(Puan AS DECIMAL(3,2))), 0) 
                           FROM Puanlar WHERE MasaID = @MasaID";

            var parameters = DatabaseHelper.CreateParameters(("@MasaID", masaId));
            var result = DatabaseHelper.ExecuteScalar(query, parameters);
            return Convert.ToDecimal(result);
        }

        /// <summary>
        /// Masanın toplam puan sayısını getir
        /// </summary>
        public int GetMasaPuanSayisi(int masaId)
        {
            string query = "SELECT COUNT(*) FROM Puanlar WHERE MasaID = @MasaID";
            var parameters = DatabaseHelper.CreateParameters(("@MasaID", masaId));
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
        }

        /// <summary>
        /// Masanın puanlarını getir
        /// </summary>
        public List<Puan> GetPuanlarByMasaId(int masaId)
        {
            string query = @"SELECT p.*, k.KullaniciAdi, k.AdSoyad AS KullaniciAdSoyad, m.MasaNo, m.MasaAdi
                           FROM Puanlar p
                           INNER JOIN Kullanicilar k ON p.KullaniciID = k.KullaniciID
                           INNER JOIN Masalar m ON p.MasaID = m.MasaID
                           WHERE p.MasaID = @MasaID
                           ORDER BY p.PuanTarihi DESC";

            var parameters = DatabaseHelper.CreateParameters(("@MasaID", masaId));
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            List<Puan> puanlar = new List<Puan>();
            foreach (DataRow row in dt.Rows)
            {
                puanlar.Add(MapToPuan(row));
            }
            return puanlar;
        }

        /// <summary>
        /// Kullanıcının bu masaya daha önce puan verip vermediğini kontrol et
        /// </summary>
        public bool HasUserRatedMasa(int kullaniciId, int masaId, int? randevuId = null)
        {
            string query = @"SELECT COUNT(*) FROM Puanlar 
                           WHERE KullaniciID = @KullaniciID AND MasaID = @MasaID
                           AND (@RandevuID IS NULL OR RandevuID = @RandevuID)";

            var parameters = DatabaseHelper.CreateParameters(
                ("@KullaniciID", kullaniciId),
                ("@MasaID", masaId),
                ("@RandevuID", randevuId)
            );

            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        #endregion

        #region Yorum ve Puan Birlikte Ekleme

        /// <summary>
        /// Yorum ve puan birlikte ekle
        /// </summary>
        public void AddYorumVePuan(Yorum yorum, Puan puan)
        {
            // Önce puanı ekle
            int puanId = AddPuan(puan);

            // Sonra yorumu ekle
            AddYorum(yorum);
        }

        #endregion

        #region Mapping Methods

        private Yorum MapToYorum(DataRow row)
        {
            return new Yorum
            {
                YorumID = Convert.ToInt32(row["YorumID"]),
                MasaID = Convert.ToInt32(row["MasaID"]),
                KullaniciID = Convert.ToInt32(row["KullaniciID"]),
                RandevuID = row["RandevuID"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["RandevuID"]),
                YorumMetni = row["YorumMetni"].ToString(),
                YorumTarihi = Convert.ToDateTime(row["YorumTarihi"]),
                Onaylandi = Convert.ToBoolean(row["Onaylandi"]),
                Aktif = Convert.ToBoolean(row["Aktif"]),
                KullaniciAdi = row["KullaniciAdi"]?.ToString(),
                KullaniciAdSoyad = row["KullaniciAdSoyad"]?.ToString(),
                MasaNo = Convert.ToInt32(row["MasaNo"]),
                MasaAdi = row["MasaAdi"]?.ToString()
            };
        }

        private Puan MapToPuan(DataRow row)
        {
            return new Puan
            {
                PuanID = Convert.ToInt32(row["PuanID"]),
                MasaID = Convert.ToInt32(row["MasaID"]),
                KullaniciID = Convert.ToInt32(row["KullaniciID"]),
                RandevuID = row["RandevuID"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["RandevuID"]),
                PuanDegeri = Convert.ToInt32(row["Puan"]),
                PuanTarihi = Convert.ToDateTime(row["PuanTarihi"]),
                KullaniciAdi = row["KullaniciAdi"]?.ToString(),
                KullaniciAdSoyad = row["KullaniciAdSoyad"]?.ToString(),
                MasaNo = Convert.ToInt32(row["MasaNo"]),
                MasaAdi = row["MasaAdi"]?.ToString()
            };
        }

        #endregion
    }
}

