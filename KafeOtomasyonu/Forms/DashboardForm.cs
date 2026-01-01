using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KafeOtomasyonu.Data;
using KafeOtomasyonu.Helpers;

namespace KafeOtomasyonu.Forms
{
    public partial class DashboardForm : XtraForm
    {
        private readonly RandevuRepository _randevuRepository;
        private readonly DegerlendirmeRepository _degerlendirmeRepository;

        public DashboardForm()
        {
            InitializeComponent();
            _randevuRepository = new RandevuRepository();
            _degerlendirmeRepository = new DegerlendirmeRepository();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            this.Text = "İstatistiklerim";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeUI();
            LoadStatistics();
        }

        private void InitializeUI()
        {
            // Ana panel - Soft grey background
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ColorTranslator.FromHtml("#e5e5e5"), // Background grey
                Padding = new Padding(20)
            };
            this.Controls.Add(mainPanel);

            // Başlık - Vintage turkuaz
            LabelControl lblBaslik = new LabelControl
            {
                Text = "📊 İSTATİSTİKLERİM",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml("#559f9e"), // Vintage turkuaz
                Location = new Point(20, 20),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(840, 50)
            };
            mainPanel.Controls.Add(lblBaslik);

            CreateUserDashboard(mainPanel);
        }

        private void CreateUserDashboard(Panel mainPanel)
        {
            int yPos = 90;
            int cardHeight = 100;
            int cardWidth = 400;
            int spacing = 20;

            // Toplam Randevu Sayısı - Mavi
            CreateStatCard(mainPanel, "🎫 Toplam Randevu", "0", 
                ColorTranslator.FromHtml("#2b80c8"), // Text blue
                new Point(20, yPos), cardWidth, cardHeight, "lblToplamRandevu");

            CreateStatCard(mainPanel, "💰 Toplam Harcama", "0 ₺", 
                ColorTranslator.FromHtml("#c82b6d"), // Error pink-red
                new Point(20 + cardWidth + spacing, yPos), cardWidth, cardHeight, "lblToplamHarcama");

            yPos += cardHeight + spacing;

            // En Çok Kullanılan Masa
            CreateStatCard(mainPanel, "⭐ Favori Masa", "Henüz yok", 
                ColorTranslator.FromHtml("#ceb951"), // Warning gold
                new Point(20, yPos), cardWidth, cardHeight, "lblFavoriMasa");

            CreateStatCard(mainPanel, "⏱️ Ort. Kullanım Süresi", "0 saat", 
                ColorTranslator.FromHtml("#559f9e"), // Vintage turkuaz
                new Point(20 + cardWidth + spacing, yPos), cardWidth, cardHeight, "lblOrtSure");

            yPos += cardHeight + spacing;

            // Verdiği Ortalama Puan
            CreateStatCard(mainPanel, "⭐ Verdiğim Ort. Puan", "0.0", 
                ColorTranslator.FromHtml("#55a586"), // Success green
                new Point(20, yPos), cardWidth, cardHeight, "lblOrtPuan");

            // Bilgi notu - Secondary color
            LabelControl lblNot = new LabelControl
            {
                Text = "💡 İstatistikleriniz sadece onaylanan ve tamamlanan randevularınıza göre hesaplanır.",
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = ColorTranslator.FromHtml("#b0b9d1"), // Secondary mavi-gri
                Location = new Point(20, yPos + cardHeight + spacing),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(840, 40),
                Appearance = { TextOptions = { WordWrap = DevExpress.Utils.WordWrap.Wrap } }
            };
            mainPanel.Controls.Add(lblNot);
        }

        private void CreateStatCard(Panel parent, string title, string value, Color bgColor, 
            Point location, int width, int height, string valueLabelName)
        {
            Panel card = new Panel
            {
                Size = new Size(width, height),
                Location = location,
                BackColor = bgColor,
                BorderStyle = BorderStyle.None
            };

            // Başlık
            LabelControl lblTitle = new LabelControl
            {
                Text = title,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 15),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(width - 30, 25)
            };

            // Değer
            LabelControl lblValue = new LabelControl
            {
                Name = valueLabelName,
                Text = value,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 45),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(width - 30, 40)
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblValue);
            parent.Controls.Add(card);
        }

        private void LoadStatistics()
        {
            LoadUserStatistics();
        }

        private void LoadUserStatistics()
        {
            int kullaniciId = SessionManager.GetCurrentUserId();

            try
            {
                // Toplam randevu sayısı
                int toplamRandevu = _randevuRepository.GetKullaniciToplamRandevuSayisi(kullaniciId);
                SetLabelText("lblToplamRandevu", toplamRandevu.ToString());

                // Toplam harcama
                decimal toplamHarcama = _randevuRepository.GetKullaniciToplamHarcama(kullaniciId);
                SetLabelText("lblToplamHarcama", $"{toplamHarcama:N2} ₺");

                // En çok kullanılan masa
                var (masaId, masaAdi, kullanimSayisi) = _randevuRepository.GetKullaniciEnCokKullanilanMasa(kullaniciId);
                SetLabelText("lblFavoriMasa", masaAdi);

                // Ortalama kullanım süresi
                decimal ortSure = _randevuRepository.GetKullaniciOrtalamaKullanimSuresi(kullaniciId);
                SetLabelText("lblOrtSure", $"{ortSure:F1} saat");

                // Verdiği ortalama puan
                decimal ortPuan = _degerlendirmeRepository.GetKullaniciOrtalamaPuan(kullaniciId);
                SetLabelText("lblOrtPuan", ortPuan > 0 ? $"{ortPuan:F1} ⭐" : "Henüz değerlendirme yok");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"İstatistikler yüklenirken hata oluştu:\n{ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetLabelText(string labelName, string text)
        {
            var label = FindControl<LabelControl>(this, labelName);
            if (label != null)
            {
                label.Text = text;
            }
        }

        private T FindControl<T>(Control parent, string name) where T : Control
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl.Name == name && ctrl is T)
                    return ctrl as T;

                if (ctrl.HasChildren)
                {
                    var found = FindControl<T>(ctrl, name);
                    if (found != null)
                        return found;
                }
            }
            return null;
        }
    }
}
