namespace KafeOtomasyonu.Forms
{
    partial class MasaDetayForm
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
            this.lblMasaBaslik = new DevExpress.XtraEditors.LabelControl();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.groupMasaBilgi = new DevExpress.XtraEditors.GroupControl();
            this.lblPCOzellik = new DevExpress.XtraEditors.LabelControl();
            this.lblAciklama = new DevExpress.XtraEditors.LabelControl();
            this.lblPuanOrtalama = new DevExpress.XtraEditors.LabelControl();
            this.lblSaatlikUcret = new DevExpress.XtraEditors.LabelControl();
            this.lblDurum = new DevExpress.XtraEditors.LabelControl();
            this.lblMasaNo = new DevExpress.XtraEditors.LabelControl();
            this.btnRandevuYap = new DevExpress.XtraEditors.SimpleButton();
            this.groupYorumYap = new DevExpress.XtraEditors.GroupControl();
            this.panelYildizlar = new System.Windows.Forms.Panel();
            this.lblPuanVer = new DevExpress.XtraEditors.LabelControl();
            this.txtYorum = new DevExpress.XtraEditors.MemoEdit();
            this.btnYorumYap = new DevExpress.XtraEditors.SimpleButton();
            this.groupYorumlar = new DevExpress.XtraEditors.GroupControl();
            this.flowPanelYorumlar = new System.Windows.Forms.FlowLayoutPanel();
            this.panelUst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupMasaBilgi)).BeginInit();
            this.groupMasaBilgi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupYorumYap)).BeginInit();
            this.groupYorumYap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtYorum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupYorumlar)).BeginInit();
            this.groupYorumlar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUst
            // 
            this.panelUst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panelUst.Controls.Add(this.btnKapat);
            this.panelUst.Controls.Add(this.lblMasaBaslik);
            this.panelUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUst.Location = new System.Drawing.Point(0, 0);
            this.panelUst.Name = "panelUst";
            this.panelUst.Size = new System.Drawing.Size(800, 60);
            this.panelUst.TabIndex = 0;
            // 
            // lblMasaBaslik
            // 
            this.lblMasaBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblMasaBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblMasaBaslik.Appearance.Options.UseFont = true;
            this.lblMasaBaslik.Appearance.Options.UseForeColor = true;
            this.lblMasaBaslik.Location = new System.Drawing.Point(20, 15);
            this.lblMasaBaslik.Name = "lblMasaBaslik";
            this.lblMasaBaslik.Size = new System.Drawing.Size(71, 30);
            this.lblMasaBaslik.TabIndex = 0;
            this.lblMasaBaslik.Text = "Masa 1";
            // 
            // btnKapat
            // 
            this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKapat.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnKapat.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnKapat.Appearance.Options.UseBackColor = true;
            this.btnKapat.Appearance.Options.UseFont = true;
            this.btnKapat.Location = new System.Drawing.Point(688, 15);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(100, 35);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // groupMasaBilgi
            // 
            this.groupMasaBilgi.Controls.Add(this.btnRandevuYap);
            this.groupMasaBilgi.Controls.Add(this.lblPCOzellik);
            this.groupMasaBilgi.Controls.Add(this.lblAciklama);
            this.groupMasaBilgi.Controls.Add(this.lblPuanOrtalama);
            this.groupMasaBilgi.Controls.Add(this.lblSaatlikUcret);
            this.groupMasaBilgi.Controls.Add(this.lblDurum);
            this.groupMasaBilgi.Controls.Add(this.lblMasaNo);
            this.groupMasaBilgi.Location = new System.Drawing.Point(20, 80);
            this.groupMasaBilgi.Name = "groupMasaBilgi";
            this.groupMasaBilgi.Size = new System.Drawing.Size(760, 180);
            this.groupMasaBilgi.TabIndex = 1;
            this.groupMasaBilgi.Text = "Masa Bilgileri";
            // 
            // lblMasaNo
            // 
            this.lblMasaNo.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMasaNo.Appearance.Options.UseFont = true;
            this.lblMasaNo.Location = new System.Drawing.Point(20, 35);
            this.lblMasaNo.Name = "lblMasaNo";
            this.lblMasaNo.Size = new System.Drawing.Size(73, 20);
            this.lblMasaNo.TabIndex = 0;
            this.lblMasaNo.Text = "Masa No: 1";
            // 
            // lblDurum
            // 
            this.lblDurum.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDurum.Appearance.Options.UseFont = true;
            this.lblDurum.Location = new System.Drawing.Point(20, 65);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(90, 20);
            this.lblDurum.TabIndex = 1;
            this.lblDurum.Text = "Durum: BOŞ";
            // 
            // lblSaatlikUcret
            // 
            this.lblSaatlikUcret.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSaatlikUcret.Appearance.Options.UseFont = true;
            this.lblSaatlikUcret.Location = new System.Drawing.Point(20, 95);
            this.lblSaatlikUcret.Name = "lblSaatlikUcret";
            this.lblSaatlikUcret.Size = new System.Drawing.Size(136, 19);
            this.lblSaatlikUcret.TabIndex = 2;
            this.lblSaatlikUcret.Text = "Saatlik Ücret: ₺15,00";
            // 
            // lblPuanOrtalama
            // 
            this.lblPuanOrtalama.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPuanOrtalama.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.lblPuanOrtalama.Appearance.Options.UseFont = true;
            this.lblPuanOrtalama.Appearance.Options.UseForeColor = true;
            this.lblPuanOrtalama.Location = new System.Drawing.Point(20, 125);
            this.lblPuanOrtalama.Name = "lblPuanOrtalama";
            this.lblPuanOrtalama.Size = new System.Drawing.Size(235, 19);
            this.lblPuanOrtalama.TabIndex = 3;
            this.lblPuanOrtalama.Text = "Ortalama Puan: 0.0/5.0 (0 değerlendirme)";
            // 
            // lblAciklama
            // 
            this.lblAciklama.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAciklama.Appearance.Options.UseFont = true;
            this.lblAciklama.Location = new System.Drawing.Point(400, 35);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(111, 15);
            this.lblAciklama.TabIndex = 4;
            this.lblAciklama.Text = "Gaming Masa - VIP";
            // 
            // lblPCOzellik
            // 
            this.lblPCOzellik.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPCOzellik.Appearance.Options.UseFont = true;
            this.lblPCOzellik.Location = new System.Drawing.Point(400, 65);
            this.lblPCOzellik.Name = "lblPCOzellik";
            this.lblPCOzellik.Size = new System.Drawing.Size(264, 15);
            this.lblPCOzellik.TabIndex = 5;
            this.lblPCOzellik.Text = "PC Özellikleri: Intel Core i7, RTX 3060, 16GB RAM";
            // 
            // btnRandevuYap
            // 
            this.btnRandevuYap.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnRandevuYap.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRandevuYap.Appearance.Options.UseBackColor = true;
            this.btnRandevuYap.Appearance.Options.UseFont = true;
            this.btnRandevuYap.Location = new System.Drawing.Point(550, 120);
            this.btnRandevuYap.Name = "btnRandevuYap";
            this.btnRandevuYap.Size = new System.Drawing.Size(180, 40);
            this.btnRandevuYap.TabIndex = 6;
            this.btnRandevuYap.Text = "Randevu Yap";
            this.btnRandevuYap.Click += new System.EventHandler(this.btnRandevuYap_Click);
            // 
            // groupYorumYap
            // 
            this.groupYorumYap.Controls.Add(this.btnYorumYap);
            this.groupYorumYap.Controls.Add(this.txtYorum);
            this.groupYorumYap.Controls.Add(this.lblPuanVer);
            this.groupYorumYap.Controls.Add(this.panelYildizlar);
            this.groupYorumYap.Location = new System.Drawing.Point(20, 280);
            this.groupYorumYap.Name = "groupYorumYap";
            this.groupYorumYap.Size = new System.Drawing.Size(760, 200);
            this.groupYorumYap.TabIndex = 2;
            this.groupYorumYap.Text = "Yorum ve Puan Ver";
            // 
            // panelYildizlar
            // 
            this.panelYildizlar.Location = new System.Drawing.Point(20, 60);
            this.panelYildizlar.Name = "panelYildizlar";
            this.panelYildizlar.Size = new System.Drawing.Size(300, 60);
            this.panelYildizlar.TabIndex = 0;
            // 
            // lblPuanVer
            // 
            this.lblPuanVer.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPuanVer.Appearance.Options.UseFont = true;
            this.lblPuanVer.Location = new System.Drawing.Point(20, 35);
            this.lblPuanVer.Name = "lblPuanVer";
            this.lblPuanVer.Size = new System.Drawing.Size(123, 19);
            this.lblPuanVer.TabIndex = 1;
            this.lblPuanVer.Text = "Masayı Puanlayın:";
            // 
            // txtYorum
            // 
            this.txtYorum.Location = new System.Drawing.Point(350, 35);
            this.txtYorum.Name = "txtYorum";
            this.txtYorum.Size = new System.Drawing.Size(380, 85);
            this.txtYorum.TabIndex = 2;
            // 
            // btnYorumYap
            // 
            this.btnYorumYap.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnYorumYap.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnYorumYap.Appearance.Options.UseBackColor = true;
            this.btnYorumYap.Appearance.Options.UseFont = true;
            this.btnYorumYap.Location = new System.Drawing.Point(550, 140);
            this.btnYorumYap.Name = "btnYorumYap";
            this.btnYorumYap.Size = new System.Drawing.Size(180, 40);
            this.btnYorumYap.TabIndex = 3;
            this.btnYorumYap.Text = "Yorum Yap";
            this.btnYorumYap.Click += new System.EventHandler(this.btnYorumYap_Click);
            // 
            // groupYorumlar
            // 
            this.groupYorumlar.Controls.Add(this.flowPanelYorumlar);
            this.groupYorumlar.Location = new System.Drawing.Point(20, 500);
            this.groupYorumlar.Name = "groupYorumlar";
            this.groupYorumlar.Size = new System.Drawing.Size(760, 300);
            this.groupYorumlar.TabIndex = 3;
            this.groupYorumlar.Text = "Kullanıcı Yorumları";
            // 
            // flowPanelYorumlar
            // 
            this.flowPanelYorumlar.AutoScroll = true;
            this.flowPanelYorumlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelYorumlar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanelYorumlar.Location = new System.Drawing.Point(2, 23);
            this.flowPanelYorumlar.Name = "flowPanelYorumlar";
            this.flowPanelYorumlar.Size = new System.Drawing.Size(756, 275);
            this.flowPanelYorumlar.TabIndex = 0;
            this.flowPanelYorumlar.WrapContents = false;
            // 
            // MasaDetayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 820);
            this.Controls.Add(this.groupYorumlar);
            this.Controls.Add(this.groupYorumYap);
            this.Controls.Add(this.groupMasaBilgi);
            this.Controls.Add(this.panelUst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MasaDetayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Masa Detayları";
            this.Load += new System.EventHandler(this.MasaDetayForm_Load);
            this.panelUst.ResumeLayout(false);
            this.panelUst.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupMasaBilgi)).EndInit();
            this.groupMasaBilgi.ResumeLayout(false);
            this.groupMasaBilgi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupYorumYap)).EndInit();
            this.groupYorumYap.ResumeLayout(false);
            this.groupYorumYap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtYorum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupYorumlar)).EndInit();
            this.groupYorumlar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelUst;
        private DevExpress.XtraEditors.LabelControl lblMasaBaslik;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
        private DevExpress.XtraEditors.GroupControl groupMasaBilgi;
        private DevExpress.XtraEditors.LabelControl lblMasaNo;
        private DevExpress.XtraEditors.LabelControl lblDurum;
        private DevExpress.XtraEditors.LabelControl lblSaatlikUcret;
        private DevExpress.XtraEditors.LabelControl lblPuanOrtalama;
        private DevExpress.XtraEditors.LabelControl lblAciklama;
        private DevExpress.XtraEditors.LabelControl lblPCOzellik;
        private DevExpress.XtraEditors.SimpleButton btnRandevuYap;
        private DevExpress.XtraEditors.GroupControl groupYorumYap;
        private System.Windows.Forms.Panel panelYildizlar;
        private DevExpress.XtraEditors.LabelControl lblPuanVer;
        private DevExpress.XtraEditors.MemoEdit txtYorum;
        private DevExpress.XtraEditors.SimpleButton btnYorumYap;
        private DevExpress.XtraEditors.GroupControl groupYorumlar;
        private System.Windows.Forms.FlowLayoutPanel flowPanelYorumlar;
    }
}

