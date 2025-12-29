using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KafeOtomasyonu.Data;
using KafeOtomasyonu.Helpers;

namespace KafeOtomasyonu.Forms
{
    public partial class RandevularimForm : XtraForm
    {
        private RandevuRepository _randevuRepo;
        private int _kullaniciId;

        public RandevularimForm()
        {
            InitializeComponent();
            _randevuRepo = new RandevuRepository();
            _kullaniciId = SessionManager.GetCurrentUserId();
            
            this.Load += RandevularimForm_Load;
        }

        private void RandevularimForm_Load(object sender, EventArgs e)
        {
            var randevular = _randevuRepo.GetByKullaniciId(_kullaniciId);
            
            string mesaj = $"Toplam {randevular.Count} randevunuz var:\n\n";
            
            foreach (var r in randevular)
            {
                mesaj += $"📅 {r.MasaAdi} - {r.RandevuTarihi:dd.MM.yyyy} {r.BaslangicSaati:hh\\:mm}\n";
                mesaj += $"   Durum: {r.Durum} - Ücret: {r.ToplamUcret:C}\n\n";
            }
            
            if (randevular.Count == 0)
            {
                mesaj = "Henüz randevunuz bulunmuyor.";
            }
            
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
