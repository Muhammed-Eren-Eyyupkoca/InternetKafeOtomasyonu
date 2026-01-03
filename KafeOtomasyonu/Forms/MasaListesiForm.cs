using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using KafeOtomasyonu.Data;
using KafeOtomasyonu.Helpers;
using KafeOtomasyonu.Models;

namespace KafeOtomasyonu.Forms
{
    public partial class MasaListesiForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly MasaRepository _masaRepository;
        private readonly RandevuRepository _randevuRepository;
        private List<Masa> _masalar;
        private Timer _refreshTimer;

        public MasaListesiForm()
        {
            InitializeComponent();
            _masaRepository = new MasaRepository();
            _randevuRepository = new RandevuRepository();
            
            _refreshTimer = new Timer();
            _refreshTimer.Interval = 30000;
            _refreshTimer.Tick += RefreshTimer_Tick;
            _refreshTimer.Start();
        }
        
        private void MasaListesiForm_Load(object sender, EventArgs e)
        {
            lblHosgeldin.Text = $"Hoş geldiniz, {SessionManager.GetCurrentUserFullName()}";
            MasalariYukle();
            MasaPanelleriniOlustur();
        }

        private void panelMasalar_Paint(object sender, PaintEventArgs e)
        {
            string watermarkText = "İnternet Kafe";
            using (Font watermarkFont = new Font("Segoe UI", 120, FontStyle.Bold))
            {
                Color watermarkColor = ColorTranslator.FromHtml("#f6f6f2");
                Color transparentColor = Color.FromArgb(15, watermarkColor.R, watermarkColor.G, watermarkColor.B);
                
                using (SolidBrush brush = new SolidBrush(transparentColor))
                {
                    SizeF textSize = e.Graphics.MeasureString(watermarkText, watermarkFont);
                    float x = (panelMasalar.Width - textSize.Width) / 2;
                    float y = (panelMasalar.Height - textSize.Height) / 2;
                    
                    e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    e.Graphics.DrawString(watermarkText, watermarkFont, brush, x, y);
                }
            }
        }

        private void MasalariYukle()
        {
            _masalar = _masaRepository.GetAll();
            
            if (_masalar.Count < 25)
            {
                MasalariOlustur();
                _masalar = _masaRepository.GetAll();
            }

            MasaDurumlariniGuncelle();
        }

        private void MasalariOlustur()
        {
            int mevcutMasaSayisi = _masalar?.Count ?? 0;
            
            for (int i = mevcutMasaSayisi + 1; i <= 25; i++)
            {
                string pcOzellik;
                decimal ucret;
                string aciklama;
                
                if (i == 7 || i == 8 || i == 17 || i == 18 || i == 23)
                {
                    pcOzellik = "Intel Core i9, RTX 3080, 32GB RAM, 240Hz Monitor";
                    ucret = 20.00m;
                    aciklama = "VIP Masa - Yüksek Performans";
                }
                else if (i == 3 || i == 4 || i == 13 || i == 14 || i >= 21)
                {
                    pcOzellik = "Intel Core i7, RTX 3070, 32GB RAM, 165Hz Monitor";
                    ucret = 18.00m;
                    aciklama = "Premium Masa";
                }
                else
                {
                    pcOzellik = "Intel Core i5, RTX 3060, 16GB RAM, 144Hz Monitor";
                    ucret = 15.00m;
                    aciklama = "Standart Gaming Masa";
                }

                var masa = new Masa
                {
                    MasaNo = i,
                    MasaAdi = $"Masa {i}",
                    SaatlikUcret = ucret,
                    Durum = "Bos",
                    Aciklama = aciklama,
                    PCOzellikleri = pcOzellik,
                    ResimYolu = null,
                    Aktif = true
                };
                _masaRepository.Add(masa);
            }
        }

