using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KafeOtomasyonu.Data;
using KafeOtomasyonu.Helpers;

namespace KafeOtomasyonu.Forms
{
    public partial class SifreDegistirForm : XtraForm
    {
        private KullaniciRepository _kullaniciRepo;

        private TextBox txtEskiSifre;
        private TextBox txtYeniSifre;
        private TextBox txtYeniSifreTekrar;
        private CheckBox chkSifreGoster;
        private SimpleButton btnKaydet;
        private SimpleButton btnIptal;
        private Label lblGuvenlik;

        public SifreDegistirForm()
        {
            InitializeComponent();
            _kullaniciRepo = new KullaniciRepository();
            
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Şifre Değiştir";
            this.Size = new Size(500, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Başlık
            Label lblBaslik = new Label
            {
                Text = "🔐 ŞİFRE DEĞİŞTİR",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(lblBaslik);

            // Uyarı mesajı
            Label lblUyari = new Label
            {
                Text = "⚠️ Şifreniz en az 6 karakter uzunluğunda olmalıdır.",
                Location = new Point(20, 55),
                Width = 440,
                ForeColor = Color.FromArgb(255, 152, 0),
                Font = new Font("Segoe UI", 9)
            };
            this.Controls.Add(lblUyari);

            // Eski Şifre
            Label lblEskiSifre = new Label
            {
                Text = "Mevcut Şifre:",
                Location = new Point(20, 90),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(lblEskiSifre);

            txtEskiSifre = new TextBox
            {
                Location = new Point(20, 115),
                Width = 440,
                Font = new Font("Segoe UI", 11),
                PasswordChar = '●'
            };
            this.Controls.Add(txtEskiSifre);

            // Yeni Şifre
            Label lblYeniSifre = new Label
            {
                Text = "Yeni Şifre:",
                Location = new Point(20, 155),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(lblYeniSifre);

            txtYeniSifre = new TextBox
            {
                Location = new Point(20, 180),
                Width = 440,
                Font = new Font("Segoe UI", 11),
                PasswordChar = '●'
            };
            txtYeniSifre.TextChanged += TxtYeniSifre_TextChanged;
            this.Controls.Add(txtYeniSifre);

            // Yeni Şifre Tekrar
            Label lblYeniSifreTekrar = new Label
            {
                Text = "Yeni Şifre (Tekrar):",
                Location = new Point(20, 220),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(lblYeniSifreTekrar);

            txtYeniSifreTekrar = new TextBox
            {
                Location = new Point(20, 245),
                Width = 440,
                Font = new Font("Segoe UI", 11),
                PasswordChar = '●'
            };
            this.Controls.Add(txtYeniSifreTekrar);

            // Güvenlik göstergesi
            lblGuvenlik = new Label
            {
                Location = new Point(20, 280),
                Width = 440,
                Height = 25,
                Text = "",
                Font = new Font("Segoe UI", 9),
                TextAlign = ContentAlignment.MiddleLeft
            };
            this.Controls.Add(lblGuvenlik);

            // Şifre göster
            chkSifreGoster = new CheckBox
            {
                Text = "Şifreleri Göster",
                Location = new Point(20, 315),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            chkSifreGoster.CheckedChanged += ChkSifreGoster_CheckedChanged;
            this.Controls.Add(chkSifreGoster);

            // Kaydet Butonu
            btnKaydet = new SimpleButton
            {
                Text = "💾 Kaydet",
                Location = new Point(250, 360),
                Size = new Size(100, 40),
                Appearance = { BackColor = Color.FromArgb(76, 175, 80), Font = new Font("Segoe UI", 10, FontStyle.Bold) }
            };
            btnKaydet.Appearance.Options.UseBackColor = true;
            btnKaydet.Appearance.Options.UseFont = true;
            btnKaydet.Click += BtnKaydet_Click;
            this.Controls.Add(btnKaydet);

            // İptal Butonu
            btnIptal = new SimpleButton
            {
                Text = "❌ İptal",
                Location = new Point(360, 360),
                Size = new Size(100, 40),
                Appearance = { BackColor = Color.FromArgb(158, 158, 158), Font = new Font("Segoe UI", 10, FontStyle.Bold) }
            };
            btnIptal.Appearance.Options.UseBackColor = true;
            btnIptal.Appearance.Options.UseFont = true;
            btnIptal.Click += (s, e) => this.Close();
            this.Controls.Add(btnIptal);
        }

        private void TxtYeniSifre_TextChanged(object sender, EventArgs e)
        {
            string sifre = txtYeniSifre.Text;
            
            if (string.IsNullOrEmpty(sifre))
            {
                lblGuvenlik.Text = "";
                lblGuvenlik.ForeColor = Color.Gray;
                return;
            }

            // Şifre gücü kontrolü
            int guc = 0;
            if (sifre.Length >= 6) guc++;
            if (sifre.Length >= 8) guc++;
            if (System.Text.RegularExpressions.Regex.IsMatch(sifre, @"[A-Z]")) guc++;
            if (System.Text.RegularExpressions.Regex.IsMatch(sifre, @"[0-9]")) guc++;
            if (System.Text.RegularExpressions.Regex.IsMatch(sifre, @"[!@#$%^&*(),.?""':{}|<>]")) guc++;

            if (guc <= 2)
            {
                lblGuvenlik.Text = "❌ Zayıf Şifre";
                lblGuvenlik.ForeColor = Color.FromArgb(244, 67, 54);
            }
            else if (guc <= 3)
            {
                lblGuvenlik.Text = "⚠️ Orta Güçlü Şifre";
                lblGuvenlik.ForeColor = Color.FromArgb(255, 152, 0);
            }
            else
            {
                lblGuvenlik.Text = "✅ Güçlü Şifre";
                lblGuvenlik.ForeColor = Color.FromArgb(76, 175, 80);
            }
        }

        private void ChkSifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            char karakter = chkSifreGoster.Checked ? '\0' : '●';
            txtEskiSifre.PasswordChar = karakter;
            txtYeniSifre.PasswordChar = karakter;
            txtYeniSifreTekrar.PasswordChar = karakter;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // Validasyon
            if (string.IsNullOrWhiteSpace(txtEskiSifre.Text))
            {
                MessageBox.Show("Lütfen mevcut şifrenizi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEskiSifre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtYeniSifre.Text))
            {
                MessageBox.Show("Lütfen yeni şifrenizi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYeniSifre.Focus();
                return;
            }

            if (txtYeniSifre.Text.Length < 6)
            {
                MessageBox.Show("Şifre en az 6 karakter uzunluğunda olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYeniSifre.Focus();
                return;
            }

            if (txtYeniSifre.Text != txtYeniSifreTekrar.Text)
            {
                MessageBox.Show("Yeni şifreler eşleşmiyor!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYeniSifreTekrar.Focus();
                return;
            }

            if (txtEskiSifre.Text == txtYeniSifre.Text)
            {
                MessageBox.Show("Yeni şifre eski şifre ile aynı olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYeniSifre.Focus();
                return;
            }

            try
            {
                int kullaniciId = SessionManager.GetCurrentUserId();

                // Şifre değiştirme işlemi (eski şifre kontrolü dahil)
                bool basarili = _kullaniciRepo.ChangeSifre(kullaniciId, txtEskiSifre.Text, txtYeniSifre.Text);

                if (!basarili)
                {
                    MessageBox.Show("Mevcut şifreniz yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEskiSifre.Focus();
                    txtEskiSifre.SelectAll();
                    return;
                }

                MessageBox.Show("Şifreniz başarıyla değiştirildi!", "Başarılı", 
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

