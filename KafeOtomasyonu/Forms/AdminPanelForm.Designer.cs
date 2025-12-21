namespace KafeOtomasyonu.Forms
{
    partial class AdminPanelForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelUst = new System.Windows.Forms.Panel();
            this.lblHosgeldin = new DevExpress.XtraEditors.LabelControl();
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.btnCikis = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageKullanicilar = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlKullanicilar = new DevExpress.XtraGrid.GridControl();
            this.gridViewKullanicilar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnBlokla = new DevExpress.XtraEditors.SimpleButton();
            this.btnBloktanCikar = new DevExpress.XtraEditors.SimpleButton();
            this.btnYenileKullanici = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPageMasalar = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlMasalar = new DevExpress.XtraGrid.GridControl();
            this.gridViewMasalar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnDurumDegistir = new DevExpress.XtraEditors.SimpleButton();
            this.btnYenileMasa = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPageRandevular = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlRandevular = new DevExpress.XtraGrid.GridControl();
            this.gridViewRandevular = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnOnayRandevu = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptalRandevu = new DevExpress.XtraEditors.SimpleButton();
            this.btnYenileRandevu = new DevExpress.XtraEditors.SimpleButton();
            this.panelUst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPageKullanicilar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlKullanicilar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewKullanicilar)).BeginInit();
            this.xtraTabPageMasalar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMasalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMasalar)).BeginInit();
            this.xtraTabPageRandevular.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRandevular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRandevular)).BeginInit();
            this.SuspendLayout();
            // 
            // panelUst
            // 
            this.panelUst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panelUst.Controls.Add(this.btnCikis);
            this.panelUst.Controls.Add(this.lblHosgeldin);
            this.panelUst.Controls.Add(this.lblBaslik);
            this.panelUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUst.Location = new System.Drawing.Point(0, 0);
            this.panelUst.Name = "panelUst";
            this.panelUst.Size = new System.Drawing.Size(1200, 70);
            this.panelUst.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.Location = new System.Drawing.Point(20, 10);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(251, 32);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "ADMIN YÖNETİM PANELİ";
            // 
            // lblHosgeldin
            // 
            this.lblHosgeldin.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHosgeldin.Appearance.ForeColor = System.Drawing.Color.LightGray;
            this.lblHosgeldin.Appearance.Options.UseFont = true;
            this.lblHosgeldin.Appearance.Options.UseForeColor = true;
            this.lblHosgeldin.Location = new System.Drawing.Point(20, 45);
            this.lblHosgeldin.Name = "lblHosgeldin";
            this.lblHosgeldin.Size = new System.Drawing.Size(120, 19);
            this.lblHosgeldin.TabIndex = 1;
            this.lblHosgeldin.Text = "Hoş geldiniz, Admin";
            // 
            // btnCikis
            // 
            this.btnCikis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCikis.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnCikis.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCikis.Appearance.Options.UseBackColor = true;
            this.btnCikis.Appearance.Options.UseFont = true;
            this.btnCikis.Location = new System.Drawing.Point(1080, 20);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(100, 35);
            this.btnCikis.TabIndex = 2;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 70);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPageKullanicilar;
            this.xtraTabControl1.Size = new System.Drawing.Size(1200, 630);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageKullanicilar,
            this.xtraTabPageMasalar,
            this.xtraTabPageRandevular});
            // 
            // xtraTabPageKullanicilar
            // 
            this.xtraTabPageKullanicilar.Controls.Add(this.btnYenileKullanici);
            this.xtraTabPageKullanicilar.Controls.Add(this.btnBloktanCikar);
            this.xtraTabPageKullanicilar.Controls.Add(this.btnBlokla);
            this.xtraTabPageKullanicilar.Controls.Add(this.gridControlKullanicilar);
            this.xtraTabPageKullanicilar.Name = "xtraTabPageKullanicilar";
            this.xtraTabPageKullanicilar.Size = new System.Drawing.Size(1198, 602);
            this.xtraTabPageKullanicilar.Text = "Kullanıcılar";
            // 
            // gridControlKullanicilar
            // 
            this.gridControlKullanicilar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlKullanicilar.Location = new System.Drawing.Point(10, 50);
            this.gridControlKullanicilar.MainView = this.gridViewKullanicilar;
            this.gridControlKullanicilar.Name = "gridControlKullanicilar";
            this.gridControlKullanicilar.Size = new System.Drawing.Size(1178, 542);
            this.gridControlKullanicilar.TabIndex = 0;
            this.gridControlKullanicilar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewKullanicilar});
            // 
            // gridViewKullanicilar
            // 
            this.gridViewKullanicilar.GridControl = this.gridControlKullanicilar;
            this.gridViewKullanicilar.Name = "gridViewKullanicilar";
            this.gridViewKullanicilar.OptionsBehavior.Editable = false;
            this.gridViewKullanicilar.OptionsView.ShowAutoFilterRow = true;
            // 
            // btnBlokla
            // 
            this.btnBlokla.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnBlokla.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBlokla.Appearance.Options.UseBackColor = true;
            this.btnBlokla.Appearance.Options.UseFont = true;
            this.btnBlokla.Location = new System.Drawing.Point(10, 10);
            this.btnBlokla.Name = "btnBlokla";
            this.btnBlokla.Size = new System.Drawing.Size(120, 30);
            this.btnBlokla.TabIndex = 1;
            this.btnBlokla.Text = "Blokla";
            this.btnBlokla.Click += new System.EventHandler(this.btnBlokla_Click);
            // 
            // btnBloktanCikar
            // 
            this.btnBloktanCikar.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnBloktanCikar.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBloktanCikar.Appearance.Options.UseBackColor = true;
            this.btnBloktanCikar.Appearance.Options.UseFont = true;
            this.btnBloktanCikar.Location = new System.Drawing.Point(140, 10);
            this.btnBloktanCikar.Name = "btnBloktanCikar";
            this.btnBloktanCikar.Size = new System.Drawing.Size(120, 30);
            this.btnBloktanCikar.TabIndex = 2;
            this.btnBloktanCikar.Text = "Bloktan Çıkar";
            this.btnBloktanCikar.Click += new System.EventHandler(this.btnBloktanCikar_Click);
            // 
            // btnYenileKullanici
            // 
            this.btnYenileKullanici.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnYenileKullanici.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnYenileKullanici.Appearance.Options.UseBackColor = true;
            this.btnYenileKullanici.Appearance.Options.UseFont = true;
            this.btnYenileKullanici.Location = new System.Drawing.Point(270, 10);
            this.btnYenileKullanici.Name = "btnYenileKullanici";
            this.btnYenileKullanici.Size = new System.Drawing.Size(100, 30);
            this.btnYenileKullanici.TabIndex = 3;
            this.btnYenileKullanici.Text = "Yenile";
            this.btnYenileKullanici.Click += new System.EventHandler(this.btnYenileKullanici_Click);
            // 
            // xtraTabPageMasalar
            // 
            this.xtraTabPageMasalar.Controls.Add(this.btnYenileMasa);
            this.xtraTabPageMasalar.Controls.Add(this.btnDurumDegistir);
            this.xtraTabPageMasalar.Controls.Add(this.gridControlMasalar);
            this.xtraTabPageMasalar.Name = "xtraTabPageMasalar";
            this.xtraTabPageMasalar.Size = new System.Drawing.Size(1198, 602);
            this.xtraTabPageMasalar.Text = "Masalar";
            // 
            // gridControlMasalar
            // 
            this.gridControlMasalar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlMasalar.Location = new System.Drawing.Point(10, 50);
            this.gridControlMasalar.MainView = this.gridViewMasalar;
            this.gridControlMasalar.Name = "gridControlMasalar";
            this.gridControlMasalar.Size = new System.Drawing.Size(1178, 542);
            this.gridControlMasalar.TabIndex = 0;
            this.gridControlMasalar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMasalar});
            // 
            // gridViewMasalar
            // 
            this.gridViewMasalar.GridControl = this.gridControlMasalar;
            this.gridViewMasalar.Name = "gridViewMasalar";
            this.gridViewMasalar.OptionsBehavior.Editable = false;
            this.gridViewMasalar.OptionsView.ShowAutoFilterRow = true;
            // 
            // btnDurumDegistir
            // 
            this.btnDurumDegistir.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnDurumDegistir.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDurumDegistir.Appearance.Options.UseBackColor = true;
            this.btnDurumDegistir.Appearance.Options.UseFont = true;
            this.btnDurumDegistir.Location = new System.Drawing.Point(10, 10);
            this.btnDurumDegistir.Name = "btnDurumDegistir";
            this.btnDurumDegistir.Size = new System.Drawing.Size(140, 30);
            this.btnDurumDegistir.TabIndex = 1;
            this.btnDurumDegistir.Text = "Durum Değiştir";
            this.btnDurumDegistir.Click += new System.EventHandler(this.btnDurumDegistir_Click);
            // 
            // btnYenileMasa
            // 
            this.btnYenileMasa.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnYenileMasa.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnYenileMasa.Appearance.Options.UseBackColor = true;
            this.btnYenileMasa.Appearance.Options.UseFont = true;
            this.btnYenileMasa.Location = new System.Drawing.Point(160, 10);
            this.btnYenileMasa.Name = "btnYenileMasa";
            this.btnYenileMasa.Size = new System.Drawing.Size(100, 30);
            this.btnYenileMasa.TabIndex = 2;
            this.btnYenileMasa.Text = "Yenile";
            this.btnYenileMasa.Click += new System.EventHandler(this.btnYenileMasa_Click);
            // 
            // xtraTabPageRandevular
            // 
            this.xtraTabPageRandevular.Controls.Add(this.btnYenileRandevu);
            this.xtraTabPageRandevular.Controls.Add(this.btnIptalRandevu);
            this.xtraTabPageRandevular.Controls.Add(this.btnOnayRandevu);
            this.xtraTabPageRandevular.Controls.Add(this.gridControlRandevular);
            this.xtraTabPageRandevular.Name = "xtraTabPageRandevular";
            this.xtraTabPageRandevular.Size = new System.Drawing.Size(1198, 602);
            this.xtraTabPageRandevular.Text = "Randevular";
            // 
            // gridControlRandevular
            // 
            this.gridControlRandevular.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlRandevular.Location = new System.Drawing.Point(10, 50);
            this.gridControlRandevular.MainView = this.gridViewRandevular;
            this.gridControlRandevular.Name = "gridControlRandevular";
            this.gridControlRandevular.Size = new System.Drawing.Size(1178, 542);
            this.gridControlRandevular.TabIndex = 0;
            this.gridControlRandevular.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRandevular});
            // 
            // gridViewRandevular
            // 
            this.gridViewRandevular.GridControl = this.gridControlRandevular;
            this.gridViewRandevular.Name = "gridViewRandevular";
            this.gridViewRandevular.OptionsBehavior.Editable = false;
            this.gridViewRandevular.OptionsView.ShowAutoFilterRow = true;
            // 
            // btnOnayRandevu
            // 
            this.btnOnayRandevu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnOnayRandevu.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOnayRandevu.Appearance.Options.UseBackColor = true;
            this.btnOnayRandevu.Appearance.Options.UseFont = true;
            this.btnOnayRandevu.Location = new System.Drawing.Point(10, 10);
            this.btnOnayRandevu.Name = "btnOnayRandevu";
            this.btnOnayRandevu.Size = new System.Drawing.Size(100, 30);
            this.btnOnayRandevu.TabIndex = 1;
            this.btnOnayRandevu.Text = "Onayla";
            this.btnOnayRandevu.Click += new System.EventHandler(this.btnOnayRandevu_Click);
            // 
            // btnIptalRandevu
            // 
            this.btnIptalRandevu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnIptalRandevu.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnIptalRandevu.Appearance.Options.UseBackColor = true;
            this.btnIptalRandevu.Appearance.Options.UseFont = true;
            this.btnIptalRandevu.Location = new System.Drawing.Point(120, 10);
            this.btnIptalRandevu.Name = "btnIptalRandevu";
            this.btnIptalRandevu.Size = new System.Drawing.Size(100, 30);
            this.btnIptalRandevu.TabIndex = 2;
            this.btnIptalRandevu.Text = "İptal Et";
            this.btnIptalRandevu.Click += new System.EventHandler(this.btnIptalRandevu_Click);
            // 
            // btnYenileRandevu
            // 
            this.btnYenileRandevu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnYenileRandevu.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnYenileRandevu.Appearance.Options.UseBackColor = true;
            this.btnYenileRandevu.Appearance.Options.UseFont = true;
            this.btnYenileRandevu.Location = new System.Drawing.Point(230, 10);
            this.btnYenileRandevu.Name = "btnYenileRandevu";
            this.btnYenileRandevu.Size = new System.Drawing.Size(100, 30);
            this.btnYenileRandevu.TabIndex = 3;
            this.btnYenileRandevu.Text = "Yenile";
            this.btnYenileRandevu.Click += new System.EventHandler(this.btnYenileRandevu_Click);
            // 
            // AdminPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.panelUst);
            this.Name = "AdminPanelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Panel - Kafe Gaming";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminPanelForm_Load);
            this.panelUst.ResumeLayout(false);
            this.panelUst.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPageKullanicilar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlKullanicilar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewKullanicilar)).EndInit();
            this.xtraTabPageMasalar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMasalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMasalar)).EndInit();
            this.xtraTabPageRandevular.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRandevular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRandevular)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelUst;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.LabelControl lblHosgeldin;
        private DevExpress.XtraEditors.SimpleButton btnCikis;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageKullanicilar;
        private DevExpress.XtraGrid.GridControl gridControlKullanicilar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewKullanicilar;
        private DevExpress.XtraEditors.SimpleButton btnBlokla;
        private DevExpress.XtraEditors.SimpleButton btnBloktanCikar;
        private DevExpress.XtraEditors.SimpleButton btnYenileKullanici;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageMasalar;
        private DevExpress.XtraGrid.GridControl gridControlMasalar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMasalar;
        private DevExpress.XtraEditors.SimpleButton btnDurumDegistir;
        private DevExpress.XtraEditors.SimpleButton btnYenileMasa;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageRandevular;
        private DevExpress.XtraGrid.GridControl gridControlRandevular;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRandevular;
        private DevExpress.XtraEditors.SimpleButton btnOnayRandevu;
        private DevExpress.XtraEditors.SimpleButton btnIptalRandevu;
        private DevExpress.XtraEditors.SimpleButton btnYenileRandevu;
    }
}

