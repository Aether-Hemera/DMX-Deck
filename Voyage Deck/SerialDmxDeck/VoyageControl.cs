using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SerialDmxDeck
{
    public partial class VoyageControl : UserControl
    {
        public VoyageControl()
        {
            InitializeComponent();
            Boats = new Color[12, 25];
            refresh = DateTime.Now;

            for (int row = 0; row < 12; row++)
            {
                for (int col = 0; col < 25; col++)
                {
                    Boats[row, col] = Color.Black;
                }
            }

        }

        Color[,] Boats;

        const int boxTotWidth = 12;
        const int boxTotHeight = 10;
        const int boxWidth = 10;
        const int boxHeight = 8;

        DateTime refresh;

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (DateTime.Now > refresh)
            { 
                base.OnPaintBackground(e);
                refresh = DateTime.Now.AddMilliseconds(3000);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            for (int row = 0; row < 12; row++)
            {
                for (int col = 0; col < 25; col++)
                {
                    Brush b = new SolidBrush(Boats[row, col]);
                    e.Graphics.FillRectangle(b, col * boxTotWidth, row * boxTotHeight, boxWidth, boxHeight);
                }
            }

            base.OnPaint(e);
        }

        public void SetColor(int row, int col, Color color)
        {
            Boats[row, col] = color;
            this.Invalidate();
        }

        public enum ChannelName
        {
            Red,
            Green,
            Blue
        }

        public void SetChannel(int row, int col, int channel, int Intensity)
        {
            switch(channel)
            {
                case 0:
                    SetChannel(row, col, ChannelName.Red, Intensity);
                    break;
                case 1:
                    SetChannel(row, col, ChannelName.Green, Intensity);
                    break;
                case 2:
                    SetChannel(row, col, ChannelName.Blue, Intensity);
                    break;
            }
        }

        public void SetChannel(int row, int col, ChannelName channel, int Intensity)
        {
            int r = Boats[row, col].R;
            int g = Boats[row, col].G;
            int b = Boats[row, col].B;

            switch (channel)
            {
                case ChannelName.Red:
                    r = Intensity;
                    break;
                case ChannelName.Green:
                    g = Intensity;
                    break;
                case ChannelName.Blue:
                    b = Intensity;
                    break;
            }

            Boats[row, col] = Color.FromArgb(r, g, b);
            this.Invalidate();
        }
    }
}
