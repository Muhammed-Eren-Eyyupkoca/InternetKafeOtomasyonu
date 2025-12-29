namespace KafeOtomasyonu.Forms
{
    partial class RandevuDialogForm
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
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.groupRandevu = new DevExpress.XtraEditors.GroupControl();
            this.lblToplamUcret = new DevExpress.XtraEditors.LabelControl();
            this.spinSaat = new DevExpress.XtraEditors.SpinEdit();
            this.timeBaslangic = new DevExpress.XtraEditors.TimeEdit();
            this.dateRandevu = new DevExpress.XtraEditors.DateEdit();
            this.lblKacSaat = new DevExpress.XtraEditors.LabelControl();
            this.lblBaslangicSaati = new DevExpress.XtraEditors.LabelControl();
            this.lblTarih = new DevExpress.XtraEditors.LabelControl();
            this.lblSaatlikUcret = new DevExpress.XtraEditors.LabelControl();
            this.lblMasaAdi = new DevExpress.XtraEditors.LabelControl();
            this.btnOlustur = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.panelUst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupRandevu)).BeginInit();
            this.groupRandevu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinSaat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeBaslangic.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateRandevu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateRandevu.Properties.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelUst
            // 
            this.panelUst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.panelUst.Controls.Add(this.lblBaslik);
            this.panelUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUst.Location = new System.Drawing.Point(0, 0);
            this.panelUst.Name = "panelUst";
            this.panelUst.Size = new System.Drawing.Size(500, 60);
            this.panelUst.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.Location = new System.Drawing.Point(20, 18);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(186, 25);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Randevu Oluşturma";
            // 
            // groupRandevu
            // 
            this.groupRandevu.Controls.Add(this.lblToplamUcret);
            this.groupRandevu.Controls.Add(this.spinSaat);
            this.groupRandevu.Controls.Add(this.timeBaslangic);
            this.groupRandevu.Controls.Add(this.dateRandevu);
            this.groupRandevu.Controls.Add(this.lblKacSaat);
            this.groupRandevu.Controls.Add(this.lblBaslangicSaati);
            this.groupRandevu.Controls.Add(this.lblTarih);
            this.groupRandevu.Controls.Add(this.lblSaatlikUcret);
            this.groupRandevu.Controls.Add(this.lblMasaAdi);
            this.groupRandevu.Location = new System.Drawing.Point(20, 80);
            this.groupRandevu.Name = "groupRandevu";
            this.groupRandevu.Size = new System.Drawing.Size(460, 280);
            this.groupRandevu.TabIndex = 1;
            this.groupRandevu.Text = "Randevu Bilgileri";
            // 
            // lblMasaAdi
            // 
            this.lblMasaAdi.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMasaAdi.Appearance.Options.UseFont = true;
            this.lblMasaAdi.Location = new System.Drawing.Point(20, 35);
            this.lblMasaAdi.Name = "lblMasaAdi";
            this.lblMasaAdi.Size = new System.Drawing.Size(56, 21);
            this.lblMasaAdi.TabIndex = 0;
            this.lblMasaAdi.Text = "Masa 1";
            // 
            // lblSaatlikUcret
            // 
            this.lblSaatlikUcret.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSaatlikUcret.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblSaatlikUcret.Appearance.Options.UseFont = true;
            this.lblSaatlikUcret.Appearance.Options.UseForeColor = true;
            this.lblSaatlikUcret.Location = new System.Drawing.Point(20, 65);
            this.lblSaatlikUcret.Name = "lblSaatlikUcret";
            this.lblSaatlikUcret.Size = new System.Drawing.Size(113, 19);
            this.lblSaatlikUcret.TabIndex = 1;
            this.lblSaatlikUcret.Text = "Saatlik Ücret: ₺75,00";
            // 
            // lblTarih
            // 
            this.lblTarih.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTarih.Appearance.Options.UseFont = true;
            this.lblTarih.Location = new System.Drawing.Point(20, 105);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(91, 19);
            this.lblTarih.TabIndex = 2;
            this.lblTarih.Text = "Randevu Tarihi:";
            // 
            // lblBaslangicSaati
            // 
            this.lblBaslangicSaati.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBaslangicSaati.Appearance.Options.UseFont = true;
            this.lblBaslangicSaati.Location = new System.Drawing.Point(20, 145);
            this.lblBaslangicSaati.Name = "lblBaslangicSaati";
            this.lblBaslangicSaati.Size = new System.Drawing.Size(98, 19);
            this.lblBaslangicSaati.TabIndex = 3;
            this.lblBaslangicSaati.Text = "Başlangıç Saati:";
            // 
            // lblKacSaat
            // 
            this.lblKacSaat.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKacSaat.Appearance.Options.UseFont = true;
            this.lblKacSaat.Location = new System.Drawing.Point(20, 185);
            this.lblKacSaat.Name = "lblKacSaat";
            this.lblKacSaat.Size = new System.Drawing.Size(127, 19);
            this.lblKacSaat.TabIndex = 4;
            this.lblKacSaat.Text = "Kaç Saat Kullanılacak:";
            // 
            // dateRandevu
            // 
            this.dateRandevu.EditValue = null;
            this.dateRandevu.Location = new System.Drawing.Point(160, 103);
            this.dateRandevu.Name = "dateRandevu";
            this.dateRandevu.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateRandevu.Properties.Appearance.Options.UseFont = true;
            this.dateRandevu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateRandevu.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateRandevu.Size = new System.Drawing.Size(280, 24);
            this.dateRandevu.TabIndex = 5;
            this.dateRandevu.EditValueChanged += new System.EventHandler(this.dateRandevu_EditValueChanged);
            // 
            // timeBaslangic
            // 
            this.timeBaslangic.EditValue = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.timeBaslangic.Location = new System.Drawing.Point(160, 143);
            this.timeBaslangic.Name = "timeBaslangic";
            this.timeBaslangic.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.timeBaslangic.Properties.Appearance.Options.UseFont = true;
            this.timeBaslangic.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeBaslangic.Size = new System.Drawing.Size(280, 24);
            this.timeBaslangic.TabIndex = 6;
            this.timeBaslangic.EditValueChanged += new System.EventHandler(this.timeBaslangic_EditValueChanged);
            // 
            // spinSaat
            // 
            this.spinSaat.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinSaat.Location = new System.Drawing.Point(160, 183);
            this.spinSaat.Name = "spinSaat";
            this.spinSaat.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.spinSaat.Properties.Appearance.Options.UseFont = true;
            this.spinSaat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinSaat.Properties.IsFloatValue = false;
            this.spinSaat.Properties.MaxValue = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.spinSaat.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinSaat.Size = new System.Drawing.Size(280, 24);
            this.spinSaat.TabIndex = 7;
            this.spinSaat.EditValueChanged += new System.EventHandler(this.spinSaat_EditValueChanged);
            // 
            // lblToplamUcret
            // 
            this.lblToplamUcret.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblToplamUcret.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblToplamUcret.Appearance.Options.UseFont = true;
            this.lblToplamUcret.Appearance.Options.UseForeColor = true;
            this.lblToplamUcret.Location = new System.Drawing.Point(20, 230);
            this.lblToplamUcret.Name = "lblToplamUcret";
            this.lblToplamUcret.Size = new System.Drawing.Size(240, 20);
            this.lblToplamUcret.TabIndex = 8;
            this.lblToplamUcret.Text = "Süre: 3 saat - Toplam Ücret: ₺45,00";
            // 
            // btnOlustur
            // 
            this.btnOlustur.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnOlustur.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOlustur.Appearance.Options.UseBackColor = true;
            this.btnOlustur.Appearance.Options.UseFont = true;
            this.btnOlustur.Location = new System.Drawing.Point(280, 380);
            this.btnOlustur.Name = "btnOlustur";
            this.btnOlustur.Size = new System.Drawing.Size(120, 40);
            this.btnOlustur.TabIndex = 2;
            this.btnOlustur.Text = "Oluştur";
            this.btnOlustur.Click += new System.EventHandler(this.btnOlustur_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnIptal.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIptal.Appearance.Options.UseBackColor = true;
            this.btnIptal.Appearance.Options.UseFont = true;
            this.btnIptal.Location = new System.Drawing.Point(140, 380);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(120, 40);
            this.btnIptal.TabIndex = 3;
            this.btnIptal.Text = "İptal";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // RandevuDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 440);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnOlustur);
            this.Controls.Add(this.groupRandevu);
            this.Controls.Add(this.panelUst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RandevuDialogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Randevu Oluştur";
            this.Load += new System.EventHandler(this.RandevuDialogForm_Load);
            this.panelUst.ResumeLayout(false);
            this.panelUst.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupRandevu)).EndInit();
            this.groupRandevu.ResumeLayout(false);
            this.groupRandevu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinSaat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeBaslangic.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateRandevu.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateRandevu.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelUst;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.GroupControl groupRandevu;
        private DevExpress.XtraEditors.LabelControl lblMasaAdi;
        private DevExpress.XtraEditors.LabelControl lblSaatlikUcret;
        private DevExpress.XtraEditors.LabelControl lblTarih;
        private DevExpress.XtraEditors.LabelControl lblBaslangicSaati;
        private DevExpress.XtraEditors.LabelControl lblKacSaat;
        private DevExpress.XtraEditors.DateEdit dateRandevu;
        private DevExpress.XtraEditors.TimeEdit timeBaslangic;
        private DevExpress.XtraEditors.SpinEdit spinSaat;
        private DevExpress.XtraEditors.LabelControl lblToplamUcret;
        private DevExpress.XtraEditors.SimpleButton btnOlustur;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
    }
}

