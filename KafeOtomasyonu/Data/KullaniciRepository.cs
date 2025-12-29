using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using KafeOtomasyonu.Helpers;
using KafeOtomasyonu.Models;

namespace KafeOtomasyonu.Data
{
    /// <summary>
    /// Kullanıcı veritabanı işlemleri
    /// </summary>
    public class KullaniciRepository
    {
        /// <summary>
        /// Kullanıcı girişi kontrolü
        /// </summary>
        public Kullanici Login(string kullaniciAdi, string sifre)
        {
            string hashedPassword = DatabaseHelper.HashPassword(sifre);
            
            string query = @"SELECT * FROM Kullanicilar 
                           WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";

            var parameters = DatabaseHelper.CreateParameters(
                ("@KullaniciAdi", kullaniciAdi),
                ("@Sifre", hashedPassword)
            );

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                var kullanici = MapToKullanici(dt.Rows[0]);
                
                // Son giriş tarihini güncelle
                UpdateSonGirisTarihi(kullanici.KullaniciID);
                
                return kullanici;
            }

            return null;
        }

        /// <summary>
        /// Yeni kullanıcı kaydı
        /// </summary>
        public int Register(Kullanici kullanici)
        {
            // Kullanıcı adı ve email kontrolü
            if (IsKullaniciAdiExists(kullanici.KullaniciAdi))
            {
                throw new Exception("Bu kullanıcı adı zaten kullanılıyor.");
            }

            if (IsEmailExists(kullanici.Email))
            {
                throw new Exception("Bu e-posta adresi zaten kullanılıyor.");
            }

            string query = @"INSERT INTO Kullanicilar 
                           (KullaniciAdi, Sifre, Email, Telefon, AdSoyad)
                           VALUES (@KullaniciAdi, @Sifre, @Email, @Telefon, @AdSoyad)";

            var parameters = DatabaseHelper.CreateParameters(
                ("@KullaniciAdi", kullanici.KullaniciAdi),
                ("@Sifre", DatabaseHelper.HashPassword(kullanici.Sifre)),
                ("@Email", kullanici.Email),
                ("@Telefon", kullanici.Telefon),
                ("@AdSoyad", kullanici.AdSoyad)
            );

            return DatabaseHelper.ExecuteInsertAndGetId(query, parameters);
        }

