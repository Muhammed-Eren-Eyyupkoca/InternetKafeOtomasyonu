using System;

namespace KafeOtomasyonu.Models
{
    /// <summary>
    /// Masa yorumlarını temsil eden model sınıfı
    /// </summary>
    public class Yorum
    {
        public int YorumID { get; set; }
        public int MasaID { get; set; }
        public int KullaniciID { get; set; }
        public int? RandevuID { get; set; }
        public string YorumMetni { get; set; }
        public DateTime YorumTarihi { get; set; }
        public bool Onaylandi { get; set; }
        public bool Aktif { get; set; }

        // Navigation properties
        public string KullaniciAdi { get; set; }
        public string KullaniciAdSoyad { get; set; }
        public int MasaNo { get; set; }
        public string MasaAdi { get; set; }

        public Yorum()
        {
            YorumTarihi = DateTime.Now;
            Onaylandi = true;
            Aktif = true;
        }
    }
}

