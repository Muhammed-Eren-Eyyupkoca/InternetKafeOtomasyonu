using System;

namespace KafeOtomasyonu.Models
{
    /// <summary>
    /// Masa değerlendirme modeli
    /// </summary>
    public class Degerlendirme
    {
        public int DegerlendirmeID { get; set; }
        public int RandevuID { get; set; }
        public int MasaID { get; set; }
        public int KullaniciID { get; set; }
        public int Puan { get; set; } // 1-5 arası
        public string Yorum { get; set; }
        public DateTime OlusturmaTarihi { get; set; }

        // Navigation properties
        public string MasaAdi { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciAdSoyad { get; set; }
    }
}

