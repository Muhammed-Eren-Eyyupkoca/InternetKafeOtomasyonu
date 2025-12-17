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
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new Size(450, 550);
            
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
                        XtraMessageBox.Show(
                            $"Hesabınız bloklanmıştır!\n\nNeden: {kullanici.BlokNedeni}\n\nLütfen yönetici ile iletişime geçin.",
                            "Hesap Bloklu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
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

                    XtraMessageBox.Show(
                        $"Hoş geldiniz, {kullanici.AdSoyad}!",
                        "Başarılı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Ana forma geç (şimdilik Form1)
                    this.Hide();
                    Form1 mainForm = new Form1();
                    mainForm.FormClosed += (s, args) => this.Close();
                    mainForm.Show();
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
            // Kayıt formunu aç (Adım 3'te oluşturulacak)
            XtraMessageBox.Show("Kayıt formu yakında eklenecek!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // TODO: Adım 3'te RegisterForm oluşturulacak
            // RegisterForm registerForm = new RegisterForm();
            // registerForm.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
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
    }
}

