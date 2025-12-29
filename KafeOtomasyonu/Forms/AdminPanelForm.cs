using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KafeOtomasyonu.Helpers;

namespace KafeOtomasyonu.Forms
{
    /// <summary>
    /// Admin yönetim paneli
    /// </summary>
    public partial class AdminPanelForm : XtraForm
    {
        public AdminPanelForm()
        {
            InitializeComponent();
        }

        private void AdminPanelForm_Load(object sender, EventArgs e)
        {
            // Admin bilgilerini göster
            lblHosgeldin.Text = $"Hoş geldiniz, {SessionManager.GetCurrentAdminName()}";
            
            // İlk sekmeyi yükle
            YukleKullanicilar();
            
            // Sekme değişikliği event'ini bağla
            xtraTabControl1.SelectedPageChanged += XtraTabControl1_SelectedPageChanged;
        }

        /// <summary>
        /// Sekme değiştiğinde otomatik yenile
        /// </summary>
        private void XtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == xtraTabPageKullanicilar)
            {
                gridControlKullanicilar.DataSource = null;
                YukleKullanicilar();
            }
            else if (e.Page == xtraTabPageMasalar)
            {
                gridControlMasalar.DataSource = null;
                YukleMasalar();
            }
            else if (e.Page == xtraTabPageRandevular)
            {
                gridControlRandevular.DataSource = null;
                YukleRandevular();
            }
        }

        /// <summary>
        /// Kullanıcıları yükle
        /// </summary>
        private void YukleKullanicilar()
        {
            var repo = new Data.KullaniciRepository();
            gridControlKullanicilar.DataSource = repo.GetAll();
        }

        /// <summary>
        /// Masaları yükle
        /// </summary>
        private void YukleMasalar()
        {
            var repo = new Data.MasaRepository();
            gridControlMasalar.DataSource = repo.GetAll();
        }

        /// <summary>
        /// Randevuları yükle
        /// </summary>
        private void YukleRandevular()
        {
            var repo = new Data.RandevuRepository();
            gridControlRandevular.DataSource = repo.GetAll();
        }

        /// <summary>
        /// Kullanıcı blokla butonu
        /// </summary>
        private void btnBlokla_Click(object sender, EventArgs e)
        {
            var view = gridViewKullanicilar;
            if (view.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Lütfen bir kullanıcı seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int kullaniciId = Convert.ToInt32(view.GetFocusedRowCellValue("KullaniciID"));
            bool bloklu = Convert.ToBoolean(view.GetFocusedRowCellValue("Bloklu"));

            if (bloklu)
            {
                XtraMessageBox.Show("Bu kullanıcı zaten bloklu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string neden = XtraInputBox.Show("Blok nedeni:", "Kullanıcıyı Blokla", "");
            if (string.IsNullOrWhiteSpace(neden))
                return;

            var repo = new Data.KullaniciRepository();
            repo.BloklaKullanici(kullaniciId, neden);

            XtraMessageBox.Show("Kullanıcı bloklandı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gridControlKullanicilar.DataSource = null;
            YukleKullanicilar();
        }

        /// <summary>
        /// Kullanıcı bloktan çıkar butonu
        /// </summary>
        private void btnBloktanCikar_Click(object sender, EventArgs e)
        {
            var view = gridViewKullanicilar;
            if (view.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Lütfen bir kullanıcı seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int kullaniciId = Convert.ToInt32(view.GetFocusedRowCellValue("KullaniciID"));
            bool bloklu = Convert.ToBoolean(view.GetFocusedRowCellValue("Bloklu"));

            if (!bloklu)
            {
                XtraMessageBox.Show("Bu kullanıcı zaten bloklu değil!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var repo = new Data.KullaniciRepository();
            repo.BlokKaldir(kullaniciId);

            XtraMessageBox.Show("Kullanıcı bloktan çıkarıldı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gridControlKullanicilar.DataSource = null;
            YukleKullanicilar();
        }

        /// <summary>
        /// Randevu onayla butonu
        /// </summary>
        private void btnOnayRandevu_Click(object sender, EventArgs e)
        {
            var view = gridViewRandevular;
            if (view.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Lütfen bir randevu seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int randevuId = Convert.ToInt32(view.GetFocusedRowCellValue("RandevuID"));
            string durum = view.GetFocusedRowCellValue("Durum").ToString();

            if (durum != "Beklemede")
            {
                XtraMessageBox.Show("Sadece beklemedeki randevular onaylanabilir!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var repo = new Data.RandevuRepository();
            repo.UpdateDurum(randevuId, "Onaylandi");

            XtraMessageBox.Show("Randevu onaylandı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gridControlRandevular.DataSource = null;
            YukleRandevular();
        }

        /// <summary>
        /// Randevu iptal butonu
        /// </summary>
        private void btnIptalRandevu_Click(object sender, EventArgs e)
        {
            var view = gridViewRandevular;
            if (view.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Lütfen bir randevu seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int randevuId = Convert.ToInt32(view.GetFocusedRowCellValue("RandevuID"));

            string neden = XtraInputBox.Show("İptal nedeni:", "Randevuyu İptal Et", "");
            if (string.IsNullOrWhiteSpace(neden))
                return;

            var repo = new Data.RandevuRepository();
            repo.IptalEt(randevuId, neden);

            XtraMessageBox.Show("Randevu iptal edildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gridControlRandevular.DataSource = null;
            YukleRandevular();
        }

        /// <summary>
        /// Masa durumu değiştir butonu
        /// </summary>
        private void btnDurumDegistir_Click(object sender, EventArgs e)
        {
            var view = gridViewMasalar;
            if (view.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Lütfen bir masa seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int masaId = Convert.ToInt32(view.GetFocusedRowCellValue("MasaID"));
            string mevcutDurum = view.GetFocusedRowCellValue("Durum").ToString();

            // Basit dialog
            string secim = XtraInputBox.Show(
                $"Mevcut durum: {mevcutDurum}\n\nYeni durumu yazın (Bos/Bakim/Dolu/Rezerve):",
                "Masa Durumu Değiştir",
                "Bakim"
            );

            if (string.IsNullOrWhiteSpace(secim))
                return;

            var repo = new Data.MasaRepository();
            repo.UpdateDurum(masaId, secim);

            XtraMessageBox.Show("Masa durumu değiştirildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gridControlMasalar.DataSource = null;
            YukleMasalar();
        }

        /// <summary>
        /// Yenile butonları
        /// </summary>
        private void btnYenileKullanici_Click(object sender, EventArgs e)
        {
            gridControlKullanicilar.DataSource = null;
            YukleKullanicilar();
        }

        private void btnYenileMasa_Click(object sender, EventArgs e)
        {
            gridControlMasalar.DataSource = null;
            YukleMasalar();
        }

        private void btnYenileRandevu_Click(object sender, EventArgs e)
        {
            gridControlRandevular.DataSource = null;
            YukleRandevular();
        }

        /// <summary>
        /// Çıkış butonu
        /// </summary>
        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Çıkış",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SessionManager.LogoutAll();
                Application.Exit();
            }
        }
    }
}

