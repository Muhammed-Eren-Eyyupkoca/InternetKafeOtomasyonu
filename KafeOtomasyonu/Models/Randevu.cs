using System;

namespace KafeOtomasyonu.Models
{
    /// <summary>
    /// Randevu bilgilerini temsil eden model sınıfı
    /// </summary>
    public class Randevu
    {
        public int RandevuID { get; set; }
        public int KullaniciID { get; set; }
        public int MasaID { get; set; }
        public DateTime RandevuTarihi { get; set; }
        public TimeSpan BaslangicSaati { get; set; }
        public TimeSpan BitisSaati { get; set; }
        public int ToplamSaat { get; set; }
        public decimal ToplamUcret { get; set; }
        public string Durum { get; set; } // Beklemede, Onaylandi, Tamamlandi, IptalEdildi, Gelmedi
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime? OnayTarihi { get; set; }
        public DateTime? TamamlanmaTarihi { get; set; }
        public string IptalNedeni { get; set; }

        // Navigation properties (ilişkili veriler için)
        public string KullaniciAdi { get; set; }
        public string KullaniciAdSoyad { get; set; }
        public int MasaNo { get; set; }
        public string MasaAdi { get; set; }

        public Randevu()
        {
            Durum = "Beklemede";
            OlusturmaTarihi = DateTime.Now;
            RandevuTarihi = DateTime.Today;
        }

        /// <summary>
        /// Toplam ücreti hesaplar
        /// </summary>
        public void HesaplaToplamUcret(decimal saatlikUcret)
        {
            ToplamSaat = (int)(BitisSaati - BaslangicSaati).TotalHours;
            ToplamUcret = ToplamSaat * saatlikUcret;
        }

        /// <summary>
        /// Randevu durumuna göre renk döndürür
        /// </summary>
        public System.Drawing.Color GetDurumRengi()
        {
            switch (Durum)
            {
                case "Beklemede":
                    return System.Drawing.Color.FromArgb(255, 193, 7); // Sarı
                case "Onaylandi":
                    return System.Drawing.Color.FromArgb(33, 150, 243); // Mavi
                case "Tamamlandi":
                    return System.Drawing.Color.FromArgb(76, 175, 80); // Yeşil
                case "IptalEdildi":
                    return System.Drawing.Color.FromArgb(158, 158, 158); // Gri
                case "Gelmedi":
                    return System.Drawing.Color.FromArgb(244, 67, 54); // Kırmızı
                default:
                    return System.Drawing.Color.FromArgb(96, 125, 139); // Mavi-gri
            }
        }
    }
}

