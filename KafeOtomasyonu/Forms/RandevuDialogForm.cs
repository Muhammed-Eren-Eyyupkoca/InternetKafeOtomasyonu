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
        private const decimal SAATLIK_UCRET = 75m; // Saatlik ücret 75 TL

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
            lblSaatlikUcret.Text = $"Saatlik Ücret: {SAATLIK_UCRET:C}";

            // Tarih seçiciyi ayarla - bugünden itibaren seçilebilir
            dateRandevu.Properties.MinValue = DateTime.Today;
            dateRandevu.EditValue = DateTime.Today;

            // Başlangıç saati ayarla
            timeBaslangic.Properties.EditFormat.FormatString = "HH:mm";
            timeBaslangic.Properties.DisplayFormat.FormatString = "HH:mm";
            timeBaslangic.Properties.Mask.EditMask = "HH:mm";
            timeBaslangic.EditValue = DateTime.Today.AddHours(9); // 09:00

            // Saat seçiciyi ayarla (1-12 saat arası)
            spinSaat.Properties.MinValue = 1;
            spinSaat.Properties.MaxValue = 12;
            spinSaat.EditValue = 3; // Varsayılan 3 saat

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
        /// Saat sayısı değiştiğinde
        /// </summary>
        private void spinSaat_EditValueChanged(object sender, EventArgs e)
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
                if (timeBaslangic.EditValue == null || spinSaat.EditValue == null)
                    return;

                int saatSayisi = Convert.ToInt32(spinSaat.EditValue);
                decimal toplamUcret = saatSayisi * SAATLIK_UCRET;

                lblToplamUcret.Text = $"Süre: {saatSayisi} saat - Toplam Ücret: {toplamUcret:C}";
                lblToplamUcret.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception)
            {
                lblToplamUcret.Text = "Geçerli değer giriniz";
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

                if (timeBaslangic.EditValue == null)
                {
                    MessageBox.Show("Lütfen başlangıç saatini giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (spinSaat.EditValue == null)
                {
                    MessageBox.Show("Lütfen kaç saat kullanacağınızı seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime randevuTarihi = ((DateTime)dateRandevu.EditValue).Date;
                DateTime baslangic = (DateTime)timeBaslangic.EditValue;
                int saatSayisi = Convert.ToInt32(spinSaat.EditValue);

                TimeSpan baslangicSaat = baslangic.TimeOfDay;
                TimeSpan bitisSaat = baslangicSaat.Add(TimeSpan.FromHours(saatSayisi));

                // Validasyonlar
                if (randevuTarihi < DateTime.Today)
                {
                    MessageBox.Show("Geçmiş tarih için randevu oluşturamazsınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Bitiş saati 24 saati geçiyorsa
                if (bitisSaat.TotalHours >= 24)
                {
                    MessageBox.Show("Randevu bitiş saati gece yarısını geçemez. Lütfen daha az saat seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Bugün için geçmiş saat kontrolü
                if (randevuTarihi == DateTime.Today && baslangicSaat < DateTime.Now.TimeOfDay)
                {
                    MessageBox.Show("Geçmiş saat için randevu oluşturamazsınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                randevu.HesaplaToplamUcret(SAATLIK_UCRET);

                int randevuId = _randevuRepository.Add(randevu);

                if (randevuId > 0)
                {
                    // Masa durumunu güncelle
                    if (randevuTarihi == DateTime.Today && baslangicSaat > DateTime.Now.TimeOfDay)
                    {
                        _masaRepository.UpdateDurum(_masa.MasaID, "Rezerve");
                    }

                    MessageBox.Show($"Randevu başarıyla oluşturuldu!\n\nTarih: {randevuTarihi:dd.MM.yyyy}\nSaat: {baslangicSaat:hh\\:mm} - {bitisSaat:hh\\:mm}\nSüre: {saatSayisi} saat\nToplam Ücret: {randevu.ToplamUcret:C}", 
                        "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

