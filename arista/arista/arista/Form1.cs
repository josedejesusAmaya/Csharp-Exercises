using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arista
{
    public partial class Form1 : Form
    {
        private bool drag = false;
        List<Arista> aristas;
        public Form1()
        {
            InitializeComponent();
            aristas = new List<Arista>();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen;
            pen = new Pen(Color.FromArgb(255, 0, 0, 0), 4);
            SolidBrush brush;
            brush = new SolidBrush(Color.FromArgb(255,255,255));
            Graphics g;
            g = e.Graphics;
            
            /*g.DrawEllipse(pen, new Rectangle(200, 200, 40, 40));
            g.FillEllipse(brush, new Rectangle(200, 200, 40, 40));

            g.DrawEllipse(pen, new Rectangle(500, 170, 40, 40));
            g.FillEllipse(brush, new Rectangle(500, 170, 40, 40));

            g.DrawRectangle(pen, new Rectangle(200, 200, 40, 40));
            */

            for (int i = 0; i < aristas.Count; i++)
                g.DrawLine(pen, aristas[i].x, aristas[i].y, aristas[i].pX, aristas[i].pY);

            //Pen pen = new Pen(Color.FromArgb(255, 0, 0, 255), 8);
            //pen.StartCap = LineCap.ArrowAnchor;
            //pen.EndCap = LineCap.RoundAnchor;
            //e.Graphics.DrawLine(pen, 20, 175, 300, 175);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!drag) return;
            aristas[aristas.Count - 1].pX = e.X;
            aristas[aristas.Count - 1].pY = e.Y;
            Invalidate();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Arista arista = new Arista();
            aristas.Add(arista);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            aristas[aristas.Count - 1].x = e.X;
            aristas[aristas.Count - 1].y = e.Y;
            drag = true;
        }
    }
}
