using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KafeOtomasyonu.Data;
using KafeOtomasyonu.Models;

namespace KafeOtomasyonu.Forms
{
    public partial class RandevuDuzenleForm : XtraForm
    {
        private Randevu _randevu;
        private RandevuRepository _randevuRepo;
        private MasaRepository _masaRepo;

        private Label lblMasaBilgi; // Masa bilgisi (değiştirilemez)
        private DateTimePicker dtpTarih;
        private System.Windows.Forms.ComboBox cmbBaslangicSaat;
        private System.Windows.Forms.ComboBox cmbSureSaat;
        private Label lblToplamUcret;
        private SimpleButton btnKaydet;
        private SimpleButton btnIptal;

        public RandevuDuzenleForm(Randevu randevu)
        {
            _randevu = randevu;
            _randevuRepo = new RandevuRepository();
            _masaRepo = new MasaRepository();

            InitializeComponent();
            InitializeCustomComponents();
            this.Load += RandevuDuzenleForm_Load;
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Randevu Düzenle";
            this.Size = new Size(500, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Başlık
            Label lblBaslik = new Label
            {
                Text = "✏️ RANDEVU DÜZENLE",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(lblBaslik);

            // Masa bilgisi (sadece görüntüleme)
            Label lblMasaBaslik = new Label
            {
                Text = "Masa:",
                Location = new Point(20, 70),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(lblMasaBaslik);

            lblMasaBilgi = new Label
            {
                Location = new Point(20, 95),
                Width = 440,
                Height = 30,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 150, 243),
                Text = "Yükleniyor...",
                TextAlign = ContentAlignment.MiddleLeft,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(240, 240, 240)
            };
            this.Controls.Add(lblMasaBilgi);

            // Tarih
            Label lblTarih = new Label
            {
                Text = "Tarih:",
                Location = new Point(20, 135),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(lblTarih);

            dtpTarih = new DateTimePicker
            {
                Location = new Point(20, 160),
                Width = 440,
                Format = DateTimePickerFormat.Long,
                MinDate = DateTime.Today,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(dtpTarih);

            // Başlangıç saati
            Label lblBaslangic = new Label
            {
                Text = "Başlangıç Saati:",
                Location = new Point(20, 200),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(lblBaslangic);

            cmbBaslangicSaat = new System.Windows.Forms.ComboBox
            {
                Location = new Point(20, 225),
                Width = 210,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(cmbBaslangicSaat);

            // Süre
            Label lblSure = new Label
            {
                Text = "Süre (Saat):",
                Location = new Point(250, 200),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(lblSure);

            cmbSureSaat = new System.Windows.Forms.ComboBox
            {
                Location = new Point(250, 225),
                Width = 210,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10)
            };
            for (int i = 1; i <= 12; i++)
            {
                cmbSureSaat.Items.Add($"{i} saat");
            }
            this.Controls.Add(cmbSureSaat);

            cmbSureSaat.SelectedIndexChanged += (s, e) => HesaplaUcret();

            // Toplam ücret
            lblToplamUcret = new Label
            {
                Text = "Toplam Ücret: 0 ₺",
                Location = new Point(20, 270),
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(76, 175, 80)
            };
            this.Controls.Add(lblToplamUcret);

            // Kaydet butonu
            btnKaydet = new SimpleButton
            {
                Text = "💾 Kaydet",
                Location = new Point(250, 330),
                Size = new Size(100, 40),
                Appearance = { BackColor = Color.FromArgb(76, 175, 80), Font = new Font("Segoe UI", 10, FontStyle.Bold) }
            };
            btnKaydet.Appearance.Options.UseBackColor = true;
            btnKaydet.Appearance.Options.UseFont = true;
            btnKaydet.Click += BtnKaydet_Click;
            this.Controls.Add(btnKaydet);

            // İptal butonu
            btnIptal = new SimpleButton
            {
                Text = "❌ İptal",
                Location = new Point(360, 330),
                Size = new Size(100, 40),
                Appearance = { BackColor = Color.FromArgb(158, 158, 158), Font = new Font("Segoe UI", 10, FontStyle.Bold) }
            };
            btnIptal.Appearance.Options.UseBackColor = true;
            btnIptal.Appearance.Options.UseFont = true;
            btnIptal.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            this.Controls.Add(btnIptal);
        }

        private void RandevuDuzenleForm_Load(object sender, EventArgs e)
        {
            // Mevcut masayı göster (değiştirilemez)
            var mevcutMasa = _masaRepo.GetAll().FirstOrDefault(m => m.MasaID == _randevu.MasaID);
            if (mevcutMasa != null)
            {
                lblMasaBilgi.Text = $"🖥️  {mevcutMasa.MasaAdi} - {mevcutMasa.SaatlikUcret:C}/saat";
            }

            // Saatleri yükle (09:00 - 23:00)
            for (int saat = 9; saat <= 23; saat++)
            {
                cmbBaslangicSaat.Items.Add($"{saat:00}:00");
            }

            // Mevcut randevu bilgilerini doldur
            dtpTarih.Value = _randevu.RandevuTarihi;

            // Başlangıç saatini seç
            string baslangicSaat = $"{_randevu.BaslangicSaati.Hours:00}:00";
            cmbBaslangicSaat.SelectedItem = baslangicSaat;

            // Süreyi seç
            cmbSureSaat.SelectedIndex = _randevu.ToplamSaat - 1;
            
            // İlk ücret hesaplaması
            HesaplaUcret();
        }

        private void HesaplaUcret()
        {
            if (cmbSureSaat.SelectedIndex == -1) return;

            var mevcutMasa = _masaRepo.GetAll().FirstOrDefault(m => m.MasaID == _randevu.MasaID);
            if (mevcutMasa == null) return;

            int sureSaat = cmbSureSaat.SelectedIndex + 1;
            decimal toplamUcret = mevcutMasa.SaatlikUcret * sureSaat;
            lblToplamUcret.Text = $"Toplam Ücret: {toplamUcret:C}";
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // Validasyon
            if (cmbBaslangicSaat.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen başlangıç saati seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbSureSaat.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen süre seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var mevcutMasa = _masaRepo.GetAll().FirstOrDefault(m => m.MasaID == _randevu.MasaID);
                if (mevcutMasa == null)
                {
                    MessageBox.Show("Masa bilgisi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int sureSaat = cmbSureSaat.SelectedIndex + 1;
                
                string[] saatParts = cmbBaslangicSaat.SelectedItem.ToString().Split(':');
                TimeSpan baslangicSaati = new TimeSpan(int.Parse(saatParts[0]), int.Parse(saatParts[1]), 0);
                TimeSpan bitisSaati = baslangicSaati.Add(TimeSpan.FromHours(sureSaat));

                // Çakışma kontrolü (kendi randevusu hariç, aynı masa için)
                if (_randevuRepo.HasConflict(_randevu.MasaID, dtpTarih.Value, baslangicSaati, bitisSaati, _randevu.RandevuID))
                {
                    MessageBox.Show("Seçilen tarih ve saatte aynı masa için başka bir randevu bulunmaktadır.", 
                                  "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Randevu güncelle (masa değişmeyecek, sadece tarih/saat)
                _randevu.RandevuTarihi = dtpTarih.Value.Date;
                _randevu.BaslangicSaati = baslangicSaati;
                _randevu.BitisSaati = bitisSaati;
                _randevu.ToplamSaat = sureSaat;
                _randevu.ToplamUcret = mevcutMasa.SaatlikUcret * sureSaat;

                _randevuRepo.Update(_randevu);

                MessageBox.Show("Randevunuz başarıyla güncellendi!", "Başarılı", 
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

