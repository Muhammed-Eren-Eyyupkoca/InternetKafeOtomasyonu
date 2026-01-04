using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace KafeOtomasyonu.Forms
{
    public class ChatBotPanel : Panel
    {
        private Panel pnlHeader;
        private Panel pnlMessages;
        private Panel pnlButtons;
        private FlowLayoutPanel flowMessages;
        private FlowLayoutPanel flowButtons;

        public event EventHandler CloseRequested;

        public ChatBotPanel()
        {
            InitializePanel();
        }

        private void InitializePanel()
        {
            this.Width = 420;
            this.Dock = DockStyle.Right;
            this.BackColor = Color.FromArgb(21, 22, 41);
            this.Visible = false;

            // ===== HEADER =====
            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(138, 43, 226), // Mor
                Padding = new Padding(15, 0, 15, 0)
            };

            Label lblTitle = new Label
            {
                Text = "🎮 Oyun Asistanı",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(15, 18)
            };
            pnlHeader.Controls.Add(lblTitle);

            Button btnClose = new Button
            {
                Text = "✕",
                Size = new Size(35, 35),
                Location = new Point(370, 12),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => CloseRequested?.Invoke(this, EventArgs.Empty);
            pnlHeader.Controls.Add(btnClose);

            this.Controls.Add(pnlHeader);

            // ===== MESSAGES AREA =====
            pnlMessages = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(21, 22, 41),
                Padding = new Padding(10)
            };

            flowMessages = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = Color.Transparent
            };
            pnlMessages.Controls.Add(flowMessages);
            this.Controls.Add(pnlMessages);

            // ===== BUTTONS AREA =====
            pnlButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 250,
                BackColor = Color.FromArgb(30, 32, 54),
                Padding = new Padding(10)
            };

            Label lblSoru = new Label
            {
                Text = "🎯 Ne öğrenmek istersin?",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 8),
                AutoSize = true
            };
            pnlButtons.Controls.Add(lblSoru);

            flowButtons = new FlowLayoutPanel
            {
                Location = new Point(10, 35),
                Size = new Size(395, 205),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                BackColor = Color.Transparent,
                AutoScroll = true
            };

            // Kategori butonları
            AddCategoryButton("🎯 FPS Oyunları", Color.FromArgb(231, 76, 60), ShowFPSGames);
            AddCategoryButton("⚔️ MOBA Oyunları", Color.FromArgb(52, 152, 219), ShowMOBAGames);
            AddCategoryButton("🗡️ RPG Oyunları", Color.FromArgb(155, 89, 182), ShowRPGGames);
            AddCategoryButton("🔥 Popüler Oyunlar", Color.FromArgb(230, 126, 34), ShowPopularGames);
            AddCategoryButton("🏎️ Yarış Oyunları", Color.FromArgb(26, 188, 156), ShowRacingGames);
            AddCategoryButton("⚽ Spor Oyunları", Color.FromArgb(46, 204, 113), ShowSportsGames);
            AddCategoryButton("🎮 Strateji Oyunları", Color.FromArgb(241, 196, 15), ShowStrategyGames);
            AddCategoryButton("💀 Korku Oyunları", Color.FromArgb(44, 62, 80), ShowHorrorGames);

            pnlButtons.Controls.Add(flowButtons);
            this.Controls.Add(pnlButtons);

            // Hoşgeldin mesajı
            AddBotMessage("Merhaba! 👋\n\nBen Oyun Asistanı! Aşağıdaki butonlara tıklayarak oyun önerileri alabilirsin.\n\nHangi tür oyun arıyorsun?");
        }

        private void AddCategoryButton(string text, Color color, Action onClick)
        {
            Button btn = new Button
            {
                Text = text,
                Size = new Size(185, 40),
                Margin = new Padding(5),
                FlatStyle = FlatStyle.Flat,
                BackColor = color,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += (s, e) => onClick();
            flowButtons.Controls.Add(btn);
        }

        private void ShowFPSGames()
        {
            AddUserMessage("FPS oyunları göster");
            AddBotMessage("🎯 **FPS OYUNLARI**\n\n" +
                "1. **Counter-Strike 2** ⭐⭐⭐⭐⭐\n" +
                "   Efsanevi taktik FPS. Rekabetçi mod için ideal.\n\n" +
                "2. **Valorant** ⭐⭐⭐⭐⭐\n" +
                "   Yetenekli ajanlarla taktik FPS. Ücretsiz!\n\n" +
                "3. **Call of Duty: Warzone** ⭐⭐⭐⭐\n" +
                "   Battle Royale modu ile heyecan dolu.\n\n" +
                "4. **Apex Legends** ⭐⭐⭐⭐\n" +
                "   Hızlı tempolu, karakter bazlı BR.\n\n" +
                "5. **PUBG** ⭐⭐⭐⭐\n" +
                "   Battle Royale türünün öncüsü.");
        }

        private void ShowMOBAGames()
        {
            AddUserMessage("MOBA oyunları göster");
            AddBotMessage("⚔️ **MOBA OYUNLARI**\n\n" +
                "1. **League of Legends** ⭐⭐⭐⭐⭐\n" +
                "   Dünyanın en popüler MOBA oyunu.\n\n" +
                "2. **Dota 2** ⭐⭐⭐⭐⭐\n" +
                "   Derin strateji, yüksek ödül havuzu.\n\n" +
                "3. **Smite** ⭐⭐⭐⭐\n" +
                "   3. şahıs perspektifli MOBA.\n\n" +
                "4. **Heroes of the Storm** ⭐⭐⭐\n" +
                "   Blizzard karakterleri ile MOBA.\n\n" +
                "💡 Yeni başlayanlar için LoL önerilir!");
        }

        private void ShowRPGGames()
        {
            AddUserMessage("RPG oyunları göster");
            AddBotMessage("🗡️ **RPG OYUNLARI**\n\n" +
                "1. **Elden Ring** ⭐⭐⭐⭐⭐\n" +
                "   Açık dünya aksiyon RPG şaheseri.\n\n" +
                "2. **Baldur's Gate 3** ⭐⭐⭐⭐⭐\n" +
                "   Yılın oyunu! Sıra tabanlı RPG.\n\n" +
                "3. **The Witcher 3** ⭐⭐⭐⭐⭐\n" +
                "   Efsanevi hikaye ve dünya.\n\n" +
                "4. **Cyberpunk 2077** ⭐⭐⭐⭐\n" +
                "   Fütüristik açık dünya RPG.\n\n" +
                "5. **Diablo IV** ⭐⭐⭐⭐\n" +
                "   Hack & Slash RPG klasiği.");
        }

        private void ShowPopularGames()
        {
            AddUserMessage("Popüler oyunları göster");
            AddBotMessage("🔥 **ŞU AN POPÜLER OYUNLAR**\n\n" +
                "1. **Fortnite** - Battle Royale 🌟\n" +
                "2. **Minecraft** - Sandbox 🌟\n" +
                "3. **GTA V Online** - Aksiyon 🌟\n" +
                "4. **Roblox** - Platform 🌟\n" +
                "5. **Counter-Strike 2** - FPS 🌟\n" +
                "6. **League of Legends** - MOBA 🌟\n" +
                "7. **Valorant** - FPS 🌟\n" +
                "8. **FIFA 24** - Spor 🌟\n\n" +
                "💡 Bu oyunlar kafemizde en çok oynananlar!");
        }

        private void ShowRacingGames()
        {
            AddUserMessage("Yarış oyunları göster");
            AddBotMessage("🏎️ **YARIŞ OYUNLARI**\n\n" +
                "1. **Forza Horizon 5** ⭐⭐⭐⭐⭐\n" +
                "   Açık dünya yarış efsanesi.\n\n" +
                "2. **Need for Speed: Unbound** ⭐⭐⭐⭐\n" +
                "   Sokak yarışı aksiyon!\n\n" +
                "3. **Gran Turismo 7** ⭐⭐⭐⭐\n" +
                "   Simülasyon yarış kralı.\n\n" +
                "4. **Assetto Corsa** ⭐⭐⭐⭐\n" +
                "   Gerçekçi simülasyon.\n\n" +
                "5. **F1 23** ⭐⭐⭐⭐\n" +
                "   Formula 1 heyecanı!");
        }

        private void ShowSportsGames()
        {
            AddUserMessage("Spor oyunları göster");
            AddBotMessage("⚽ **SPOR OYUNLARI**\n\n" +
                "1. **EA FC 24 (FIFA)** ⭐⭐⭐⭐⭐\n" +
                "   Futbol simülasyonunun kralı.\n\n" +
                "2. **NBA 2K24** ⭐⭐⭐⭐\n" +
                "   Basketbol tutkunları için.\n\n" +
                "3. **PES / eFootball** ⭐⭐⭐⭐\n" +
                "   Ücretsiz futbol deneyimi.\n\n" +
                "4. **WWE 2K23** ⭐⭐⭐\n" +
                "   Güreş aksiyonu!\n\n" +
                "💡 FIFA turnuvalarımıza katıl!");
        }

        private void ShowStrategyGames()
        {
            AddUserMessage("Strateji oyunları göster");
            AddBotMessage("🎮 **STRATEJİ OYUNLARI**\n\n" +
                "1. **Age of Empires IV** ⭐⭐⭐⭐⭐\n" +
                "   Klasik RTS geri döndü!\n\n" +
                "2. **Civilization VI** ⭐⭐⭐⭐⭐\n" +
                "   Sıra tabanlı strateji efsanesi.\n\n" +
                "3. **Total War: Warhammer 3** ⭐⭐⭐⭐\n" +
                "   Epik savaşlar!\n\n" +
                "4. **Starcraft II** ⭐⭐⭐⭐\n" +
                "   E-spor klasiği. Ücretsiz!\n\n" +
                "5. **Europa Universalis IV** ⭐⭐⭐⭐\n" +
                "   Derin grand strateji.");
        }

        private void ShowHorrorGames()
        {
            AddUserMessage("Korku oyunları göster");
            AddBotMessage("💀 **KORKU OYUNLARI**\n\n" +
                "1. **Resident Evil 4 Remake** ⭐⭐⭐⭐⭐\n" +
                "   Korku aksiyon şaheseri!\n\n" +
                "2. **Phasmophobia** ⭐⭐⭐⭐\n" +
                "   Co-op hayalet avı. Çok korkunç!\n\n" +
                "3. **Dead by Daylight** ⭐⭐⭐⭐\n" +
                "   Asimetrik multiplayer korku.\n\n" +
                "4. **Outlast Series** ⭐⭐⭐⭐\n" +
                "   Saf korku deneyimi.\n\n" +
                "5. **Alan Wake 2** ⭐⭐⭐⭐⭐\n" +
                "   Psikolojik korku.\n\n" +
                "⚠️ Kalp hastalarına önerilmez!");
        }

        public void AddUserMessage(string message)
        {
            var msgPanel = CreateMessageBubble(message, true);
            flowMessages.Controls.Add(msgPanel);
            ScrollToBottom();
        }

        public void AddBotMessage(string message)
        {
            var msgPanel = CreateMessageBubble(message, false);
            flowMessages.Controls.Add(msgPanel);
            ScrollToBottom();
        }

        private Panel CreateMessageBubble(string message, bool isUser)
        {
            Panel bubble = new Panel
            {
                AutoSize = true,
                MaximumSize = new Size(360, 0),
                MinimumSize = new Size(100, 40),
                Margin = new Padding(5, 5, 5, 5),
                Padding = new Padding(12),
                BackColor = isUser ? Color.FromArgb(138, 43, 226) : Color.FromArgb(45, 47, 70)
            };

            Label lblMessage = new Label
            {
                Text = message,
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = Color.White,
                AutoSize = true,
                MaximumSize = new Size(330, 0),
                Location = new Point(12, 10)
            };
            bubble.Controls.Add(lblMessage);

            // Yuvarlak köşeler
            bubble.Paint += (s, e) =>
            {
                using (GraphicsPath path = RoundedRect(bubble.ClientRectangle, 12))
                {
                    bubble.Region = new Region(path);
                }
            };

            return bubble;
        }

        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            path.AddArc(arc, 180, 90);
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();

            return path;
        }

        private void ScrollToBottom()
        {
            flowMessages.VerticalScroll.Value = flowMessages.VerticalScroll.Maximum;
            flowMessages.PerformLayout();
        }

        public new void Show()
        {
            this.Visible = true;
            this.BringToFront();
        }

        public new void Hide()
        {
            this.Visible = false;
        }

        public void Toggle()
        {
            if (this.Visible)
                Hide();
            else
                Show();
        }
    }
}
