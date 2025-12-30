using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KafeOtomasyonu.Data;
using KafeOtomasyonu.Helpers;
using KafeOtomasyonu.Models;

namespace KafeOtomasyonu.Forms
{
    public partial class ProfilForm : XtraForm
    {
        private KullaniciRepository _kullaniciRepo;
        private Kullanici _kullanici;

        private TextBox txtAdSoyad;
        private TextBox txtEmail;
        private TextBox txtTelefon;
        private Label lblKullaniciAdi;
        private Label lblKayitTarihi;
        private SimpleButton btnKaydet;
        private SimpleButton btnIptal;
        private SimpleButton btnSifreDegistir;

        public ProfilForm()
        {
            InitializeComponent();
            _kullaniciRepo = new KullaniciRepository();
            
            InitializeCustomComponents();
            this.Load += ProfilForm_Load;
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Profilim";
            this.Size = new Size(550, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Başlık
            Label lblBaslik = new Label
            {
                Text = "👤 PROFİL BİLGİLERİM",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(lblBaslik);

            // Kullanıcı Adı (Değiştirilemez)
            Label lblKullaniciAdiBaslik = new Label
            {
                Text = "Kullanıcı Adı:",
                Location = new Point(20, 70),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(lblKullaniciAdiBaslik);

            lblKullaniciAdi = new Label
            {
                Location = new Point(20, 95),
                Width = 490,
                Height = 30,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 150, 243),
                TextAlign = ContentAlignment.MiddleLeft,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(240, 240, 240)
            };
            this.Controls.Add(lblKullaniciAdi);

            // Ad Soyad
            Label lblAdSoyadBaslik = new Label
            {
                Text = "Ad Soyad:",
                Location = new Point(20, 140),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(lblAdSoyadBaslik);

            txtAdSoyad = new TextBox
            {
                Location = new Point(20, 165),
                Width = 490,
                Font = new Font("Segoe UI", 11)
            };
            this.Controls.Add(txtAdSoyad);

            // Email
            Label lblEmailBaslik = new Label
            {
                Text = "E-posta:",
                Location = new Point(20, 205),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(lblEmailBaslik);

            txtEmail = new TextBox
            {
                Location = new Point(20, 230),
                Width = 490,
                Font = new Font("Segoe UI", 11)
            };
            this.Controls.Add(txtEmail);

            // Telefon
            Label lblTelefonBaslik = new Label
            {
                Text = "Telefon:",
                Location = new Point(20, 270),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(lblTelefonBaslik);

            txtTelefon = new TextBox
            {
                Location = new Point(20, 295),
                Width = 490,
                Font = new Font("Segoe UI", 11),
                MaxLength = 11
            };
            this.Controls.Add(txtTelefon);

            // Kayıt Tarihi (Sadece bilgi)
            Label lblKayitTarihiBaslik = new Label
            {
                Text = "Kayıt Tarihi:",
                Location = new Point(20, 335),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(lblKayitTarihiBaslik);

            lblKayitTarihi = new Label
            {
                Location = new Point(20, 360),
                Width = 490,
                Height = 30,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleLeft,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(250, 250, 250)
            };
            this.Controls.Add(lblKayitTarihi);

            // Şifre Değiştir Butonu
            btnSifreDegistir = new SimpleButton
            {
                Text = "🔐 Şifre Değiştir",
                Location = new Point(20, 410),
                Size = new Size(150, 35),
                Appearance = { BackColor = Color.FromArgb(255, 152, 0), Font = new Font("Segoe UI", 10, FontStyle.Bold) }
            };
            btnSifreDegistir.Appearance.Options.UseBackColor = true;
            btnSifreDegistir.Appearance.Options.UseFont = true;
            btnSifreDegistir.Click += BtnSifreDegistir_Click;
            this.Controls.Add(btnSifreDegistir);

            // Kaydet Butonu
            btnKaydet = new SimpleButton
            {
                Text = "💾 Kaydet",
                Location = new Point(300, 410),
                Size = new Size(100, 35),
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
                Location = new Point(410, 410),
                Size = new Size(100, 35),
                Appearance = { BackColor = Color.FromArgb(158, 158, 158), Font = new Font("Segoe UI", 10, FontStyle.Bold) }
            };
            btnIptal.Appearance.Options.UseBackColor = true;
            btnIptal.Appearance.Options.UseFont = true;
            btnIptal.Click += (s, e) => this.Close();
            this.Controls.Add(btnIptal);
        }

        private void ProfilForm_Load(object sender, EventArgs e)
        {
            _kullanici = _kullaniciRepo.GetById(SessionManager.GetCurrentUserId());
            
            if (_kullanici != null)
            {
                lblKullaniciAdi.Text = $"  {_kullanici.KullaniciAdi}";
                txtAdSoyad.Text = _kullanici.AdSoyad;
                txtEmail.Text = _kullanici.Email;
                txtTelefon.Text = _kullanici.Telefon;
                lblKayitTarihi.Text = $"  {_kullanici.KayitTarihi:dd MMMM yyyy (dddd)}";
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // Validasyon
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text))
            {
                MessageBox.Show("Lütfen ad soyad giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdSoyad.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Lütfen e-posta giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            // Email formatı kontrolü
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Lütfen geçerli bir e-posta adresi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefon.Text))
            {
                MessageBox.Show("Lütfen telefon numarası giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefon.Focus();
                return;
            }

            try
            {
                // Email değişti mi kontrol et (başka kullanıcıda var mı?)
                if (txtEmail.Text != _kullanici.Email && _kullaniciRepo.IsEmailExists(txtEmail.Text))
                {
                    MessageBox.Show("Bu e-posta adresi başka bir kullanıcı tarafından kullanılıyor.", 
                                  "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Güncelle
                _kullaniciRepo.UpdateProfil(
                    _kullanici.KullaniciID,
                    txtAdSoyad.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtTelefon.Text.Trim()
                );

                MessageBox.Show("Profil bilgileriniz başarıyla güncellendi!", "Başarılı", 
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSifreDegistir_Click(object sender, EventArgs e)
        {
            using (var sifreForm = new SifreDegistirForm())
            {
                sifreForm.ShowDialog();
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }
    }
}
