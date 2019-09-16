using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GDI
{
    class Nodo
    {
        static int orden = 65;

        int num;
        Point centro;
        int radio;
        Rectangle rec;

        GraphicsPath gp;
        Pen circ;
        Pen lin;
        Font letra;
        List<Nodo> conec;

        public Nodo (int x, int y, int r)
        {
            centro = new Point(x, y);
            radio = r;
            rec = new Rectangle(x - r, y - r, 2 * r, 2 * r);

            gp = new GraphicsPath();
            gp.AddEllipse(rec);

            circ = new Pen(Brushes.Black, 3);
            letra = new Font("arial", 12);

            num = orden++;
            conec = new List<Nodo>();

            //Flecha
            GraphicsPath gpFlecha = new GraphicsPath();
            lin = new Pen(Brushes.Blue, 3);

            gpFlecha.AddLine(new Point(0, 0), new Point(3, -3));
            gpFlecha.AddLine(new Point(0, 0), new Point(-3, -3));
            lin.CustomEndCap = new CustomLineCap(null, gpFlecha);
        }

        public virtual void DibujaNodo(Graphics g)
        {
            g.FillPath(Brushes.White, gp);
            g.DrawPath(circ, gp);
            g.DrawString(Convert.ToChar(num).ToString(), letra, Brushes.Black, rec, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }
            
        //silen voice

        public virtual void DibujaArista(Graphics g)
        {
            foreach (Nodo item in conec)
            {
                double tg = (double)(centro.Y - item.centro.Y) / (item.centro.X - centro.X);
                double atg = Math.Atan(tg);

                int a = (int)(radio * Math.Cos(atg));
                int b = (int)(radio * Math.Sin(atg));
                
                if ((centro.X < item.centro.X))
                {
                    a *= -1;
                    b *= -1;
                }

                Point p = new Point(item.centro.X + a, item.centro.Y - b);
                //Point p = new Point(item.centro.X, item.centro.Y);
                g.DrawLine(lin, centro, p);
            }
        }
        public bool Adentro(Point pt)
        {
            return gp.IsVisible(pt);
        }

        public void Posicion(Point pt)
        {
            gp.Transform(new Matrix(1, 0, 0, 1, pt.X - centro.X, pt.Y - centro.Y));
            centro = pt;
            rec = Rectangle.Round(gp.GetBounds());
        }

        public void ConectarA(Nodo n)
        {
            conec.Add(n);
        }

        public void Desconectar(Nodo n)
        {
            conec.Remove(n);
        }
    }
}
