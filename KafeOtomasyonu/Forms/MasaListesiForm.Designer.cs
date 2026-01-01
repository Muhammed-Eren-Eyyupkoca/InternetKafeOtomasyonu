namespace KafeOtomasyonu.Forms
{
    partial class MasaListesiForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelUst = new System.Windows.Forms.Panel();
            this.btnCikis = new DevExpress.XtraEditors.SimpleButton();
            this.btnProfil = new DevExpress.XtraEditors.SimpleButton();
            this.btnIstatistik = new DevExpress.XtraEditors.SimpleButton();
            this.btnRandevularim = new DevExpress.XtraEditors.SimpleButton();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.lblHosgeldin = new DevExpress.XtraEditors.LabelControl();
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.panelMasalar = new System.Windows.Forms.Panel();
            this.panelLegend = new System.Windows.Forms.Panel();
            this.lblLegendBaslik = new DevExpress.XtraEditors.LabelControl();
            this.pnlBos = new System.Windows.Forms.Panel();
            this.lblBos = new DevExpress.XtraEditors.LabelControl();
            this.pnlRezerve = new System.Windows.Forms.Panel();
            this.lblRezerve = new DevExpress.XtraEditors.LabelControl();
            this.pnlDolu = new System.Windows.Forms.Panel();
            this.lblDolu = new DevExpress.XtraEditors.LabelControl();
            this.panelUst.SuspendLayout();
            this.panelLegend.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUst - Modern dark navbar with gradient effect
            // 
            this.panelUst.BackColor = System.Drawing.ColorTranslator.FromHtml("#151629"); // Dark premium
            this.panelUst.Controls.Add(this.btnCikis);
            this.panelUst.Controls.Add(this.btnProfil);
            this.panelUst.Controls.Add(this.btnIstatistik);
            this.panelUst.Controls.Add(this.btnRandevularim);
            this.panelUst.Controls.Add(this.btnYenile);
            this.panelUst.Controls.Add(this.lblHosgeldin);
            this.panelUst.Controls.Add(this.lblBaslik);
            this.panelUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUst.Location = new System.Drawing.Point(0, 0);
            this.panelUst.Name = "panelUst";
            this.panelUst.Size = new System.Drawing.Size(1400, 80);
            this.panelUst.TabIndex = 0;
            // 
            // btnCikis - Error button (red/pink)
            // 
            this.btnCikis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCikis.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#c82b6d"); // Error pink-red
            this.btnCikis.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCikis.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCikis.Appearance.Options.UseBackColor = true;
            this.btnCikis.Appearance.Options.UseFont = true;
            this.btnCikis.Appearance.Options.UseForeColor = true;
            this.btnCikis.Location = new System.Drawing.Point(1270, 22);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(110, 40);
            this.btnCikis.TabIndex = 3;
            this.btnCikis.Text = "🚪 Çıkış";
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnProfil - Premium blue button
            // 
            this.btnProfil.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2b80c8"); // Premium blue
            this.btnProfil.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnProfil.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProfil.Appearance.Options.UseBackColor = true;
            this.btnProfil.Appearance.Options.UseForeColor = true;
            this.btnProfil.Appearance.Options.UseFont = true;
            this.btnProfil.Location = new System.Drawing.Point(780, 22);
            this.btnProfil.Name = "btnProfil";
            this.btnProfil.Size = new System.Drawing.Size(130, 40);
            this.btnProfil.TabIndex = 5;
            this.btnProfil.Text = "👤 Profilim";
            this.btnProfil.Visible = true;
            this.btnProfil.Enabled = true;
            this.btnProfil.Click += new System.EventHandler(this.btnProfil_Click);
            // 
            // btnIstatistik - Warning gold button
            // 
            this.btnIstatistik.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#ceb951"); // Warning gold
            this.btnIstatistik.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnIstatistik.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIstatistik.Appearance.Options.UseBackColor = true;
            this.btnIstatistik.Appearance.Options.UseForeColor = true;
            this.btnIstatistik.Appearance.Options.UseFont = true;
            this.btnIstatistik.Location = new System.Drawing.Point(620, 22);
            this.btnIstatistik.Name = "btnIstatistik";
            this.btnIstatistik.Size = new System.Drawing.Size(150, 40);
            this.btnIstatistik.TabIndex = 6;
            this.btnIstatistik.Text = "📊 İstatistikler";
            this.btnIstatistik.Visible = true;
            this.btnIstatistik.Enabled = true;
            this.btnIstatistik.Click += new System.EventHandler(this.btnIstatistik_Click);
            // 
            // btnRandevularim - Premium blue button
            // 
            this.btnRandevularim.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2b80c8"); // Premium blue
            this.btnRandevularim.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnRandevularim.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRandevularim.Appearance.Options.UseBackColor = true;
            this.btnRandevularim.Appearance.Options.UseForeColor = true;
            this.btnRandevularim.Appearance.Options.UseFont = true;
            this.btnRandevularim.Location = new System.Drawing.Point(440, 22);
            this.btnRandevularim.Name = "btnRandevularim";
            this.btnRandevularim.Size = new System.Drawing.Size(170, 40);
            this.btnRandevularim.TabIndex = 4;
            this.btnRandevularim.Text = "📅 Randevularım";
            this.btnRandevularim.Visible = true;
            this.btnRandevularim.Enabled = true;
            this.btnRandevularim.Click += new System.EventHandler(this.btnRandevularim_Click);
            // 
            // btnYenile - Success green button
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#55a586"); // Success green
            this.btnYenile.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnYenile.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnYenile.Appearance.Options.UseBackColor = true;
            this.btnYenile.Appearance.Options.UseFont = true;
            this.btnYenile.Appearance.Options.UseForeColor = true;
            this.btnYenile.Location = new System.Drawing.Point(1140, 22);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(120, 40);
            this.btnYenile.TabIndex = 2;
            this.btnYenile.Text = "🔄 Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // lblHosgeldin - Welcome text
            // 
            this.lblHosgeldin.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHosgeldin.Appearance.ForeColor = System.Drawing.ColorTranslator.FromHtml("#b0b9d1"); // Secondary grey-blue
            this.lblHosgeldin.Appearance.Options.UseFont = true;
            this.lblHosgeldin.Appearance.Options.UseForeColor = true;
            this.lblHosgeldin.Location = new System.Drawing.Point(25, 48);
            this.lblHosgeldin.Name = "lblHosgeldin";
            this.lblHosgeldin.Size = new System.Drawing.Size(119, 19);
            this.lblHosgeldin.TabIndex = 1;
            this.lblHosgeldin.Text = "Hoş geldiniz, Kullanıcı";
            // 
            // lblBaslik - Main title
            // 
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.Location = new System.Drawing.Point(25, 15);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(320, 37);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "🎮 Kafe Gaming - Masa Seçimi";
            // 
            // panelMasalar - Dark premium background with watermark
            // 
            this.panelMasalar.BackColor = System.Drawing.ColorTranslator.FromHtml("#151629"); // Dark premium
            this.panelMasalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMasalar.Location = new System.Drawing.Point(0, 80);
            this.panelMasalar.Name = "panelMasalar";
            this.panelMasalar.Size = new System.Drawing.Size(1400, 670);
            this.panelMasalar.TabIndex = 1;
            this.panelMasalar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMasalar_Paint);
            // 
            // panelLegend - Bottom legend bar
            // 
            this.panelLegend.BackColor = System.Drawing.ColorTranslator.FromHtml("#151629"); // Dark premium
            this.panelLegend.Controls.Add(this.lblDolu);
            this.panelLegend.Controls.Add(this.pnlDolu);
            this.panelLegend.Controls.Add(this.lblRezerve);
            this.panelLegend.Controls.Add(this.pnlRezerve);
            this.panelLegend.Controls.Add(this.lblBos);
            this.panelLegend.Controls.Add(this.pnlBos);
            this.panelLegend.Controls.Add(this.lblLegendBaslik);
            this.panelLegend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLegend.Location = new System.Drawing.Point(0, 750);
            this.panelLegend.Name = "panelLegend";
            this.panelLegend.Size = new System.Drawing.Size(1400, 50);
            this.panelLegend.TabIndex = 2;
            // 
            // lblLegendBaslik
            // 
            this.lblLegendBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLegendBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblLegendBaslik.Appearance.Options.UseFont = true;
            this.lblLegendBaslik.Appearance.Options.UseForeColor = true;
            this.lblLegendBaslik.Location = new System.Drawing.Point(25, 15);
            this.lblLegendBaslik.Name = "lblLegendBaslik";
            this.lblLegendBaslik.Size = new System.Drawing.Size(115, 20);
            this.lblLegendBaslik.TabIndex = 0;
            this.lblLegendBaslik.Text = "Masa Durumları:";
            // 
            // pnlBos - Green indicator
            // 
            this.pnlBos.BackColor = System.Drawing.ColorTranslator.FromHtml("#55a586"); // Success green
            this.pnlBos.Location = new System.Drawing.Point(160, 13);
            this.pnlBos.Name = "pnlBos";
            this.pnlBos.Size = new System.Drawing.Size(35, 24);
            this.pnlBos.TabIndex = 1;
            // 
            // lblBos
            // 
            this.lblBos.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBos.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBos.Appearance.Options.UseFont = true;
            this.lblBos.Appearance.Options.UseForeColor = true;
            this.lblBos.Location = new System.Drawing.Point(205, 16);
            this.lblBos.Name = "lblBos";
            this.lblBos.Size = new System.Drawing.Size(24, 19);
            this.lblBos.TabIndex = 2;
            this.lblBos.Text = "Boş";
            // 
            // pnlRezerve - Gold indicator
            // 
            this.pnlRezerve.BackColor = System.Drawing.ColorTranslator.FromHtml("#ceb951"); // Warning gold
            this.pnlRezerve.Location = new System.Drawing.Point(270, 13);
            this.pnlRezerve.Name = "pnlRezerve";
            this.pnlRezerve.Size = new System.Drawing.Size(35, 24);
            this.pnlRezerve.TabIndex = 3;
            // 
            // lblRezerve
            // 
            this.lblRezerve.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRezerve.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblRezerve.Appearance.Options.UseFont = true;
            this.lblRezerve.Appearance.Options.UseForeColor = true;
            this.lblRezerve.Location = new System.Drawing.Point(315, 16);
            this.lblRezerve.Name = "lblRezerve";
            this.lblRezerve.Size = new System.Drawing.Size(50, 19);
            this.lblRezerve.TabIndex = 4;
            this.lblRezerve.Text = "Rezerve";
            // 
            // pnlDolu - Red/Pink indicator
            // 
            this.pnlDolu.BackColor = System.Drawing.ColorTranslator.FromHtml("#c82b6d"); // Error pink-red
            this.pnlDolu.Location = new System.Drawing.Point(410, 13);
            this.pnlDolu.Name = "pnlDolu";
            this.pnlDolu.Size = new System.Drawing.Size(35, 24);
            this.pnlDolu.TabIndex = 5;
            // 
            // lblDolu
            // 
            this.lblDolu.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDolu.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblDolu.Appearance.Options.UseFont = true;
            this.lblDolu.Appearance.Options.UseForeColor = true;
            this.lblDolu.Location = new System.Drawing.Point(455, 16);
            this.lblDolu.Name = "lblDolu";
            this.lblDolu.Size = new System.Drawing.Size(31, 19);
            this.lblDolu.TabIndex = 6;
            this.lblDolu.Text = "Dolu";
            // 
            // MasaListesiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.panelMasalar);
            this.Controls.Add(this.panelLegend);
            this.Controls.Add(this.panelUst);
            this.Name = "MasaListesiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kafe Gaming - Masa Listesi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MasaListesiForm_Load);
            this.panelUst.ResumeLayout(false);
            this.panelUst.PerformLayout();
            this.panelLegend.ResumeLayout(false);
            this.panelLegend.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelUst;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.LabelControl lblHosgeldin;
        private DevExpress.XtraEditors.SimpleButton btnIstatistik;
        private DevExpress.XtraEditors.SimpleButton btnRandevularim;
        private DevExpress.XtraEditors.SimpleButton btnProfil;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private DevExpress.XtraEditors.SimpleButton btnCikis;
        private System.Windows.Forms.Panel panelMasalar;
        private System.Windows.Forms.Panel panelLegend;
        private DevExpress.XtraEditors.LabelControl lblLegendBaslik;
        private System.Windows.Forms.Panel pnlBos;
        private DevExpress.XtraEditors.LabelControl lblBos;
        private System.Windows.Forms.Panel pnlRezerve;
        private DevExpress.XtraEditors.LabelControl lblRezerve;
        private System.Windows.Forms.Panel pnlDolu;
        private DevExpress.XtraEditors.LabelControl lblDolu;
    }
}
