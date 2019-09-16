using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        Bitmap b = (Bitmap)Image.FromFile(@"C:\Users\Owner\Pictures\human.jpg");
        public Form1()
        {
            InitializeComponent();
            this.SetClientSizeCore(b.Width,b.Height);

            for (int i = 0; i < b.Width; i++)
            {
                for (int w = 0; w < b.Height; w++)
                {
                    Color r = b.GetPixel(i, w);
                    //quitar el rojo
                    //r = Color.FromArgb(0, r.G, r.B);
                    //r = Color.FromArgb(200, 200, 200);
                    
                    //una forma de gris
                    //r = Color.FromArgb(r.R, r.R, r.R);
                    int prom = (r.R + r.G + r.B) / 3;
                    
                    //otra forma de gris
                    //r = Color.FromArgb(prom, prom, prom);
                    
                    //blanco y negro
                    if (prom >= 0 && prom <= 127)
                        r = Color.FromArgb(0, 0, 0);
                    else
                        r = Color.FromArgb(255, 255, 255);
                    
                    //negativo
                    //r = Color.FromArgb(255-r.R, 255-r.G, 255-r.B);
                    b.SetPixel(i,w,r);
                }
            }
            //Color c = b.GetPixel(0,0);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = e.Graphics;
            g.DrawImage(b, 0, 0);
        }
    }
}
