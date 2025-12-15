-- =====================================================
-- KAFE OTOMASYONU VERİTABANI OLUŞTURMA SCRİPTİ
-- SQL Server için hazırlanmıştır
-- =====================================================

-- Veritabanını oluştur
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'KafeOtomasyonuDB')
BEGIN
    CREATE DATABASE KafeOtomasyonuDB;
END
GO

USE KafeOtomasyonuDB;
GO

-- =====================================================
-- TABLOLARI OLUŞTUR
-- =====================================================

-- 1. Kullanıcılar Tablosu
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Kullanicilar')
BEGIN
    CREATE TABLE Kullanicilar (
        KullaniciID INT IDENTITY(1,1) PRIMARY KEY,
        KullaniciAdi NVARCHAR(50) NOT NULL UNIQUE,
        Sifre NVARCHAR(256) NOT NULL, -- Hash'lenmiş şifre
        Email NVARCHAR(100) NOT NULL UNIQUE,
        Telefon NVARCHAR(15),
        AdSoyad NVARCHAR(100) NOT NULL,
        KayitTarihi DATETIME DEFAULT GETDATE(),
        SonGirisTarihi DATETIME,
        Bloklu BIT DEFAULT 0, -- 0: Aktif, 1: Bloklu
        BlokNedeni NVARCHAR(255),
        BlokTarihi DATETIME
    );
END
GO

-- 2. Adminler Tablosu
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Adminler')
BEGIN
    CREATE TABLE Adminler (
        AdminID INT IDENTITY(1,1) PRIMARY KEY,
        AdminAdi NVARCHAR(50) NOT NULL UNIQUE,
        Sifre NVARCHAR(256) NOT NULL, -- Hash'lenmiş şifre
        AdSoyad NVARCHAR(100) NOT NULL,
        Email NVARCHAR(100),
        OlusturmaTarihi DATETIME DEFAULT GETDATE(),
        SonGirisTarihi DATETIME,
        Aktif BIT DEFAULT 1
    );
END
GO

-- 3. Masalar Tablosu
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Masalar')
BEGIN
    CREATE TABLE Masalar (
        MasaID INT IDENTITY(1,1) PRIMARY KEY,
        MasaNo INT NOT NULL UNIQUE,
        MasaAdi NVARCHAR(50),
        SaatlikUcret DECIMAL(10,2) NOT NULL DEFAULT 15.00,
        Durum NVARCHAR(20) DEFAULT 'Bos', -- Bos, Dolu, Rezerve, Bakim
        ResimYolu NVARCHAR(255),
        Aciklama NVARCHAR(500),
        PCOzellikleri NVARCHAR(500), -- Bilgisayar özellikleri
        Aktif BIT DEFAULT 1,
        OlusturmaTarihi DATETIME DEFAULT GETDATE()
    );
END
GO

-- 4. Randevular Tablosu
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Randevular')
BEGIN
    CREATE TABLE Randevular (
        RandevuID INT IDENTITY(1,1) PRIMARY KEY,
        KullaniciID INT NOT NULL,
        MasaID INT NOT NULL,
        RandevuTarihi DATE NOT NULL,
        BaslangicSaati TIME NOT NULL,
        BitisSaati TIME NOT NULL,
        ToplamSaat INT NOT NULL,
        ToplamUcret DECIMAL(10,2) NOT NULL,
        Durum NVARCHAR(20) DEFAULT 'Beklemede', -- Beklemede, Onaylandi, Tamamlandi, IptalEdildi, Gelmedi
        OlusturmaTarihi DATETIME DEFAULT GETDATE(),
        OnayTarihi DATETIME,
        TamamlanmaTarihi DATETIME,
        IptalNedeni NVARCHAR(255),
        FOREIGN KEY (KullaniciID) REFERENCES Kullanicilar(KullaniciID),
        FOREIGN KEY (MasaID) REFERENCES Masalar(MasaID)
    );
END
GO

