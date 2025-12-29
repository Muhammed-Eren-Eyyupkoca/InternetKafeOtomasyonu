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
            SaatlikUcret = 75.00m; // Saatlik ücret 75 TL
            Durum = "Bos";
            Aktif = true;
            OlusturmaTarihi = DateTime.Now;
        }

        /// <summary>
        /// Masa durumuna göre renk döndürür
        /// </summary>
        public System.Drawing.Color GetDurumRengi()
        {
            switch (Durum)
            {
                case "Bos":
                    return System.Drawing.Color.FromArgb(76, 175, 80); // Yeşil
                case "Dolu":
                    return System.Drawing.Color.FromArgb(244, 67, 54); // Kırmızı
                case "Rezerve":
                    return System.Drawing.Color.FromArgb(255, 152, 0); // Turuncu
                case "Bakim":
                    return System.Drawing.Color.FromArgb(158, 158, 158); // Gri
                default:
                    return System.Drawing.Color.FromArgb(33, 150, 243); // Mavi
            }
        }
    }
}

