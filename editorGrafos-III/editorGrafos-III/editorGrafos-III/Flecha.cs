using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace editorGrafos_III
{
    class Flecha
    {
        public Nodo origen;
        public Nodo destino;

        Pen pen;
        Pen pen2;
        Point flecha1;
        Point flecha2;
        int radio = 20;
        public bool conectar = true;

        public Flecha(Nodo inicio, Nodo fin)
        {
            origen = inicio;
            destino = fin;
            pen = new Pen(Color.Green, 6);
        }

        public void dibujaFlecha(Graphics g)
        {
            if (!conectar) return;

            pen.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;

            double tg = (double)(origen.centro.Y - destino.centro.Y) / (destino.centro.X - origen.centro.X);

            double atg = Math.Atan(tg);

            int a = (int)(radio * Math.Cos(atg));
            int b = (int)(radio * Math.Sin(atg));

            if ((origen.centro.X < destino.centro.X))
            {
                a *= -1;
                b *= -1;
            }
            Point p = new Point(destino.centro.X + a, destino.centro.Y - b);
            g.DrawLine(pen, p.X, p.Y, origen.centro.X, origen.centro.Y);
        }
    }
}
