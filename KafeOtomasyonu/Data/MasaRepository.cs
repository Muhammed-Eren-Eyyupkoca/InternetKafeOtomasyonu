using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using KafeOtomasyonu.Helpers;
using KafeOtomasyonu.Models;

namespace KafeOtomasyonu.Data
{
    /// <summary>
    /// Masa veritabanı işlemleri
    /// </summary>
    public class MasaRepository
    {
        /// <summary>
        /// Tüm masaları getir (puan ortalaması ile - Degerlendirmeler tablosundan)
        /// </summary>
        public List<Masa> GetAll()
        {
            string query = @"SELECT m.*, 
                           ISNULL(AVG(CAST(d.Puan AS DECIMAL(3,2))), 0) AS PuanOrtalamasi,
                           COUNT(d.DegerlendirmeID) AS ToplamPuanSayisi
                           FROM Masalar m
                           LEFT JOIN Degerlendirmeler d ON m.MasaID = d.MasaID
                           WHERE m.Aktif = 1
                           GROUP BY m.MasaID, m.MasaNo, m.MasaAdi, m.SaatlikUcret, 
                                    m.Durum, m.ResimYolu, m.Aciklama, m.PCOzellikleri, 
                                    m.Aktif, m.OlusturmaTarihi
                           ORDER BY m.MasaNo";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            
            List<Masa> masalar = new List<Masa>();
            foreach (DataRow row in dt.Rows)
            {
                masalar.Add(MapToMasa(row));
            }
            return masalar;
        }

