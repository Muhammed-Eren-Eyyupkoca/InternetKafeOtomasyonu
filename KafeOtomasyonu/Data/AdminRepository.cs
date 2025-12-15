using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using KafeOtomasyonu.Helpers;
using KafeOtomasyonu.Models;

namespace KafeOtomasyonu.Data
{
    /// <summary>
    /// Admin veritabanı işlemleri
    /// </summary>
    public class AdminRepository
    {
        /// <summary>
        /// Admin girişi kontrolü
        /// </summary>
        public Admin Login(string adminAdi, string sifre)
        {
            string hashedPassword = DatabaseHelper.HashPassword(sifre);
            
            string query = @"SELECT * FROM Adminler 
                           WHERE AdminAdi = @AdminAdi AND Sifre = @Sifre AND Aktif = 1";

            var parameters = DatabaseHelper.CreateParameters(
                ("@AdminAdi", adminAdi),
                ("@Sifre", hashedPassword)
            );

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                var admin = MapToAdmin(dt.Rows[0]);
                
                // Son giriş tarihini güncelle
                UpdateSonGirisTarihi(admin.AdminID);
                
                return admin;
            }

            return null;
        }

        /// <summary>
        /// Son giriş tarihini güncelle
        /// </summary>
        private void UpdateSonGirisTarihi(int adminId)
        {
            string query = "UPDATE Adminler SET SonGirisTarihi = @SonGirisTarihi WHERE AdminID = @AdminID";
            var parameters = DatabaseHelper.CreateParameters(
                ("@SonGirisTarihi", DateTime.Now),
                ("@AdminID", adminId)
            );
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Admin işlem logu ekle
        /// </summary>
        public void AddLog(int adminId, string islem, string aciklama, int? kullaniciId = null, int? masaId = null)
        {
            string query = @"INSERT INTO AdminLoglar 
                           (AdminID, Islem, Aciklama, IlgiliKullaniciID, IlgiliMasaID)
                           VALUES (@AdminID, @Islem, @Aciklama, @IlgiliKullaniciID, @IlgiliMasaID)";

            var parameters = DatabaseHelper.CreateParameters(
                ("@AdminID", adminId),
                ("@Islem", islem),
                ("@Aciklama", aciklama),
                ("@IlgiliKullaniciID", kullaniciId),
                ("@IlgiliMasaID", masaId)
            );

            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Admin loglarını getir
        /// </summary>
        public List<AdminLog> GetLogs(int? adminId = null, int limit = 100)
        {
            string query = @"SELECT TOP (@Limit) al.*, a.AdminAdi, k.KullaniciAdi, m.MasaNo
                           FROM AdminLoglar al
                           INNER JOIN Adminler a ON al.AdminID = a.AdminID
                           LEFT JOIN Kullanicilar k ON al.IlgiliKullaniciID = k.KullaniciID
                           LEFT JOIN Masalar m ON al.IlgiliMasaID = m.MasaID
                           WHERE (@AdminID IS NULL OR al.AdminID = @AdminID)
                           ORDER BY al.IslemTarihi DESC";

            var parameters = DatabaseHelper.CreateParameters(
                ("@Limit", limit),
                ("@AdminID", adminId)
            );

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            
            List<AdminLog> logs = new List<AdminLog>();
            foreach (DataRow row in dt.Rows)
            {
                logs.Add(new AdminLog
                {
                    LogID = Convert.ToInt32(row["LogID"]),
                    AdminID = Convert.ToInt32(row["AdminID"]),
                    Islem = row["Islem"].ToString(),
                    Aciklama = row["Aciklama"]?.ToString(),
                    IslemTarihi = Convert.ToDateTime(row["IslemTarihi"]),
                    IlgiliKullaniciID = row["IlgiliKullaniciID"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["IlgiliKullaniciID"]),
                    IlgiliMasaID = row["IlgiliMasaID"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["IlgiliMasaID"]),
                    AdminAdi = row["AdminAdi"].ToString(),
                    KullaniciAdi = row["KullaniciAdi"]?.ToString(),
                    MasaNo = row["MasaNo"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["MasaNo"])
                });
            }
            return logs;
        }

        /// <summary>
        /// Tüm adminleri getir
        /// </summary>
        public List<Admin> GetAll()
        {
            string query = "SELECT * FROM Adminler ORDER BY OlusturmaTarihi DESC";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            
            List<Admin> adminler = new List<Admin>();
            foreach (DataRow row in dt.Rows)
            {
                adminler.Add(MapToAdmin(row));
            }
            return adminler;
        }

        /// <summary>
        /// DataRow'dan Admin nesnesine dönüştürme
        /// </summary>
        private Admin MapToAdmin(DataRow row)
        {
            return new Admin
            {
                AdminID = Convert.ToInt32(row["AdminID"]),
                AdminAdi = row["AdminAdi"].ToString(),
                Sifre = row["Sifre"].ToString(),
                AdSoyad = row["AdSoyad"].ToString(),
                Email = row["Email"]?.ToString(),
                OlusturmaTarihi = Convert.ToDateTime(row["OlusturmaTarihi"]),
                SonGirisTarihi = row["SonGirisTarihi"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["SonGirisTarihi"]),
                Aktif = Convert.ToBoolean(row["Aktif"])
            };
        }
    }
}

