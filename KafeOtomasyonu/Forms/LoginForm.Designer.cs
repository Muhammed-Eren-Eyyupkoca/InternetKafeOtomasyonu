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
            // panelContainer (İç kısım - Beyaz modern kart)
            // 
            this.panelContainer.BackColor = Color.White;
            this.panelContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
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
            this.panelContainer.Size = new Size(450, 500);
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
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = ColorTranslator.FromHtml("#40E0D0");
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.Appearance.Options.UseTextOptions = true;
            this.lblBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBaslik.Location = new Point(25, 80);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new Size(400, 50);
            this.lblBaslik.TabIndex = 1;
            this.lblBaslik.Text = "İnternet Kafe Otomasyonu";
            
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.Appearance.Font = new Font("Segoe UI", 11F);
            this.lblKullaniciAdi.Appearance.ForeColor = Color.FromArgb(64, 64, 64);
            this.lblKullaniciAdi.Appearance.Options.UseFont = true;
            this.lblKullaniciAdi.Appearance.Options.UseForeColor = true;
            this.lblKullaniciAdi.Location = new Point(75, 160);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new Size(85, 20);
            this.lblKullaniciAdi.TabIndex = 2;
            this.lblKullaniciAdi.Text = "Kullanıcı Adı:";
            
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new Point(75, 185);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Properties.Appearance.Font = new Font("Segoe UI", 11F);
            this.txtKullaniciAdi.Properties.Appearance.Options.UseFont = true;
            this.txtKullaniciAdi.Properties.AutoHeight = false;
            this.txtKullaniciAdi.Size = new Size(300, 40);
            this.txtKullaniciAdi.TabIndex = 0;
            
            // 
            // lblSifre
            // 
            this.lblSifre.Appearance.Font = new Font("Segoe UI", 11F);
            this.lblSifre.Appearance.ForeColor = Color.FromArgb(64, 64, 64);
            this.lblSifre.Appearance.Options.UseFont = true;
            this.lblSifre.Appearance.Options.UseForeColor = true;
            this.lblSifre.Location = new Point(75, 240);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new Size(35, 20);
            this.lblSifre.TabIndex = 4;
            this.lblSifre.Text = "Şifre:";
            
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new Point(75, 265);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Properties.Appearance.Font = new Font("Segoe UI", 11F);
            this.txtSifre.Properties.Appearance.Options.UseFont = true;
            this.txtSifre.Properties.AutoHeight = false;
            this.txtSifre.Properties.PasswordChar = '●';
            this.txtSifre.Properties.UseSystemPasswordChar = true;
            this.txtSifre.Size = new Size(300, 40);
            this.txtSifre.TabIndex = 1;
            this.txtSifre.KeyPress += new KeyPressEventHandler(this.txtSifre_KeyPress);
            
            // 
            // chkBeniHatirla
            // 
            this.chkBeniHatirla.Location = new Point(75, 320);
            this.chkBeniHatirla.Name = "chkBeniHatirla";
            this.chkBeniHatirla.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            this.chkBeniHatirla.Properties.Appearance.Options.UseFont = true;
            this.chkBeniHatirla.Properties.Caption = "Beni Hatırla";
            this.chkBeniHatirla.Size = new Size(120, 22);
            this.chkBeniHatirla.TabIndex = 2;
            
            // 
            // chkAdminGirisi
            // 
            this.chkAdminGirisi.Location = new Point(220, 320);
            this.chkAdminGirisi.Name = "chkAdminGirisi";
            this.chkAdminGirisi.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            this.chkAdminGirisi.Properties.Appearance.ForeColor = Color.FromArgb(244, 67, 54);
            this.chkAdminGirisi.Properties.Appearance.Options.UseFont = true;
            this.chkAdminGirisi.Properties.Appearance.Options.UseForeColor = true;
            this.chkAdminGirisi.Properties.Caption = "Admin Girişi";
            this.chkAdminGirisi.Size = new Size(155, 22);
            this.chkAdminGirisi.TabIndex = 8;
            
            // 
            // btnGirisYap
            // 
            this.btnGirisYap.Appearance.BackColor = ColorTranslator.FromHtml("#40E0D0");
            this.btnGirisYap.Appearance.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnGirisYap.Appearance.ForeColor = Color.White;
            this.btnGirisYap.Appearance.Options.UseBackColor = true;
            this.btnGirisYap.Appearance.Options.UseFont = true;
            this.btnGirisYap.Appearance.Options.UseForeColor = true;
            this.btnGirisYap.Location = new Point(75, 360);
            this.btnGirisYap.Name = "btnGirisYap";
            this.btnGirisYap.Size = new Size(300, 45);
            this.btnGirisYap.TabIndex = 3;
            this.btnGirisYap.Text = "Giriş Yap";
            this.btnGirisYap.Click += new System.EventHandler(this.btnGirisYap_Click);
            
            // 
            // linkKayitOl
            // 
            this.linkKayitOl.Appearance.Font = new Font("Segoe UI", 10F);
            this.linkKayitOl.Appearance.ForeColor = ColorTranslator.FromHtml("#40E0D0");
            this.linkKayitOl.Appearance.Options.UseFont = true;
            this.linkKayitOl.Appearance.Options.UseForeColor = true;
            this.linkKayitOl.Location = new Point(125, 425);
            this.linkKayitOl.Name = "linkKayitOl";
            this.linkKayitOl.Size = new Size(200, 18);
            this.linkKayitOl.TabIndex = 4;
            this.linkKayitOl.Text = "Hesabınız yok mu? Kayıt Ol";
            this.linkKayitOl.Click += new System.EventHandler(this.linkKayitOl_Click);
            
            // 
            // LoginForm
            // 
            this.AutoScaleMode = AutoScaleMode.None;
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

