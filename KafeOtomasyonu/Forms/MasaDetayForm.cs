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
            this.Text = $"{_masa.MasaAdi} - Detay ve Randevu";
            this.Size = new Size(750, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            // ===== ÜST KISIM: MASA BİLGİLERİ VE RANDEVU BUTONU =====
            Panel pnlUst = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(750, 180),
                BackColor = Color.FromArgb(21, 22, 41) // Dark premium
            };
            this.Controls.Add(pnlUst);

            // Başlık
            Label lblBaslik = new Label
            {
                Text = $"🖥️  {_masa.MasaAdi}",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(25, 15),
                AutoSize = true
            };
            pnlUst.Controls.Add(lblBaslik);

            // Puan bilgisi
            decimal ortalamaPuan = _degerlendirmeRepo.GetOrtalamaPuan(_masa.MasaID);
            int degerlendirmeSayisi = _degerlendirmeRepo.GetDegerlendirmeSayisi(_masa.MasaID);

            Label lblPuan = new Label
            {
                Text = $"⭐ {ortalamaPuan:0.0} ({degerlendirmeSayisi} değerlendirme)",
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.FromArgb(255, 193, 7),
                Location = new Point(25, 55),
                AutoSize = true
            };
            pnlUst.Controls.Add(lblPuan);

            // Ücret bilgisi
            Label lblUcret = new Label
            {
                Text = $"💰 {_masa.SaatlikUcret:C}/saat",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(85, 165, 134),
                Location = new Point(25, 85),
                AutoSize = true
            };
            pnlUst.Controls.Add(lblUcret);

            // Durum bilgisi
            Label lblDurum = new Label
            {
                Text = $"📊 Durum: {_masa.Durum}",
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.White,
                Location = new Point(25, 115),
                AutoSize = true
            };
            pnlUst.Controls.Add(lblDurum);

            // ===== RANDEVU AL BUTONU =====
            Button btnRandevuAl = new Button
            {
                Text = "📅 RANDEVU AL",
                Location = new Point(500, 40),
                Size = new Size(200, 60),
                BackColor = Color.FromArgb(43, 128, 200),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRandevuAl.FlatAppearance.BorderSize = 0;
            btnRandevuAl.Click += BtnRandevuAl_Click;
            pnlUst.Controls.Add(btnRandevuAl);

            // Kapat butonu
            Button btnKapat = new Button
            {
                Text = "❌ KAPAT",
                Location = new Point(500, 115),
                Size = new Size(200, 45),
                BackColor = Color.FromArgb(200, 60, 60),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnKapat.FlatAppearance.BorderSize = 0;
            btnKapat.Click += (s, e) => this.Close();
            pnlUst.Controls.Add(btnKapat);

            // ===== ALT KISIM: KULLANICI YORUMLARI =====
            Label lblYorumlarBaslik = new Label
            {
                Text = "💬 KULLANICI YORUMLARI",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(21, 22, 41),
                Location = new Point(25, 195),
                AutoSize = true
            };
            this.Controls.Add(lblYorumlarBaslik);

            // Yorumlar paneli
            flowPanel = new FlowLayoutPanel
            {
                Location = new Point(25, 235),
                Size = new Size(685, 360),
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(248, 249, 250)
            };
            this.Controls.Add(flowPanel);
        }

        private void MasaDetayForm_Load(object sender, EventArgs e)
        {
            var degerlendirmeler = _degerlendirmeRepo.GetByMasaId(_masa.MasaID);

            if (degerlendirmeler.Count == 0)
            {
                Label lblBos = new Label
                {
                    Text = "Henüz bu masa için değerlendirme yapılmamış.",
                    Font = new Font("Segoe UI", 12),
                    ForeColor = Color.Gray,
                    Margin = new Padding(15),
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
                Width = 650,
                MinimumSize = new Size(650, 90),
                AutoSize = true,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(8),
                BackColor = Color.White,
                Padding = new Padding(15)
            };

            // Yıldızlar
            string yildizlar = new string('★', degerlendirme.Puan) + new string('☆', 5 - degerlendirme.Puan);
            Label lblYildizlar = new Label
            {
                Text = yildizlar,
                Location = new Point(15, 12),
                Font = new Font("Segoe UI", 16),
                ForeColor = Color.FromArgb(255, 193, 7),
                AutoSize = true
            };
            panel.Controls.Add(lblYildizlar);

            // Kullanıcı ve tarih
            Label lblKullanici = new Label
            {
                Text = $"{degerlendirme.KullaniciAdSoyad}  •  {degerlendirme.OlusturmaTarihi:dd MMMM yyyy}",
                Location = new Point(15, 45),
                Width = 620,
                Font = new Font("Segoe UI", 10),
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
                    Location = new Point(15, 70),
                    Width = 620,
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.FromArgb(50, 50, 50),
                    AutoSize = true,
                    MaximumSize = new Size(620, 0)
                };
                panel.Controls.Add(lblYorum);
                panel.Height = lblYorum.Bottom + 15;
            }
            else
            {
                panel.Height = 80;
            }

            return panel;
        }

        private void BtnRandevuAl_Click(object sender, EventArgs e)
        {
            using (var randevuDialog = new RandevuDialogForm(_masa))
            {
                if (randevuDialog.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
