using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace editorGrafos_III
{
    class Arista
    {
        public Nodo destino;
        int radio = 15;
        int auxX = 0;
        int auxY = 0;
        Pen pen;
        SolidBrush brush = new SolidBrush(Color.Red);
        Rectangle rec;

        public Arista(Nodo final)
        {
            destino = final;
        }

        public Arista()
        {

        }

        public void dibujaArista(Graphics g, int t, Point origen, bool mueveN)
        {
            //encontrar punto medio
            auxX = (origen.X + destino.centro.X) / 2;
            auxY = (origen.Y + destino.centro.Y) / 2;

            if (t == 0) //linea
            {
                pen = new Pen(Color.Blue, 3);
                if (origen.X == destino.centro.X && origen.Y == destino.centro.Y && !mueveN)
                {
                    //Console.WriteLine("es una oreja simple");
                    rec = new Rectangle(origen.X + 7 * 2, origen.Y - 10 * 2, 15 * 2, 15 * 2);
                    g.DrawEllipse(pen, rec);
                    //Rectangle rectangulo;
                    //rectangulo = new Rectangle(origen.centro.X + 7 * 2, origen.centro.Y - 10 * 2, 30, 30);
                    //g.DrawRectangle(pen, rectangulo);
                }
                else
                    g.DrawLine(pen, origen, destino.centro);
            }

            if (t == 1) //flecha
            {
                pen = new Pen(Color.Red, 3);                
                double tg = (double)(origen.Y - destino.centro.Y) / (destino.centro.X - origen.X);
                if (tg.ToString() == "NaN") //con esta condicion puedo detectar la oreja dirigida 
                {
                    rec = new Rectangle(origen.X + 7 * 2, origen.Y - 10 * 2, 15 * 2, 15 * 2);
                    g.DrawEllipse(pen, rec);
                    return;
                }

                double atg = Math.Atan(tg);
                int a = (int)(30 * Math.Cos(atg));
                int b = (int)(30 * Math.Sin(atg));

                if ((origen.X < destino.centro.X))
                {
                    a *= -1;
                    b *= -1;
                }

                if (origen.X == destino.centro.X)
                    b *= -1;

                Point p = new Point(destino.centro.X + a, destino.centro.Y - b);
                g.DrawLine(pen, origen, p);
                rec = new Rectangle(p.X - 5, p.Y - 5, 2 * 5, 2 * 5);
                g.DrawEllipse(pen, rec);
                g.FillEllipse(brush, rec);
            }
        }

        public void setFinal(Nodo fin)
        {
            destino = fin;
        }

        //responde si el clic esta dentro de la arista
        public bool adentro(Point pt)
        {
            bool band = false;
            if (pt.X >= (auxX - radio) && pt.X <= 2 * radio + (auxX - radio))
                if (pt.Y >= (auxY - radio) && pt.Y <= 2 * radio + (auxY - radio))
                    band = true;
            return band;
        } 
    }
}
