# İnternet Kafe Otomasyonu

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

**Geliştirici:** Muhammed Eren Eyyüpkoca

---

**Not:** Bu proje eğitim amaçlı gerçekleştirilmektedir ve güncellemeler devam edecektir.