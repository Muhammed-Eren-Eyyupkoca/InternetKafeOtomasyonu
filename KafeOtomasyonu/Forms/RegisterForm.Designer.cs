using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace KafeOtomasyonu.Forms
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private PanelControl panelContainer;
        private LabelControl lblBaslik;
        private LabelControl lblAdSoyad;
        private TextEdit txtAdSoyad;
        private LabelControl lblKullaniciAdi;
        private TextEdit txtKullaniciAdi;
        private LabelControl lblEmail;
        private TextEdit txtEmail;
        private LabelControl lblTelefon;
        private TextEdit txtTelefon;
        private LabelControl lblSifre;
        private TextEdit txtSifre;
        private LabelControl lblSifreTekrar;
        private TextEdit txtSifreTekrar;
        private SimpleButton btnKayitOl;
        private HyperlinkLabelControl linkGirisYap;
        private PictureEdit pictureEdit1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelContainer = new DevExpress.XtraEditors.PanelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.lblAdSoyad = new DevExpress.XtraEditors.LabelControl();
            this.txtAdSoyad = new DevExpress.XtraEditors.TextEdit();
            this.lblKullaniciAdi = new DevExpress.XtraEditors.LabelControl();
            this.txtKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            this.lblEmail = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.lblTelefon = new DevExpress.XtraEditors.LabelControl();
            this.txtTelefon = new DevExpress.XtraEditors.TextEdit();
            this.lblSifre = new DevExpress.XtraEditors.LabelControl();
            this.txtSifre = new DevExpress.XtraEditors.TextEdit();
            this.lblSifreTekrar = new DevExpress.XtraEditors.LabelControl();
            this.txtSifreTekrar = new DevExpress.XtraEditors.TextEdit();
            this.btnKayitOl = new DevExpress.XtraEditors.SimpleButton();
            this.linkGirisYap = new DevExpress.XtraEditors.HyperlinkLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdSoyad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifreTekrar.Properties)).BeginInit();
            this.SuspendLayout();
            
            // 
            // panelContainer - Premium white card
            // 
            this.panelContainer.BackColor = Color.White;
            this.panelContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelContainer.Controls.Add(this.pictureEdit1);
            this.panelContainer.Controls.Add(this.lblBaslik);
            this.panelContainer.Controls.Add(this.lblAdSoyad);
            this.panelContainer.Controls.Add(this.txtAdSoyad);
            this.panelContainer.Controls.Add(this.lblKullaniciAdi);
            this.panelContainer.Controls.Add(this.txtKullaniciAdi);
            this.panelContainer.Controls.Add(this.lblEmail);
            this.panelContainer.Controls.Add(this.txtEmail);
            this.panelContainer.Controls.Add(this.lblTelefon);
            this.panelContainer.Controls.Add(this.txtTelefon);
            this.panelContainer.Controls.Add(this.lblSifre);
            this.panelContainer.Controls.Add(this.txtSifre);
            this.panelContainer.Controls.Add(this.lblSifreTekrar);
            this.panelContainer.Controls.Add(this.txtSifreTekrar);
            this.panelContainer.Controls.Add(this.btnKayitOl);
            this.panelContainer.Controls.Add(this.linkGirisYap);
            this.panelContainer.Anchor = AnchorStyles.None;
            this.panelContainer.Location = new Point(10, 10);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new Size(500, 700);
            this.panelContainer.TabIndex = 0;
            
            // 
            // pictureEdit1 (Logo/İkon alanı - Gizli)
            // 
            this.pictureEdit1.Location = new Point(225, 15);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new Size(1, 1);
            this.pictureEdit1.TabIndex = 0;
            this.pictureEdit1.Visible = false;
            
            // 
            // lblBaslik - Modern dark title
            // 
            this.lblBaslik.Appearance.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = ColorTranslator.FromHtml("#151629"); // Dark premium
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.Appearance.Options.UseTextOptions = true;
            this.lblBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBaslik.Location = new Point(25, 40);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new Size(450, 50);
            this.lblBaslik.TabIndex = 1;
            this.lblBaslik.Text = "Kayıt Ol";
            
            // 
            // lblAdSoyad - Modern label
            // 
            this.lblAdSoyad.Appearance.Font = new Font("Segoe UI", 10F);
            this.lblAdSoyad.Appearance.ForeColor = ColorTranslator.FromHtml("#b0b9d1"); // Secondary grey-blue
            this.lblAdSoyad.Appearance.Options.UseFont = true;
            this.lblAdSoyad.Appearance.Options.UseForeColor = true;
            this.lblAdSoyad.Location = new Point(80, 110);
            this.lblAdSoyad.Name = "lblAdSoyad";
            this.lblAdSoyad.Size = new Size(70, 20);
            this.lblAdSoyad.TabIndex = 2;
            this.lblAdSoyad.Text = "Ad Soyad";
            
            // 
            // txtAdSoyad - Modern input
            // 
            this.txtAdSoyad.Location = new Point(80, 135);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.Properties.Appearance.Font = new Font("Segoe UI", 11F);
            this.txtAdSoyad.Properties.Appearance.Options.UseFont = true;
            this.txtAdSoyad.Properties.AutoHeight = false;
            this.txtAdSoyad.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtAdSoyad.Size = new Size(340, 42);
            this.txtAdSoyad.TabIndex = 0;
            
            // 
            // lblKullaniciAdi - Modern label
            // 
            this.lblKullaniciAdi.Appearance.Font = new Font("Segoe UI", 10F);
            this.lblKullaniciAdi.Appearance.ForeColor = ColorTranslator.FromHtml("#b0b9d1"); // Secondary grey-blue
            this.lblKullaniciAdi.Appearance.Options.UseFont = true;
            this.lblKullaniciAdi.Appearance.Options.UseForeColor = true;
            this.lblKullaniciAdi.Location = new Point(80, 190);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new Size(85, 20);
            this.lblKullaniciAdi.TabIndex = 4;
            this.lblKullaniciAdi.Text = "Kullanıcı Adı";
            
            // 
            // txtKullaniciAdi - Modern input
            // 
            this.txtKullaniciAdi.Location = new Point(80, 215);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Properties.Appearance.Font = new Font("Segoe UI", 11F);
            this.txtKullaniciAdi.Properties.Appearance.Options.UseFont = true;
            this.txtKullaniciAdi.Properties.AutoHeight = false;
            this.txtKullaniciAdi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtKullaniciAdi.Size = new Size(340, 42);
            this.txtKullaniciAdi.TabIndex = 1;
            
            // 
            // lblEmail - Modern label
            // 
            this.lblEmail.Appearance.Font = new Font("Segoe UI", 10F);
            this.lblEmail.Appearance.ForeColor = ColorTranslator.FromHtml("#b0b9d1"); // Secondary grey-blue
            this.lblEmail.Appearance.Options.UseFont = true;
            this.lblEmail.Appearance.Options.UseForeColor = true;
            this.lblEmail.Location = new Point(80, 270);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(55, 20);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "E-posta";
            
            // 
            // txtEmail - Modern input
            // 
            this.txtEmail.Location = new Point(80, 295);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.Appearance.Font = new Font("Segoe UI", 11F);
            this.txtEmail.Properties.Appearance.Options.UseFont = true;
            this.txtEmail.Properties.AutoHeight = false;
            this.txtEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtEmail.Size = new Size(340, 42);
            this.txtEmail.TabIndex = 2;
            
            // 
            // lblTelefon - Modern label
            // 
            this.lblTelefon.Appearance.Font = new Font("Segoe UI", 10F);
            this.lblTelefon.Appearance.ForeColor = ColorTranslator.FromHtml("#b0b9d1"); // Secondary grey-blue
            this.lblTelefon.Appearance.Options.UseFont = true;
            this.lblTelefon.Appearance.Options.UseForeColor = true;
            this.lblTelefon.Location = new Point(80, 350);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new Size(130, 20);
            this.lblTelefon.TabIndex = 8;
            this.lblTelefon.Text = "Telefon (opsiyonel)";
            
            // 
            // txtTelefon - Modern input
            // 
            this.txtTelefon.Location = new Point(80, 375);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Properties.Appearance.Font = new Font("Segoe UI", 11F);
            this.txtTelefon.Properties.Appearance.Options.UseFont = true;
            this.txtTelefon.Properties.AutoHeight = false;
            this.txtTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtTelefon.Properties.Mask.EditMask = "0599 999 99 99";
            this.txtTelefon.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtTelefon.Size = new Size(340, 42);
            this.txtTelefon.TabIndex = 3;
            
            // 
            // lblSifre - Modern label
            // 
            this.lblSifre.Appearance.Font = new Font("Segoe UI", 10F);
            this.lblSifre.Appearance.ForeColor = ColorTranslator.FromHtml("#b0b9d1"); // Secondary grey-blue
            this.lblSifre.Appearance.Options.UseFont = true;
            this.lblSifre.Appearance.Options.UseForeColor = true;
            this.lblSifre.Location = new Point(80, 430);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new Size(35, 20);
            this.lblSifre.TabIndex = 10;
            this.lblSifre.Text = "Şifre";
            
            // 
            // txtSifre - Modern input
            // 
            this.txtSifre.Location = new Point(80, 455);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Properties.Appearance.Font = new Font("Segoe UI", 11F);
            this.txtSifre.Properties.Appearance.Options.UseFont = true;
            this.txtSifre.Properties.AutoHeight = false;
            this.txtSifre.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtSifre.Properties.PasswordChar = '●';
            this.txtSifre.Properties.UseSystemPasswordChar = true;
            this.txtSifre.Size = new Size(340, 42);
            this.txtSifre.TabIndex = 4;
            
            // 
            // lblSifreTekrar - Modern label
            // 
            this.lblSifreTekrar.Appearance.Font = new Font("Segoe UI", 10F);
            this.lblSifreTekrar.Appearance.ForeColor = ColorTranslator.FromHtml("#b0b9d1"); // Secondary grey-blue
            this.lblSifreTekrar.Appearance.Options.UseFont = true;
            this.lblSifreTekrar.Appearance.Options.UseForeColor = true;
            this.lblSifreTekrar.Location = new Point(80, 510);
            this.lblSifreTekrar.Name = "lblSifreTekrar";
            this.lblSifreTekrar.Size = new Size(80, 20);
            this.lblSifreTekrar.TabIndex = 12;
            this.lblSifreTekrar.Text = "Şifre Tekrar";
            
            // 
            // txtSifreTekrar - Modern input
            // 
            this.txtSifreTekrar.Location = new Point(80, 535);
            this.txtSifreTekrar.Name = "txtSifreTekrar";
            this.txtSifreTekrar.Properties.Appearance.Font = new Font("Segoe UI", 11F);
            this.txtSifreTekrar.Properties.Appearance.Options.UseFont = true;
            this.txtSifreTekrar.Properties.AutoHeight = false;
            this.txtSifreTekrar.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtSifreTekrar.Properties.PasswordChar = '●';
            this.txtSifreTekrar.Properties.UseSystemPasswordChar = true;
            this.txtSifreTekrar.Size = new Size(340, 42);
            this.txtSifreTekrar.TabIndex = 5;
            this.txtSifreTekrar.KeyPress += new KeyPressEventHandler(this.txtSifreTekrar_KeyPress);
            
            // 
            // btnKayitOl - Premium green button
            // 
            this.btnKayitOl.Appearance.BackColor = ColorTranslator.FromHtml("#55a586"); // Success green
            this.btnKayitOl.Appearance.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.btnKayitOl.Appearance.ForeColor = Color.White;
            this.btnKayitOl.Appearance.Options.UseBackColor = true;
            this.btnKayitOl.Appearance.Options.UseFont = true;
            this.btnKayitOl.Appearance.Options.UseForeColor = true;
            this.btnKayitOl.Location = new Point(80, 600);
            this.btnKayitOl.Name = "btnKayitOl";
            this.btnKayitOl.Size = new Size(340, 50);
            this.btnKayitOl.TabIndex = 6;
            this.btnKayitOl.Text = "Kayıt Ol";
            this.btnKayitOl.Click += new System.EventHandler(this.btnKayitOl_Click);
            
            // 
            // linkGirisYap - Modern blue link
            // 
            this.linkGirisYap.Appearance.Font = new Font("Segoe UI", 10F);
            this.linkGirisYap.Appearance.ForeColor = ColorTranslator.FromHtml("#2b80c8"); // Premium blue
            this.linkGirisYap.Appearance.Options.UseFont = true;
            this.linkGirisYap.Appearance.Options.UseForeColor = true;
            this.linkGirisYap.Location = new Point(130, 665);
            this.linkGirisYap.Name = "linkGirisYap";
            this.linkGirisYap.Size = new Size(240, 20);
            this.linkGirisYap.TabIndex = 7;
            this.linkGirisYap.Text = "Zaten hesabınız var mı? Giriş Yap";
            this.linkGirisYap.Click += new System.EventHandler(this.linkGirisYap_Click);
            
            // 
            // RegisterForm
            // 
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = ColorTranslator.FromHtml("#151629"); // Dark background
            this.ClientSize = new Size(800, 750);
            this.Controls.Add(this.panelContainer);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "RegisterForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Kayıt Ol - İnternet Kafe Otomasyonu";
            this.WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdSoyad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifreTekrar.Properties)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