-- 5. Puanlar Tablosu
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Puanlar')
BEGIN
    CREATE TABLE Puanlar (
        PuanID INT IDENTITY(1,1) PRIMARY KEY,
        MasaID INT NOT NULL,
        KullaniciID INT NOT NULL,
        RandevuID INT,
        Puan INT NOT NULL CHECK (Puan >= 1 AND Puan <= 5), -- 1-5 arası
        PuanTarihi DATETIME DEFAULT GETDATE(),
        FOREIGN KEY (MasaID) REFERENCES Masalar(MasaID),
        FOREIGN KEY (KullaniciID) REFERENCES Kullanicilar(KullaniciID),
        FOREIGN KEY (RandevuID) REFERENCES Randevular(RandevuID)
    );
END
GO

-- 6. Yorumlar Tablosu
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Yorumlar')
BEGIN
    CREATE TABLE Yorumlar (
        YorumID INT IDENTITY(1,1) PRIMARY KEY,
        MasaID INT NOT NULL,
        KullaniciID INT NOT NULL,
        RandevuID INT,
        YorumMetni NVARCHAR(1000) NOT NULL,
        YorumTarihi DATETIME DEFAULT GETDATE(),
        Onaylandi BIT DEFAULT 1, -- Admin onayı
        Aktif BIT DEFAULT 1,
        FOREIGN KEY (MasaID) REFERENCES Masalar(MasaID),
        FOREIGN KEY (KullaniciID) REFERENCES Kullanicilar(KullaniciID),
        FOREIGN KEY (RandevuID) REFERENCES Randevular(RandevuID)
    );
END
GO

-- 7. Admin İşlem Log Tablosu
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'AdminLoglar')
BEGIN
    CREATE TABLE AdminLoglar (
        LogID INT IDENTITY(1,1) PRIMARY KEY,
        AdminID INT NOT NULL,
        Islem NVARCHAR(100) NOT NULL,
        Aciklama NVARCHAR(500),
        IslemTarihi DATETIME DEFAULT GETDATE(),
        IlgiliKullaniciID INT,
        IlgiliMasaID INT,
        FOREIGN KEY (AdminID) REFERENCES Adminler(AdminID)
    );
END
GO

-- =====================================================
-- VARSAYILAN VERİLER
-- =====================================================

