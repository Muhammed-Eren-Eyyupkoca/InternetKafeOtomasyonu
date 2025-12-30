using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KafeOtomasyonu.Data;
using KafeOtomasyonu.Helpers;
using KafeOtomasyonu.Models;

namespace KafeOtomasyonu.Forms
{
    public partial class DegerlendirmeYapForm : XtraForm
    {
        private Randevu _randevu;
        private DegerlendirmeRepository _degerlendirmeRepo;

        private Label lblMasaBilgi;
        private Panel pnlYildizlar;
        private Label[] lblYildizlar;
        private int _secilenPuan = 0;
        private TextBox txtYorum;
        private Label lblPuanBilgi;
        private SimpleButton btnKaydet;
        private SimpleButton btnIptal;

        public DegerlendirmeYapForm(Randevu randevu)
        {
            _randevu = randevu;
            _degerlendirmeRepo = new DegerlendirmeRepository();

            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Değerlendirme Yap";
            this.Size = new Size(550, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Başlık
            Label lblBaslik = new Label
            {
                Text = "⭐ DEĞERLENDĐRME YAP",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(lblBaslik);

            // Masa bilgisi
            Label lblMasaBaslik = new Label
            {
                Text = "Değerlendirdiğiniz Masa:",
                Location = new Point(20, 60),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(lblMasaBaslik);

            lblMasaBilgi = new Label
            {
                Location = new Point(20, 85),
                Width = 490,
                Height = 30,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 150, 243),
                TextAlign = ContentAlignment.MiddleLeft,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(240, 240, 240),
                Text = $"  🖥️ {_randevu.MasaAdi} - {_randevu.RandevuTarihi:dd.MM.yyyy}"
            };
            this.Controls.Add(lblMasaBilgi);

            // Puan başlık
            Label lblPuanBaslik = new Label
            {
                Text = "Puanınız: (Yıldızlara tıklayın)",
                Location = new Point(20, 135),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(lblPuanBaslik);

            // Yıldızlar paneli
            pnlYildizlar = new Panel
            {
                Location = new Point(20, 160),
                Size = new Size(300, 60),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(pnlYildizlar);

            // Yıldızları oluştur
            lblYildizlar = new Label[5];
            for (int i = 0; i < 5; i++)
            {
                int puan = i + 1;
                lblYildizlar[i] = new Label
                {
                    Text = "☆",
                    Location = new Point(10 + (i * 55), 10),
                    Size = new Size(50, 40),
                    Font = new Font("Segoe UI", 32),
                    ForeColor = Color.Gray,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    Tag = puan
                };
                lblYildizlar[i].Click += Yildiz_Click;
                lblYildizlar[i].MouseEnter += Yildiz_MouseEnter;
                pnlYildizlar.Controls.Add(lblYildizlar[i]);
            }

            pnlYildizlar.MouseLeave += (s, e) => YildizlariGuncelle(_secilenPuan);

            // Puan bilgisi
            lblPuanBilgi = new Label
            {
                Location = new Point(330, 165),
                Width = 180,
                Height = 50,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.Gray,
                Text = "Puan seçiniz",
                TextAlign = ContentAlignment.MiddleLeft
            };
            this.Controls.Add(lblPuanBilgi);

            // Yorum başlık
            Label lblYorumBaslik = new Label
            {
                Text = "Yorumunuz: (İsteğe bağlı)",
                Location = new Point(20, 240),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(lblYorumBaslik);

            // Yorum textbox
            txtYorum = new TextBox
            {
                Location = new Point(20, 265),
                Width = 490,
                Height = 120,
                Font = new Font("Segoe UI", 10),
                Multiline = true,
                MaxLength = 1000,
                ScrollBars = ScrollBars.Vertical,
                PlaceholderText = "Deneyiminizi bizimle paylaşın... (Maksimum 1000 karakter)"
            };
            this.Controls.Add(txtYorum);

            // Karakter sayacı
            Label lblKarakter = new Label
            {
                Location = new Point(20, 390),
                Width = 490,
                Height = 20,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                Text = "0 / 1000 karakter",
                TextAlign = ContentAlignment.TopRight
            };
            this.Controls.Add(lblKarakter);

            txtYorum.TextChanged += (s, e) =>
            {
                lblKarakter.Text = $"{txtYorum.Text.Length} / 1000 karakter";
            };

            // Kaydet Butonu
            btnKaydet = new SimpleButton
            {
                Text = "⭐ Değerlendir",
                Location = new Point(300, 425),
                Size = new Size(100, 40),
                Appearance = { BackColor = Color.FromArgb(255, 193, 7), Font = new Font("Segoe UI", 10, FontStyle.Bold) }
            };
            btnKaydet.Appearance.Options.UseBackColor = true;
            btnKaydet.Appearance.Options.UseFont = true;
            btnKaydet.Click += BtnKaydet_Click;
            this.Controls.Add(btnKaydet);

            // İptal Butonu
            btnIptal = new SimpleButton
            {
                Text = "❌ İptal",
                Location = new Point(410, 425),
                Size = new Size(100, 40),
                Appearance = { BackColor = Color.FromArgb(158, 158, 158), Font = new Font("Segoe UI", 10, FontStyle.Bold) }
            };
            btnIptal.Appearance.Options.UseBackColor = true;
            btnIptal.Appearance.Options.UseFont = true;
            btnIptal.Click += (s, e) => this.Close();
            this.Controls.Add(btnIptal);
        }

        private void Yildiz_Click(object sender, EventArgs e)
        {
            Label yildiz = sender as Label;
            if (yildiz != null)
            {
                _secilenPuan = (int)yildiz.Tag;
                YildizlariGuncelle(_secilenPuan);
                PuanBilgisiGuncelle();
            }
        }

        private void Yildiz_MouseEnter(object sender, EventArgs e)
        {
            Label yildiz = sender as Label;
            if (yildiz != null)
            {
                int hoverPuan = (int)yildiz.Tag;
                YildizlariGuncelle(hoverPuan);
            }
        }

        private void YildizlariGuncelle(int puan)
        {
            for (int i = 0; i < 5; i++)
            {
                if (i < puan)
                {
                    lblYildizlar[i].Text = "★";
                    lblYildizlar[i].ForeColor = Color.FromArgb(255, 193, 7);
                }
                else
                {
                    lblYildizlar[i].Text = "☆";
                    lblYildizlar[i].ForeColor = Color.Gray;
                }
            }
        }

        private void PuanBilgisiGuncelle()
        {
            string[] puanMetinleri = { "", "⭐ Çok Kötü", "⭐⭐ Kötü", "⭐⭐⭐ Orta", "⭐⭐⭐⭐ İyi", "⭐⭐⭐⭐⭐ Mükemmel" };
            Color[] puanRenkleri = { Color.Gray, Color.FromArgb(244, 67, 54), Color.FromArgb(255, 152, 0), 
                                     Color.FromArgb(255, 193, 7), Color.FromArgb(139, 195, 74), Color.FromArgb(76, 175, 80) };

            if (_secilenPuan > 0 && _secilenPuan <= 5)
            {
                lblPuanBilgi.Text = puanMetinleri[_secilenPuan];
                lblPuanBilgi.ForeColor = puanRenkleri[_secilenPuan];
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // Validasyon
            if (_secilenPuan == 0)
            {
                MessageBox.Show("Lütfen bir puan seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Değerlendirme oluştur
                var degerlendirme = new Degerlendirme
                {
                    RandevuID = _randevu.RandevuID,
                    MasaID = _randevu.MasaID,
                    KullaniciID = SessionManager.GetCurrentUserId(),
                    Puan = _secilenPuan,
                    Yorum = string.IsNullOrWhiteSpace(txtYorum.Text) ? null : txtYorum.Text.Trim()
                };

                _degerlendirmeRepo.Add(degerlendirme);

                MessageBox.Show("Değerlendirmeniz için teşekkür ederiz!", "Başarılı", 
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

