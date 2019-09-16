using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace explosion
{
    public partial class Form1 : Form
    {
        private List<Circulo> circulos = new List<Circulo>();
        private int ncirculos = 0;
        private int conCuad1 = 0;
        private int conCuad2 = 0;
        private int conCuad3 = 0;
        private int conCuad4 = 0;
        private int ancho = 20;
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void avanza(object sender, EventArgs e)
        {

            foreach (var c in circulos)
            {
                c.x += c.dx;
                c.y += c.dy;
            }
            Invalidate();
        } 

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brush;
            Graphics graphic = e.Graphics;

            brush = new SolidBrush(Color.FromArgb(255, 255, 0, 0));
            for (int i = 0; i < circulos.Count; i++)
            {
                graphic.FillEllipse(brush, new Rectangle(circulos[i].x, circulos[i].y, ancho, ancho));
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            circulos.Clear();
            ncirculos = (int)numCir.Value -1;
            for (int i = 0; i <= ncirculos; i++)
            {
                Circulo c = new Circulo();
                c.x = e.X;
                c.y = e.Y;
                c = defineSectores(c);
                circulos.Add(c);
            }

            Timer t = new Timer();
            t.Interval = 16;
            t.Tick += avanza;
            t.Start();
        }
        
        private Circulo defineSectores(Circulo c)
        {
            int dirx, diry;
            dirx = r.Next(0, 2);
            if (dirx == 0)
                dirx = -1;

            diry = r.Next(0, 2);
            if (diry == 0)
                diry = -1;
            
            c.dx = r.Next(1, 9);
            c.dx = c.dx * dirx;

            c.dy = r.Next(1, 9);
            c.dy = c.dy * diry;
            return c;
        }
    }
}
