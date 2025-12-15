using System;
using KafeOtomasyonu.Models;

namespace KafeOtomasyonu.Helpers
{
    /// <summary>
    /// Oturum yönetimi için yardımcı sınıf
    /// Giriş yapan kullanıcı veya admin bilgilerini tutar
    /// </summary>
    public static class SessionManager
    {
        // Giriş yapan kullanıcı
        private static Kullanici _currentUser;
        
        // Giriş yapan admin
        private static Admin _currentAdmin;

        /// <summary>
        /// Aktif kullanıcı
        /// </summary>
        public static Kullanici CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        /// <summary>
        /// Aktif admin
        /// </summary>
        public static Admin CurrentAdmin
        {
            get { return _currentAdmin; }
            set { _currentAdmin = value; }
        }

        /// <summary>
        /// Kullanıcı oturumu açık mı?
        /// </summary>
        public static bool IsUserLoggedIn
        {
            get { return _currentUser != null; }
        }

        /// <summary>
        /// Admin oturumu açık mı?
        /// </summary>
        public static bool IsAdminLoggedIn
        {
            get { return _currentAdmin != null; }
        }

        /// <summary>
        /// Kullanıcı girişi yap
        /// </summary>
        public static void LoginUser(Kullanici user)
        {
            _currentUser = user;
            _currentAdmin = null; // Admin oturumunu kapat
        }

        /// <summary>
        /// Admin girişi yap
        /// </summary>
        public static void LoginAdmin(Admin admin)
        {
            _currentAdmin = admin;
        }

        /// <summary>
        /// Kullanıcı oturumunu kapat
        /// </summary>
        public static void LogoutUser()
        {
            _currentUser = null;
        }

        /// <summary>
        /// Admin oturumunu kapat
        /// </summary>
        public static void LogoutAdmin()
        {
            _currentAdmin = null;
        }

        /// <summary>
        /// Tüm oturumları kapat
        /// </summary>
        public static void LogoutAll()
        {
            _currentUser = null;
            _currentAdmin = null;
        }

        /// <summary>
        /// Aktif kullanıcının ID'sini döndürür
        /// </summary>
        public static int GetCurrentUserId()
        {
            return _currentUser?.KullaniciID ?? 0;
        }

        /// <summary>
        /// Aktif kullanıcının adını döndürür
        /// </summary>
        public static string GetCurrentUserName()
        {
            return _currentUser?.KullaniciAdi ?? "Misafir";
        }

        /// <summary>
        /// Aktif kullanıcının tam adını döndürür
        /// </summary>
        public static string GetCurrentUserFullName()
        {
            return _currentUser?.AdSoyad ?? "Misafir Kullanıcı";
        }

        /// <summary>
        /// Aktif adminin ID'sini döndürür
        /// </summary>
        public static int GetCurrentAdminId()
        {
            return _currentAdmin?.AdminID ?? 0;
        }

        /// <summary>
        /// Aktif adminin adını döndürür
        /// </summary>
        public static string GetCurrentAdminName()
        {
            return _currentAdmin?.AdminAdi ?? "";
        }
    }
}

