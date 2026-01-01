using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace KafeOtomasyonu.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private PanelControl panelContainer;
        private LabelControl lblBaslik;
        private LabelControl lblKullaniciAdi;
        private TextEdit txtKullaniciAdi;
        private LabelControl lblSifre;
        private TextEdit txtSifre;
        private CheckEdit chkBeniHatirla;
        private CheckEdit chkAdminGirisi;
        private SimpleButton btnGirisYap;
        private HyperlinkLabelControl linkKayitOl;
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
            this.lblKullaniciAdi = new DevExpress.XtraEditors.LabelControl();
            this.txtKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            this.lblSifre = new DevExpress.XtraEditors.LabelControl();
            this.txtSifre = new DevExpress.XtraEditors.TextEdit();
            this.chkBeniHatirla = new DevExpress.XtraEditors.CheckEdit();
            this.chkAdminGirisi = new DevExpress.XtraEditors.CheckEdit();
            this.btnGirisYap = new DevExpress.XtraEditors.SimpleButton();
            this.linkKayitOl = new DevExpress.XtraEditors.HyperlinkLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBeniHatirla.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAdminGirisi.Properties)).BeginInit();
            this.SuspendLayout();
            
            // 
            // panelContainer - Premium white card with shadow effect
            // 
            this.panelContainer.BackColor = Color.White;
            this.panelContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelContainer.Controls.Add(this.pictureEdit1);
            this.panelContainer.Controls.Add(this.lblBaslik);
            this.panelContainer.Controls.Add(this.lblKullaniciAdi);
            this.panelContainer.Controls.Add(this.txtKullaniciAdi);
            this.panelContainer.Controls.Add(this.lblSifre);
            this.panelContainer.Controls.Add(this.txtSifre);
            this.panelContainer.Controls.Add(this.chkBeniHatirla);
            this.panelContainer.Controls.Add(this.chkAdminGirisi);
            this.panelContainer.Controls.Add(this.btnGirisYap);
            this.panelContainer.Controls.Add(this.linkKayitOl);
            this.panelContainer.Anchor = AnchorStyles.None;
            this.panelContainer.Location = new Point(10, 10);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new Size(500, 550);
            this.panelContainer.TabIndex = 0;
            
            // 
            // pictureEdit1 (Logo/İkon alanı - Gizli)
            // 
            this.pictureEdit1.Location = new Point(175, 20);
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
            // lblBaslik - Premium dark title
            // 
            this.lblBaslik.Appearance.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = ColorTranslator.FromHtml("#151629"); // Dark premium
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.Appearance.Options.UseTextOptions = true;
            this.lblBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBaslik.Location = new Point(25, 50);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new Size(450, 60);
            this.lblBaslik.TabIndex = 1;
            this.lblBaslik.Text = "İnternet Kafe";
            
            // 
            // lblKullaniciAdi - Modern label
            // 
            this.lblKullaniciAdi.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.lblKullaniciAdi.Appearance.ForeColor = ColorTranslator.FromHtml("#b0b9d1"); // Secondary grey-blue
            this.lblKullaniciAdi.Appearance.Options.UseFont = true;
            this.lblKullaniciAdi.Appearance.Options.UseForeColor = true;
            this.lblKullaniciAdi.Location = new Point(80, 150);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new Size(85, 20);
            this.lblKullaniciAdi.TabIndex = 2;
            this.lblKullaniciAdi.Text = "Kullanıcı Adı";
            
            // 
            // txtKullaniciAdi - Modern input with border
            // 
            this.txtKullaniciAdi.Location = new Point(80, 175);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Properties.Appearance.Font = new Font("Segoe UI", 12F);
            this.txtKullaniciAdi.Properties.Appearance.Options.UseFont = true;
            this.txtKullaniciAdi.Properties.AutoHeight = false;
            this.txtKullaniciAdi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtKullaniciAdi.Size = new Size(340, 45);
            this.txtKullaniciAdi.TabIndex = 0;
            
            // 
            // lblSifre - Modern label
            // 
            this.lblSifre.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.lblSifre.Appearance.ForeColor = ColorTranslator.FromHtml("#b0b9d1"); // Secondary grey-blue
            this.lblSifre.Appearance.Options.UseFont = true;
            this.lblSifre.Appearance.Options.UseForeColor = true;
            this.lblSifre.Location = new Point(80, 240);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new Size(35, 20);
            this.lblSifre.TabIndex = 4;
            this.lblSifre.Text = "Şifre";
            
            // 
            // txtSifre - Modern input with border
            // 
            this.txtSifre.Location = new Point(80, 265);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Properties.Appearance.Font = new Font("Segoe UI", 12F);
            this.txtSifre.Properties.Appearance.Options.UseFont = true;
            this.txtSifre.Properties.AutoHeight = false;
            this.txtSifre.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtSifre.Properties.PasswordChar = '●';
            this.txtSifre.Properties.UseSystemPasswordChar = true;
            this.txtSifre.Size = new Size(340, 45);
            this.txtSifre.TabIndex = 1;
            this.txtSifre.KeyPress += new KeyPressEventHandler(this.txtSifre_KeyPress);
            
            // 
            // chkBeniHatirla - Modern checkbox
            // 
            this.chkBeniHatirla.Location = new Point(80, 330);
            this.chkBeniHatirla.Name = "chkBeniHatirla";
            this.chkBeniHatirla.Properties.Appearance.Font = new Font("Segoe UI", 9.5F);
            this.chkBeniHatirla.Properties.Appearance.ForeColor = ColorTranslator.FromHtml("#151629");
            this.chkBeniHatirla.Properties.Appearance.Options.UseFont = true;
            this.chkBeniHatirla.Properties.Appearance.Options.UseForeColor = true;
            this.chkBeniHatirla.Properties.Caption = "Beni Hatırla";
            this.chkBeniHatirla.Size = new Size(120, 22);
            this.chkBeniHatirla.TabIndex = 2;
            
            // 
            // chkAdminGirisi - Warning checkbox
            // 
            this.chkAdminGirisi.Location = new Point(280, 330);
            this.chkAdminGirisi.Name = "chkAdminGirisi";
            this.chkAdminGirisi.Properties.Appearance.Font = new Font("Segoe UI", 9.5F);
            this.chkAdminGirisi.Properties.Appearance.ForeColor = ColorTranslator.FromHtml("#c82b6d"); // Error color
            this.chkAdminGirisi.Properties.Appearance.Options.UseFont = true;
            this.chkAdminGirisi.Properties.Appearance.Options.UseForeColor = true;
            this.chkAdminGirisi.Properties.Caption = "Admin Girişi";
            this.chkAdminGirisi.Size = new Size(140, 22);
            this.chkAdminGirisi.TabIndex = 8;
            
            // 
            // btnGirisYap - Premium blue gradient button
            // 
            this.btnGirisYap.Appearance.BackColor = ColorTranslator.FromHtml("#2b80c8"); // Premium blue
            this.btnGirisYap.Appearance.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.btnGirisYap.Appearance.ForeColor = Color.White;
            this.btnGirisYap.Appearance.Options.UseBackColor = true;
            this.btnGirisYap.Appearance.Options.UseFont = true;
            this.btnGirisYap.Appearance.Options.UseForeColor = true;
            this.btnGirisYap.Location = new Point(80, 380);
            this.btnGirisYap.Name = "btnGirisYap";
            this.btnGirisYap.Size = new Size(340, 50);
            this.btnGirisYap.TabIndex = 3;
            this.btnGirisYap.Text = "Giriş Yap";
            this.btnGirisYap.Click += new System.EventHandler(this.btnGirisYap_Click);
            
            // 
            // linkKayitOl - Modern blue link
            // 
            this.linkKayitOl.Appearance.Font = new Font("Segoe UI", 10F);
            this.linkKayitOl.Appearance.ForeColor = ColorTranslator.FromHtml("#2b80c8"); // Premium blue
            this.linkKayitOl.Appearance.Options.UseFont = true;
            this.linkKayitOl.Appearance.Options.UseForeColor = true;
            this.linkKayitOl.Location = new Point(140, 460);
            this.linkKayitOl.Name = "linkKayitOl";
            this.linkKayitOl.Size = new Size(220, 20);
            this.linkKayitOl.TabIndex = 4;
            this.linkKayitOl.Text = "Hesabınız yok mu? Kayıt Ol";
            this.linkKayitOl.Click += new System.EventHandler(this.linkKayitOl_Click);
            
            // 
            // LoginForm - Dark premium background
            // 
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = ColorTranslator.FromHtml("#151629"); // Dark premium background
            this.ClientSize = new Size(800, 600);
            this.Controls.Add(this.panelContainer);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "LoginForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Giriş Yap - İnternet Kafe Otomasyonu";
            this.WindowState = FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBeniHatirla.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAdminGirisi.Properties)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

