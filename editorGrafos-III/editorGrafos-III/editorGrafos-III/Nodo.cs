using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace editorGrafos_III
{
    class Nodo
    {
        static int orden = 65;

        public int letra;
        public Point centro;
        int radio;
        Rectangle rec;
        Font tipoLetra;
        Pen circ;
        Pen pen;
        SolidBrush brush;
        Graphics gAux;

        public Nodo(int x, int y, int r)
        {
            centro = new Point(x, y);
            radio = r;
            letra = orden++;
            tipoLetra = new Font("arial", 12);
            circ = new Pen(Brushes.Black, 3);
            pen = new Pen(Color.Black, 5);
            brush = new SolidBrush(Color.White);
        }

        public void dibujaNodo(Graphics g)
        {
            gAux = g;
            rec = new Rectangle(centro.X - radio, centro.Y - radio, 2 * radio, 2 * radio);
            g.DrawEllipse(pen, rec);
            g.FillEllipse(brush , rec);
            g.DrawString(Convert.ToChar(letra).ToString(), tipoLetra, Brushes.Black, rec, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }

        public bool adentro(Point pt)
        {
            bool band = false;
            int x = centro.X - 20;
            int y = centro.Y - 20;

            if (pt.X >= x && pt.X <= x + radio * 2)
                if (pt.Y >= y && pt.Y <= y + radio * 2)
                    band = true;
            return band;
        }

        public void posicion(Point pt)
        {
            centro = pt;
        }
    }
}
