# İnternet Kafe Otomasyonu

---

## 🚀 Kurulum

### 1. **Projeyi Klonlayın:**
```bash
git clone https://github.com/YOUR_USERNAME/KafeOtomasyonu.git
cd KafeOtomasyonu
```

### 2. **Veritabanı Kurulumu:**
- SQL Server Management Studio'yu açın
- `Database` klasöründeki SQL scriptlerini sırayla çalıştırın:
  - `01_Create_Database.sql`
  - `02_Create_Tables.sql`
  - `03_Insert_Sample_Data.sql`
  - vb...

### 3. **App.config Ayarları:**
- `KafeOtomasyonu/App.config.example` dosyasını `App.config` olarak kopyalayın
- `App.config` içindeki connection string'i kendi SQL Server bilgilerinize göre düzenleyin:
```xml
<connectionStrings>
  <add name="KafeOtomasyonuDB" 
       connectionString="Server=YOUR_SERVER;Database=KafeOtomasyonuDB;Integrated Security=True;TrustServerCertificate=True;" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 4. **Projeyi Çalıştırın:**
- Visual Studio'da projeyi açın
- `F5` tuşuna basarak çalıştırın

---

## 📌 1. Güncelleme

**Temel olarak Veri Tabanı oluşturuldu:**

- Visual Studio 2022'de DevExpress 25.1 ile Windows Forms projesi oluşturuldu
- Microsoft SQL Server'da veritabanı şeması tasarlandı
- Tablolar oluşturuldu (Kullanicilar, Masalar, Randevular, Puanlar, Yorumlar, Adminler, AdminLogs)
- Bağlantı string'i ve veritabanı helper sınıfı eklendi
- SHA256 ile şifre hashleme eklendi

---

## 📌 2. Güncelleme

**Modern giriş ekranı eklendi:**

- DevExpress kontrolleri ile modern giriş ekranı tasarlandı
- Kullanıcı adı ve şifre doğrulama eklendi
- "Kayıt Ol" butonuna yönlendirme eklendi
- "Beni Hatırla" özelliği eklendi
- Bloklu kullanıcı kontrolü eklendi
- SessionManager ile oturum yönetimi eklendi

---

## 📌 3. Güncelleme

**Kayıt ol sayfası ve modern tasarım eklendi:**

- Login sayfası ile uyumlu modern tasarım
- Ad Soyad, Kullanıcı Adı, E-posta, Telefon ve Şifre alanları
- E-posta ve telefon formatı doğrulama
- Şifre eşleşme kontrolü (min 6 karakter)
- Kullanıcı adı ve e-posta tekil kontrolü
- Başarılı kayıt sonrası Login sayfasına yönlendirme
- Tam ekran responsive tasarım eklendi
- Beyaz kart tasarımı ile modern görünüm
- Logo alanı kaldırıldı, temiz tasarım
- Animasyonlu bildirim sistemi eklendi
- Yukarıdan kayarak gelen toast notification'lar
- Turkuaz (#40E0D0) renk şeması optimizasyonu
- Tüm fontlar ve spacing'ler modernize edildi
- DPI ölçeklendirme sorunları çözüldü

---

## 📌 4. Güncelleme

**Masa Yönetim Sistemi ve Admin Paneli:**

- 25 masalı görsel sistem (üst 10, alt 10, sağ 5, sol boş-giriş)
- Renk kodlu durum sistemi (yeşil: boş, turuncu: rezerve, kırmızı: dolu)
- Her masada puan ortalaması ve yıldız gösterimi
- Masaya tıklayınca detay ekranı açılıyor
- 5 yıldız puanlama sistemi
- Yorum yapma ve görüntüleme
- Randevu oluşturma sistemi (tarih, saat, ücret hesaplama)
- Çakışma kontrolü
- Otomatik masa durumu güncelleme (30 saniye)
- Admin paneli (kullanıcı blokla, masa durumu değiştir, randevu onayla)
- Admin girişi checkbox ile (admin/admin123)

---

## 📌 5. Güncelleme

**Gelişmiş Randevu Sistemi:**

- DevExpress DateEdit ile tarih seçimi
- DevExpress TimeEdit ile başlangıç saati seçimi
- DevExpress SpinEdit ile kaç saat kullanılacağı seçimi (1-12 saat)
- Saatlik ücret 75 TL olarak güncellendi
- Otomatik ücret hesaplama ve anlık gösterim
- Gelişmiş randevu çakışma kontrolü
- Geçmiş tarih ve saat kontrolü
- Gece yarısını geçen randevu kontrolü
- Randevu onay ekranı ile detaylı bilgi gösterimi
- Başarılı randevu sonrası bilgilendirme mesajı

---

## 📌 6. Güncelleme

**Kullanıcı Profil Yönetimi ve Randevu İşlemleri:**

- **Randevularım Sayfası:**
  - Kullanıcının tüm randevularını listeleme
  - Durum bazlı filtreleme (Tümü, Beklemede, Onaylandı, İptal Edildi, Tamamlandı)
  - Renk kodlu durum gösterimi
  - Randevu detayları (Masa, tarih, saat, ücret)
  - Otomatik yenileme butonu

- **Randevu İptal Sistemi:**
  - Aktif randevuları iptal edebilme
  - İptal nedeni girme zorunluluğu
  - Geçmiş randevular için iptal butonu gösterilmez
  - İptal onay ekranı

- **Randevu Düzenleme Sistemi:**
  - Randevu tarih ve saat değiştirme
  - Çakışma kontrolü ile güncelleme
  - Otomatik ücret yeniden hesaplama
  - Geçmiş randevular düzenlenemez

- **Profil Sayfası:**
  - Kullanıcı bilgilerini görüntüleme
  - Ad Soyad düzenleme
  - E-posta güncelleme (benzersizlik kontrolü)
  - Telefon güncelleme
  - Kayıt tarihi ve son giriş bilgisi
  - Kullanıcı adı salt okunur (değiştirilemez)

- **Şifre Değiştirme:**
  - Mevcut şifre doğrulama
  - Yeni şifre girme (min 6 karakter)
  - Şifre eşleşme kontrolü
  - Güvenli şifre güncelleme

- **Ana Sayfa İyileştirmeleri:**
  - Üst menüye "📅 Randevularım" butonu eklendi
  - Üst menüye "👤 Profilim" butonu eklendi
  - Modern mor ve turkuaz renk şeması
  - Butonlar responsive yerleşim

---

## 📌 7. Güncelleme

**Puanlama ve Yorum Sistemi:**

- **Değerlendirme Yapma:**
  - Tamamlanan randevular için değerlendirme butonu
  - İnteraktif 5 yıldız puanlama sistemi
  - Yorum yazma alanı (opsiyonel, max 1000 karakter)
  - Karakter sayacı ile gerçek zamanlı geri bildirim
  - Yıldız hover ve seçim efektleri

- **Değerlendirme Kuralları:**
  - Her randevu sadece bir kez değerlendirilebilir
  - Sadece "Tamamlandı" durumundaki randevular değerlendirilebilir
  - Veritabanı seviyesinde tekil kontrol (UNIQUE constraint)
  - Kullanıcı kontrollü değerlendirme tekrarı engelleme

- **Masa Detay Sayfası:**
  - Masaya ait tüm yorumları görüntüleme
  - Ortalama puan hesaplama ve gösterimi
  - Toplam değerlendirme sayısı
  - Kullanıcı adı ile yorum listeleme
  - Tarih sıralı yorum gösterimi (en yeni üstte)
  - Modern kart tasarımı ile yorum kartları

- **Veritabanı:**
  - Degerlendirmeler tablosu oluşturuldu
  - Foreign key ilişkileri (Randevular, Masalar, Kullanicilar)
  - Puan kontrolü (1-5 arası CHECK constraint)
  - İndeksler ile performans optimizasyonu
  - Otomatik tarih damgası (OlusturmaTarihi)

- **Repository Pattern:**
  - DegerlendirmeRepository sınıfı
  - Add, GetByMasaId, GetMasaAveragePuan metodları
  - HasUserReviewedRandevu kontrolü
  - GetMasaDegerlendirmeCount istatistik metodu

---

## 📌 8. Güncelleme

**Premium UI/UX Tasarım ve İstatistik Dashboard:**

- **Giriş ve Kayıt Ekranları Yenilendi:**
  - Turkuaz renk paleti tamamen kaldırıldı
  - Dark premium background (#151629) eklendi
  - Premium mavi (#2b80c8) butonlar
  - Success yeşil (#55a586) kayıt butonu
  - Soft grey-blue (#b0b9d1) label renkleri
  - Modern flat design (border'lar kaldırıldı)
  - Büyük, rahat input'lar (42-45px)
  - Bold, modern butonlar (50px)
  - Responsive tam ekran tasarım
  - Beyaz kart tasarımı üzerinde form elementleri

- **Masa Listesi Ekranı Modernize Edildi:**
  - Dark premium arka plan (#151629)
  - "İnternet Kafe" watermark (şeffaf, ortada)
  - Üst navbar yüksekliği artırıldı (70px → 80px)
  - Tüm butonlar büyütüldü ve modernize edildi (40px)
  - Emoji ikonlar eklendi (📅 🖥️ 📊 👤 🔄 🚪)
  - Premium renk paleti:
    - Mavi (#2b80c8): Randevu ve Profil butonları
    - Yeşil (#55a586): Yenile butonu ve Boş masalar
    - Sarı (#ceb951): İstatistik butonu ve Rezerve masalar
    - Kırmızı (#c82b6d): Çıkış butonu ve Dolu masalar
  - Masa kartları büyütüldü (120x100px → 140x120px)
  - Hover efekti eklendi (kartlar üzerine gelince açılır)
  - Border kaldırıldı (modern flat design)
  - Kartlar arası boşluk artırıldı (10px → 15px)
  - Daha büyük fontlar ve spacing

- **Kullanıcı İstatistik Dashboard'u:**
  - Kullanıcıya özel istatistik paneli eklendi
  - Toplam randevu sayısı gösterimi
  - Toplam harcama miktarı (TL)
  - En çok kullanılan masa bilgisi
  - Temiz, kart bazlı tasarım
  - Ana sayfa üst menüsünden erişim (📊 İstatistikler butonu)

- **Kod İyileştirmeleri:**
  - RandevuRepository'de duplicate metodlar temizlendi
  - DashboardForm kullanıcı istatistikleri için optimize edildi
  - SessionManager entegrasyonu
  - Repository pattern ile temiz veri erişimi

- **Genel UI/UX İyileştirmeleri:**
  - Tüm formlar dark theme ile uyumlu
  - Tutarlı renk paleti tüm ekranlarda
  - Modern, şık ve profesyonel görünüm
  - Kullanıcı dostu, rahat tıklanabilir butonlar
  - Watermark ile premium branding

---

## 📌 9. Güncelleme

**Masa Detay Sayfası Yenilendi ve Hata Düzeltmeleri:**

- **Masa Detay Formu Yeniden Tasarlandı:**
  - Üst kısım: Koyu premium arka plan (#151629) ile masa bilgileri
  - Masa adı, puan, ücret ve durum bilgileri net gösterim
  - Büyük ve belirgin "📅 RANDEVU AL" butonu (mavi, 200x60px)
  - "❌ KAPAT" butonu (kırmızı, 200x45px)
  - Alt kısım: Kullanıcı yorumları listesi (açık arka plan)

- **Randevu Alma Akışı İyileştirildi:**
  - Masaya tıklayınca detay sayfası açılıyor
  - Detay sayfasında "RANDEVU AL" butonuna tıklayınca randevu formu açılıyor
  - Daha sezgisel ve kullanıcı dostu akış
  - Yorumları görüntülerken randevu alabilme imkanı

- **Hata Düzeltmeleri:**
  - Masa tıklama olayları düzeltildi
  - Buton görünürlük sorunları giderildi
  - Form yükleme sırası optimize edildi
  - Dosya kaydetme ve derleme sorunları çözüldü

- **UI/UX İyileştirmeleri:**
  - Yorum kartları modernize edildi (beyaz arka plan, gölge efekti)
  - Yıldız puanlama daha büyük ve belirgin (16px font)
  - Kullanıcı adı ve tarih bilgisi düzenli gösterim
  - Responsive tasarım ile farklı ekran boyutlarına uyum
  - Tutarlı renk şeması tüm ekranlarda

---

## 📌 10. Güncelleme

**ChatBot Sistemi, Admin Paneli Modernizasyonu ve Fiyat Güncellemeleri:**

- **Oyun Öneri ChatBot'u:**
  - Ekranın sağ alt köşesinde yuvarlak mor buton (🤖)
  - Tıklandığında sağdan açılan modern panel
  - Slide-in/slide-out animasyonu
  - Buton tabanlı kategori seçimi:
    - 🔫 FPS Oyunları (Valorant, CS2, Apex Legends, Warzone)
    - ⚔️ MOBA Oyunları (LoL, Dota 2, Smite)
    - 🧙‍♂️ RPG Oyunları (Witcher 3, Elden Ring, Cyberpunk)
    - 🧠 Strateji Oyunları (StarCraft II, Age of Empires, Civilization)
    - 🗺️ Macera Oyunları (RDR2, Uncharted, God of War)
    - ⚽ Spor Oyunları (FIFA, NBA 2K, F1)
    - 🔥 Popüler Oyunlar
    - 🎲 Rastgele Öneri
  - Her oyun için puan ve açıklama
  - Koyu mor tema (#1e1e2e) ile modern görünüm

- **Masa Durumu Basitleştirildi:**
  - Eski sistem: "Boş", "Rezerve", "Dolu"
  - Yeni sistem: "Uygun" (yeşil) ve "Uygun Değil" (kırmızı)
  - Alt bar legend güncellendi
  - Daha sade ve anlaşılır durum gösterimi

- **Masa Fiyatları Güncellendi:**
  - Standart Masalar: 15 TL → 50 TL/saat
  - Premium Masalar: 18 TL → 75 TL/saat
  - VIP Masalar: 20 TL → 100 TL/saat
  - Dinamik fiyat hesaplama (masa bazlı)
  - Randevu formlarında otomatik ücret güncelleme

- **Admin Paneli Modernize Edildi:**
  - Dashboard kartları eklendi:
    - 👥 Toplam Kullanıcı (mavi kart)
    - 🖥️ Aktif Masa (yeşil kart)
    - 📅 Bugünkü Randevu (sarı kart)
    - 💰 Bugünkü Gelir (mor kart)
  - Koyu premium tema (#151629)
  - Zebra desenli grid'ler (okunurluk için)
  - Büyük font (11pt) ve 35px satır yüksekliği
  - Emoji'li sütun başlıkları
  - Mavi header bar
  - Sütun genişlikleri optimize edildi
  - Açıklama ve PC Özellikleri sütunları genişletildi

- **Kod Temizliği ve Optimizasyon:**
  - Kullanılmayan dosyalar silindi:
    - GeminiService.cs (API servisi)
    - gemini-config.json (API key)
    - RandevuDuzenleDialog.cs (duplicate form)
    - ADIM_4_OZET.md (geliştirme notları)
  - Boş klasörler temizlendi (Services, Database)
  - .gitignore güncellendi (yeni kurallar eklendi)
  - Proje yapısı sadeleştirildi

- **Ana Ekran İyileştirmeleri:**
  - "Masa Seçimi" yazısı buton çakışması düzeltildi
  - Alt legend bar yüksekliği optimize edildi
  - ChatBot butonları tam görünür hale getirildi

---

## 📌 Ek Güncellemeler

**Giriş Ekranı Yeniden Tasarlandı ve Animasyonlar Eklendi:**

- **Oyun Logoları Arka Planı:**
  - 5x3 grid formatında oyun logoları mozaiği
  - Dinamik resim yükleme (Resources/GameLogos klasöründen)
  - Otomatik kare crop ve ortalama
  - Yarı saydam koyu overlay (login kartı belirgin olsun)
  - İnce grid çizgileri ile modern görünüm
  - Oyun logoları: COD, Valorant, Forza, Minecraft, F1, Witcher, CS2, EA Sports, PlayStation, LoL, Rockstar, FC26, RDR2, PUBG, GTA V

- **İp Animasyonu ile Giriş Paneli:**
  - Başlangıçta "🎮 GİRİŞ YAP" butonu ekranın ortasında
  - Butona tıklayınca giriş paneli tavandan ip ile iniyor
  - Kahverengi halat efekti (detaylı çizgilerle)
  - Üstte metal kanca, altta bağlantı noktası
  - Yavaşlayan animasyon (easing efekti)
  - Panel ortaya gelince durur ve input'a odaklanır

- **Masa Kartlarında Yıldız Puanı Düzeltildi:**
  - Eski: Puanlar tablosundan (kullanılmıyordu)
  - Yeni: Degerlendirmeler tablosundan gerçek puan ortalaması
  - Masa seçim ekranında doğru yıldız gösterimi

- **Masa Detay Sayfası Genişletildi:**
  - Form boyutu: 750px → 950px
  - Sol taraf: Kullanıcı yorumları (550px)
  - Sağ taraf: PC Özellikleri paneli (320px)
  - Masa tipi gösterimi: Standart / ⭐ Premium / 👑 VIP
  - PC özellikleri: İşlemci, Ekran Kartı, RAM, Monitör
  - Her özellik için ikon ve detaylı bilgi
  - Koyu tema (dark premium) tasarım

- **ChatBot Ekran Kayması:**
  - ChatBot açıldığında masa paneli otomatik daralıyor
  - Sağ taraftaki masalar (21-25) yeniden konumlanıyor
  - ChatBot kapandığında eski haline dönüyor
  - Akıcı animasyon efekti

- **Hata Düzeltmeleri:**
  - MasaDetayForm'da duplicate butonlar kaldırıldı
  - Designer dosyası temizlendi
  - Form boyutları optimize edildi

---

**Geliştirici:** Muhammed Eren Eyyüpkoca

---

**Not:** Bu proje eğitim amaçlı gerçekleştirilmiştir ve proje son bulmuştur.
## TEŞEKKÜRLER...