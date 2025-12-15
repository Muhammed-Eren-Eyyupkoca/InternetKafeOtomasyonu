using System;

namespace KafeOtomasyonu.Models
{
    /// <summary>
    /// Masa puanlamalarını temsil eden model sınıfı
    /// </summary>
    public class Puan
    {
        public int PuanID { get; set; }
        public int MasaID { get; set; }
        public int KullaniciID { get; set; }
        public int? RandevuID { get; set; }
        public int PuanDegeri { get; set; } // 1-5 arası
        public DateTime PuanTarihi { get; set; }

        // Navigation properties
        public string KullaniciAdi { get; set; }
        public string KullaniciAdSoyad { get; set; }
        public int MasaNo { get; set; }
        public string MasaAdi { get; set; }

        public Puan()
        {
            PuanTarihi = DateTime.Now;
            PuanDegeri = 5;
        }

        /// <summary>
        /// Puanın geçerli olup olmadığını kontrol eder
        /// </summary>
        public bool IsValid()
        {
            return PuanDegeri >= 1 && PuanDegeri <= 5;
        }
    }
}

