using System;
using System.Drawing;
using System.Windows.Forms;

namespace dosFiguras
{
    public partial class Form1 : Form
    {
        Timer timer;
        private int x = 0;
        private int x2;
        private int y = 100;
        private int y2 = 100;
        private int w = 100;
        private int h = 50;
        private int w2 = 100;
        private int h2 = 50;
        private int vel = 5;
        private int dirx = 1;
        private int diry = 1;
        private int dirx2 = 1;
        private int diry2 = 1;
        public Form1()
        {
            InitializeComponent();
            x2 = ClientSize.Width - w2;
            timer = new Timer();
            timer.Interval = 1000 / 60;
            timer.Tick += Timer_Tick1;
            timer.Start();
        }

        private void Timer_Tick1(object sender, EventArgs e)
        {
            //aqui van todas las actualizaciones
            //DateTime.Now.Millisecond
            Random r = new Random();
            x += dirx * vel;
            y += diry * vel;
            x2 -= dirx2 * vel;
            y2 -= diry2 * vel;
            if (x <= 0)
            {
                int p = r.Next(0, 4);
                if (p == 0)
                    diry = -diry;
                dirx = -dirx;
                x = 0;
            }

            if (y <= 0)
            {
                int p = r.Next(0, 4);
                if (p == 0)
                    dirx = -dirx;
                diry = -diry;
                y = 0;
            }

            if (y + h >= this.ClientSize.Height)
            {
                int p = r.Next(0, 4);
                if (p == 1)
                    dirx = -dirx;
                diry = -diry;
                y = this.ClientSize.Height - h;
            }

            if (x + w >= this.ClientSize.Width)
            {
                int p = r.Next(0, 4);
                if (p == 1)
                    diry = -diry;
                dirx = -dirx;
                x = this.ClientSize.Width - w;
            }

            if (x2 <= 0)
            {
                int p = r.Next(0, 6);
                if (p == 0)
                    diry2 = -diry2;
                dirx2 = -dirx2;
                x2 = 0;
            }

            if (y2 <= 0)
            {
                int p = r.Next(0, 6);
                if (p == 0)
                    dirx2 = -dirx2;
                diry2 = -diry2;
                y2 = 0;
            }

            if (y2 + h2 >= this.ClientSize.Height)
            {
                int p = r.Next(0, 6);
                if (p == 1)
                    dirx2 = -dirx2;
                diry2 = -diry2;
                y2 = this.ClientSize.Height - h2;
            }

            if (x2 + w2 >= this.ClientSize.Width)
            {
                int p = r.Next(0, 6);
                if (p == 1)
                    diry2 = -diry2;
                dirx2 = -dirx2;
                x2 = this.ClientSize.Width - w2;
            }

            if (x2 > x &&      y2 > y &&      x2 < x + w &&      y2 < y + h ||
           x2 + w2 > x &&      y2 > y && x2 + w2 < x + w &&      y2 < y + h ||
           x2 + w2 > x && y2 + h2 > y && x2 + w2 < x + w && y2 + h2 < y + h ||
                x2 > x && y2 + h2 > y &&      x2 < x + w && y2 + h2 < y + h)
            {
                dirx = -dirx;
                diry = -diry;
                dirx2 = -dirx2;
                diry2 = -diry2;
            }
            Invalidate();
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            Pen p;
            SolidBrush b;
            Graphics g;
            g = null;
            p = new Pen(Color.FromArgb(255, 255, 255));
            b = new SolidBrush(Color.FromArgb(255, 0, 0, 255)); //azul
            g = e.Graphics;
            g.DrawRectangle(p, x, y, w, h);
            g.FillRectangle(b, x, y, w, h);
            b = new SolidBrush(Color.FromArgb(255, 255, 0, 0)); //rojo
            g.DrawRectangle(p, x2, y2, w2, h2);
            g.FillRectangle(b, x2, y2, w2, h2);
        }
    }
}
    