        /// <summary>
        /// ID ile masa getir (Degerlendirmeler tablosundan puan)
        /// </summary>
        public Masa GetById(int id)
        {
            string query = @"SELECT m.*, 
                           ISNULL(AVG(CAST(d.Puan AS DECIMAL(3,2))), 0) AS PuanOrtalamasi,
                           COUNT(d.DegerlendirmeID) AS ToplamPuanSayisi
                           FROM Masalar m
                           LEFT JOIN Degerlendirmeler d ON m.MasaID = d.MasaID
                           WHERE m.MasaID = @MasaID
                           GROUP BY m.MasaID, m.MasaNo, m.MasaAdi, m.SaatlikUcret, 
                                    m.Durum, m.ResimYolu, m.Aciklama, m.PCOzellikleri, 
                                    m.Aktif, m.OlusturmaTarihi";

            var parameters = DatabaseHelper.CreateParameters(("@MasaID", id));
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return MapToMasa(dt.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// Masa durumunu güncelle
        /// </summary>
        public void UpdateDurum(int masaId, string durum)
        {
            string query = "UPDATE Masalar SET Durum = @Durum WHERE MasaID = @MasaID";
            var parameters = DatabaseHelper.CreateParameters(
                ("@Durum", durum),
                ("@MasaID", masaId)
            );
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Masa fiyatını güncelle
        /// </summary>
        public void UpdateFiyat(int masaId, decimal yeniFiyat)
        {
            string query = "UPDATE Masalar SET SaatlikUcret = @SaatlikUcret WHERE MasaID = @MasaID";
            var parameters = DatabaseHelper.CreateParameters(
                ("@SaatlikUcret", yeniFiyat),
                ("@MasaID", masaId)
            );
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Boş masaları getir (Degerlendirmeler tablosundan puan)
        /// </summary>
        public List<Masa> GetBosMasalar()
        {
            string query = @"SELECT m.*, 
                           ISNULL(AVG(CAST(d.Puan AS DECIMAL(3,2))), 0) AS PuanOrtalamasi,
                           COUNT(d.DegerlendirmeID) AS ToplamPuanSayisi
                           FROM Masalar m
                           LEFT JOIN Degerlendirmeler d ON m.MasaID = d.MasaID
                           WHERE m.Aktif = 1 AND m.Durum = 'Bos'
                           GROUP BY m.MasaID, m.MasaNo, m.MasaAdi, m.SaatlikUcret, 
                                    m.Durum, m.ResimYolu, m.Aciklama, m.PCOzellikleri, 
                                    m.Aktif, m.OlusturmaTarihi
                           ORDER BY m.MasaNo";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            
            List<Masa> masalar = new List<Masa>();
            foreach (DataRow row in dt.Rows)
            {
                masalar.Add(MapToMasa(row));
            }
            return masalar;
        }

        /// <summary>
        /// Masa resim yolunu güncelle
        /// </summary>
        public void UpdateResimYolu(int masaId, string resimYolu)
        {
            string query = "UPDATE Masalar SET ResimYolu = @ResimYolu WHERE MasaID = @MasaID";
            var parameters = DatabaseHelper.CreateParameters(
                ("@ResimYolu", resimYolu),
                ("@MasaID", masaId)
            );
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Yeni masa ekle
        /// </summary>
        public int Add(Masa masa)
        {
            string query = @"INSERT INTO Masalar 
                           (MasaNo, MasaAdi, SaatlikUcret, Durum, ResimYolu, Aciklama, PCOzellikleri)
                           VALUES (@MasaNo, @MasaAdi, @SaatlikUcret, @Durum, @ResimYolu, @Aciklama, @PCOzellikleri)";

            var parameters = DatabaseHelper.CreateParameters(
                ("@MasaNo", masa.MasaNo),
                ("@MasaAdi", masa.MasaAdi),
                ("@SaatlikUcret", masa.SaatlikUcret),
                ("@Durum", masa.Durum),
                ("@ResimYolu", masa.ResimYolu),
                ("@Aciklama", masa.Aciklama),
                ("@PCOzellikleri", masa.PCOzellikleri)
            );

            return DatabaseHelper.ExecuteInsertAndGetId(query, parameters);
        }

        /// <summary>
        /// Masa güncelle
        /// </summary>
        public void Update(Masa masa)
        {
            string query = @"UPDATE Masalar SET 
                           MasaNo = @MasaNo, MasaAdi = @MasaAdi, SaatlikUcret = @SaatlikUcret,
                           Durum = @Durum, ResimYolu = @ResimYolu, Aciklama = @Aciklama, 
                           PCOzellikleri = @PCOzellikleri
                           WHERE MasaID = @MasaID";

            var parameters = DatabaseHelper.CreateParameters(
                ("@MasaNo", masa.MasaNo),
                ("@MasaAdi", masa.MasaAdi),
                ("@SaatlikUcret", masa.SaatlikUcret),
                ("@Durum", masa.Durum),
                ("@ResimYolu", masa.ResimYolu),
                ("@Aciklama", masa.Aciklama),
                ("@PCOzellikleri", masa.PCOzellikleri),
                ("@MasaID", masa.MasaID)
            );

            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// DataRow'dan Masa nesnesine dönüştürme
        /// </summary>
        private Masa MapToMasa(DataRow row)
        {
            return new Masa
            {
                MasaID = Convert.ToInt32(row["MasaID"]),
                MasaNo = Convert.ToInt32(row["MasaNo"]),
                MasaAdi = row["MasaAdi"]?.ToString(),
                SaatlikUcret = Convert.ToDecimal(row["SaatlikUcret"]),
                Durum = row["Durum"].ToString(),
                ResimYolu = row["ResimYolu"]?.ToString(),
                Aciklama = row["Aciklama"]?.ToString(),
                PCOzellikleri = row["PCOzellikleri"]?.ToString(),
                Aktif = Convert.ToBoolean(row["Aktif"]),
                OlusturmaTarihi = Convert.ToDateTime(row["OlusturmaTarihi"]),
                PuanOrtalamasi = row.Table.Columns.Contains("PuanOrtalamasi") ? Convert.ToDecimal(row["PuanOrtalamasi"]) : 0,
                ToplamPuanSayisi = row.Table.Columns.Contains("ToplamPuanSayisi") ? Convert.ToInt32(row["ToplamPuanSayisi"]) : 0
            };
        }
    }
}