-- Varsayılan Admin Ekle (Şifre: admin123 - SHA256 hash'lenmiş)
IF NOT EXISTS (SELECT * FROM Adminler WHERE AdminAdi = 'admin')
BEGIN
    INSERT INTO Adminler (AdminAdi, Sifre, AdSoyad, Email)
    VALUES ('admin', 'EF92B778BAFE771E89245B89ECBC08A44A4E166C06659911881F383D4473E94F', 'Sistem Admini', 'admin@kafeootomasyon.com');
END
GO

-- Örnek Masalar Ekle
IF NOT EXISTS (SELECT * FROM Masalar)
BEGIN
    INSERT INTO Masalar (MasaNo, MasaAdi, SaatlikUcret, Durum, PCOzellikleri, Aciklama) VALUES
    (1, 'Masa 1', 15.00, 'Bos', 'Intel i5, 16GB RAM, RTX 3060, 144Hz Monitor', 'Pencere kenarı, sessiz bölge'),
    (2, 'Masa 2', 15.00, 'Bos', 'Intel i5, 16GB RAM, RTX 3060, 144Hz Monitor', 'Pencere kenarı'),
    (3, 'Masa 3', 18.00, 'Bos', 'Intel i7, 32GB RAM, RTX 3070, 165Hz Monitor', 'Premium bölge'),
    (4, 'Masa 4', 18.00, 'Bos', 'Intel i7, 32GB RAM, RTX 3070, 165Hz Monitor', 'Premium bölge'),
    (5, 'Masa 5', 15.00, 'Bos', 'Intel i5, 16GB RAM, RTX 3060, 144Hz Monitor', 'Orta bölge'),
    (6, 'Masa 6', 15.00, 'Bos', 'Intel i5, 16GB RAM, RTX 3060, 144Hz Monitor', 'Orta bölge'),
    (7, 'Masa 7', 20.00, 'Bos', 'Intel i9, 32GB RAM, RTX 3080, 240Hz Monitor', 'VIP bölge'),
    (8, 'Masa 8', 20.00, 'Bos', 'Intel i9, 32GB RAM, RTX 3080, 240Hz Monitor', 'VIP bölge'),
    (9, 'Masa 9', 15.00, 'Bos', 'Intel i5, 16GB RAM, RTX 3060, 144Hz Monitor', 'Arka bölge'),
    (10, 'Masa 10', 15.00, 'Bos', 'Intel i5, 16GB RAM, RTX 3060, 144Hz Monitor', 'Arka bölge'),
    (11, 'Masa 11', 18.00, 'Bos', 'Intel i7, 32GB RAM, RTX 3070, 165Hz Monitor', 'Premium bölge'),
    (12, 'Masa 12', 18.00, 'Bos', 'Intel i7, 32GB RAM, RTX 3070, 165Hz Monitor', 'Premium bölge');
END
GO

-- =====================================================
-- YARDIMCI VIEW'LAR
-- =====================================================

-- Masa Puan Ortalaması View
IF EXISTS (SELECT * FROM sys.views WHERE name = 'vw_MasaPuanOrtalamasi')
    DROP VIEW vw_MasaPuanOrtalamasi;
GO

CREATE VIEW vw_MasaPuanOrtalamasi AS
SELECT 
    m.MasaID,
    m.MasaNo,
    m.MasaAdi,
    ISNULL(AVG(CAST(p.Puan AS DECIMAL(3,2))), 0) AS PuanOrtalamasi,
    COUNT(p.PuanID) AS ToplamPuanSayisi
FROM Masalar m
LEFT JOIN Puanlar p ON m.MasaID = p.MasaID
GROUP BY m.MasaID, m.MasaNo, m.MasaAdi;
GO

-- Aktif Randevular View
IF EXISTS (SELECT * FROM sys.views WHERE name = 'vw_AktifRandevular')
    DROP VIEW vw_AktifRandevular;
GO

CREATE VIEW vw_AktifRandevular AS
SELECT 
    r.RandevuID,
    r.RandevuTarihi,
    r.BaslangicSaati,
    r.BitisSaati,
    r.ToplamSaat,
    r.ToplamUcret,
    r.Durum,
    k.KullaniciID,
    k.KullaniciAdi,
    k.AdSoyad AS KullaniciAdSoyad,
    m.MasaID,
    m.MasaNo,
    m.MasaAdi
FROM Randevular r
INNER JOIN Kullanicilar k ON r.KullaniciID = k.KullaniciID
INNER JOIN Masalar m ON r.MasaID = m.MasaID
WHERE r.Durum IN ('Beklemede', 'Onaylandi');
GO

-- Kullanıcı Detaylı Bilgi View
IF EXISTS (SELECT * FROM sys.views WHERE name = 'vw_KullaniciBilgileri')
    DROP VIEW vw_KullaniciBilgileri;
GO

CREATE VIEW vw_KullaniciBilgileri AS
SELECT 
    k.KullaniciID,
    k.KullaniciAdi,
    k.Email,
    k.Telefon,
    k.AdSoyad,
    k.KayitTarihi,
    k.SonGirisTarihi,
    k.Bloklu,
    k.BlokNedeni,
    COUNT(r.RandevuID) AS ToplamRandevu,
    SUM(CASE WHEN r.Durum = 'Gelmedi' THEN 1 ELSE 0 END) AS GelmediSayisi
FROM Kullanicilar k
LEFT JOIN Randevular r ON k.KullaniciID = r.KullaniciID
GROUP BY k.KullaniciID, k.KullaniciAdi, k.Email, k.Telefon, k.AdSoyad, 
         k.KayitTarihi, k.SonGirisTarihi, k.Bloklu, k.BlokNedeni;
GO

PRINT 'Veritabanı başarıyla oluşturuldu!';
GO

