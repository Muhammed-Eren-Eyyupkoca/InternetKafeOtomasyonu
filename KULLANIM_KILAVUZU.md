# 🎮 Kafe Otomasyonu - Kullanım Kılavuzu

## 📋 İçindekiler
1. [Sistemi Başlatma](#sistemi-başlatma)
2. [Giriş Yapma](#giriş-yapma)
3. [Masa Seçimi](#masa-seçimi)
4. [Randevu Oluşturma](#randevu-oluşturma)
5. [Yorum ve Puan Verme](#yorum-ve-puan-verme)
6. [Sık Sorulan Sorular](#sık-sorulan-sorular)

---

## 🚀 Sistemi Başlatma

### Gereksinimler
- ✅ Visual Studio 2022
- ✅ .NET 8.0
- ✅ SQL Server (LocalDB veya Express)
- ✅ DevExpress 25.1

### Adımlar
1. **Veritabanını Oluşturun:**
   - SQL Server Management Studio'yu açın
   - `KafeOtomasyonu/Database/KafeOtomasyonu_Database.sql` dosyasını açın
   - Scripti çalıştırın (F5)
   - "Veritabanı başarıyla oluşturuldu!" mesajını görmelisiniz

2. **Bağlantı Ayarlarını Kontrol Edin:**
   - `KafeOtomasyonu/Helpers/DatabaseHelper.cs` dosyasını açın
   - ConnectionString'i kendi SQL Server bilgilerinize göre ayarlayın:
   ```csharp
   Server=localhost;Database=KafeOtomasyonuDB;Integrated Security=true;
   ```

3. **Projeyi Çalıştırın:**
   - Visual Studio'da projeyi açın
   - F5 tuşuna basın veya "Start" butonuna tıklayın
   - Giriş ekranı açılmalıdır

---

## 🔐 Giriş Yapma

### Yeni Kullanıcı Kaydı
1. Giriş ekranında "Kayıt Ol" linkine tıklayın
2. Bilgilerinizi doldurun:
   - **Ad Soyad:** Tam adınız
   - **Kullanıcı Adı:** Benzersiz bir kullanıcı adı
   - **E-posta:** Geçerli bir e-posta adresi
   - **Telefon:** 05XX XXX XX XX formatında
   - **Şifre:** Minimum 6 karakter
   - **Şifre Tekrar:** Aynı şifre
3. "Kayıt Ol" butonuna tıklayın
4. Başarılı mesajından sonra giriş ekranına yönlendirileceksiniz

### Giriş Yapma
1. Kullanıcı adınızı girin
2. Şifrenizi girin
3. "Beni Hatırla" seçeneğini işaretleyebilirsiniz
4. "Giriş Yap" butonuna tıklayın
5. Başarılı girişten sonra masa listesi ekranı açılacak

---

## 🎯 Masa Seçimi

### Masa Listesi Ekranı
Giriş yaptıktan sonra karşınıza 25 masanın bulunduğu ana ekran gelecek.

#### Masa Renk Kodları
- 🟢 **Yeşil:** Masa boş - Randevu alabilirsiniz
- 🟠 **Turuncu:** Masa rezerve - Gelecekte randevu var
- 🔴 **Kırmızı:** Masa dolu - Şu anda kullanımda

#### Masa Bilgileri
Her masa kartında şunları göreceksiniz:
- **Masa No:** Masa 1, Masa 2, vb.
- **Yıldız Puanı:** ★★★★☆ (Kullanıcı yorumlarına göre)
- **Puan Ortalaması:** 4.2/5.0 gibi
- **Durum:** BOŞ, REZERVE veya DOLU
- **Saatlik Ücret:** ₺15,00/saat

#### Masa Seçme
- İstediğiniz masaya **tıklayın**
- Masa detay ekranı açılacak

### Ekran Kontrolleri
- **Yenile Butonu:** Masa durumlarını manuel yeniler
- **Çıkış Butonu:** Uygulamadan çıkış yapar
- **Otomatik Yenileme:** Her 30 saniyede otomatik güncellenir

---

## 📅 Randevu Oluşturma

### Adımlar
1. **Masa Seçin:**
   - Boş (yeşil) bir masaya tıklayın
   - Masa detay ekranında "Randevu Yap" butonuna tıklayın

2. **Tarih Seçin:**
   - Açılan takvimden tarih seçin
   - Sadece bugün ve gelecek tarihler seçilebilir

3. **Saat Seçin:**
   - **Başlangıç Saati:** Gelecek istediğiniz saat
   - **Bitiş Saati:** Ayrılacağınız saat
   - Saatler açılır menüden seçilir

4. **Ücret Kontrolü:**
   - Sistem otomatik olarak toplam ücreti hesaplar
   - Örnek: "Süre: 3 saat - Toplam Ücret: ₺45,00"

5. **Onaylama:**
   - "Oluştur" butonuna tıklayın
   - Başarılı mesajını görün
   - Randevunuz kaydedildi!

### Önemli Notlar
- ⚠️ Geçmiş tarih seçemezsiniz
- ⚠️ Bitiş saati başlangıçtan sonra olmalı
- ⚠️ Aynı saatte başka randevu varsa çakışma hatası alırsınız
- ✅ Randevunuz "Beklemede" durumunda oluşturulur

---

## ⭐ Yorum ve Puan Verme

### Yorum Yapma
1. **Masa Detay Ekranında:**
   - Bir masaya tıklayın
   - Aşağıya "Yorum ve Puan Ver" bölümüne inin

2. **Puan Verin (Zorunlu):**
   - 5 yıldızdan istediğiniz kadarına tıklayın
   - Yıldızlar üzerine geldiğinizde renk değiştirir
   - Tıkladığınızda seçim yapılır (turuncu → altın sarısı)

3. **Yorum Yazın:**
   - Sağ taraftaki metin alanına yorumunuzu yazın
   - Örnek: "Çok iyi bir masa, ekipmanlar harika!"

4. **Gönderin:**
   - "Yorum Yap" butonuna tıklayın
   - Başarılı mesajını görün
   - Yorumunuz listeye eklenecek

### Yorumları Görüntüleme
- Sayfa en altında "Kullanıcı Yorumları" bölümü var
- Tüm yorumlar kronolojik sırada
- Her yorumda:
  - Kullanıcı adı
  - Yorum tarihi
  - Yorum metni

### Puan Ortalaması
- Masanın genel puanı otomatik hesaplanır
- Masa kartında ve detay sayfasında görünür
- Örnek: ★★★★☆ 4.2 (15 değerlendirme)

---

## ❓ Sık Sorulan Sorular

### Giriş ve Hesap
**S: Şifremi unuttum, ne yapmalıyım?**  
C: Şu anda şifre sıfırlama özelliği yok. Admin ile iletişime geçmelisiniz.

**S: Kullanıcı adımı değiştirebilir miyim?**  
C: Hayır, kullanıcı adı kayıt sırasında belirlenir ve değiştirilemez.

**S: Hesabım neden bloklu?**  
C: Bloklu hesaplar giriş yaparken neden gösterir. Admin ile iletişime geçin.

### Masalar
**S: Hangi masa hangi bölgede?**  
C: 
- **Masa 1-10:** Üst kenar
- **Masa 11-20:** Alt kenar
- **Masa 21-25:** Sağ kenar

**S: VIP masalar hangisi?**  
C: Masa 7, 8, 17, 18, 23 (Intel i9, RTX 3080)

**S: Premium masalar hangisi?**  
C: Masa 3, 4, 13, 14, 21, 22, 24, 25 (Intel i7, RTX 3070)

**S: Masa durumları ne zaman güncellenir?**  
C: Otomatik olarak her 30 saniyede ve manuel "Yenile" butonu ile.

### Randevular
**S: Randevumu iptal edebilir miyim?**  
C: Şu anda iptal özelliği kullanıcı panelinde yok. İleriki güncellemelerde eklenecek.

**S: Randevum onaylanacak mı?**  
C: Randevular "Beklemede" durumunda oluşturulur. Admin onayı ile "Onaylandı" olur.

**S: Aynı anda birden fazla randevu alabilir miyim?**  
C: Evet, farklı masalar ve saatler için istediğiniz kadar randevu alabilirsiniz.

**S: Geçmiş randevularımı görebilir miyim?**  
C: Şu anda sadece aktif randevular gösteriliyor. Geçmiş randevular özelliği eklenecek.

### Yorumlar ve Puanlar
**S: Yorumum hemen görünür mü?**  
C: Evet, yorumlar otomatik onaylanır ve hemen görünür.

**S: Yorumumu silebilir miyim?**  
C: Şu anda kullanıcılar kendi yorumlarını silemez. Admin silebilir.

**S: Bir masaya birden fazla puan verebilir miyim?**  
C: Hayır, her kullanıcı her masaya bir kez puan verebilir.

**S: Puan vermeden yorum yapabilir miyim?**  
C: Hayır, yorum yapmak için puan vermek zorunludur.

### Teknik Sorunlar
**S: "Veritabanı bağlantısı kurulamadı" hatası alıyorum?**  
C: 
1. SQL Server çalışıyor mu kontrol edin
2. ConnectionString'i kontrol edin
3. Veritabanını oluşturup oluşturmadığınızı kontrol edin

**S: Masalar görünmüyor?**  
C: 
1. Veritabanı scriptini çalıştırdınız mı?
2. "Yenile" butonuna tıklayın
3. Uygulamayı yeniden başlatın

**S: Formlar doğru görünmüyor?**  
C: DevExpress 25.1 kurulu olduğundan emin olun.

---

## 📞 Destek

Sorunlarınız için:
- **Geliştirici:** Muhammed Eren Eyyüpkoca
- **GitHub:** (Proje GitHub linki buraya)
- **E-posta:** (İletişim e-postası buraya)

---

## 🎓 İpuçları

### Masa Seçimi İçin
1. **Puan ortalaması yüksek** masaları tercih edin
2. **Yorumları okuyun** - Diğer kullanıcıların deneyimlerinden faydalanın
3. **PC özelliklerine bakın** - İhtiyacınıza göre seçin

### Randevu İçin
1. **Önceden rezervasyon yapın** - Son dakika yerine günler öncesinden
2. **Uzun süreli randevularda** fiyata dikkat edin
3. **Popüler saatleri kaçırın** - Gece geç saatler daha müsait

### Yorum İçin
1. **Detaylı yorum yazın** - Diğer kullanıcılara yardımcı olun
2. **Dürüst puan verin** - Sistem böyle gelişir
3. **PC performansı hakkında** bilgi verin

---

**Keyifli Oyunlar! 🎮**

