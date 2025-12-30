-- Degerlendirmeler tablosu
CREATE TABLE Degerlendirmeler (
    DegerlendirmeID INT PRIMARY KEY IDENTITY(1,1),
    RandevuID INT NOT NULL,
    MasaID INT NOT NULL,
    KullaniciID INT NOT NULL,
    Puan INT NOT NULL CHECK (Puan BETWEEN 1 AND 5),
    Yorum NVARCHAR(1000) NULL,
    OlusturmaTarihi DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Degerlendirmeler_Randevular FOREIGN KEY (RandevuID) REFERENCES Randevular(RandevuID),
    CONSTRAINT FK_Degerlendirmeler_Masalar FOREIGN KEY (MasaID) REFERENCES Masalar(MasaID),
    CONSTRAINT FK_Degerlendirmeler_Kullanicilar FOREIGN KEY (KullaniciID) REFERENCES Kullanicilar(KullaniciID),
    CONSTRAINT UQ_Degerlendirmeler_Randevu UNIQUE (RandevuID) -- Bir randevu için bir değerlendirme
);

-- Index'ler
CREATE INDEX IX_Degerlendirmeler_MasaID ON Degerlendirmeler(MasaID);
CREATE INDEX IX_Degerlendirmeler_KullaniciID ON Degerlendirmeler(KullaniciID);
CREATE INDEX IX_Degerlendirmeler_Puan ON Degerlendirmeler(Puan);

GO

-- Örnek değerlendirmeler
INSERT INTO Degerlendirmeler (RandevuID, MasaID, KullaniciID, Puan, Yorum) VALUES
-- (Tamamlanmış randevulardan seçerek eklenecek)
-- Şimdilik boş bırakıyoruz
(1, 1, 1, 5, 'Harika bir deneyimdi! Bilgisayar çok hızlıydı ve ortam çok rahatttı.'),
(2, 2, 1, 4, 'Güzel bir masaydı, sadece internet biraz yavaştı.'),
(3, 3, 2, 5, 'Mükemmel! Kesinlikle tekrar geleceğim.');

GO

PRINT 'Degerlendirmeler tablosu başarıyla oluşturuldu!';

