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

**Geliştirici:** Muhammed Eren Eyyüpkoca

---

**Not:** Bu proje eğitim amaçlı gerçekleştirilmektedir ve güncellemeler devam edecektir.