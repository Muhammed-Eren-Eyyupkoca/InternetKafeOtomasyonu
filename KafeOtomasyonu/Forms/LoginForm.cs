using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KafeOtomasyonu.Data;
using KafeOtomasyonu.Helpers;

namespace KafeOtomasyonu.Forms
{
    public partial class LoginForm : XtraForm
    {
        private readonly KullaniciRepository _kullaniciRepository;

        public LoginForm()
        {
            InitializeComponent();
            _kullaniciRepository = new KullaniciRepository();
            
            // Form ayarları
            this.Text = "Giriş Yap";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.WindowState = FormWindowState.Maximized; // Tam ekran başlat
            
            // Renk şeması
            this.BackColor = ColorTranslator.FromHtml("#40E0D0"); // Turkuaz çerçeve
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            // Boş alan kontrolü
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text))
            {
                XtraMessageBox.Show("Kullanıcı adı boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKullaniciAdi.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                XtraMessageBox.Show("Şifre boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSifre.Focus();
                return;
            }

            try
            {
                // Giriş kontrolü
                var kullanici = _kullaniciRepository.Login(txtKullaniciAdi.Text.Trim(), txtSifre.Text);

                if (kullanici != null)
                {
                    // Bloklu kullanıcı kontrolü
                    if (kullanici.Bloklu)
                    {
                        ShowModernNotification(
                            $"Hesabınız bloklanmıştır!\n\nNeden: {kullanici.BlokNedeni}\n\nLütfen yönetici ile iletişime geçin.",
                            "Hesap Bloklu",
                            false
                        );
                        return;
                    }

                    // Oturum aç
                    SessionManager.LoginUser(kullanici);

                    // Beni hatırla
                    if (chkBeniHatirla.Checked)
                    {
                        Properties.Settings.Default.RememberMe = true;
                        Properties.Settings.Default.SavedUsername = txtKullaniciAdi.Text.Trim();
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.RememberMe = false;
                        Properties.Settings.Default.SavedUsername = string.Empty;
                        Properties.Settings.Default.Save();
                    }

                    ShowModernNotification(
                        $"Hoş geldiniz, {kullanici.AdSoyad}!",
                        "Giriş Başarılı",
                        true
                    );

                    // Animasyon için kısa bekleme
                    System.Threading.Tasks.Task.Delay(1500).ContinueWith(_ =>
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            // Ana forma geç
                            this.Hide();
                            Form1 mainForm = new Form1();
                            mainForm.FormClosed += (s, args) => this.Close();
                            mainForm.Show();
                        });
                    });
                }
                else
                {
                    XtraMessageBox.Show(
                        "Kullanıcı adı veya şifre hatalı!",
                        "Hata",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    txtSifre.Clear();
                    txtKullaniciAdi.Focus();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Giriş yapılırken bir hata oluştu:\n{ex.Message}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void linkKayitOl_Click(object sender, EventArgs e)
        {
            // Kayıt formunu aç
            RegisterForm registerForm = new RegisterForm();
            if (registerForm.ShowDialog() == DialogResult.OK)
            {
                // Kayıt başarılı olduğunda odaklan
                this.txtKullaniciAdi.Focus();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Paneli ekranın tam ortasına yerleştir
            panelContainer.Location = new Point(
                (this.ClientSize.Width - panelContainer.Width) / 2,
                (this.ClientSize.Height - panelContainer.Height) / 2
            );

            // Beni hatırla ayarı varsa kullanıcı adını doldur
            if (Properties.Settings.Default.RememberMe)
            {
                txtKullaniciAdi.Text = Properties.Settings.Default.SavedUsername;
                chkBeniHatirla.Checked = true;
                txtSifre.Focus();
            }
            else
            {
                txtKullaniciAdi.Focus();
            }

            // Veritabanı bağlantı kontrolü
            if (!DatabaseHelper.TestConnection())
            {
                XtraMessageBox.Show(
                    "Veritabanı bağlantısı kurulamadı!\n\nLütfen SQL Server'ın çalıştığından ve bağlantı ayarlarının doğru olduğundan emin olun.",
                    "Bağlantı Hatası",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void txtSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Enter tuşuna basılınca giriş yap
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnGirisYap_Click(sender, e);
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

