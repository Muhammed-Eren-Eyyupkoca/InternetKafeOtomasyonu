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
    /// <summary>
    /// Kafe masalarını görsel olarak gösteren ana form
    /// </summary>
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
            
            // Otomatik yenileme timer'ı
            _refreshTimer = new Timer();
            _refreshTimer.Interval = 30000; // 30 saniyede bir
            _refreshTimer.Tick += RefreshTimer_Tick;
            _refreshTimer.Start();
        }

        private void MasaListesiForm_Load(object sender, EventArgs e)
        {
            lblHosgeldin.Text = $"Hoş geldiniz, {SessionManager.GetCurrentUserFullName()}";
            MasalariYukle();
            MasaPanelleriniOlustur();
        }

        /// <summary>
        /// Masaları veritabanından yükle ve durumlarını güncelle
        /// </summary>
        private void MasalariYukle()
        {
            _masalar = _masaRepository.GetAll();
            
            // Eğer 25 masa yoksa, eksik masaları oluştur
            if (_masalar.Count < 25)
            {
                MasalariOlustur();
                _masalar = _masaRepository.GetAll();
            }

            // Masa durumlarını randevulara göre güncelle
            MasaDurumlariniGuncelle();
        }

        /// <summary>
        /// İlk kurulumda 25 masayı oluştur (veya eksik masaları tamamla)
        /// </summary>
        private void MasalariOlustur()
        {
            // Mevcut en yüksek masa numarasını bul
            int mevcutMasaSayisi = _masalar?.Count ?? 0;
            
            // 25 masaya tamamla
            for (int i = mevcutMasaSayisi + 1; i <= 25; i++)
            {
                // PC özellikleri masa numarasına göre değişsin
                string pcOzellik;
                decimal ucret;
                string aciklama;
                
                if (i == 7 || i == 8 || i == 17 || i == 18 || i == 23)
                {
                    // VIP masalar
                    pcOzellik = "Intel Core i9, RTX 3080, 32GB RAM, 240Hz Monitor";
                    ucret = 20.00m;
                    aciklama = "VIP Masa - Yüksek Performans";
                }
                else if (i == 3 || i == 4 || i == 13 || i == 14 || i >= 21)
                {
                    // Premium masalar
                    pcOzellik = "Intel Core i7, RTX 3070, 32GB RAM, 165Hz Monitor";
                    ucret = 18.00m;
                    aciklama = "Premium Masa";
                }
                else
                {
                    // Standart masalar
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

        /// <summary>
        /// Masa durumlarını aktif randevulara göre güncelle
        /// </summary>
        private void MasaDurumlariniGuncelle()
        {
            var aktifRandevular = _randevuRepository.GetAktifRandevular();
            var bugun = DateTime.Today;
            var simdi = DateTime.Now.TimeOfDay;

            foreach (var masa in _masalar)
            {
                // Bu masanın bugün için randevularını kontrol et
                var masaRandevulari = aktifRandevular.Where(r => r.MasaID == masa.MasaID && r.RandevuTarihi.Date == bugun).ToList();

                if (masaRandevulari.Any())
                {
                    // Şu anda aktif olan randevu var mı?
                    var aktifRandevu = masaRandevulari.FirstOrDefault(r => 
                        r.BaslangicSaati <= simdi && r.BitisSaati > simdi && r.Durum == "Onaylandi");

                    if (aktifRandevu != null)
                    {
                        // Masa şu anda dolu
                        if (masa.Durum != "Dolu")
                        {
                            _masaRepository.UpdateDurum(masa.MasaID, "Dolu");
                            masa.Durum = "Dolu";
                        }
                    }
                    else
                    {
                        // Gelecekte randevu var mı?
                        var gelecekRandevu = masaRandevulari.FirstOrDefault(r => 
                            r.BaslangicSaati > simdi && (r.Durum == "Onaylandi" || r.Durum == "Beklemede"));

                        if (gelecekRandevu != null)
                        {
                            // Masa rezerve
                            if (masa.Durum != "Rezerve")
                            {
                                _masaRepository.UpdateDurum(masa.MasaID, "Rezerve");
                                masa.Durum = "Rezerve";
                            }
                        }
                        else if (masa.Durum != "Bos" && masa.Durum != "Bakim")
                        {
                            // Masa boş
                            _masaRepository.UpdateDurum(masa.MasaID, "Bos");
                            masa.Durum = "Bos";
                        }
                    }
                }
                else if (masa.Durum != "Bos" && masa.Durum != "Bakim")
                {
                    // Randevu yok, masa boş
                    _masaRepository.UpdateDurum(masa.MasaID, "Bos");
                    masa.Durum = "Bos";
                }
            }
        }

        /// <summary>
        /// Masa panellerini ekranda yerleştirir
        /// Üst: 10 masa, Alt: 10 masa, Sağ: 5 masa, Sol: Boş (giriş)
        /// TOPLAM: 25 masa (Üst kenarda ilk 10, Alt kenarda 10, Sağda ortada 5)
        /// </summary>
        private void MasaPanelleriniOlustur()
        {
            panelMasalar.Controls.Clear();

            if (_masalar == null || _masalar.Count < 25)
            {
                // Eğer 25 masa yoksa, oluştur
                if (_masalar == null || _masalar.Count == 0)
                    return;
            }

            int panelGenislik = 120;
            int panelYukseklik = 100;
            int bosluk = 10;

            // Üst kenar - 10 masa (Masa 1-10) - Yatay sıralı, sol köşe hariç
            // Sol köşe boş (giriş için), ondan sonra 10 masa
            int ustBaslangicX = 150; // Sol köşeyi boş bırak
            for (int i = 0; i < 10 && i < _masalar.Count; i++)
            {
                var masa = _masalar[i];
                var panel = MasaPaneliOlustur(masa, panelGenislik, panelYukseklik);
                panel.Location = new Point(ustBaslangicX + (i * (panelGenislik + bosluk)), bosluk);
                panelMasalar.Controls.Add(panel);
            }

            // Alt kenar - 10 masa (Masa 11-20) - Yatay sıralı
            int altY = panelMasalar.Height - panelYukseklik - bosluk;
            for (int i = 10; i < 20 && i < _masalar.Count; i++)
            {
                var masa = _masalar[i];
                var panel = MasaPaneliOlustur(masa, panelGenislik, panelYukseklik);
                panel.Location = new Point(ustBaslangicX + ((i - 10) * (panelGenislik + bosluk)), altY);
                panelMasalar.Controls.Add(panel);
            }

            // Sağ kenar - 5 masa (Masa 21-25) - Dikey sıralı, ortada
            int sagX = panelMasalar.Width - panelGenislik - bosluk;
            int ortaBaslangicY = (panelMasalar.Height - (5 * panelYukseklik + 4 * bosluk)) / 2;
            
            for (int i = 20; i < 25 && i < _masalar.Count; i++)
            {
                var masa = _masalar[i];
                var panel = MasaPaneliOlustur(masa, panelGenislik, panelYukseklik);
                panel.Location = new Point(sagX, ortaBaslangicY + ((i - 20) * (panelYukseklik + bosluk)));
                panelMasalar.Controls.Add(panel);
            }
        }

        /// <summary>
        /// Tek bir masa paneli oluşturur
        /// </summary>
        private Panel MasaPaneliOlustur(Masa masa, int genislik, int yukseklik)
        {
            Panel panel = new Panel
            {
                Size = new Size(genislik, yukseklik),
                BackColor = masa.GetDurumRengi(),
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand,
                Tag = masa
            };

            // Masa numarası
            Label lblMasaNo = new Label
            {
                Text = $"Masa {masa.MasaNo}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                Size = new Size(genislik - 10, 25),
                Location = new Point(5, 5),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Puan ortalaması (yıldız)
            string yildizlar = YildizMetniOlustur(masa.PuanOrtalamasi);
            Label lblPuan = new Label
            {
                Text = yildizlar + $" ({masa.PuanOrtalamasi:F1})",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.White,
                AutoSize = false,
                Size = new Size(genislik - 10, 20),
                Location = new Point(5, 35),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Durum etiketi
            Label lblDurum = new Label
            {
                Text = GetDurumMetni(masa.Durum),
                Font = new Font("Segoe UI", 8, FontStyle.Regular),
                ForeColor = Color.White,
                AutoSize = false,
                Size = new Size(genislik - 10, 18),
                Location = new Point(5, 60),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Saatlik ücret
            Label lblUcret = new Label
            {
                Text = $"{masa.SaatlikUcret:C}/saat",
                Font = new Font("Segoe UI", 7, FontStyle.Regular),
                ForeColor = Color.White,
                AutoSize = false,
                Size = new Size(genislik - 10, 15),
                Location = new Point(5, 78),
                TextAlign = ContentAlignment.MiddleCenter
            };

            panel.Controls.Add(lblMasaNo);
            panel.Controls.Add(lblPuan);
            panel.Controls.Add(lblDurum);
            panel.Controls.Add(lblUcret);

            // Tıklama olayı
            panel.Click += (s, e) => MasaPaneli_Click(masa);
            foreach (Control ctrl in panel.Controls)
            {
                ctrl.Click += (s, e) => MasaPaneli_Click(masa);
            }

            return panel;
        }

        /// <summary>
        /// Puan ortalamasından yıldız metni oluşturur
        /// </summary>
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

        /// <summary>
        /// Durum kodundan Türkçe metin döndürür
        /// </summary>
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

        /// <summary>
        /// Masa paneline tıklandığında detay formunu aç
        /// </summary>
        private void MasaPaneli_Click(Masa masa)
        {
            using (var detayForm = new MasaDetayForm(masa))
            {
                if (detayForm.ShowDialog() == DialogResult.OK)
                {
                    // Masa durumu değişmiş olabilir, yenile
                    MasalariYukle();
                    MasaPanelleriniOlustur();
                }
            }
        }

        /// <summary>
        /// Timer ile otomatik yenileme
        /// </summary>
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            MasalariYukle();
            MasaPanelleriniOlustur();
        }

        /// <summary>
        /// Manuel yenileme butonu
        /// </summary>
        private void btnYenile_Click(object sender, EventArgs e)
        {
            MasalariYukle();
            MasaPanelleriniOlustur();
        }

        /// <summary>
        /// Çıkış butonu
        /// </summary>
        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Çıkış", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SessionManager.LogoutAll();
                Application.Exit();
            }
        }

        /// <summary>
        /// Form kapanırken timer'ı temizle
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _refreshTimer?.Stop();
            _refreshTimer?.Dispose();
        }
    }
}

