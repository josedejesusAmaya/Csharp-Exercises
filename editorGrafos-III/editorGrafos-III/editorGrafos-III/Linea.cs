using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace editorGrafos_III
{
    class Linea
    {
        public Nodo origen;
        public Nodo destino;
        public bool conectar = true;

        Graphics gAux;
        Pen pen;

        public Linea(Nodo inicio, Nodo fin)
        {
            origen = inicio;
            destino = fin;
            pen = new Pen(Color.Blue, 6);
        }

        public void dibujaLinea(Graphics g)
        {
            if (conectar)
                g.DrawLine(pen, origen.centro.X, origen.centro.Y, destino.centro.X, destino.centro.Y);
        }
    }
}
