using System;

namespace KafeOtomasyonu.Models
{
    /// <summary>
    /// Admin işlem loglarını temsil eden model sınıfı
    /// </summary>
    public class AdminLog
    {
        public int LogID { get; set; }
        public int AdminID { get; set; }
        public string Islem { get; set; }
        public string Aciklama { get; set; }
        public DateTime IslemTarihi { get; set; }
        public int? IlgiliKullaniciID { get; set; }
        public int? IlgiliMasaID { get; set; }

        // Navigation properties
        public string AdminAdi { get; set; }
        public string KullaniciAdi { get; set; }
        public int? MasaNo { get; set; }

        public AdminLog()
        {
            IslemTarihi = DateTime.Now;
        }
    }
}

