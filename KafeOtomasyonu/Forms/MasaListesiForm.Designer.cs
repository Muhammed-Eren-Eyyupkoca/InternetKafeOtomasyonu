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
            // panelUst
            // 
            this.panelUst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panelUst.Controls.Add(this.btnCikis);
            this.panelUst.Controls.Add(this.btnYenile);
            this.panelUst.Controls.Add(this.lblHosgeldin);
            this.panelUst.Controls.Add(this.lblBaslik);
            this.panelUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUst.Location = new System.Drawing.Point(0, 0);
            this.panelUst.Name = "panelUst";
            this.panelUst.Size = new System.Drawing.Size(1400, 70);
            this.panelUst.TabIndex = 0;
            // 
            // btnCikis
            // 
            this.btnCikis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCikis.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnCikis.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCikis.Appearance.Options.UseBackColor = true;
            this.btnCikis.Appearance.Options.UseFont = true;
            this.btnCikis.Location = new System.Drawing.Point(1280, 20);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(100, 35);
            this.btnCikis.TabIndex = 3;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnYenile.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnYenile.Appearance.Options.UseBackColor = true;
            this.btnYenile.Appearance.Options.UseFont = true;
            this.btnYenile.Location = new System.Drawing.Point(1160, 20);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(100, 35);
            this.btnYenile.TabIndex = 2;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // lblHosgeldin
            // 
            this.lblHosgeldin.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblHosgeldin.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblHosgeldin.Appearance.Options.UseFont = true;
            this.lblHosgeldin.Appearance.Options.UseForeColor = true;
            this.lblHosgeldin.Location = new System.Drawing.Point(20, 43);
            this.lblHosgeldin.Name = "lblHosgeldin";
            this.lblHosgeldin.Size = new System.Drawing.Size(119, 17);
            this.lblHosgeldin.TabIndex = 1;
            this.lblHosgeldin.Text = "Hoş geldiniz, Kullanıcı";
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.Location = new System.Drawing.Point(20, 10);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(300, 32);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Kafe Gaming - Masa Seçimi";
            // 
            // panelMasalar
            // 
            this.panelMasalar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelMasalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMasalar.Location = new System.Drawing.Point(0, 70);
            this.panelMasalar.Name = "panelMasalar";
            this.panelMasalar.Size = new System.Drawing.Size(1400, 680);
            this.panelMasalar.TabIndex = 1;
            // 
            // panelLegend
            // 
            this.panelLegend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
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
            this.lblLegendBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLegendBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblLegendBaslik.Appearance.Options.UseFont = true;
            this.lblLegendBaslik.Appearance.Options.UseForeColor = true;
            this.lblLegendBaslik.Location = new System.Drawing.Point(20, 15);
            this.lblLegendBaslik.Name = "lblLegendBaslik";
            this.lblLegendBaslik.Size = new System.Drawing.Size(107, 19);
            this.lblLegendBaslik.TabIndex = 0;
            this.lblLegendBaslik.Text = "Masa Durumları:";
            // 
            // pnlBos
            // 
            this.pnlBos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.pnlBos.Location = new System.Drawing.Point(150, 15);
            this.pnlBos.Name = "pnlBos";
            this.pnlBos.Size = new System.Drawing.Size(30, 20);
            this.pnlBos.TabIndex = 1;
            // 
            // lblBos
            // 
            this.lblBos.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBos.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBos.Appearance.Options.UseFont = true;
            this.lblBos.Appearance.Options.UseForeColor = true;
            this.lblBos.Location = new System.Drawing.Point(190, 17);
            this.lblBos.Name = "lblBos";
            this.lblBos.Size = new System.Drawing.Size(19, 15);
            this.lblBos.TabIndex = 2;
            this.lblBos.Text = "Boş";
            // 
            // pnlRezerve
            // 
            this.pnlRezerve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.pnlRezerve.Location = new System.Drawing.Point(250, 15);
            this.pnlRezerve.Name = "pnlRezerve";
            this.pnlRezerve.Size = new System.Drawing.Size(30, 20);
            this.pnlRezerve.TabIndex = 3;
            // 
            // lblRezerve
            // 
            this.lblRezerve.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRezerve.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblRezerve.Appearance.Options.UseFont = true;
            this.lblRezerve.Appearance.Options.UseForeColor = true;
            this.lblRezerve.Location = new System.Drawing.Point(290, 17);
            this.lblRezerve.Name = "lblRezerve";
            this.lblRezerve.Size = new System.Drawing.Size(41, 15);
            this.lblRezerve.TabIndex = 4;
            this.lblRezerve.Text = "Rezerve";
            // 
            // pnlDolu
            // 
            this.pnlDolu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.pnlDolu.Location = new System.Drawing.Point(370, 15);
            this.pnlDolu.Name = "pnlDolu";
            this.pnlDolu.Size = new System.Drawing.Size(30, 20);
            this.pnlDolu.TabIndex = 5;
            // 
            // lblDolu
            // 
            this.lblDolu.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDolu.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblDolu.Appearance.Options.UseFont = true;
            this.lblDolu.Appearance.Options.UseForeColor = true;
            this.lblDolu.Location = new System.Drawing.Point(410, 17);
            this.lblDolu.Name = "lblDolu";
            this.lblDolu.Size = new System.Drawing.Size(25, 15);
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

