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
            // panelContainer (İç kısım - Beyaz modern kart)
            // 
            this.panelContainer.BackColor = Color.White;
            this.panelContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
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
            this.panelContainer.Size = new Size(450, 620);
            this.panelContainer.TabIndex = 0;
            
            // 
            // pictureEdit1 (Logo/İkon alanı - Gizli)
            // 
            this.pictureEdit1.Location = new Point(200, 10);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new Size(50, 50);
            this.pictureEdit1.TabIndex = 0;
            this.pictureEdit1.Visible = false;
            
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = ColorTranslator.FromHtml("#40E0D0");
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.Appearance.Options.UseTextOptions = true;
            this.lblBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBaslik.Location = new Point(25, 30);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new Size(400, 50);
            this.lblBaslik.TabIndex = 1;
            this.lblBaslik.Text = "Kayıt Ol";
            
            // 
            // lblAdSoyad
            // 
            this.lblAdSoyad.Appearance.Font = new Font("Segoe UI", 11F);
            this.lblAdSoyad.Appearance.ForeColor = Color.FromArgb(64, 64, 64);
            this.lblAdSoyad.Appearance.Options.UseFont = true;
            this.lblAdSoyad.Appearance.Options.UseForeColor = true;
            this.lblAdSoyad.Location = new Point(75, 100);
            this.lblAdSoyad.Name = "lblAdSoyad";
            this.lblAdSoyad.Size = new Size(70, 20);
            this.lblAdSoyad.TabIndex = 2;
            this.lblAdSoyad.Text = "Ad Soyad:";
            
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.Location = new Point(75, 122);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.Properties.Appearance.Font = new Font("Segoe UI", 11F);
            this.txtAdSoyad.Properties.Appearance.Options.UseFont = true;
            this.txtAdSoyad.Properties.AutoHeight = false;
            this.txtAdSoyad.Size = new Size(300, 38);
            this.txtAdSoyad.TabIndex = 0;
            
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.Appearance.Font = new Font("Segoe UI", 11F);
            this.lblKullaniciAdi.Appearance.ForeColor = Color.FromArgb(64, 64, 64);
            this.lblKullaniciAdi.Appearance.Options.UseFont = true;
            this.lblKullaniciAdi.Appearance.Options.UseForeColor = true;
            this.lblKullaniciAdi.Location = new Point(75, 170);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new Size(85, 20);
            this.lblKullaniciAdi.TabIndex = 4;
            this.lblKullaniciAdi.Text = "Kullanıcı Adı:";
            
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new Point(75, 192);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Properties.Appearance.Font = new Font("Segoe UI", 11F);
            this.txtKullaniciAdi.Properties.Appearance.Options.UseFont = true;
            this.txtKullaniciAdi.Properties.AutoHeight = false;
            this.txtKullaniciAdi.Size = new Size(300, 38);
            this.txtKullaniciAdi.TabIndex = 1;
            
            // 
            // lblEmail
            // 
            this.lblEmail.Appearance.Font = new Font("Segoe UI", 11F);
            this.lblEmail.Appearance.ForeColor = Color.FromArgb(64, 64, 64);
            this.lblEmail.Appearance.Options.UseFont = true;
            this.lblEmail.Appearance.Options.UseForeColor = true;
            this.lblEmail.Location = new Point(75, 240);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(55, 20);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "E-posta:";
            
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new Point(75, 262);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.Appearance.Font = new Font("Segoe UI", 11F);
            this.txtEmail.Properties.Appearance.Options.UseFont = true;
            this.txtEmail.Properties.AutoHeight = false;
            this.txtEmail.Size = new Size(300, 38);
            this.txtEmail.TabIndex = 2;
            
            // 
            // lblTelefon
            // 
            this.lblTelefon.Appearance.Font = new Font("Segoe UI", 11F);
            this.lblTelefon.Appearance.ForeColor = Color.FromArgb(64, 64, 64);
            this.lblTelefon.Appearance.Options.UseFont = true;
            this.lblTelefon.Appearance.Options.UseForeColor = true;
            this.lblTelefon.Location = new Point(75, 310);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new Size(130, 20);
            this.lblTelefon.TabIndex = 8;
            this.lblTelefon.Text = "Telefon (opsiyonel):";
            
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new Point(75, 332);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Properties.Appearance.Font = new Font("Segoe UI", 11F);
            this.txtTelefon.Properties.Appearance.Options.UseFont = true;
            this.txtTelefon.Properties.AutoHeight = false;
            this.txtTelefon.Properties.Mask.EditMask = "0599 999 99 99";
            this.txtTelefon.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtTelefon.Size = new Size(300, 38);
            this.txtTelefon.TabIndex = 3;
            
            // 
            // lblSifre
            // 
            this.lblSifre.Appearance.Font = new Font("Segoe UI", 11F);
            this.lblSifre.Appearance.ForeColor = Color.FromArgb(64, 64, 64);
            this.lblSifre.Appearance.Options.UseFont = true;
            this.lblSifre.Appearance.Options.UseForeColor = true;
            this.lblSifre.Location = new Point(75, 380);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new Size(35, 20);
            this.lblSifre.TabIndex = 10;
            this.lblSifre.Text = "Şifre:";
            
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new Point(75, 402);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Properties.Appearance.Font = new Font("Segoe UI", 11F);
            this.txtSifre.Properties.Appearance.Options.UseFont = true;
            this.txtSifre.Properties.AutoHeight = false;
            this.txtSifre.Properties.PasswordChar = '●';
            this.txtSifre.Properties.UseSystemPasswordChar = true;
            this.txtSifre.Size = new Size(300, 38);
            this.txtSifre.TabIndex = 4;
            
            // 
            // lblSifreTekrar
            // 
            this.lblSifreTekrar.Appearance.Font = new Font("Segoe UI", 11F);
            this.lblSifreTekrar.Appearance.ForeColor = Color.FromArgb(64, 64, 64);
            this.lblSifreTekrar.Appearance.Options.UseFont = true;
            this.lblSifreTekrar.Appearance.Options.UseForeColor = true;
            this.lblSifreTekrar.Location = new Point(75, 450);
            this.lblSifreTekrar.Name = "lblSifreTekrar";
            this.lblSifreTekrar.Size = new Size(80, 20);
            this.lblSifreTekrar.TabIndex = 12;
            this.lblSifreTekrar.Text = "Şifre Tekrar:";
            
            // 
            // txtSifreTekrar
            // 
            this.txtSifreTekrar.Location = new Point(75, 472);
            this.txtSifreTekrar.Name = "txtSifreTekrar";
            this.txtSifreTekrar.Properties.Appearance.Font = new Font("Segoe UI", 11F);
            this.txtSifreTekrar.Properties.Appearance.Options.UseFont = true;
            this.txtSifreTekrar.Properties.AutoHeight = false;
            this.txtSifreTekrar.Properties.PasswordChar = '●';
            this.txtSifreTekrar.Properties.UseSystemPasswordChar = true;
            this.txtSifreTekrar.Size = new Size(300, 38);
            this.txtSifreTekrar.TabIndex = 5;
            this.txtSifreTekrar.KeyPress += new KeyPressEventHandler(this.txtSifreTekrar_KeyPress);
            
            // 
            // btnKayitOl
            // 
            this.btnKayitOl.Appearance.BackColor = ColorTranslator.FromHtml("#40E0D0");
            this.btnKayitOl.Appearance.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnKayitOl.Appearance.ForeColor = Color.White;
            this.btnKayitOl.Appearance.Options.UseBackColor = true;
            this.btnKayitOl.Appearance.Options.UseFont = true;
            this.btnKayitOl.Appearance.Options.UseForeColor = true;
            this.btnKayitOl.Location = new Point(75, 525);
            this.btnKayitOl.Name = "btnKayitOl";
            this.btnKayitOl.Size = new Size(300, 45);
            this.btnKayitOl.TabIndex = 6;
            this.btnKayitOl.Text = "Kayıt Ol";
            this.btnKayitOl.Click += new System.EventHandler(this.btnKayitOl_Click);
            
            // 
            // linkGirisYap
            // 
            this.linkGirisYap.Appearance.Font = new Font("Segoe UI", 10F);
            this.linkGirisYap.Appearance.ForeColor = ColorTranslator.FromHtml("#40E0D0");
            this.linkGirisYap.Appearance.Options.UseFont = true;
            this.linkGirisYap.Appearance.Options.UseForeColor = true;
            this.linkGirisYap.Location = new Point(110, 585);
            this.linkGirisYap.Name = "linkGirisYap";
            this.linkGirisYap.Size = new Size(230, 18);
            this.linkGirisYap.TabIndex = 7;
            this.linkGirisYap.Text = "Zaten hesabınız var mı? Giriş Yap";
            this.linkGirisYap.Click += new System.EventHandler(this.linkGirisYap_Click);
            
            // 
            // RegisterForm
            // 
            this.AutoScaleMode = AutoScaleMode.None;
            this.ClientSize = new Size(800, 700);
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

