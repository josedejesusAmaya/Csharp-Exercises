using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examenTres
{
    public partial class Form1 : Form
    {
        Bitmap b = (Bitmap)Image.FromFile(@"C:\Users\Owner\Pictures\google2.jpg");
        ColorDialog MyDialog = new ColorDialog();
        Color p, r;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = e.Graphics;
            g.DrawImage(b, 0, 0);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            r = b.GetPixel(e.X, e.Y);
            MyDialog.ShowDialog();
            p = MyDialog.Color;
            /*MessageBox.Show("" + r.R);
            MessageBox.Show("" + r.B);
            MessageBox.Show("" + r.G);
            
            MessageBox.Show("" + p.R);
            MessageBox.Show("" + p.B);
            MessageBox.Show("" + p.G);
            */
            //p = Color.FromArgb(red, blue, green);
            for (int i = 0; i < b.Width; i++)
            {
                for (int w = 0; w < b.Height; w++)
                {
                    Color r = b.GetPixel(i, w);
                    r = Color.FromArgb(0, r.G, r.B);
                    b.SetPixel(i,w,r);    
                }
            }
            Invalidate();
        }
    }
}
