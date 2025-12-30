using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KafeOtomasyonu.Data;
using KafeOtomasyonu.Models;

namespace KafeOtomasyonu.Forms
{
    public partial class MasaDetayForm : XtraForm
    {
        private Masa _masa;
        private DegerlendirmeRepository _degerlendirmeRepo;
        private FlowLayoutPanel flowPanel;

        public MasaDetayForm(Masa masa)
        {
            _masa = masa;
            _degerlendirmeRepo = new DegerlendirmeRepository();

            InitializeComponent();
            InitializeCustomComponents();
            this.Load += MasaDetayForm_Load;
        }

        private void InitializeCustomComponents()
        {
            this.Text = $"{_masa.MasaAdi} - Detay ve Yorumlar";
            this.Size = new Size(700, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Başlık
            Label lblBaslik = new Label
            {
                Text = $"🖥️  {_masa.MasaAdi}",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(lblBaslik);

            // Puan ve bilgiler
            Panel pnlBilgi = new Panel
            {
                Location = new Point(20, 60),
                Size = new Size(640, 80),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(250, 250, 250)
            };

            decimal ortalamaPuan = _degerlendirmeRepo.GetOrtalamaPuan(_masa.MasaID);
            int degerlendirmeSayisi = _degerlendirmeRepo.GetDegerlendirmeSayisi(_masa.MasaID);

            Label lblPuan = new Label
            {
                Text = $"⭐ {ortalamaPuan:0.0}",
                Location = new Point(20, 15),
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 193, 7),
                AutoSize = true
            };
            pnlBilgi.Controls.Add(lblPuan);

            Label lblDegerlendirmeSayisi = new Label
            {
                Text = $"{degerlendirmeSayisi} değerlendirme",
                Location = new Point(20, 50),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                AutoSize = true
            };
            pnlBilgi.Controls.Add(lblDegerlendirmeSayisi);

            Label lblUcret = new Label
            {
                Text = $"💰 {_masa.SaatlikUcret:C}/saat",
                Location = new Point(300, 25),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(76, 175, 80),
                AutoSize = true
            };
            pnlBilgi.Controls.Add(lblUcret);

            Label lblDurum = new Label
            {
                Text = $"📊 {_masa.Durum}",
                Location = new Point(500, 25),
                Font = new Font("Segoe UI", 12),
                ForeColor = _masa.Durum == "Aktif" ? Color.FromArgb(76, 175, 80) : Color.Gray,
                AutoSize = true
            };
            pnlBilgi.Controls.Add(lblDurum);

            this.Controls.Add(pnlBilgi);

            // Yorumlar başlık
            Label lblYorumlarBaslik = new Label
            {
                Text = "💬 KULLANICI YORUMLARI",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(20, 160),
                AutoSize = true
            };
            this.Controls.Add(lblYorumlarBaslik);

            // Yorumlar paneli
            flowPanel = new FlowLayoutPanel
            {
                Location = new Point(20, 195),
                Size = new Size(640, 330),
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(flowPanel);

            // Kapat butonu
            SimpleButton btnKapat = new SimpleButton
            {
                Text = "❌ Kapat",
                Location = new Point(560, 535),
                Size = new Size(100, 35),
                Appearance = { BackColor = Color.FromArgb(158, 158, 158), Font = new Font("Segoe UI", 10, FontStyle.Bold) }
            };
            btnKapat.Appearance.Options.UseBackColor = true;
            btnKapat.Appearance.Options.UseFont = true;
            btnKapat.Click += (s, e) => this.Close();
            this.Controls.Add(btnKapat);
        }

        private void MasaDetayForm_Load(object sender, EventArgs e)
        {
            var degerlendirmeler = _degerlendirmeRepo.GetByMasaId(_masa.MasaID);

            if (degerlendirmeler.Count == 0)
            {
                Label lblBos = new Label
                {
                    Text = "Henüz bu masa için değerlendirme yapılmamış.",
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.Gray,
                    Margin = new Padding(10),
                    AutoSize = true
                };
                flowPanel.Controls.Add(lblBos);
                return;
            }

            foreach (var deg in degerlendirmeler)
            {
                Panel yorumPanel = OlusturYorumPanel(deg);
                flowPanel.Controls.Add(yorumPanel);
            }
        }

        private Panel OlusturYorumPanel(Degerlendirme degerlendirme)
        {
            Panel panel = new Panel
            {
                Width = 600,
                MinimumSize = new Size(600, 100),
                AutoSize = true,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            // Yıldızlar
            string yildizlar = new string('★', degerlendirme.Puan) + new string('☆', 5 - degerlendirme.Puan);
            Label lblYildizlar = new Label
            {
                Text = yildizlar,
                Location = new Point(10, 10),
                Font = new Font("Segoe UI", 14),
                ForeColor = Color.FromArgb(255, 193, 7),
                AutoSize = true
            };
            panel.Controls.Add(lblYildizlar);

            // Kullanıcı ve tarih
            Label lblKullanici = new Label
            {
                Text = $"{degerlendirme.KullaniciAdSoyad}  •  {degerlendirme.OlusturmaTarihi:dd MMMM yyyy}",
                Location = new Point(10, 40),
                Width = 580,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                AutoSize = false
            };
            panel.Controls.Add(lblKullanici);

            // Yorum
            if (!string.IsNullOrWhiteSpace(degerlendirme.Yorum))
            {
                Label lblYorum = new Label
                {
                    Text = degerlendirme.Yorum,
                    Location = new Point(10, 65),
                    Width = 580,
                    Font = new Font("Segoe UI", 10),
                    AutoSize = true,
                    MaximumSize = new Size(580, 0)
                };
                panel.Controls.Add(lblYorum);

                // Panel yüksekliğini yoruma göre ayarla
                panel.Height = lblYorum.Bottom + 10;
            }
            else
            {
                panel.Height = 75;
            }

            return panel;
        }
    }
}
