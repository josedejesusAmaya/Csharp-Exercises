using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace claseJueves
{
    public partial class Form1 : Form
    {
        private int x = 0, y= 0, p = 5;
        Bitmap b = (Bitmap)Image.FromFile(@"C:\Users\Owner\Pictures\human.jpg");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = e.Graphics;
            g.DrawImage(b, x, y);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 38) // up
                y -= p;
            if (e.KeyValue == 40) // down
                y += p;
            if (e.KeyValue == 39) //right
                x += p;
            if (e.KeyValue == 37) //lefth
                x -= p;
            Invalidate();
        }
    }
}
