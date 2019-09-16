using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClaseLunes
{
    public partial class Form1 : Form
    {
        Timer timer;
        private int x = 0;
        private int y = 100;
        private int ancho = 100;
        private int alto = 50;
        private bool band = true;
        private int rojo;
        private int verde;
        private int vel = 0;
        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000 / 60;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        //int dir = 1; int velo = 5;
        private void Timer_Tick(object sender, EventArgs e)
        {
            //DateTime.Now.Millisecond
            Random r = new Random();
            //aqui van todas las actualizaciones
            /*
            x+= dir*velo;
            if (x+ancho >= ClientSize.Width)
            {
                dir = -dir;
                x = ClientSize.Width - ancho;
            }
            if (x <= 0)
            {
                dir = -dir;
                x = 0;
            }
            */
            
            if (x+ancho <= this.ClientSize.Width && band)
            {
                x++;
                if (x + ancho == this.ClientSize.Width)
                {
                    rojo = 255;
                    verde = 0;
                    this.BackColor = System.Drawing.Color.Black;
                }       
            }
            else
            {
                band = false;
                x--;
                if (x == 0)
                {
                    band = true;
                    verde = 255;
                    rojo = 0;
                    this.BackColor = System.Drawing.Color.Blue;
                }
                    
            }
            
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen p;
            SolidBrush b;
            Graphics g;
            g = null;
            p = new Pen(Color.FromArgb(255, 255, 255));
            b = new SolidBrush(Color.FromArgb(255, rojo, verde, 255));
            g = e.Graphics;
            g.DrawRectangle(p, x, y, ancho, alto);
            g.FillRectangle(b, x, y, ancho, alto);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (vel <= 3)
                vel++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (vel != 0)
                vel--;
        }
    }
}
