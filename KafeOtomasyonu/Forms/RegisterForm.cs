using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KafeOtomasyonu.Data;
using KafeOtomasyonu.Models;

namespace KafeOtomasyonu.Forms
{
    public partial class RegisterForm : XtraForm
    {
        private readonly KullaniciRepository _kullaniciRepository;

        public RegisterForm()
        {
            InitializeComponent();
            _kullaniciRepository = new KullaniciRepository();
            
            // Form ayarları
            this.Text = "Kayıt Ol";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.WindowState = FormWindowState.Maximized; // Tam ekran başlat
            
            // Renk şeması (Login ile aynı)
            this.BackColor = ColorTranslator.FromHtml("#40E0D0"); // Turkuaz çerçeve
            
            // Load event
            this.Load += RegisterForm_Load;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            // Paneli ekranın tam ortasına yerleştir
            panelContainer.Location = new Point(
                (this.ClientSize.Width - panelContainer.Width) / 2,
                (this.ClientSize.Height - panelContainer.Height) / 2
            );
            
            txtAdSoyad.Focus();
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            // Boş alan kontrolleri
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text))
            {
                XtraMessageBox.Show("Ad Soyad boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdSoyad.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text))
            {
                XtraMessageBox.Show("Kullanıcı adı boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKullaniciAdi.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                XtraMessageBox.Show("E-posta adresi boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                XtraMessageBox.Show("Şifre boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSifre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSifreTekrar.Text))
            {
                XtraMessageBox.Show("Şifre tekrar boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSifreTekrar.Focus();
                return;
            }

            // Kullanıcı adı uzunluk kontrolü
            if (txtKullaniciAdi.Text.Trim().Length < 3)
            {
                XtraMessageBox.Show("Kullanıcı adı en az 3 karakter olmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKullaniciAdi.Focus();
                return;
            }

            // E-posta formatı kontrolü
            if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                XtraMessageBox.Show("Geçerli bir e-posta adresi giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            // Telefon formatı kontrolü (opsiyonel)
            if (!string.IsNullOrWhiteSpace(txtTelefon.Text) && !IsValidPhone(txtTelefon.Text.Trim()))
            {
                XtraMessageBox.Show("Geçerli bir telefon numarası giriniz!\n\nÖrnek: 05XX XXX XX XX", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefon.Focus();
                return;
            }

            // Şifre uzunluk kontrolü
            if (txtSifre.Text.Length < 6)
            {
                XtraMessageBox.Show("Şifre en az 6 karakter olmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSifre.Focus();
                return;
            }

            // Şifre eşleşme kontrolü
            if (txtSifre.Text != txtSifreTekrar.Text)
            {
                XtraMessageBox.Show("Şifreler eşleşmiyor!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSifreTekrar.Clear();
                txtSifre.Focus();
                return;
            }

            try
            {
                // Yeni kullanıcı oluştur
                var yeniKullanici = new Kullanici
                {
                    AdSoyad = txtAdSoyad.Text.Trim(),
                    KullaniciAdi = txtKullaniciAdi.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Telefon = string.IsNullOrWhiteSpace(txtTelefon.Text) ? null : txtTelefon.Text.Trim(),
                    Sifre = txtSifre.Text // Repository'de hashlenecek
                };

                // Kayıt işlemi
                int kullaniciId = _kullaniciRepository.Register(yeniKullanici);

                if (kullaniciId > 0)
                {
                    ShowModernNotification(
                        $"Kayıt başarılı! Hoş geldiniz {yeniKullanici.AdSoyad}.\n\nŞimdi giriş yapabilirsiniz.",
                        "Kayıt Başarılı",
                        true
                    );

                    // Animasyon için kısa bekleme
                    System.Threading.Tasks.Task.Delay(2000).ContinueWith(_ =>
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            // Formu kapat
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Kayıt yapılırken bir hata oluştu:\n\n{ex.Message}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void linkGirisYap_Click(object sender, EventArgs e)
        {
            // Formu kapat ve Login'e geri dön
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// E-posta formatı doğrulama
        /// </summary>
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

        /// <summary>
        /// Telefon formatı doğrulama (Türkiye formatı)
        /// </summary>
        private bool IsValidPhone(string phone)
        {
            try
            {
                // Sadece rakamları al
                string cleanPhone = Regex.Replace(phone, @"[^\d]", "");
                
                // 10 veya 11 haneli olmalı (05XXXXXXXXX veya 5XXXXXXXXX)
                if (cleanPhone.Length == 10 && cleanPhone.StartsWith("5"))
                    return true;
                    
                if (cleanPhone.Length == 11 && cleanPhone.StartsWith("05"))
                    return true;

                return false;
            }
            catch
            {
                return false;
            }
        }

        private void txtSifreTekrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Enter tuşuna basılınca kayıt ol
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnKayitOl_Click(sender, e);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Modern animasyonlu bildirim göster
        /// </summary>
        private void ShowModernNotification(string message, string title, bool isSuccess)
        {
            // Modern bildirim paneli oluştur
            var notificationPanel = new DevExpress.XtraEditors.PanelControl();
            var titleLabel = new DevExpress.XtraEditors.LabelControl();
            var messageLabel = new DevExpress.XtraEditors.LabelControl();

            // Panel ayarları
            notificationPanel.BackColor = isSuccess ? ColorTranslator.FromHtml("#40E0D0") : Color.FromArgb(231, 76, 60);
            notificationPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            notificationPanel.Size = new Size(400, 100);
            notificationPanel.Location = new Point(
                (this.ClientSize.Width - 400) / 2,
                -120  // Başlangıçta ekranın dışında
            );

            // Başlık
            titleLabel.Text = title;
            titleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(20, 20);
            titleLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            titleLabel.Size = new Size(360, 25);

            // Mesaj
            messageLabel.Text = message;
            messageLabel.Font = new Font("Segoe UI", 10F);
            messageLabel.ForeColor = Color.White;
            messageLabel.Location = new Point(20, 50);
            messageLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            messageLabel.Size = new Size(360, 40);

            notificationPanel.Controls.Add(titleLabel);
            notificationPanel.Controls.Add(messageLabel);
            this.Controls.Add(notificationPanel);
            notificationPanel.BringToFront();

            // Animasyon - Yukarıdan kayarak gir
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 10;
            int targetY = 20;
            int currentY = -120;

            timer.Tick += (s, e) =>
            {
                currentY += 8;
                if (currentY >= targetY)
                {
                    currentY = targetY;
                    timer.Stop();

                    // 2 saniye bekle sonra kayarak çık
                    System.Threading.Tasks.Task.Delay(2000).ContinueWith(_ =>
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            var hideTimer = new System.Windows.Forms.Timer();
                            hideTimer.Interval = 10;
                            hideTimer.Tick += (s2, e2) =>
                            {
                                currentY -= 8;
                                notificationPanel.Location = new Point(notificationPanel.Location.X, currentY);
                                if (currentY <= -120)
                                {
                                    hideTimer.Stop();
                                    this.Controls.Remove(notificationPanel);
                                    notificationPanel.Dispose();
                                }
                            };
                            hideTimer.Start();
                        });
                    });
                }
                notificationPanel.Location = new Point(notificationPanel.Location.X, currentY);
            };
            timer.Start();
        }
    }
}