        private void MasaDurumlariniGuncelle()
        {
            var aktifRandevular = _randevuRepository.GetAktifRandevular();
            var bugun = DateTime.Today;
            var simdi = DateTime.Now.TimeOfDay;

            foreach (var masa in _masalar)
            {
                var masaRandevulari = aktifRandevular.Where(r => r.MasaID == masa.MasaID && r.RandevuTarihi.Date == bugun).ToList();

                if (masaRandevulari.Any())
                {
                    var aktifRandevu = masaRandevulari.FirstOrDefault(r => 
                        r.BaslangicSaati <= simdi && r.BitisSaati > simdi && r.Durum == "Onaylandi");

                    if (aktifRandevu != null)
                    {
                        if (masa.Durum != "Dolu")
                        {
                            _masaRepository.UpdateDurum(masa.MasaID, "Dolu");
                            masa.Durum = "Dolu";
                        }
                    }
                    else
                    {
                        var gelecekRandevu = masaRandevulari.FirstOrDefault(r => 
                            r.BaslangicSaati > simdi && (r.Durum == "Onaylandi" || r.Durum == "Beklemede"));

                        if (gelecekRandevu != null)
                        {
                            if (masa.Durum != "Rezerve")
                            {
                                _masaRepository.UpdateDurum(masa.MasaID, "Rezerve");
                                masa.Durum = "Rezerve";
                            }
                        }
                        else if (masa.Durum != "Bos" && masa.Durum != "Bakim")
                        {
                            _masaRepository.UpdateDurum(masa.MasaID, "Bos");
                            masa.Durum = "Bos";
                        }
                    }
                }
                else if (masa.Durum != "Bos" && masa.Durum != "Bakim")
                {
                    _masaRepository.UpdateDurum(masa.MasaID, "Bos");
                    masa.Durum = "Bos";
                }
            }
        }

        private void MasaPanelleriniOlustur()
        {
            panelMasalar.Controls.Clear();

            if (_masalar == null || _masalar.Count < 25)
            {
                if (_masalar == null || _masalar.Count == 0)
                    return;
            }

            int panelGenislik = 140;
            int panelYukseklik = 120;
            int bosluk = 15;

            int ustBaslangicX = 150;
            for (int i = 0; i < 10 && i < _masalar.Count; i++)
            {
                var masa = _masalar[i];
                var panel = MasaPaneliOlustur(masa, panelGenislik, panelYukseklik);
                panel.Location = new Point(ustBaslangicX + (i * (panelGenislik + bosluk)), 20);
                panelMasalar.Controls.Add(panel);
            }

            int altY = panelMasalar.Height - panelYukseklik - 20;
            for (int i = 10; i < 20 && i < _masalar.Count; i++)
            {
                var masa = _masalar[i];
                var panel = MasaPaneliOlustur(masa, panelGenislik, panelYukseklik);
                panel.Location = new Point(ustBaslangicX + ((i - 10) * (panelGenislik + bosluk)), altY);
                panelMasalar.Controls.Add(panel);
            }

            int sagX = panelMasalar.Width - panelGenislik - 20;
            int ortaBaslangicY = (panelMasalar.Height - (5 * panelYukseklik + 4 * bosluk)) / 2;
            
            for (int i = 20; i < 25 && i < _masalar.Count; i++)
            {
                var masa = _masalar[i];
                var panel = MasaPaneliOlustur(masa, panelGenislik, panelYukseklik);
                panel.Location = new Point(sagX, ortaBaslangicY + ((i - 20) * (panelYukseklik + bosluk)));
                panelMasalar.Controls.Add(panel);
            }
        }

