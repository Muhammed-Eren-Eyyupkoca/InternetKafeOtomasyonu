using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KafeOtomasyonu.Data;
using KafeOtomasyonu.Helpers;

namespace KafeOtomasyonu.Forms
{
    public partial class ProfilForm : XtraForm
    {
        private KullaniciRepository _kullaniciRepo;

        public ProfilForm()
        {
            InitializeComponent();
            _kullaniciRepo = new KullaniciRepository();
            
            this.Load += ProfilForm_Load;
        }

        private void ProfilForm_Load(object sender, EventArgs e)
        {
            var kullanici = _kullaniciRepo.GetById(SessionManager.GetCurrentUserId());
            
            if (kullanici != null)
            {
                string mesaj = "👤 PROFİL BİLGİLERİ\n\n";
                mesaj += $"Ad Soyad: {kullanici.AdSoyad}\n";
                mesaj += $"Kullanıcı Adı: {kullanici.KullaniciAdi}\n";
                mesaj += $"E-posta: {kullanici.Email}\n";
                mesaj += $"Telefon: {kullanici.Telefon}\n";
                mesaj += $"Kayıt Tarihi: {kullanici.KayitTarihi:dd.MM.yyyy}\n";
                mesaj += $"\n(Düzenleme özellikleri yakında eklenecek!)";
                
                Label lblMesaj = new Label
                {
                    Text = mesaj,
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 11),
                    Padding = new Padding(20),
                    AutoSize = false
                };
                this.Controls.Add(lblMesaj);
            }
        }
    }
}
