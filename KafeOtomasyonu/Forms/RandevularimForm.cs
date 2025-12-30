using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KafeOtomasyonu.Data;
using KafeOtomasyonu.Helpers;
using KafeOtomasyonu.Models;

namespace KafeOtomasyonu.Forms
{
    public partial class RandevularimForm : XtraForm
    {
        private RandevuRepository _randevuRepo;
        private DegerlendirmeRepository _degerlendirmeRepo;
        private int _kullaniciId;
        private FlowLayoutPanel flowPanel;

        public RandevularimForm()
        {
            InitializeComponent();
            _randevuRepo = new RandevuRepository();
            _degerlendirmeRepo = new DegerlendirmeRepository();
            _kullaniciId = SessionManager.GetCurrentUserId();
            
            this.Load += RandevularimForm_Load;
        }

        private void RandevularimForm_Load(object sender, EventArgs e)
        {
            // Ana panel
            flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(20),
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };
            this.Controls.Add(flowPanel);

            RandevulariYukle();
        }

        private void RandevulariYukle()
        {
            flowPanel.Controls.Clear();
            var randevular = _randevuRepo.GetByKullaniciId(_kullaniciId);

            // Başlık
            Label lblBaslik = new Label
            {
                Text = $"📅 RANDEVULARIM ({randevular.Count})",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 20)
            };
            flowPanel.Controls.Add(lblBaslik);

            if (randevular.Count == 0)
            {
                Label lblBos = new Label
                {
                    Text = "Henüz randevunuz bulunmuyor.",
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.Gray,
                    AutoSize = true
                };
                flowPanel.Controls.Add(lblBos);
                return;
            }

            // Randevuları listele
            foreach (var randevu in randevular.OrderBy(r => r.RandevuTarihi).ThenBy(r => r.BaslangicSaati))
            {
                Panel randevuPanel = OlusturRandevuPanel(randevu);
                flowPanel.Controls.Add(randevuPanel);
            }
        }

        private Panel OlusturRandevuPanel(Randevu randevu)
        {
            Panel panel = new Panel
            {
                Width = 850,
                Height = 120,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 15),
                BackColor = Color.White
            };

            // Durum rengine göre sol border
            Panel leftBorder = new Panel
            {
                Width = 5,
                Height = 120,
                Dock = DockStyle.Left,
                BackColor = (randevu.Durum == "Aktif" || randevu.Durum == "Onaylandi") ? Color.FromArgb(76, 175, 80) :
                           (randevu.Durum == "Iptal" || randevu.Durum == "IptalEdildi") ? Color.FromArgb(244, 67, 54) :
                           Color.FromArgb(158, 158, 158)
            };
            panel.Controls.Add(leftBorder);

            // Bilgi alanı
            Label lblBilgi = new Label
            {
                Location = new Point(20, 15),
                Width = 600,
                Height = 90,
                Font = new Font("Segoe UI", 10),
                Text = $"🖥️  {randevu.MasaAdi}\n" +
                       $"📅  {randevu.RandevuTarihi:dd MMMM yyyy (dddd)}\n" +
                       $"🕐  {randevu.BaslangicSaati:hh\\:mm} - {randevu.BitisSaati:hh\\:mm} ({randevu.ToplamSaat} saat)\n" +
                       $"💰  {randevu.ToplamUcret:C}   |   📊 Durum: {randevu.Durum}"
            };
            panel.Controls.Add(lblBilgi);

            // Butonlar
            string durumLower = randevu.Durum?.ToLower() ?? "";
            bool iptalEdilmis = durumLower.Contains("iptal") || durumLower.Contains("gelmedi");
            bool tamamlanmis = durumLower.Contains("tamamlan");
            
            // Aktif randevular için Düzenle ve İptal butonları
            if (!iptalEdilmis && !tamamlanmis)
            {
                SimpleButton btnDuzenle = new SimpleButton
                {
                    Text = "✏️ Düzenle",
                    Location = new Point(650, 25),
                    Size = new Size(90, 32),
                    Appearance = { BackColor = Color.FromArgb(33, 150, 243), Font = new Font("Segoe UI", 9, FontStyle.Bold) }
                };
                btnDuzenle.Appearance.Options.UseBackColor = true;
                btnDuzenle.Appearance.Options.UseFont = true;
                btnDuzenle.Click += (s, e) => DuzenleRandevu(randevu);
                panel.Controls.Add(btnDuzenle);

                SimpleButton btnIptal = new SimpleButton
                {
                    Text = "❌ İptal",
                    Location = new Point(650, 65),
                    Size = new Size(90, 32),
                    Appearance = { BackColor = Color.FromArgb(244, 67, 54), Font = new Font("Segoe UI", 9, FontStyle.Bold) }
                };
                btnIptal.Appearance.Options.UseBackColor = true;
                btnIptal.Appearance.Options.UseFont = true;
                btnIptal.Click += (s, e) => IptalEtRandevu(randevu);
                panel.Controls.Add(btnIptal);
            }

            // Tamamlanmış randevular için Değerlendirme butonu
            if (tamamlanmis)
            {
                // Daha önce değerlendirilmiş mi kontrol et
                bool degerlendirilebilir = !_degerlendirmeRepo.HasDegerlendirme(randevu.RandevuID);

                SimpleButton btnDegerlendir = new SimpleButton
                {
                    Text = degerlendirilebilir ? "⭐ Değerlendir" : "✅ Değerlendirildi",
                    Location = new Point(650, 40),
                    Size = new Size(120, 35),
                    Appearance = { 
                        BackColor = degerlendirilebilir ? Color.FromArgb(255, 193, 7) : Color.FromArgb(158, 158, 158), 
                        Font = new Font("Segoe UI", 9, FontStyle.Bold) 
                    },
                    Enabled = degerlendirilebilir
                };
                btnDegerlendir.Appearance.Options.UseBackColor = true;
                btnDegerlendir.Appearance.Options.UseFont = true;
                
                if (degerlendirilebilir)
                {
                    btnDegerlendir.Click += (s, e) => DegerlendirmeYap(randevu);
                }
                
                panel.Controls.Add(btnDegerlendir);
            }

            return panel;
        }

        private void DuzenleRandevu(Randevu randevu)
        {
            using (var duzenleForm = new RandevuDuzenleForm(randevu))
            {
                if (duzenleForm.ShowDialog() == DialogResult.OK)
                {
                    RandevulariYukle();
                }
            }
        }

        private void IptalEtRandevu(Randevu randevu)
        {
            var sonuc = MessageBox.Show(
                $"'{randevu.MasaAdi}' için {randevu.RandevuTarihi:dd.MM.yyyy} tarihli randevunuzu iptal etmek istediğinize emin misiniz?",
                "Randevu İptal",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (sonuc == DialogResult.Yes)
            {
                try
                {
                    _randevuRepo.IptalEt(randevu.RandevuID);
                    MessageBox.Show("Randevunuz başarıyla iptal edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RandevulariYukle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DegerlendirmeYap(Randevu randevu)
        {
            using (var degerlendirmeForm = new DegerlendirmeYapForm(randevu))
            {
                if (degerlendirmeForm.ShowDialog() == DialogResult.OK)
                {
                    RandevulariYukle(); // Listeyi yenile (Değerlendirildi durumu için)
                }
            }
        }
    }
}
