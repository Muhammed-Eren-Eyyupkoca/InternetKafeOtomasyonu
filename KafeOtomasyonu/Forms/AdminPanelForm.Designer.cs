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
            
            // Dashboard Kartları
            this.panelDashboard = new System.Windows.Forms.Panel();
            this.cardKullanici = new System.Windows.Forms.Panel();
            this.lblKullaniciSayi = new System.Windows.Forms.Label();
            this.lblKullaniciBaslik = new System.Windows.Forms.Label();
            this.cardMasa = new System.Windows.Forms.Panel();
            this.lblMasaSayi = new System.Windows.Forms.Label();
            this.lblMasaBaslik = new System.Windows.Forms.Label();
            this.cardRandevu = new System.Windows.Forms.Panel();
            this.lblRandevuSayi = new System.Windows.Forms.Label();
            this.lblRandevuBaslik = new System.Windows.Forms.Label();
            this.cardGelir = new System.Windows.Forms.Panel();
            this.lblGelirSayi = new System.Windows.Forms.Label();
            this.lblGelirBaslik = new System.Windows.Forms.Label();
            
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
            this.panelDashboard.SuspendLayout();
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
            // panelUst - Modern dark header
            // 
            this.panelUst.BackColor = System.Drawing.ColorTranslator.FromHtml("#151629");
            this.panelUst.Controls.Add(this.btnCikis);
            this.panelUst.Controls.Add(this.lblHosgeldin);
            this.panelUst.Controls.Add(this.lblBaslik);
            this.panelUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUst.Location = new System.Drawing.Point(0, 0);
            this.panelUst.Name = "panelUst";
            this.panelUst.Size = new System.Drawing.Size(1400, 80);
            this.panelUst.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.Location = new System.Drawing.Point(25, 15);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(300, 37);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "🛡️ Admin Paneli";
            // 
            // lblHosgeldin
            // 
            this.lblHosgeldin.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHosgeldin.Appearance.ForeColor = System.Drawing.ColorTranslator.FromHtml("#b0b9d1");
            this.lblHosgeldin.Appearance.Options.UseFont = true;
            this.lblHosgeldin.Appearance.Options.UseForeColor = true;
            this.lblHosgeldin.Location = new System.Drawing.Point(25, 52);
            this.lblHosgeldin.Name = "lblHosgeldin";
            this.lblHosgeldin.Size = new System.Drawing.Size(120, 19);
            this.lblHosgeldin.TabIndex = 1;
            this.lblHosgeldin.Text = "Hoş geldiniz, Admin";
            // 
            // btnCikis
            // 
            this.btnCikis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCikis.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#c82b6d");
            this.btnCikis.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCikis.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCikis.Appearance.Options.UseBackColor = true;
            this.btnCikis.Appearance.Options.UseFont = true;
            this.btnCikis.Appearance.Options.UseForeColor = true;
            this.btnCikis.Location = new System.Drawing.Point(1270, 22);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(110, 40);
            this.btnCikis.TabIndex = 2;
            this.btnCikis.Text = "🚪 Çıkış";
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // panelDashboard - Dashboard kartları paneli
            // 
            this.panelDashboard.BackColor = System.Drawing.ColorTranslator.FromHtml("#1a1b2e");
            this.panelDashboard.Controls.Add(this.cardKullanici);
            this.panelDashboard.Controls.Add(this.cardMasa);
            this.panelDashboard.Controls.Add(this.cardRandevu);
            this.panelDashboard.Controls.Add(this.cardGelir);
            this.panelDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDashboard.Location = new System.Drawing.Point(0, 80);
            this.panelDashboard.Name = "panelDashboard";
            this.panelDashboard.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelDashboard.Size = new System.Drawing.Size(1400, 130);
            this.panelDashboard.TabIndex = 2;
            // 
            // cardKullanici - Kullanıcı kartı
            // 
            this.cardKullanici.BackColor = System.Drawing.ColorTranslator.FromHtml("#2b80c8");
            this.cardKullanici.Location = new System.Drawing.Point(25, 15);
            this.cardKullanici.Name = "cardKullanici";
            this.cardKullanici.Size = new System.Drawing.Size(320, 100);
            this.cardKullanici.TabIndex = 0;
            // 
            // lblKullaniciSayi
            // 
            this.lblKullaniciSayi.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblKullaniciSayi.ForeColor = System.Drawing.Color.White;
            this.lblKullaniciSayi.Location = new System.Drawing.Point(15, 10);
            this.lblKullaniciSayi.Name = "lblKullaniciSayi";
            this.lblKullaniciSayi.Size = new System.Drawing.Size(150, 50);
            this.lblKullaniciSayi.Text = "0";
            this.cardKullanici.Controls.Add(this.lblKullaniciSayi);
            // 
            // lblKullaniciBaslik
            // 
            this.lblKullaniciBaslik.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblKullaniciBaslik.ForeColor = System.Drawing.Color.White;
            this.lblKullaniciBaslik.Location = new System.Drawing.Point(15, 65);
            this.lblKullaniciBaslik.Name = "lblKullaniciBaslik";
            this.lblKullaniciBaslik.Size = new System.Drawing.Size(200, 25);
            this.lblKullaniciBaslik.Text = "👥 Toplam Kullanıcı";
            this.cardKullanici.Controls.Add(this.lblKullaniciBaslik);
            // 
            // cardMasa - Masa kartı
            // 
            this.cardMasa.BackColor = System.Drawing.ColorTranslator.FromHtml("#55a586");
            this.cardMasa.Location = new System.Drawing.Point(365, 15);
            this.cardMasa.Name = "cardMasa";
            this.cardMasa.Size = new System.Drawing.Size(320, 100);
            this.cardMasa.TabIndex = 1;
            // 
            // lblMasaSayi
            // 
            this.lblMasaSayi.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblMasaSayi.ForeColor = System.Drawing.Color.White;
            this.lblMasaSayi.Location = new System.Drawing.Point(15, 10);
            this.lblMasaSayi.Name = "lblMasaSayi";
            this.lblMasaSayi.Size = new System.Drawing.Size(150, 50);
            this.lblMasaSayi.Text = "0";
            this.cardMasa.Controls.Add(this.lblMasaSayi);
            // 
            // lblMasaBaslik
            // 
            this.lblMasaBaslik.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblMasaBaslik.ForeColor = System.Drawing.Color.White;
            this.lblMasaBaslik.Location = new System.Drawing.Point(15, 65);
            this.lblMasaBaslik.Name = "lblMasaBaslik";
            this.lblMasaBaslik.Size = new System.Drawing.Size(200, 25);
            this.lblMasaBaslik.Text = "🖥️ Aktif Masa";
            this.cardMasa.Controls.Add(this.lblMasaBaslik);
            // 
            // cardRandevu - Randevu kartı
            // 
            this.cardRandevu.BackColor = System.Drawing.ColorTranslator.FromHtml("#ceb951");
            this.cardRandevu.Location = new System.Drawing.Point(705, 15);
            this.cardRandevu.Name = "cardRandevu";
            this.cardRandevu.Size = new System.Drawing.Size(320, 100);
            this.cardRandevu.TabIndex = 2;
            // 
            // lblRandevuSayi
            // 
            this.lblRandevuSayi.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblRandevuSayi.ForeColor = System.Drawing.Color.White;
            this.lblRandevuSayi.Location = new System.Drawing.Point(15, 10);
            this.lblRandevuSayi.Name = "lblRandevuSayi";
            this.lblRandevuSayi.Size = new System.Drawing.Size(150, 50);
            this.lblRandevuSayi.Text = "0";
            this.cardRandevu.Controls.Add(this.lblRandevuSayi);
            // 
            // lblRandevuBaslik
            // 
            this.lblRandevuBaslik.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblRandevuBaslik.ForeColor = System.Drawing.Color.White;
            this.lblRandevuBaslik.Location = new System.Drawing.Point(15, 65);
            this.lblRandevuBaslik.Name = "lblRandevuBaslik";
            this.lblRandevuBaslik.Size = new System.Drawing.Size(200, 25);
            this.lblRandevuBaslik.Text = "📅 Bugünkü Randevu";
            this.cardRandevu.Controls.Add(this.lblRandevuBaslik);
            // 
            // cardGelir - Gelir kartı
            // 
            this.cardGelir.BackColor = System.Drawing.ColorTranslator.FromHtml("#8a2be2");
            this.cardGelir.Location = new System.Drawing.Point(1045, 15);
            this.cardGelir.Name = "cardGelir";
            this.cardGelir.Size = new System.Drawing.Size(320, 100);
            this.cardGelir.TabIndex = 3;
            // 
            // lblGelirSayi
            // 
            this.lblGelirSayi.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblGelirSayi.ForeColor = System.Drawing.Color.White;
            this.lblGelirSayi.Location = new System.Drawing.Point(15, 10);
            this.lblGelirSayi.Name = "lblGelirSayi";
            this.lblGelirSayi.Size = new System.Drawing.Size(200, 50);
            this.lblGelirSayi.Text = "₺0";
            this.cardGelir.Controls.Add(this.lblGelirSayi);
            // 
            // lblGelirBaslik
            // 
            this.lblGelirBaslik.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblGelirBaslik.ForeColor = System.Drawing.Color.White;
            this.lblGelirBaslik.Location = new System.Drawing.Point(15, 65);
            this.lblGelirBaslik.Name = "lblGelirBaslik";
            this.lblGelirBaslik.Size = new System.Drawing.Size(200, 25);
            this.lblGelirBaslik.Text = "💰 Bugünkü Gelir";
            this.cardGelir.Controls.Add(this.lblGelirBaslik);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 210);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPageKullanicilar;
            this.xtraTabControl1.Size = new System.Drawing.Size(1400, 590);
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
            this.xtraTabPageKullanicilar.Size = new System.Drawing.Size(1398, 562);
            this.xtraTabPageKullanicilar.Text = "👥 Kullanıcılar";
            // 
            // gridControlKullanicilar
            // 
            this.gridControlKullanicilar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlKullanicilar.Location = new System.Drawing.Point(10, 60);
            this.gridControlKullanicilar.MainView = this.gridViewKullanicilar;
            this.gridControlKullanicilar.Name = "gridControlKullanicilar";
            this.gridControlKullanicilar.Size = new System.Drawing.Size(1378, 492);
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
            this.btnBlokla.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#c82b6d");
            this.btnBlokla.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBlokla.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnBlokla.Appearance.Options.UseBackColor = true;
            this.btnBlokla.Appearance.Options.UseFont = true;
            this.btnBlokla.Appearance.Options.UseForeColor = true;
            this.btnBlokla.Location = new System.Drawing.Point(10, 15);
            this.btnBlokla.Name = "btnBlokla";
            this.btnBlokla.Size = new System.Drawing.Size(140, 38);
            this.btnBlokla.TabIndex = 1;
            this.btnBlokla.Text = "🚫 Blokla";
            this.btnBlokla.Click += new System.EventHandler(this.btnBlokla_Click);
            // 
            // btnBloktanCikar
            // 
            this.btnBloktanCikar.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#55a586");
            this.btnBloktanCikar.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBloktanCikar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnBloktanCikar.Appearance.Options.UseBackColor = true;
            this.btnBloktanCikar.Appearance.Options.UseFont = true;
            this.btnBloktanCikar.Appearance.Options.UseForeColor = true;
            this.btnBloktanCikar.Location = new System.Drawing.Point(160, 15);
            this.btnBloktanCikar.Name = "btnBloktanCikar";
            this.btnBloktanCikar.Size = new System.Drawing.Size(160, 38);
            this.btnBloktanCikar.TabIndex = 2;
            this.btnBloktanCikar.Text = "✅ Bloktan Çıkar";
            this.btnBloktanCikar.Click += new System.EventHandler(this.btnBloktanCikar_Click);
            // 
            // btnYenileKullanici
            // 
            this.btnYenileKullanici.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2b80c8");
            this.btnYenileKullanici.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnYenileKullanici.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnYenileKullanici.Appearance.Options.UseBackColor = true;
            this.btnYenileKullanici.Appearance.Options.UseFont = true;
            this.btnYenileKullanici.Appearance.Options.UseForeColor = true;
            this.btnYenileKullanici.Location = new System.Drawing.Point(330, 15);
            this.btnYenileKullanici.Name = "btnYenileKullanici";
            this.btnYenileKullanici.Size = new System.Drawing.Size(120, 38);
            this.btnYenileKullanici.TabIndex = 3;
            this.btnYenileKullanici.Text = "🔄 Yenile";
            this.btnYenileKullanici.Click += new System.EventHandler(this.btnYenileKullanici_Click);
            // 
            // xtraTabPageMasalar
            // 
            this.xtraTabPageMasalar.Controls.Add(this.btnYenileMasa);
            this.xtraTabPageMasalar.Controls.Add(this.btnDurumDegistir);
            this.xtraTabPageMasalar.Controls.Add(this.gridControlMasalar);
            this.xtraTabPageMasalar.Name = "xtraTabPageMasalar";
            this.xtraTabPageMasalar.Size = new System.Drawing.Size(1398, 562);
            this.xtraTabPageMasalar.Text = "🖥️ Masalar";
            // 
            // gridControlMasalar
            // 
            this.gridControlMasalar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlMasalar.Location = new System.Drawing.Point(10, 60);
            this.gridControlMasalar.MainView = this.gridViewMasalar;
            this.gridControlMasalar.Name = "gridControlMasalar";
            this.gridControlMasalar.Size = new System.Drawing.Size(1378, 492);
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
            this.btnDurumDegistir.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#ceb951");
            this.btnDurumDegistir.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDurumDegistir.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDurumDegistir.Appearance.Options.UseBackColor = true;
            this.btnDurumDegistir.Appearance.Options.UseFont = true;
            this.btnDurumDegistir.Appearance.Options.UseForeColor = true;
            this.btnDurumDegistir.Location = new System.Drawing.Point(10, 15);
            this.btnDurumDegistir.Name = "btnDurumDegistir";
            this.btnDurumDegistir.Size = new System.Drawing.Size(170, 38);
            this.btnDurumDegistir.TabIndex = 1;
            this.btnDurumDegistir.Text = "⚙️ Durum Değiştir";
            this.btnDurumDegistir.Click += new System.EventHandler(this.btnDurumDegistir_Click);
            // 
            // btnYenileMasa
            // 
            this.btnYenileMasa.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2b80c8");
            this.btnYenileMasa.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnYenileMasa.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnYenileMasa.Appearance.Options.UseBackColor = true;
            this.btnYenileMasa.Appearance.Options.UseFont = true;
            this.btnYenileMasa.Appearance.Options.UseForeColor = true;
            this.btnYenileMasa.Location = new System.Drawing.Point(190, 15);
            this.btnYenileMasa.Name = "btnYenileMasa";
            this.btnYenileMasa.Size = new System.Drawing.Size(120, 38);
            this.btnYenileMasa.TabIndex = 2;
            this.btnYenileMasa.Text = "🔄 Yenile";
            this.btnYenileMasa.Click += new System.EventHandler(this.btnYenileMasa_Click);
            // 
            // xtraTabPageRandevular
            // 
            this.xtraTabPageRandevular.Controls.Add(this.btnYenileRandevu);
            this.xtraTabPageRandevular.Controls.Add(this.btnIptalRandevu);
            this.xtraTabPageRandevular.Controls.Add(this.btnOnayRandevu);
            this.xtraTabPageRandevular.Controls.Add(this.gridControlRandevular);
            this.xtraTabPageRandevular.Name = "xtraTabPageRandevular";
            this.xtraTabPageRandevular.Size = new System.Drawing.Size(1398, 562);
            this.xtraTabPageRandevular.Text = "📅 Randevular";
            // 
            // gridControlRandevular
            // 
            this.gridControlRandevular.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlRandevular.Location = new System.Drawing.Point(10, 60);
            this.gridControlRandevular.MainView = this.gridViewRandevular;
            this.gridControlRandevular.Name = "gridControlRandevular";
            this.gridControlRandevular.Size = new System.Drawing.Size(1378, 492);
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
            this.btnOnayRandevu.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#55a586");
            this.btnOnayRandevu.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOnayRandevu.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnOnayRandevu.Appearance.Options.UseBackColor = true;
            this.btnOnayRandevu.Appearance.Options.UseFont = true;
            this.btnOnayRandevu.Appearance.Options.UseForeColor = true;
            this.btnOnayRandevu.Location = new System.Drawing.Point(10, 15);
            this.btnOnayRandevu.Name = "btnOnayRandevu";
            this.btnOnayRandevu.Size = new System.Drawing.Size(130, 38);
            this.btnOnayRandevu.TabIndex = 1;
            this.btnOnayRandevu.Text = "✅ Onayla";
            this.btnOnayRandevu.Click += new System.EventHandler(this.btnOnayRandevu_Click);
            // 
            // btnIptalRandevu
            // 
            this.btnIptalRandevu.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#c82b6d");
            this.btnIptalRandevu.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIptalRandevu.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnIptalRandevu.Appearance.Options.UseBackColor = true;
            this.btnIptalRandevu.Appearance.Options.UseFont = true;
            this.btnIptalRandevu.Appearance.Options.UseForeColor = true;
            this.btnIptalRandevu.Location = new System.Drawing.Point(150, 15);
            this.btnIptalRandevu.Name = "btnIptalRandevu";
            this.btnIptalRandevu.Size = new System.Drawing.Size(130, 38);
            this.btnIptalRandevu.TabIndex = 2;
            this.btnIptalRandevu.Text = "❌ İptal Et";
            this.btnIptalRandevu.Click += new System.EventHandler(this.btnIptalRandevu_Click);
            // 
            // btnYenileRandevu
            // 
            this.btnYenileRandevu.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2b80c8");
            this.btnYenileRandevu.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnYenileRandevu.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnYenileRandevu.Appearance.Options.UseBackColor = true;
            this.btnYenileRandevu.Appearance.Options.UseFont = true;
            this.btnYenileRandevu.Appearance.Options.UseForeColor = true;
            this.btnYenileRandevu.Location = new System.Drawing.Point(290, 15);
            this.btnYenileRandevu.Name = "btnYenileRandevu";
            this.btnYenileRandevu.Size = new System.Drawing.Size(120, 38);
            this.btnYenileRandevu.TabIndex = 3;
            this.btnYenileRandevu.Text = "🔄 Yenile";
            this.btnYenileRandevu.Click += new System.EventHandler(this.btnYenileRandevu_Click);
            // 
            // AdminPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#151629");
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.panelDashboard);
            this.Controls.Add(this.panelUst);
            this.Name = "AdminPanelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "🛡️ Admin Panel - Kafe Gaming";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminPanelForm_Load);
            this.panelUst.ResumeLayout(false);
            this.panelUst.PerformLayout();
            this.panelDashboard.ResumeLayout(false);
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
        
        // Dashboard Kartları
        private System.Windows.Forms.Panel panelDashboard;
        private System.Windows.Forms.Panel cardKullanici;
        private System.Windows.Forms.Label lblKullaniciSayi;
        private System.Windows.Forms.Label lblKullaniciBaslik;
        private System.Windows.Forms.Panel cardMasa;
        private System.Windows.Forms.Label lblMasaSayi;
        private System.Windows.Forms.Label lblMasaBaslik;
        private System.Windows.Forms.Panel cardRandevu;
        private System.Windows.Forms.Label lblRandevuSayi;
        private System.Windows.Forms.Label lblRandevuBaslik;
        private System.Windows.Forms.Panel cardGelir;
        private System.Windows.Forms.Label lblGelirSayi;
        private System.Windows.Forms.Label lblGelirBaslik;
        
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
