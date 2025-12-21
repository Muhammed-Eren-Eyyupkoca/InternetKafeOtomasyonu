using System;
using System.Windows.Forms;
using KafeOtomasyonu.Data;
using KafeOtomasyonu.Helpers;
using KafeOtomasyonu.Models;

namespace KafeOtomasyonu.Forms
{
    /// <summary>
    /// Randevu oluşturma dialog formu
    /// </summary>
    public partial class RandevuDialogForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly Masa _masa;
        private readonly RandevuRepository _randevuRepository;
        private readonly MasaRepository _masaRepository;

        public RandevuDialogForm(Masa masa)
        {
            InitializeComponent();
            _masa = masa;
            _randevuRepository = new RandevuRepository();
            _masaRepository = new MasaRepository();
        }

        private void RandevuDialogForm_Load(object sender, EventArgs e)
        {
            lblMasaAdi.Text = _masa.MasaAdi ?? $"Masa {_masa.MasaNo}";
            lblSaatlikUcret.Text = $"Saatlik Ücret: {_masa.SaatlikUcret:C}";

            // Tarih seçiciyi ayarla - bugünden itibaren seçilebilir
            dateRandevu.Properties.MinValue = DateTime.Today;
            dateRandevu.EditValue = DateTime.Today;

            // Saat seçicileri ayarla
            timeBaslangic.Properties.EditFormat.FormatString = "HH:mm";
            timeBaslangic.Properties.DisplayFormat.FormatString = "HH:mm";
            timeBaslangic.Properties.Mask.EditMask = "HH:mm";
            timeBaslangic.EditValue = DateTime.Today.AddHours(9); // 09:00

            timeBitis.Properties.EditFormat.FormatString = "HH:mm";
            timeBitis.Properties.DisplayFormat.FormatString = "HH:mm";
            timeBitis.Properties.Mask.EditMask = "HH:mm";
            timeBitis.EditValue = DateTime.Today.AddHours(12); // 12:00

            HesaplaToplamUcret();
        }

        /// <summary>
        /// Başlangıç saati değiştiğinde
        /// </summary>
        private void timeBaslangic_EditValueChanged(object sender, EventArgs e)
        {
            HesaplaToplamUcret();
        }

        /// <summary>
        /// Bitiş saati değiştiğinde
        /// </summary>
        private void timeBitis_EditValueChanged(object sender, EventArgs e)
        {
            HesaplaToplamUcret();
        }

        /// <summary>
        /// Tarih değiştiğinde
        /// </summary>
        private void dateRandevu_EditValueChanged(object sender, EventArgs e)
        {
            HesaplaToplamUcret();
        }

        /// <summary>
        /// Toplam ücreti hesapla ve göster
        /// </summary>
        private void HesaplaToplamUcret()
        {
            try
            {
                if (timeBaslangic.EditValue == null || timeBitis.EditValue == null)
                    return;

                DateTime baslangic = (DateTime)timeBaslangic.EditValue;
                DateTime bitis = (DateTime)timeBitis.EditValue;

                TimeSpan baslangicSaat = baslangic.TimeOfDay;
                TimeSpan bitisSaat = bitis.TimeOfDay;

                if (bitisSaat <= baslangicSaat)
                {
                    lblToplamUcret.Text = "Bitiş saati, başlangıç saatinden sonra olmalıdır!";
                    lblToplamUcret.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                int saatFarki = (int)(bitisSaat - baslangicSaat).TotalHours;
                decimal toplamUcret = saatFarki * _masa.SaatlikUcret;

                lblToplamUcret.Text = $"Süre: {saatFarki} saat - Toplam Ücret: {toplamUcret:C}";
                lblToplamUcret.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception)
            {
                lblToplamUcret.Text = "Geçerli saat giriniz";
                lblToplamUcret.ForeColor = System.Drawing.Color.Red;
            }
        }

        /// <summary>
        /// Randevu oluştur butonu
        /// </summary>
        private void btnOlustur_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateRandevu.EditValue == null)
                {
                    MessageBox.Show("Lütfen tarih seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (timeBaslangic.EditValue == null || timeBitis.EditValue == null)
                {
                    MessageBox.Show("Lütfen başlangıç ve bitiş saatlerini giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime randevuTarihi = ((DateTime)dateRandevu.EditValue).Date;
                DateTime baslangic = (DateTime)timeBaslangic.EditValue;
                DateTime bitis = (DateTime)timeBitis.EditValue;

                TimeSpan baslangicSaat = baslangic.TimeOfDay;
                TimeSpan bitisSaat = bitis.TimeOfDay;

                // Validasyonlar
                if (bitisSaat <= baslangicSaat)
                {
                    MessageBox.Show("Bitiş saati, başlangıç saatinden sonra olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (randevuTarihi < DateTime.Today)
                {
                    MessageBox.Show("Geçmiş tarih için randevu oluşturamazsınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Çakışma kontrolü
                if (_randevuRepository.HasConflict(_masa.MasaID, randevuTarihi, baslangicSaat, bitisSaat))
                {
                    MessageBox.Show("Seçtiğiniz tarih ve saatte bu masa için başka bir randevu bulunmaktadır.", 
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Randevu oluştur
                var randevu = new Randevu
                {
                    KullaniciID = SessionManager.GetCurrentUserId(),
                    MasaID = _masa.MasaID,
                    RandevuTarihi = randevuTarihi,
                    BaslangicSaati = baslangicSaat,
                    BitisSaati = bitisSaat,
                    Durum = "Beklemede"
                };

                randevu.HesaplaToplamUcret(_masa.SaatlikUcret);

                int randevuId = _randevuRepository.Add(randevu);

                if (randevuId > 0)
                {
                    // Masa durumunu güncelle
                    if (randevuTarihi == DateTime.Today && baslangicSaat > DateTime.Now.TimeOfDay)
                    {
                        _masaRepository.UpdateDurum(_masa.MasaID, "Rezerve");
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Randevu oluşturulurken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// İptal butonu
        /// </summary>
        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

