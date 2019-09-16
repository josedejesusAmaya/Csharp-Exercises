using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace imageRebotando
{
    public partial class Form1 : Form
    {
        Bitmap b = (Bitmap)Image.FromFile(@"C:\Users\Owner\Pictures\cerebrito.png");
        private int vel = 5;
        private bool band = false;
        Timer timer;
        List<Imagen> imagenes;
        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            imagenes = new List<Imagen>();
            timer.Interval = 1000 / 60;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < imagenes.Count; i++)
            {
                imagenes[i].x += imagenes[i].dirx * vel;
                if (imagenes[i].x + (b.Width - 40) >= this.ClientSize.Width)
                {
                    imagenes[i].dirx = -imagenes[i].dirx;
                    imagenes[i].x = this.ClientSize.Width - (b.Width - 40);
                }

                if (imagenes[i].x <= 25)
                {
                    imagenes[i].dirx = -imagenes[i].dirx;
                    imagenes[i].x = 25;
                }
            }
            
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (band)
            {
                Graphics g;
                g = null;
                g = e.Graphics;
                for (int i = 0; i < imagenes.Count; i++)
                    g.DrawImage(b, imagenes[i].x - 35, imagenes[i].y - 35);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Imagen im = new Imagen();
            im.x = e.X;
            im.y = e.Y;
            imagenes.Add(im);
            band = true;
        }
    }
}
