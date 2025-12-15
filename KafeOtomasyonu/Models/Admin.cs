using System;

namespace KafeOtomasyonu.Models
{
    /// <summary>
    /// Admin bilgilerini temsil eden model sınıfı
    /// </summary>
    public class Admin
    {
        public int AdminID { get; set; }
        public string AdminAdi { get; set; }
        public string Sifre { get; set; }
        public string AdSoyad { get; set; }
        public string Email { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime? SonGirisTarihi { get; set; }
        public bool Aktif { get; set; }

        public Admin()
        {
            OlusturmaTarihi = DateTime.Now;
            Aktif = true;
        }
    }
}

