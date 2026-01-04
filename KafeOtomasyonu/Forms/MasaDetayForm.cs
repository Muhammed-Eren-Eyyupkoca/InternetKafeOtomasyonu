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
            this.Size = new Size(950, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            // ===== ÜST KISIM: MASA BİLGİLERİ VE RANDEVU BUTONU =====
            Panel pnlUst = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(950, 180),
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
                Location = new Point(700, 40),
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
                Location = new Point(700, 115),
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

            // ===== ALT KISIM: YORUMLAR (SOL) VE PC ÖZELLİKLERİ (SAĞ) =====
            
            // Sol taraf - Yorumlar başlığı
            Label lblYorumlarBaslik = new Label
            {
                Text = "💬 KULLANICI YORUMLARI",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.FromArgb(21, 22, 41),
                Location = new Point(25, 195),
                AutoSize = true
            };
            this.Controls.Add(lblYorumlarBaslik);

            // Yorumlar paneli (daraltıldı)
            flowPanel = new FlowLayoutPanel
            {
                Location = new Point(25, 230),
                Size = new Size(550, 365),
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(248, 249, 250)
            };
            this.Controls.Add(flowPanel);

            // ===== SAĞ TARAF: PC ÖZELLİKLERİ =====
            Label lblPCBaslik = new Label
            {
                Text = "🖥️ PC ÖZELLİKLERİ",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.FromArgb(21, 22, 41),
                Location = new Point(595, 195),
                AutoSize = true
            };
            this.Controls.Add(lblPCBaslik);

            // PC Özellikleri Panel
            Panel pnlPCOzellikleri = new Panel
            {
                Location = new Point(595, 230),
                Size = new Size(320, 365),
                BackColor = Color.FromArgb(30, 32, 54),
                BorderStyle = BorderStyle.None
            };
            this.Controls.Add(pnlPCOzellikleri);

            // PC Özellikleri içeriği
            string[] ozellikler = _masa.PCOzellikleri?.Split(',') ?? new string[0];
            
            // Masa tipi belirleme
            string masaTipi = "Standart";
            Color tipRengi = Color.FromArgb(46, 204, 113); // Yeşil
            
            if (_masa.MasaNo == 7 || _masa.MasaNo == 8 || _masa.MasaNo == 17 || 
                _masa.MasaNo == 18 || _masa.MasaNo == 23)
            {
                masaTipi = "👑 VIP";
                tipRengi = Color.FromArgb(255, 193, 7); // Altın
            }
            else if (_masa.MasaNo == 3 || _masa.MasaNo == 4 || _masa.MasaNo == 13 || 
                     _masa.MasaNo == 14 || _masa.MasaNo >= 21)
            {
                masaTipi = "⭐ Premium";
                tipRengi = Color.FromArgb(138, 43, 226); // Mor
            }

            // Masa Tipi Label
            Label lblMasaTipi = new Label
            {
                Text = masaTipi,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = tipRengi,
                Location = new Point(15, 15),
                AutoSize = true
            };
            pnlPCOzellikleri.Controls.Add(lblMasaTipi);

            // Ayırıcı çizgi
            Panel separator = new Panel
            {
                Location = new Point(15, 55),
                Size = new Size(290, 2),
                BackColor = Color.FromArgb(60, 64, 90)
            };
            pnlPCOzellikleri.Controls.Add(separator);

            // Özellik ikonları ve metinleri
            int yPos = 75;
            string[] ikonlar = { "💻", "🎮", "🧠", "📺" };
            string[] basliklar = { "İşlemci", "Ekran Kartı", "RAM", "Monitör" };

            for (int i = 0; i < ozellikler.Length && i < 4; i++)
            {
                string ozellik = ozellikler[i].Trim();
                
                // İkon ve başlık
                Label lblIcon = new Label
                {
                    Text = ikonlar[i],
                    Font = new Font("Segoe UI", 20),
                    ForeColor = Color.White,
                    Location = new Point(15, yPos),
                    Size = new Size(40, 40)
                };
                pnlPCOzellikleri.Controls.Add(lblIcon);

                Label lblOzellikBaslik = new Label
                {
                    Text = basliklar[i],
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.FromArgb(150, 155, 180),
                    Location = new Point(60, yPos),
                    AutoSize = true
                };
                pnlPCOzellikleri.Controls.Add(lblOzellikBaslik);

                Label lblOzellikDeger = new Label
                {
                    Text = ozellik,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point(60, yPos + 20),
                    Size = new Size(245, 25),
                    AutoEllipsis = true
                };
                pnlPCOzellikleri.Controls.Add(lblOzellikDeger);

                yPos += 70;
            }

            // Açıklama
            if (!string.IsNullOrEmpty(_masa.Aciklama))
            {
                Panel separator2 = new Panel
                {
                    Location = new Point(15, yPos + 5),
                    Size = new Size(290, 2),
                    BackColor = Color.FromArgb(60, 64, 90)
                };
                pnlPCOzellikleri.Controls.Add(separator2);

                Label lblAciklama = new Label
                {
                    Text = $"📝 {_masa.Aciklama}",
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.FromArgb(180, 185, 200),
                    Location = new Point(15, yPos + 20),
                    Size = new Size(290, 40),
                    AutoEllipsis = true
                };
                pnlPCOzellikleri.Controls.Add(lblAciklama);
            }
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
                Width = 520,
                MinimumSize = new Size(520, 90),
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
                Font = new Font("Segoe UI", 14),
                ForeColor = Color.FromArgb(255, 193, 7),
                AutoSize = true
            };
            panel.Controls.Add(lblYildizlar);

            // Kullanıcı ve tarih
            Label lblKullanici = new Label
            {
                Text = $"{degerlendirme.KullaniciAdSoyad}  •  {degerlendirme.OlusturmaTarihi:dd MMMM yyyy}",
                Location = new Point(15, 40),
                Width = 490,
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
                    Location = new Point(15, 65),
                    Width = 490,
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.FromArgb(50, 50, 50),
                    AutoSize = true,
                    MaximumSize = new Size(490, 0)
                };
                panel.Controls.Add(lblYorum);
                panel.Height = lblYorum.Bottom + 15;
            }
            else
            {
                panel.Height = 75;
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

        private void BtnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
