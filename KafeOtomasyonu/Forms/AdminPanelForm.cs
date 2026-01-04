using System;
using System.Linq;
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
            
            // Grid'leri özelleştir
            GridStiliniAyarla(gridViewKullanicilar);
            GridStiliniAyarla(gridViewMasalar);
            GridStiliniAyarla(gridViewRandevular);
            
            // Dashboard kartlarını güncelle
            GuncelleDashboard();
            
            // İlk sekmeyi yükle
            YukleKullanicilar();
            
            // Sekme değişikliği event'ini bağla
            xtraTabControl1.SelectedPageChanged += XtraTabControl1_SelectedPageChanged;
        }
        
        /// <summary>
        /// Grid stilini ayarla - Zebra desen ve büyük font
        /// </summary>
        private void GridStiliniAyarla(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            // Satır yüksekliği
            gridView.RowHeight = 35;
            
            // Font ayarları
            gridView.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 11F);
            gridView.Appearance.Row.Options.UseFont = true;
            
            // Header font
            gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            gridView.Appearance.HeaderPanel.Options.UseFont = true;
            gridView.Appearance.HeaderPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#2b80c8");
            gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White;
            gridView.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            
            // Zebra deseni - Çift satırlar
            gridView.Appearance.EvenRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#f8f9fa");
            gridView.Appearance.EvenRow.Options.UseBackColor = true;
            
            // Zebra deseni - Tek satırlar
            gridView.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            gridView.Appearance.OddRow.Options.UseBackColor = true;
            
            // Zebra desenini aktif et
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.OptionsView.EnableAppearanceOddRow = true;
            
            // Seçili satır rengi
            gridView.Appearance.FocusedRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#cce5ff");
            gridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            
            // Grid ayarları
            gridView.OptionsView.ColumnAutoWidth = false;
            gridView.OptionsView.ShowGroupPanel = false; // Grup panelini kapat
            
            // Sütunları optimize et
            gridView.BestFitColumns();
        }
        
        /// <summary>
        /// Masa grid'i için özel sütun genişlikleri
        /// </summary>
        private void MasaGridSutunlariAyarla()
        {
            // Önce BestFit yap
            gridViewMasalar.BestFitColumns();
            
            // Sonra belirli sütunları genişlet
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridViewMasalar.Columns)
            {
                switch (col.FieldName)
                {
                    case "Aciklama":
                        col.Width = 200;
                        col.Caption = "📝 Açıklama";
                        break;
                    case "PCOzellikleri":
                        col.Width = 250;
                        col.Caption = "💻 PC Özellikleri";
                        break;
                    case "MasaAdi":
                        col.Width = 120;
                        col.Caption = "🎮 Masa Adı";
                        break;
                    case "MasaNo":
                        col.Width = 80;
                        col.Caption = "No";
                        break;
                    case "MasaID":
                        col.Width = 60;
                        col.Caption = "ID";
                        break;
                    case "SaatlikUcret":
                        col.Width = 100;
                        col.Caption = "💰 Ücret";
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        col.DisplayFormat.FormatString = "{0:C}";
                        break;
                    case "Durum":
                        col.Width = 90;
                        col.Caption = "📊 Durum";
                        break;
                    case "Aktif":
                        col.Width = 60;
                        col.Caption = "✅";
                        break;
                    case "OlusturmaTarihi":
                        col.Width = 110;
                        col.Caption = "📅 Tarih";
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        col.DisplayFormat.FormatString = "dd.MM.yyyy";
                        break;
                    case "PuanOrtalamasi":
                        col.Width = 80;
                        col.Caption = "⭐ Puan";
                        break;
                    case "ToplamPuanSayisi":
                        col.Width = 80;
                        col.Caption = "🔢 Oy";
                        break;
                    case "ResimYolu":
                        col.Visible = false; // Resim yolunu gizle
                        break;
                }
            }
        }
        
        /// <summary>
        /// Kullanıcı grid'i için özel sütun genişlikleri
        /// </summary>
        private void KullaniciGridSutunlariAyarla()
        {
            gridViewKullanicilar.BestFitColumns();
            
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridViewKullanicilar.Columns)
            {
                switch (col.FieldName)
                {
                    case "KullaniciID":
                        col.Width = 60;
                        col.Caption = "ID";
                        break;
                    case "KullaniciAdi":
                        col.Width = 150;
                        col.Caption = "👤 Kullanıcı Adı";
                        break;
                    case "Email":
                        col.Width = 200;
                        col.Caption = "📧 E-posta";
                        break;
                    case "Telefon":
                        col.Width = 130;
                        col.Caption = "📱 Telefon";
                        break;
                    case "KayitTarihi":
                        col.Width = 110;
                        col.Caption = "📅 Kayıt Tarihi";
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        col.DisplayFormat.FormatString = "dd.MM.yyyy";
                        break;
                    case "Aktif":
                        col.Width = 70;
                        col.Caption = "✅ Aktif";
                        break;
                    case "Sifre":
                        col.Visible = false; // Şifreyi gizle
                        break;
                }
            }
        }
        
        /// <summary>
        /// Randevu grid'i için özel sütun genişlikleri
        /// </summary>
        private void RandevuGridSutunlariAyarla()
        {
            gridViewRandevular.BestFitColumns();
            
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridViewRandevular.Columns)
            {
                switch (col.FieldName)
                {
                    case "RandevuID":
                        col.Width = 60;
                        col.Caption = "ID";
                        break;
                    case "KullaniciID":
                        col.Width = 80;
                        col.Caption = "👤 K.ID";
                        break;
                    case "MasaID":
                        col.Width = 80;
                        col.Caption = "🎮 M.ID";
                        break;
                    case "RandevuTarihi":
                        col.Width = 110;
                        col.Caption = "📅 Tarih";
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        col.DisplayFormat.FormatString = "dd.MM.yyyy";
                        break;
                    case "BaslangicSaati":
                        col.Width = 100;
                        col.Caption = "⏰ Başlangıç";
                        break;
                    case "BitisSaati":
                        col.Width = 100;
                        col.Caption = "⏰ Bitiş";
                        break;
                    case "Durum":
                        col.Width = 100;
                        col.Caption = "📊 Durum";
                        break;
                    case "ToplamUcret":
                        col.Width = 100;
                        col.Caption = "💰 Ücret";
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        col.DisplayFormat.FormatString = "{0:C}";
                        break;
                    case "OlusturmaTarihi":
                        col.Width = 110;
                        col.Caption = "📝 Oluşturma";
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        col.DisplayFormat.FormatString = "dd.MM.yyyy";
                        break;
                }
            }
        }
        
        /// <summary>
        /// Dashboard kartlarını güncelle
        /// </summary>
        private void GuncelleDashboard()
        {
            try
            {
                var kullaniciRepo = new Data.KullaniciRepository();
                var masaRepo = new Data.MasaRepository();
                var randevuRepo = new Data.RandevuRepository();
                
                // Toplam kullanıcı sayısı
                var kullanicilar = kullaniciRepo.GetAll();
                lblKullaniciSayi.Text = kullanicilar.Count.ToString();
                
                // Aktif masa sayısı
                var masalar = masaRepo.GetAll();
                lblMasaSayi.Text = masalar.Count.ToString();
                
                // Bugünkü randevu sayısı
                var tumRandevular = randevuRepo.GetAll();
                var bugunRandevular = tumRandevular.Where(r => r.RandevuTarihi.Date == DateTime.Today).ToList();
                lblRandevuSayi.Text = bugunRandevular.Count.ToString();
                
                // Bugünkü toplam gelir
                decimal bugunGelir = bugunRandevular
                    .Where(r => r.Durum == "Onaylandi" || r.Durum == "Tamamlandi")
                    .Sum(r => r.ToplamUcret);
                lblGelirSayi.Text = $"₺{bugunGelir:N0}";
            }
            catch (Exception)
            {
                // Hata durumunda varsayılan değerler
                lblKullaniciSayi.Text = "0";
                lblMasaSayi.Text = "0";
                lblRandevuSayi.Text = "0";
                lblGelirSayi.Text = "₺0";
            }
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
            
            // Sütun genişliklerini ayarla
            KullaniciGridSutunlariAyarla();
        }

        /// <summary>
        /// Masaları yükle
        /// </summary>
        private void YukleMasalar()
        {
            var repo = new Data.MasaRepository();
            gridControlMasalar.DataSource = repo.GetAll();
            
            // Sütun genişliklerini ayarla
            MasaGridSutunlariAyarla();
        }

        /// <summary>
        /// Randevuları yükle
        /// </summary>
        private void YukleRandevular()
        {
            var repo = new Data.RandevuRepository();
            gridControlRandevular.DataSource = repo.GetAll();
            
            // Sütun genişliklerini ayarla
            RandevuGridSutunlariAyarla();
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

