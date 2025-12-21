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
    /// Masa detay, randevu ve yorum formu
    /// </summary>
    public partial class MasaDetayForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly Masa _masa;
        private readonly MasaRepository _masaRepository;
        private readonly RandevuRepository _randevuRepository;
        private readonly YorumPuanRepository _yorumPuanRepository;
        private List<Yorum> _yorumlar;
        private int _secilenPuan = 0;

        public MasaDetayForm(Masa masa)
        {
            InitializeComponent();
            _masa = masa;
            _masaRepository = new MasaRepository();
            _randevuRepository = new RandevuRepository();
            _yorumPuanRepository = new YorumPuanRepository();
        }

        private void MasaDetayForm_Load(object sender, EventArgs e)
        {
            MasaBilgileriniYukle();
            YorumlarıYukle();
            PuanYildizlariniOlustur();
        }

        /// <summary>
        /// Masa bilgilerini forma yükle
        /// </summary>
        private void MasaBilgileriniYukle()
        {
            lblMasaBaslik.Text = _masa.MasaAdi ?? $"Masa {_masa.MasaNo}";
            lblMasaNo.Text = $"Masa No: {_masa.MasaNo}";
            lblDurum.Text = $"Durum: {GetDurumMetni(_masa.Durum)}";
            lblDurum.ForeColor = _masa.GetDurumRengi();
            lblSaatlikUcret.Text = $"Saatlik Ücret: {_masa.SaatlikUcret:C}";
            lblPuanOrtalama.Text = $"Ortalama Puan: {_masa.PuanOrtalamasi:F1}/5.0 ({_masa.ToplamPuanSayisi} değerlendirme)";
            
            if (!string.IsNullOrEmpty(_masa.Aciklama))
                lblAciklama.Text = _masa.Aciklama;
            
            if (!string.IsNullOrEmpty(_masa.PCOzellikleri))
                lblPCOzellik.Text = "PC Özellikleri: " + _masa.PCOzellikleri;

            // Randevu butonunu duruma göre ayarla
            if (_masa.Durum == "Dolu" || _masa.Durum == "Bakim")
            {
                btnRandevuYap.Enabled = false;
                btnRandevuYap.Text = "Randevu Alınamaz";
            }
            else if (_masa.Durum == "Rezerve")
            {
                btnRandevuYap.Text = "Rezervasyon Yap";
            }
            else
            {
                btnRandevuYap.Text = "Randevu Yap";
            }
        }

        /// <summary>
        /// Yıldız puanlama butonlarını oluştur
        /// </summary>
        private void PuanYildizlariniOlustur()
        {
            panelYildizlar.Controls.Clear();
            
            for (int i = 1; i <= 5; i++)
            {
                Button btnYildiz = new Button
                {
                    Text = "☆",
                    Font = new Font("Segoe UI", 24, FontStyle.Regular),
                    Size = new Size(50, 50),
                    Location = new Point((i - 1) * 55, 0),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Transparent,
                    ForeColor = Color.Gray,
                    Cursor = Cursors.Hand,
                    Tag = i
                };

                btnYildiz.FlatAppearance.BorderSize = 0;
                btnYildiz.Click += BtnYildiz_Click;
                btnYildiz.MouseEnter += BtnYildiz_MouseEnter;
                btnYildiz.MouseLeave += BtnYildiz_MouseLeave;

                panelYildizlar.Controls.Add(btnYildiz);
            }
        }

        /// <summary>
        /// Yıldıza tıklandığında
        /// </summary>
        private void BtnYildiz_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                _secilenPuan = (int)btn.Tag;
                YildizlariGuncelle(_secilenPuan, true);
            }
        }

        /// <summary>
        /// Mouse yıldızın üzerine geldiğinde
        /// </summary>
        private void BtnYildiz_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && _secilenPuan == 0)
            {
                int puan = (int)btn.Tag;
                YildizlariGuncelle(puan, false);
            }
        }

        /// <summary>
        /// Mouse yıldızdan ayrıldığında
        /// </summary>
        private void BtnYildiz_MouseLeave(object sender, EventArgs e)
        {
            if (_secilenPuan == 0)
            {
                YildizlariGuncelle(0, false);
            }
            else
            {
                YildizlariGuncelle(_secilenPuan, true);
            }
        }

        /// <summary>
        /// Yıldızların görünümünü güncelle
        /// </summary>
        private void YildizlariGuncelle(int puan, bool secildi)
        {
            foreach (Control ctrl in panelYildizlar.Controls)
            {
                if (ctrl is Button btn)
                {
                    int yildizNo = (int)btn.Tag;
                    if (yildizNo <= puan)
                    {
                        btn.Text = "★";
                        btn.ForeColor = secildi ? Color.Gold : Color.Orange;
                    }
                    else
                    {
                        btn.Text = "☆";
                        btn.ForeColor = Color.Gray;
                    }
                }
            }
        }

        /// <summary>
        /// Yorumları yükle ve göster
        /// </summary>
        private void YorumlarıYukle()
        {
            _yorumlar = _yorumPuanRepository.GetYorumlarByMasaId(_masa.MasaID);
            flowPanelYorumlar.Controls.Clear();

            if (_yorumlar.Count == 0)
            {
                Label lblYorumYok = new Label
                {
                    Text = "Henüz yorum yapılmamış. İlk yorumu siz yapın!",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Padding = new Padding(10)
                };
                flowPanelYorumlar.Controls.Add(lblYorumYok);
                return;
            }

            foreach (var yorum in _yorumlar)
            {
                Panel yorumPanel = YorumPaneliOlustur(yorum);
                flowPanelYorumlar.Controls.Add(yorumPanel);
            }
        }

        /// <summary>
        /// Tek bir yorum paneli oluştur
        /// </summary>
        private Panel YorumPaneliOlustur(Yorum yorum)
        {
            Panel panel = new Panel
            {
                Width = flowPanelYorumlar.Width - 30,
                Height = 80,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(250, 250, 250),
                Margin = new Padding(5)
            };

            // Kullanıcı adı ve tarih
            Label lblKullanici = new Label
            {
                Text = $"{yorum.KullaniciAdSoyad ?? yorum.KullaniciAdi} - {yorum.YorumTarihi:dd.MM.yyyy HH:mm}",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 150, 243),
                AutoSize = true,
                Location = new Point(10, 10)
            };

            // Yorum metni
            Label lblYorum = new Label
            {
                Text = yorum.YorumMetni,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.Black,
                AutoSize = false,
                Size = new Size(panel.Width - 20, 45),
                Location = new Point(10, 30)
            };

            panel.Controls.Add(lblKullanici);
            panel.Controls.Add(lblYorum);

            return panel;
        }

        /// <summary>
        /// Randevu yap butonu
        /// </summary>
        private void btnRandevuYap_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsUserLoggedIn)
            {
                MessageBox.Show("Randevu yapabilmek için giriş yapmalısınız.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var randevuDialog = new RandevuDialogForm(_masa))
            {
                if (randevuDialog.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Randevunuz başarıyla oluşturuldu!", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Yorum yap butonu
        /// </summary>
        private void btnYorumYap_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsUserLoggedIn)
            {
                MessageBox.Show("Yorum yapabilmek için giriş yapmalısınız.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string yorumMetni = txtYorum.Text.Trim();

            if (string.IsNullOrWhiteSpace(yorumMetni))
            {
                MessageBox.Show("Lütfen yorum metni giriniz.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_secilenPuan == 0)
            {
                MessageBox.Show("Lütfen yıldız puanı seçiniz.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Yorum ekle
                var yorum = new Yorum
                {
                    MasaID = _masa.MasaID,
                    KullaniciID = SessionManager.GetCurrentUserId(),
                    YorumMetni = yorumMetni,
                    RandevuID = null
                };

                // Puan ekle
                var puan = new Puan
                {
                    MasaID = _masa.MasaID,
                    KullaniciID = SessionManager.GetCurrentUserId(),
                    PuanDegeri = _secilenPuan,
                    RandevuID = null
                };

                _yorumPuanRepository.AddYorumVePuan(yorum, puan);

                MessageBox.Show("Yorumunuz ve puanınız başarıyla kaydedildi!", "Başarılı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Formu temizle
                txtYorum.Clear();
                _secilenPuan = 0;
                YildizlariGuncelle(0, false);

                // Yorumları yenile
                YorumlarıYukle();

                // Masa bilgilerini güncelle (puan ortalaması değişti)
                var guncelMasa = _masaRepository.GetById(_masa.MasaID);
                if (guncelMasa != null)
                {
                    _masa.PuanOrtalamasi = guncelMasa.PuanOrtalamasi;
                    _masa.ToplamPuanSayisi = guncelMasa.ToplamPuanSayisi;
                    lblPuanOrtalama.Text = $"Ortalama Puan: {_masa.PuanOrtalamasi:F1}/5.0 ({_masa.ToplamPuanSayisi} değerlendirme)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Kapat butonu
        /// </summary>
        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}

