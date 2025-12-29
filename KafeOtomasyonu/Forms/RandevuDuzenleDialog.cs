using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KafeOtomasyonu.Data;
using KafeOtomasyonu.Models;

namespace KafeOtomasyonu.Forms
{
    /// <summary>
    /// Randevu düzenleme dialog formu
    /// </summary>
    public partial class RandevuDuzenleDialog : XtraForm
    {
        private Randevu _randevu;
        private RandevuRepository _randevuRepo;
        private DateEdit dtpTarih;
        private TimeEdit tpBaslangic;
        private SpinEdit spnSaat;
        private Label lblUcret;
        private decimal saatlikUcret = 75m;

        public RandevuDuzenleDialog(Randevu randevu)
        {
            _randevu = randevu;
            _randevuRepo = new RandevuRepository();
            InitializeComponent();
            InitializeUI();
            LoadRandevuData();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            
            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Name = "RandevuDuzenleDialog";
            this.Text = "Randevu Düzenle";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
            this.ResumeLayout(false);
        }

        private void InitializeUI()
        {
            // Ana panel
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(30),
                BackColor = Color.White
            };
            this.Controls.Add(mainPanel);

            // Başlık
            Label lblBaslik = new Label
            {
                Text = $"🖥️ {_randevu.MasaAdi} - Randevu Düzenle",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 224, 208),
                AutoSize = true,
                Location = new Point(0, 0)
            };
            mainPanel.Controls.Add(lblBaslik);

            // Tarih
            Label lblTarih = new Label
            {
                Text = "Tarih:",
                Font = new Font("Segoe UI", 10),
                Location = new Point(0, 60),
                AutoSize = true
            };
            mainPanel.Controls.Add(lblTarih);

            dtpTarih = new DateEdit
            {
                Location = new Point(0, 85),
                Width = 440,
                Properties = { DisplayFormat = { FormatString = "dd MMMM yyyy", FormatType = DevExpress.Utils.FormatType.DateTime } }
            };
            dtpTarih.Properties.MinValue = DateTime.Today;
            dtpTarih.EditValue = DateTime.Today;
            dtpTarih.EditValueChanged += OnValueChanged;
            mainPanel.Controls.Add(dtpTarih);

            // Başlangıç saati
            Label lblBaslangic = new Label
            {
                Text = "Başlangıç Saati:",
                Font = new Font("Segoe UI", 10),
                Location = new Point(0, 130),
                AutoSize = true
            };
            mainPanel.Controls.Add(lblBaslangic);

            tpBaslangic = new TimeEdit
            {
                Location = new Point(0, 155),
                Width = 440,
                Properties = { DisplayFormat = { FormatString = "HH:mm", FormatType = DevExpress.Utils.FormatType.DateTime } }
            };
            tpBaslangic.EditValue = DateTime.Today.AddHours(10);
            tpBaslangic.EditValueChanged += OnValueChanged;
            mainPanel.Controls.Add(tpBaslangic);

            // Kaç saat kullanılacak
            Label lblSaat = new Label
            {
                Text = "Kaç Saat:",
                Font = new Font("Segoe UI", 10),
                Location = new Point(0, 200),
                AutoSize = true
            };
            mainPanel.Controls.Add(lblSaat);

            spnSaat = new SpinEdit
            {
                Location = new Point(0, 225),
                Width = 440
            };
            spnSaat.Properties.MinValue = 1;
            spnSaat.Properties.MaxValue = 12;
            spnSaat.EditValue = 1;
            spnSaat.EditValueChanged += OnValueChanged;
            mainPanel.Controls.Add(spnSaat);

            // Ücret bilgisi
            lblUcret = new Label
            {
                Text = "Süre: 1 saat - Toplam Ücret: ₺75,00",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Green,
                Location = new Point(0, 270),
                Size = new Size(440, 25),
                TextAlign = ContentAlignment.MiddleCenter
            };
            mainPanel.Controls.Add(lblUcret);

            // Butonlar
            SimpleButton btnKaydet = new SimpleButton
            {
                Text = "💾 Kaydet",
                Location = new Point(250, 320),
                Size = new Size(90, 35),
                Font = new Font("Segoe UI", 10)
            };
            btnKaydet.Click += BtnKaydet_Click;
            mainPanel.Controls.Add(btnKaydet);

            SimpleButton btnIptal = new SimpleButton
            {
                Text = "❌ İptal",
                Location = new Point(350, 320),
                Size = new Size(90, 35),
                Font = new Font("Segoe UI", 10)
            };
            btnIptal.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            mainPanel.Controls.Add(btnIptal);
        }

        private void LoadRandevuData()
        {
            dtpTarih.EditValue = _randevu.RandevuTarihi;
            tpBaslangic.EditValue = DateTime.Today + _randevu.BaslangicSaati;
            spnSaat.EditValue = _randevu.ToplamSaat;
            HesaplaUcret();
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            HesaplaUcret();
        }

        private void HesaplaUcret()
        {
            if (spnSaat.EditValue == null) return;

            int saat = Convert.ToInt32(spnSaat.EditValue);
            decimal toplamUcret = saat * saatlikUcret;

            lblUcret.Text = $"Süre: {saat} saat - Toplam Ücret: {toplamUcret:C2}";
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime yeniTarih = Convert.ToDateTime(dtpTarih.EditValue);
                DateTime baslangicDT = Convert.ToDateTime(tpBaslangic.EditValue);
                TimeSpan yeniBaslangic = baslangicDT.TimeOfDay;
                int saat = Convert.ToInt32(spnSaat.EditValue);
                TimeSpan yeniBitis = yeniBaslangic.Add(TimeSpan.FromHours(saat));

                // Validasyonlar
                if (yeniTarih < DateTime.Today)
                {
                    XtraMessageBox.Show("Geçmiş tarih seçemezsiniz!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime randevuDateTime = yeniTarih.Date + yeniBaslangic;
                if (randevuDateTime < DateTime.Now)
                {
                    XtraMessageBox.Show("Geçmiş saat seçemezsiniz!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (yeniBitis > TimeSpan.FromHours(24))
                {
                    XtraMessageBox.Show("Randevu gece yarısını geçemez!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Çakışma kontrolü (mevcut randevu hariç)
                bool cakismaVar = _randevuRepo.HasConflict(_randevu.MasaID, yeniTarih, yeniBaslangic, yeniBitis, _randevu.RandevuID);
                if (cakismaVar)
                {
                    XtraMessageBox.Show("Bu saatlerde zaten bir randevu var!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal toplamUcret = saat * saatlikUcret;

                // Güncelle
                _randevuRepo.Update(_randevu.RandevuID, yeniTarih, yeniBaslangic, yeniBitis, saat, toplamUcret);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Hata: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

