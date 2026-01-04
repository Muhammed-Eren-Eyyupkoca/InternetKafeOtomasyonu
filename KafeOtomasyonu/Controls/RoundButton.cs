using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace KafeOtomasyonu.Controls
{
    public class RoundButton : Button
    {
        private Color _buttonColor = Color.FromArgb(138, 43, 226); // Mor renk
        private Color _hoverColor = Color.FromArgb(155, 89, 182);
        private Color _pressColor = Color.FromArgb(106, 27, 154);
        private bool _isHovering = false;
        private bool _isPressed = false;

        public Color ButtonColor
        {
            get => _buttonColor;
            set { _buttonColor = value; Invalidate(); }
        }

        public Color HoverColor
        {
            get => _hoverColor;
            set { _hoverColor = value; Invalidate(); }
        }

        public RoundButton()
        {
            this.Size = new Size(70, 70);
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 24, FontStyle.Regular);
            this.Cursor = Cursors.Hand;
            this.Text = "🤖";

            // Double buffering için
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | 
                         ControlStyles.UserPaint | 
                         ControlStyles.DoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Arka plan rengi
            Color currentColor = _buttonColor;
            if (_isPressed)
                currentColor = _pressColor;
            else if (_isHovering)
                currentColor = _hoverColor;

            // Gölge efekti
            using (GraphicsPath shadowPath = new GraphicsPath())
            {
                shadowPath.AddEllipse(4, 4, this.Width - 8, this.Height - 8);
                using (PathGradientBrush shadowBrush = new PathGradientBrush(shadowPath))
                {
                    shadowBrush.CenterColor = Color.FromArgb(50, 0, 0, 0);
                    shadowBrush.SurroundColors = new Color[] { Color.Transparent };
                    e.Graphics.FillPath(shadowBrush, shadowPath);
                }
            }

            // Ana daire
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(2, 2, this.Width - 8, this.Height - 8);
                
                // Gradient arka plan
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    new Rectangle(0, 0, this.Width, this.Height),
                    currentColor,
                    ControlPaint.Dark(currentColor, 0.2f),
                    LinearGradientMode.ForwardDiagonal))
                {
                    e.Graphics.FillPath(brush, path);
                }

                // Parlak efekt (üst kısım)
                using (GraphicsPath highlightPath = new GraphicsPath())
                {
                    highlightPath.AddEllipse(8, 4, this.Width - 20, (this.Height - 8) / 2);
                    using (PathGradientBrush highlightBrush = new PathGradientBrush(highlightPath))
                    {
                        highlightBrush.CenterColor = Color.FromArgb(60, 255, 255, 255);
                        highlightBrush.SurroundColors = new Color[] { Color.Transparent };
                        e.Graphics.FillPath(highlightBrush, highlightPath);
                    }
                }
            }

            // Metin (emoji)
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font,
                new Rectangle(0, 0, this.Width - 4, this.Height - 4),
                this.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _isHovering = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _isHovering = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _isPressed = true;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _isPressed = false;
            Invalidate();
            base.OnMouseUp(e);
        }
    }
}