        private Panel MasaPaneliOlustur(Masa masa, int genislik, int yukseklik)
        {
            Panel panel = new Panel
            {
                Size = new Size(genislik, yukseklik),
                BackColor = masa.GetDurumRengi(),
                BorderStyle = BorderStyle.None,
                Cursor = Cursors.Hand,
                Tag = masa
            };

            Label lblMasaNo = new Label
            {
                Text = $"Masa {masa.MasaNo}",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                Size = new Size(genislik - 10, 30),
                Location = new Point(5, 8),
                TextAlign = ContentAlignment.MiddleCenter
            };

            string yildizlar = YildizMetniOlustur(masa.PuanOrtalamasi);
            Label lblPuan = new Label
            {
                Text = yildizlar + $" ({masa.PuanOrtalamasi:F1})",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.White,
                AutoSize = false,
                Size = new Size(genislik - 10, 22),
                Location = new Point(5, 42),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblDurum = new Label
            {
                Text = GetDurumMetni(masa.Durum),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                Size = new Size(genislik - 10, 20),
                Location = new Point(5, 70),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblUcret = new Label
            {
                Text = $"{masa.SaatlikUcret:C}/saat",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                ForeColor = Color.White,
                AutoSize = false,
                Size = new Size(genislik - 10, 18),
                Location = new Point(5, 95),
                TextAlign = ContentAlignment.MiddleCenter
            };

            panel.Controls.Add(lblMasaNo);
            panel.Controls.Add(lblPuan);
            panel.Controls.Add(lblDurum);
            panel.Controls.Add(lblUcret);

            // MASA TIKLANDIGINDA RANDEVU DIALOG ACILIR
            panel.Click += (s, e) => AcRandevuDialog(masa);
            foreach (Control ctrl in panel.Controls)
            {
                ctrl.Click += (s, e) => AcRandevuDialog(masa);
            }

            panel.MouseEnter += (s, e) =>
            {
                panel.BackColor = AjustarBrilho(masa.GetDurumRengi(), 1.15f);
            };
            panel.MouseLeave += (s, e) =>
            {
                panel.BackColor = masa.GetDurumRengi();
            };

            return panel;
        }

        // MASA DETAY FORMU AÇAR
        private void AcRandevuDialog(Masa masa)
        {
            using (var detayForm = new MasaDetayForm(masa))
            {
                if (detayForm.ShowDialog() == DialogResult.OK)
                {
                    MasalariYukle();
                    MasaPanelleriniOlustur();
                }
            }
        }

        private Color AjustarBrilho(Color cor, float fator)
        {
            int r = Math.Min(255, (int)(cor.R * fator));
            int g = Math.Min(255, (int)(cor.G * fator));
            int b = Math.Min(255, (int)(cor.B * fator));
            return Color.FromArgb(cor.A, r, g, b);
        }

        private string YildizMetniOlustur(decimal puan)
        {
            if (puan == 0)
                return "☆☆☆☆☆";

            int tamYildiz = (int)Math.Floor(puan);
            bool yarimYildiz = (puan - tamYildiz) >= 0.5m;

            string yildizlar = "";
            for (int i = 0; i < tamYildiz; i++)
                yildizlar += "★";
            
            if (yarimYildiz && tamYildiz < 5)
                yildizlar += "⯨";
            
            int bosYildiz = 5 - tamYildiz - (yarimYildiz ? 1 : 0);
            for (int i = 0; i < bosYildiz; i++)
                yildizlar += "☆";

            return yildizlar;
        }

        private string GetDurumMetni(string durum)
        {
            switch (durum)
            {
                case "Bos": return "BOŞ";
                case "Dolu": return "DOLU";
                case "Rezerve": return "REZERVE";
                case "Bakim": return "BAKIM";
                default: return durum.ToUpper();
            }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            MasalariYukle();
            MasaPanelleriniOlustur();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            MasalariYukle();
            MasaPanelleriniOlustur();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Çıkış", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SessionManager.LogoutAll();
                Application.Exit();
            }
        }

        private void btnRandevularim_Click(object sender, EventArgs e)
        {
            using (var randevularimForm = new RandevularimForm())
            {
                randevularimForm.ShowDialog();
                MasalariYukle();
                MasaPanelleriniOlustur();
            }
        }

        private void btnProfil_Click(object sender, EventArgs e)
        {
            using (var profilForm = new ProfilForm())
            {
                profilForm.ShowDialog();
                lblHosgeldin.Text = $"Hoş geldiniz, {SessionManager.GetCurrentUserFullName()}";
            }
        }

        private void btnIstatistik_Click(object sender, EventArgs e)
        {
            using (var dashboardForm = new DashboardForm())
            {
                dashboardForm.ShowDialog();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _refreshTimer?.Stop();
            _refreshTimer?.Dispose();
        }
    }
}
