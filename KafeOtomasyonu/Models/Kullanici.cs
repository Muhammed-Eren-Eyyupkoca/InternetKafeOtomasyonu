using System;

namespace KafeOtomasyonu.Models
{
    /// <summary>
    /// Kullanıcı bilgilerini temsil eden model sınıfı
    /// </summary>
    public class Kullanici
    {
        public int KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string AdSoyad { get; set; }
        public DateTime KayitTarihi { get; set; }
        public DateTime? SonGirisTarihi { get; set; }
        public bool Bloklu { get; set; }
        public string BlokNedeni { get; set; }
        public DateTime? BlokTarihi { get; set; }

        public Kullanici()
        {
            KayitTarihi = DateTime.Now;
            Bloklu = false;
        }
    }
}

