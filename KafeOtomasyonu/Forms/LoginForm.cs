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
        private readonly AdminRepository _adminRepository;

        public LoginForm()
        {
            InitializeComponent();
            _kullaniciRepository = new KullaniciRepository();
            _adminRepository = new AdminRepository();
            
            // Form ayarları
            this.Text = "Giriş Yap";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.WindowState = FormWindowState.Maximized; // Tam ekran başlat
            
            // Vintage Renk Şeması
            this.BackColor = ColorTranslator.FromHtml("#151629"); // Dark vintage lacivert
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
                // Admin girişi mi kontrol et
                if (chkAdminGirisi != null && chkAdminGirisi.Checked)
                {
                    AdminGirisi();
                }
                else
                {
                    KullaniciGirisi();
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

        /// <summary>
        /// Kullanıcı girişi
        /// </summary>
        private void KullaniciGirisi()
        {
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
                        MasaListesiForm mainForm = new MasaListesiForm();
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

        /// <summary>
        /// Admin girişi
        /// </summary>
        private void AdminGirisi()
        {
            try
            {
                // Debug: Hash'i kontrol et
                string girisHash = DatabaseHelper.HashPassword(txtSifre.Text);
                
                // Debug: Veritabanında admin var mı kontrol et
                string checkQuery = "SELECT COUNT(*), Sifre FROM Adminler WHERE AdminAdi = @AdminAdi GROUP BY Sifre";
                var checkParams = DatabaseHelper.CreateParameters(("@AdminAdi", txtKullaniciAdi.Text.Trim()));
                var dt = DatabaseHelper.ExecuteQuery(checkQuery, checkParams);
                
                if (dt.Rows.Count == 0)
                {
                    XtraMessageBox.Show(
                        $"'{txtKullaniciAdi.Text}' adında admin bulunamadı!\n\nSQL scriptini çalıştırdınız mı?",
                        "Admin Bulunamadı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
                
                string dbHash = dt.Rows[0]["Sifre"].ToString();
                
                if (girisHash != dbHash)
                {
                    XtraMessageBox.Show(
                        $"Şifre hash'leri uyuşmuyor!\n\n" +
                        $"Girdiğiniz şifrenin hash'i:\n{girisHash}\n\n" +
                        $"Veritabanındaki hash:\n{dbHash}\n\n" +
                        $"Şifre: admin123 olmalı",
                        "Hash Uyuşmazlığı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                var admin = _adminRepository.Login(txtKullaniciAdi.Text.Trim(), txtSifre.Text);

                if (admin != null)
                {
                    // Aktif kontrol
                    if (!admin.Aktif)
                    {
                        XtraMessageBox.Show(
                            "Admin hesabınız devre dışı bırakılmış!",
                            "Erişim Engellendi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    // Oturum aç
                    SessionManager.LoginAdmin(admin);

                    ShowModernNotification(
                        $"Hoş geldiniz Admin, {admin.AdSoyad}!",
                        "Admin Girişi Başarılı",
                        true
                    );

                    // Animasyon için kısa bekleme
                    System.Threading.Tasks.Task.Delay(1500).ContinueWith(_ =>
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            // Admin paneline geç
                            this.Hide();
                            AdminPanelForm adminPanel = new AdminPanelForm();
                            adminPanel.FormClosed += (s, args) => this.Close();
                            adminPanel.Show();
                        });
                    });
                }
                else
                {
                    XtraMessageBox.Show(
                        "Admin kullanıcı adı veya şifre hatalı!\n\nAdmin: admin\nŞifre: admin123",
                        "Giriş Hatası",
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
                    $"Admin girişi sırasında hata:\n\n{ex.Message}",
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
            // Admin yoksa oluştur (tek seferlik)
            try
            {
                string checkQuery = "SELECT COUNT(*) FROM Adminler WHERE AdminAdi = 'admin'";
                int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery));
                
                if (count == 0)
                {
                    // Admin yok, oluştur
                    string insertQuery = @"INSERT INTO Adminler (AdminAdi, Sifre, AdSoyad, Email, Aktif) 
                                         VALUES ('admin', '240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9', 'Sistem Admini', 'admin@kafeotomasyon.com', 1)";
                    DatabaseHelper.ExecuteNonQuery(insertQuery);
                }
                else
                {
                    // Admin var, hash'ini düzelt
                    string updateQuery = "UPDATE Adminler SET Sifre = '240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9' WHERE AdminAdi = 'admin' AND Sifre != '240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9'";
                    DatabaseHelper.ExecuteNonQuery(updateQuery);
                }
            }
            catch { /* Sessizce geç */ }

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

            // Panel ayarları - Vintage renkler
            notificationPanel.BackColor = isSuccess ? ColorTranslator.FromHtml("#55a586") : ColorTranslator.FromHtml("#c82b6d");
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

