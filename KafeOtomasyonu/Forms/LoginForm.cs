using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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
        private List<Image> _gameLogos;
        private Image _cachedBackground;
        
        // Animasyon değişkenleri
        private Button btnShowLogin;
        private Timer dropAnimationTimer;
        private int currentPanelY;
        private int targetPanelY;
        private int ropeLength;
        private bool isAnimating = false;
        private bool isPanelVisible = false;

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
            this.DoubleBuffered = true;
            
            // Vintage Renk Şeması
            this.BackColor = ColorTranslator.FromHtml("#151629"); // Dark vintage lacivert
            
            // Oyun logolarını yükle
            LoadGameLogos();
            
            // Animasyon butonunu oluştur
            CreateShowLoginButton();
            
            // Animasyon timer'ı
            dropAnimationTimer = new Timer();
            dropAnimationTimer.Interval = 12;
            dropAnimationTimer.Tick += DropAnimationTimer_Tick;
        }

        private void CreateShowLoginButton()
        {
            btnShowLogin = new Button
            {
                Text = "🎮 GİRİŞ YAP",
                Size = new Size(220, 60),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(43, 128, 200),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnShowLogin.FlatAppearance.BorderSize = 0;
            btnShowLogin.Click += BtnShowLogin_Click;
            this.Controls.Add(btnShowLogin);
            btnShowLogin.BringToFront();
        }

        private void BtnShowLogin_Click(object sender, EventArgs e)
        {
            if (isAnimating) return;
            
            // Butonu gizle
            btnShowLogin.Visible = false;
            
            // Panel animasyonunu başlat
            StartDropAnimation();
        }

        private void StartDropAnimation()
        {
            isAnimating = true;
            isPanelVisible = true;
            
            // Panel başlangıç pozisyonu (ekranın üstünde)
            currentPanelY = -panelContainer.Height - 50;
            ropeLength = 0;
            
            // Hedef pozisyon (ekranın ortası)
            targetPanelY = (this.ClientSize.Height - panelContainer.Height) / 2;
            
            // Paneli görünür yap ve pozisyonla
            panelContainer.Visible = true;
            panelContainer.Location = new Point(
                (this.ClientSize.Width - panelContainer.Width) / 2,
                currentPanelY
            );
            
            dropAnimationTimer.Start();
        }

        private void DropAnimationTimer_Tick(object sender, EventArgs e)
        {
            // Yavaşlayan animasyon (easing)
            int distance = targetPanelY - currentPanelY;
            int step = Math.Max(4, distance / 8);
            
            currentPanelY += step;
            ropeLength = currentPanelY + panelContainer.Height / 2 + 50;
            
            if (currentPanelY >= targetPanelY)
            {
                currentPanelY = targetPanelY;
                ropeLength = targetPanelY + panelContainer.Height / 2 + 50;
                dropAnimationTimer.Stop();
                isAnimating = false;
                
                // Input'a odaklan
                if (Properties.Settings.Default.RememberMe && !string.IsNullOrEmpty(txtKullaniciAdi.Text))
                    txtSifre.Focus();
                else
                    txtKullaniciAdi.Focus();
            }
            
            // Panel pozisyonunu güncelle
            panelContainer.Location = new Point(
                (this.ClientSize.Width - panelContainer.Width) / 2,
                currentPanelY
            );
            
            // İpi çizmek için formu yeniden çiz
            this.Invalidate();
        }

        private void LoadGameLogos()
        {
            _gameLogos = new List<Image>();
            try
            {
                string logosPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "GameLogos");
                if (Directory.Exists(logosPath))
                {
                    string[] imageFiles = Directory.GetFiles(logosPath, "*.*");
                    foreach (string file in imageFiles)
                    {
                        string ext = Path.GetExtension(file).ToLower();
                        if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".bmp")
                        {
                            try
                            {
                                Image img = Image.FromFile(file);
                                _gameLogos.Add(img);
                            }
                            catch { }
                        }
                    }
                }
            }
            catch { }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            if (_gameLogos != null && _gameLogos.Count > 0)
            {
                // Cache'lenmiş arka plan yoksa veya boyut değiştiyse yeniden oluştur
                if (_cachedBackground == null || _cachedBackground.Width != this.Width || _cachedBackground.Height != this.Height)
                {
                    _cachedBackground?.Dispose();
                    _cachedBackground = CreateGameLogosBackground();
                }
                
                if (_cachedBackground != null)
                {
                    e.Graphics.DrawImage(_cachedBackground, 0, 0);
                }
            }
            
            // İpi çiz (panel görünürse)
            if (isPanelVisible && ropeLength > 0)
            {
                DrawRope(e.Graphics);
            }
        }

        private void DrawRope(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            
            int ropeX = this.ClientSize.Width / 2;
            int ropeStartY = 0;
            int ropeEndY = Math.Min(ropeLength, currentPanelY + 10);
            
            // İp gölgesi
            using (Pen shadowPen = new Pen(Color.FromArgb(80, 0, 0, 0), 6))
            {
                g.DrawLine(shadowPen, ropeX + 2, ropeStartY, ropeX + 2, ropeEndY + 2);
            }
            
            // Ana ip (kalın kahverengi halat)
            using (Pen ropePen = new Pen(Color.FromArgb(139, 90, 43), 4))
            {
                g.DrawLine(ropePen, ropeX, ropeStartY, ropeX, ropeEndY);
            }
            
            // İp detayları (çizgiler)
            using (Pen detailPen = new Pen(Color.FromArgb(100, 60, 30), 1))
            {
                for (int y = ropeStartY; y < ropeEndY; y += 15)
                {
                    g.DrawLine(detailPen, ropeX - 2, y, ropeX + 2, y + 8);
                }
            }
            
            // Üst bağlantı noktası (kanca)
            using (SolidBrush hookBrush = new SolidBrush(Color.FromArgb(169, 169, 169)))
            {
                g.FillEllipse(hookBrush, ropeX - 8, ropeStartY - 5, 16, 16);
            }
            using (Pen hookPen = new Pen(Color.FromArgb(105, 105, 105), 2))
            {
                g.DrawEllipse(hookPen, ropeX - 8, ropeStartY - 5, 16, 16);
            }
            
            // Alt bağlantı noktası (panele bağlı)
            if (ropeEndY > 10)
            {
                using (SolidBrush connectorBrush = new SolidBrush(Color.FromArgb(169, 169, 169)))
                {
                    g.FillEllipse(connectorBrush, ropeX - 6, ropeEndY - 3, 12, 12);
                }
            }
        }

        private Image CreateGameLogosBackground()
        {
            if (_gameLogos == null || _gameLogos.Count == 0)
                return null;

            Bitmap background = new Bitmap(this.Width, this.Height);
            using (Graphics g = Graphics.FromImage(background))
            {
                // Arka plan rengini doldur
                Color bgColor = ColorTranslator.FromHtml("#151629");
                g.Clear(bgColor);
                
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;

                // Grid hesaplama - 5 sütun x 3 satır
                int columns = 5;
                int rows = 3;
                int tileWidth = this.Width / columns;
                int tileHeight = this.Height / rows;
                int tileSize = Math.Min(tileWidth, tileHeight); // Kare için

                // Logoları ortala
                int startX = (this.Width - (columns * tileSize)) / 2;
                int startY = (this.Height - (rows * tileSize)) / 2;

                int logoIndex = 0;
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < columns; col++)
                    {
                        int x = startX + col * tileSize;
                        int y = startY + row * tileSize;

                        // Logo seç (döngüsel)
                        Image logo = _gameLogos[logoIndex % _gameLogos.Count];
                        logoIndex++;

                        // Logoyu kare olarak crop et ve çiz
                        DrawSquareCroppedImage(g, logo, x, y, tileSize);
                    }
                }

                // Üzerine yarı saydam koyu overlay (login kartı belirgin olsun)
                using (SolidBrush overlayBrush = new SolidBrush(Color.FromArgb(180, 21, 22, 41)))
                {
                    g.FillRectangle(overlayBrush, 0, 0, this.Width, this.Height);
                }

                // Kenar çizgileri (grid efekti için)
                using (Pen gridPen = new Pen(Color.FromArgb(40, 255, 255, 255), 2))
                {
                    for (int col = 0; col <= columns; col++)
                    {
                        int x = startX + col * tileSize;
                        g.DrawLine(gridPen, x, startY, x, startY + rows * tileSize);
                    }
                    for (int row = 0; row <= rows; row++)
                    {
                        int y = startY + row * tileSize;
                        g.DrawLine(gridPen, startX, y, startX + columns * tileSize, y);
                    }
                }
            }

            return background;
        }

        private void DrawSquareCroppedImage(Graphics g, Image source, int x, int y, int size)
        {
            // Resmi kare olarak ortadan crop et
            int srcSize = Math.Min(source.Width, source.Height);
            int srcX = (source.Width - srcSize) / 2;
            int srcY = (source.Height - srcSize) / 2;

            Rectangle destRect = new Rectangle(x, y, size, size);
            Rectangle srcRect = new Rectangle(srcX, srcY, srcSize, srcSize);

            g.DrawImage(source, destRect, srcRect, GraphicsUnit.Pixel);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            _cachedBackground?.Dispose();
            _cachedBackground = null;
            
            // Butonu ortala
            if (btnShowLogin != null && btnShowLogin.Visible)
            {
                btnShowLogin.Location = new Point(
                    (this.ClientSize.Width - btnShowLogin.Width) / 2,
                    (this.ClientSize.Height - btnShowLogin.Height) / 2
                );
            }
            
            // Eğer panel görünürse ve animasyon bittiyse ortala
            if (panelContainer != null && panelContainer.Visible && !isAnimating)
            {
                targetPanelY = (this.ClientSize.Height - panelContainer.Height) / 2;
                currentPanelY = targetPanelY;
                ropeLength = targetPanelY + panelContainer.Height / 2 + 50;
                panelContainer.Location = new Point(
                    (this.ClientSize.Width - panelContainer.Width) / 2,
                    targetPanelY
                );
            }
            
            this.Invalidate();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            // Temizlik
            _cachedBackground?.Dispose();
            if (_gameLogos != null)
            {
                foreach (var logo in _gameLogos)
                {
                    logo?.Dispose();
                }
                _gameLogos.Clear();
            }
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

            // Başlangıçta paneli gizle
            panelContainer.Visible = false;
            isPanelVisible = false;
            
            // "Giriş Yap" butonunu ekranın ortasına yerleştir
            btnShowLogin.Location = new Point(
                (this.ClientSize.Width - btnShowLogin.Width) / 2,
                (this.ClientSize.Height - btnShowLogin.Height) / 2
            );
            btnShowLogin.Visible = true;
            btnShowLogin.BringToFront();

            // Beni hatırla ayarı varsa kullanıcı adını doldur
            if (Properties.Settings.Default.RememberMe)
            {
                txtKullaniciAdi.Text = Properties.Settings.Default.SavedUsername;
                chkBeniHatirla.Checked = true;
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