        /// <summary>
        /// Kullanıcı adı var mı kontrolü
        /// </summary>
        public bool IsKullaniciAdiExists(string kullaniciAdi)
        {
            string query = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi = @KullaniciAdi";
            var parameters = DatabaseHelper.CreateParameters(("@KullaniciAdi", kullaniciAdi));
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        /// <summary>
        /// Email var mı kontrolü
        /// </summary>
        public bool IsEmailExists(string email)
        {
            string query = "SELECT COUNT(*) FROM Kullanicilar WHERE Email = @Email";
            var parameters = DatabaseHelper.CreateParameters(("@Email", email));
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        /// <summary>
        /// Son giriş tarihini güncelle
        /// </summary>
        private void UpdateSonGirisTarihi(int kullaniciId)
        {
            string query = "UPDATE Kullanicilar SET SonGirisTarihi = @SonGirisTarihi WHERE KullaniciID = @KullaniciID";
            var parameters = DatabaseHelper.CreateParameters(
                ("@SonGirisTarihi", DateTime.Now),
                ("@KullaniciID", kullaniciId)
            );
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Kullanıcı blokla
        /// </summary>
        public void BloklaKullanici(int kullaniciId, string neden)
        {
            string query = @"UPDATE Kullanicilar 
                           SET Bloklu = 1, BlokNedeni = @BlokNedeni, BlokTarihi = @BlokTarihi 
                           WHERE KullaniciID = @KullaniciID";

            var parameters = DatabaseHelper.CreateParameters(
                ("@BlokNedeni", neden),
                ("@BlokTarihi", DateTime.Now),
                ("@KullaniciID", kullaniciId)
            );

            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Kullanıcı bloğunu kaldır
        /// </summary>
        public void BlokKaldir(int kullaniciId)
        {
            string query = @"UPDATE Kullanicilar 
                           SET Bloklu = 0, BlokNedeni = NULL, BlokTarihi = NULL 
                           WHERE KullaniciID = @KullaniciID";

            var parameters = DatabaseHelper.CreateParameters(("@KullaniciID", kullaniciId));
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Tüm kullanıcıları getir
        /// </summary>
        public List<Kullanici> GetAll()
        {
            string query = "SELECT * FROM Kullanicilar ORDER BY KayitTarihi DESC";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            
            List<Kullanici> kullanicilar = new List<Kullanici>();
            foreach (DataRow row in dt.Rows)
            {
                kullanicilar.Add(MapToKullanici(row));
            }
            return kullanicilar;
        }

        /// <summary>
        /// ID ile kullanıcı getir
        /// </summary>
        public Kullanici GetById(int id)
        {
            string query = "SELECT * FROM Kullanicilar WHERE KullaniciID = @KullaniciID";
            var parameters = DatabaseHelper.CreateParameters(("@KullaniciID", id));
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return MapToKullanici(dt.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// Kullanıcı bilgilerini güncelle (Ad Soyad, Email, Telefon)
        /// </summary>
        public void UpdateProfil(int kullaniciId, string adSoyad, string email, string telefon)
        {
            // Email kontrolü (kendi ID'si hariç)
            string checkQuery = "SELECT COUNT(*) FROM Kullanicilar WHERE Email = @Email AND KullaniciID != @KullaniciID";
            var checkParams = DatabaseHelper.CreateParameters(
                ("@Email", email),
                ("@KullaniciID", kullaniciId)
            );
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery, checkParams));
            
            if (count > 0)
            {
                throw new Exception("Bu e-posta adresi başka bir kullanıcı tarafından kullanılıyor.");
            }

            string query = @"UPDATE Kullanicilar 
                           SET AdSoyad = @AdSoyad, Email = @Email, Telefon = @Telefon
                           WHERE KullaniciID = @KullaniciID";

            var parameters = DatabaseHelper.CreateParameters(
                ("@AdSoyad", adSoyad),
                ("@Email", email),
                ("@Telefon", telefon),
                ("@KullaniciID", kullaniciId)
            );

            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Şifre değiştir
        /// </summary>
        public bool ChangeSifre(int kullaniciId, string eskiSifre, string yeniSifre)
        {
            // Önce eski şifreyi kontrol et
            string hashedEskiSifre = DatabaseHelper.HashPassword(eskiSifre);
            string checkQuery = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciID = @KullaniciID AND Sifre = @Sifre";
            var checkParams = DatabaseHelper.CreateParameters(
                ("@KullaniciID", kullaniciId),
                ("@Sifre", hashedEskiSifre)
            );
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery, checkParams));
            
            if (count == 0)
            {
                return false; // Eski şifre yanlış
            }

            // Yeni şifreyi güncelle
            string hashedYeniSifre = DatabaseHelper.HashPassword(yeniSifre);
            string updateQuery = "UPDATE Kullanicilar SET Sifre = @Sifre WHERE KullaniciID = @KullaniciID";
            var updateParams = DatabaseHelper.CreateParameters(
                ("@Sifre", hashedYeniSifre),
                ("@KullaniciID", kullaniciId)
            );
            DatabaseHelper.ExecuteNonQuery(updateQuery, updateParams);
            
            return true;
        }

        /// <summary>
        /// DataRow'dan Kullanici nesnesine dönüştürme
        /// </summary>
        private Kullanici MapToKullanici(DataRow row)
        {
            return new Kullanici
            {
                KullaniciID = Convert.ToInt32(row["KullaniciID"]),
                KullaniciAdi = row["KullaniciAdi"].ToString(),
                Sifre = row["Sifre"].ToString(),
                Email = row["Email"].ToString(),
                Telefon = row["Telefon"]?.ToString(),
                AdSoyad = row["AdSoyad"].ToString(),
                KayitTarihi = Convert.ToDateTime(row["KayitTarihi"]),
                SonGirisTarihi = row["SonGirisTarihi"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["SonGirisTarihi"]),
                Bloklu = Convert.ToBoolean(row["Bloklu"]),
                BlokNedeni = row["BlokNedeni"]?.ToString(),
                BlokTarihi = row["BlokTarihi"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["BlokTarihi"])
            };
        }
    }
}

