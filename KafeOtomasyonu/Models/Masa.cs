using System;

namespace KafeOtomasyonu.Models
{
    /// <summary>
    /// Masa bilgilerini temsil eden model sınıfı
    /// </summary>
    public class Masa
    {
        public int MasaID { get; set; }
        public int MasaNo { get; set; }
        public string MasaAdi { get; set; }
        public decimal SaatlikUcret { get; set; }
        public string Durum { get; set; } // Bos, Dolu, Rezerve, Bakim
        public string ResimYolu { get; set; }
        public string Aciklama { get; set; }
        public string PCOzellikleri { get; set; }
        public bool Aktif { get; set; }
        public DateTime OlusturmaTarihi { get; set; }

        // Hesaplanan özellikler
        public decimal PuanOrtalamasi { get; set; }
        public int ToplamPuanSayisi { get; set; }

        public Masa()
        {
            SaatlikUcret = 50.00m; // Varsayılan saatlik ücret 50 TL
            Durum = "Bos";
            Aktif = true;
            OlusturmaTarihi = DateTime.Now;
        }

        /// <summary>
        /// Masa durumuna göre renk döndürür
        /// Uygun (Boş) = Yeşil, Uygun Değil (Dolu/Rezerve/Bakım) = Kırmızı
        /// </summary>
        public System.Drawing.Color GetDurumRengi()
        {
            switch (Durum)
            {
                case "Bos":
                    return System.Drawing.Color.FromArgb(46, 204, 113); // Yeşil - Uygun
                default:
                    return System.Drawing.Color.FromArgb(231, 76, 60); // Kırmızı - Uygun Değil
            }
        }
        
        /// <summary>
        /// Masa uygun mu (Boş durumunda mı) kontrol eder
        /// </summary>
        public bool IsUygun()
        {
            return Durum == "Bos";
        }
    }
}

