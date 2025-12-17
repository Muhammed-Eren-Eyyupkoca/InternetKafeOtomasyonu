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
            this.btnGirisYap = new DevExpress.XtraEditors.SimpleButton();
            this.linkKayitOl = new DevExpress.XtraEditors.HyperlinkLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBeniHatirla.Properties)).BeginInit();
            this.SuspendLayout();
            
            // 
            // panelContainer (İç kısım - Açık Gri)
            // 
            this.panelContainer.BackColor = ColorTranslator.FromHtml("#E5E5E5");
            this.panelContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelContainer.Controls.Add(this.pictureEdit1);
            this.panelContainer.Controls.Add(this.lblBaslik);
            this.panelContainer.Controls.Add(this.lblKullaniciAdi);
            this.panelContainer.Controls.Add(this.txtKullaniciAdi);
            this.panelContainer.Controls.Add(this.lblSifre);
            this.panelContainer.Controls.Add(this.txtSifre);
            this.panelContainer.Controls.Add(this.chkBeniHatirla);
            this.panelContainer.Controls.Add(this.btnGirisYap);
            this.panelContainer.Controls.Add(this.linkKayitOl);
            this.panelContainer.Location = new Point(15, 15);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new Size(420, 520);
            this.panelContainer.TabIndex = 0;
            
            // 
            // pictureEdit1 (Logo/İkon alanı)
            // 
            this.pictureEdit1.Location = new Point(160, 30);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new Size(100, 100);
            this.pictureEdit1.TabIndex = 0;
            
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = ColorTranslator.FromHtml("#40E0D0");
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.Appearance.Options.UseTextOptions = true;
            this.lblBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBaslik.Location = new Point(20, 150);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new Size(380, 40);
            this.lblBaslik.TabIndex = 1;
            this.lblBaslik.Text = "İnternet Kafe Otomasyonu";
            
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.Appearance.Font = new Font("Segoe UI", 10F);
            this.lblKullaniciAdi.Appearance.Options.UseFont = true;
            this.lblKullaniciAdi.Location = new Point(60, 220);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new Size(75, 17);
            this.lblKullaniciAdi.TabIndex = 2;
            this.lblKullaniciAdi.Text = "Kullanıcı Adı:";
            
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new Point(60, 243);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Properties.Appearance.Font = new Font("Segoe UI", 11F);
            this.txtKullaniciAdi.Properties.Appearance.Options.UseFont = true;
            this.txtKullaniciAdi.Properties.AutoHeight = false;
            this.txtKullaniciAdi.Size = new Size(300, 40);
            this.txtKullaniciAdi.TabIndex = 0;
            
            // 
            // lblSifre
            // 
            this.lblSifre.Appearance.Font = new Font("Segoe UI", 10F);
            this.lblSifre.Appearance.Options.UseFont = true;
            this.lblSifre.Location = new Point(60, 300);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new Size(32, 17);
            this.lblSifre.TabIndex = 4;
            this.lblSifre.Text = "Şifre:";
            
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new Point(60, 323);
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
            this.chkBeniHatirla.Location = new Point(60, 380);
            this.chkBeniHatirla.Name = "chkBeniHatirla";
            this.chkBeniHatirla.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            this.chkBeniHatirla.Properties.Appearance.Options.UseFont = true;
            this.chkBeniHatirla.Properties.Caption = "Beni Hatırla";
            this.chkBeniHatirla.Size = new Size(120, 20);
            this.chkBeniHatirla.TabIndex = 2;
            
            // 
            // btnGirisYap
            // 
            this.btnGirisYap.Appearance.BackColor = ColorTranslator.FromHtml("#40E0D0");
            this.btnGirisYap.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnGirisYap.Appearance.ForeColor = Color.White;
            this.btnGirisYap.Appearance.Options.UseBackColor = true;
            this.btnGirisYap.Appearance.Options.UseFont = true;
            this.btnGirisYap.Appearance.Options.UseForeColor = true;
            this.btnGirisYap.Location = new Point(60, 420);
            this.btnGirisYap.Name = "btnGirisYap";
            this.btnGirisYap.Size = new Size(300, 45);
            this.btnGirisYap.TabIndex = 3;
            this.btnGirisYap.Text = "Giriş Yap";
            this.btnGirisYap.Click += new System.EventHandler(this.btnGirisYap_Click);
            
            // 
            // linkKayitOl
            // 
            this.linkKayitOl.Appearance.Font = new Font("Segoe UI", 9F);
            this.linkKayitOl.Appearance.Options.UseFont = true;
            this.linkKayitOl.Location = new Point(145, 480);
            this.linkKayitOl.Name = "linkKayitOl";
            this.linkKayitOl.Size = new Size(130, 15);
            this.linkKayitOl.TabIndex = 4;
            this.linkKayitOl.Text = "Hesabınız yok mu? Kayıt Ol";
            this.linkKayitOl.Click += new System.EventHandler(this.linkKayitOl_Click);
            
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(450, 550);
            this.Controls.Add(this.panelContainer);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Giriş Yap - İnternet Kafe Otomasyonu";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBeniHatirla.Properties)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

