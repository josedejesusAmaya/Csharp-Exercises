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
        public int letra;
        public Point centro;
        int radio = 20;
        public int grado;
        Rectangle rec;
        Font tipoLetra;
        Pen pen;
        SolidBrush brush;
        Graphics gAux;
        List<Arista> aristas;
        bool mueveN = false;

        public Nodo(int x, int y, int orden)
        {
            centro = new Point(x, y);
            letra = orden;
            tipoLetra = new Font("arial", 12);
            brush = new SolidBrush(Color.White);
            aristas = new List<Arista>();
        }

        public Nodo()
        {

        }

        public void dibujaNodos(Graphics g, Color c, int tipo)
        {
            rec = new Rectangle(centro.X - radio, centro.Y - radio, 2 * radio, 2 * radio);
            pen = new Pen(c, 5);
            g.DrawEllipse(pen, rec);
            g.FillEllipse(brush, rec);
            g.DrawString(Convert.ToChar(letra).ToString(), tipoLetra, Brushes.Black, rec, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });           
        }

        public void dibujaAristas(Graphics g, Color c, int tipo)
        {
            foreach (Arista item in aristas)
                item.dibujaArista(g, tipo, centro, mueveN);

        }

        public void nDestino(Nodo delet)
        {
            Arista sel = new Arista();
            foreach (Arista item in aristas)
                if (item.destino == delet)
                    sel = item;

            if (sel != null)
                aristas.Remove(sel);
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

        public void creaArista(Nodo destino)
        {
            aristas.Add(new Arista(destino));
        }

        public void vMueve(bool v)
        {
            mueveN = v;
        }
    }
}
