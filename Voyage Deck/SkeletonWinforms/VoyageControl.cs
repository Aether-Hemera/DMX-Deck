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
        int Rows = 0;
        int Cols = 0;

        public VoyageControl()
        {
            InitializeComponent();
            Boats = new Color[Rows, Cols];
            refresh = DateTime.Now;
        }

        private void PrepareArray()
        {
            Boats = new Color[Rows,Cols];
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    Boats[row, col] = Color.White;
                }
            }
        }

        protected T[,] ResizeArray<T>(T[,] original, int x, int y)
        {
            T[,] newArray = new T[x, y];
            int minX = Math.Min(original.GetLength(0), newArray.GetLength(0));
            int minY = Math.Min(original.GetLength(1), newArray.GetLength(1));

            for (int i = 0; i < minY; ++i)
                Array.Copy(original, i * original.GetLength(0), newArray, i * newArray.GetLength(0), minX);
            return newArray;
        }

        Color[,] Boats;

        const int boxTotWidth = 12;
        const int boxTotHeight = 12;
        const int boxWidth = 10;
        const int boxHeight = 10;

        DateTime refresh;

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (DateTime.Now > refresh)
            { 
                base.OnPaintBackground(e);
                refresh = DateTime.Now.AddMilliseconds(3000);
            }
        }

        public enum Order
        {
            Normal,
            Inverted
        }


        private Order _rowOrder = Order.Inverted;

        public Order RowOrder
        {
            get { return _rowOrder; }
            set { _rowOrder = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    if (Boats[row, col] != null)
                    {
                        var x = col*boxTotWidth;
                        var y = row*boxTotHeight;

                        if (RowOrder == Order.Inverted)
                            y = this.Height - y - boxHeight;

                        Brush b = new SolidBrush(Boats[row, col]);
                        e.Graphics.FillRectangle(b, x ,y , boxWidth, boxHeight);
                    }
                }
            }
            base.OnPaint(e);
        }

        public void SetColor(int row, int col, Color color)
        {
            bool bResize = false;
            if (row >= Rows)
            {
                Rows = row + 1;
                bResize = true;
            }
            if (col >= Cols)
            {
                Cols = col + 1;
                bResize = true;
            }
            if (bResize)
                PrepareArray();
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
