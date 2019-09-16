using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace editorGrafos
{
    class Nodo
    {
        public int X, Y;

        static int orden = 65;
        int num;
        Point centro;
        int radio;
        Rectangle rec;

        GraphicsPath gp;
        Pen circulo;
        Pen linea;
        List<Nodo> conec;
        Font letra;

        public Nodo(int x, int y, int r)
        {
            centro = new Point(x, y);
            radio = r;
            rec = new Rectangle(x - r, y - r, 2 * r, 2 * r);

            gp = new GraphicsPath();
            gp.AddEllipse(rec);

            circulo = new Pen(Brushes.Black, 3);
            letra = new Font("arial", 12);
            num = orden++;
            conec = new List<Nodo>();

            linea = new Pen(Brushes.DimGray, 3);

            GraphicsPath gpLin = new GraphicsPath();
            gpLin.AddLine(new Point(0, 0), new Point(3, -3));
           
            linea.CustomEndCap = new CustomLineCap(null,gpLin);
        }

        public virtual void DibujaNodo(Graphics g)
        {
            g.FillPath(Brushes.White, gp);
            g.DrawPath(circulo, gp);
            g.DrawString(Convert.ToChar(num).ToString(), letra, Brushes.Black, rec, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
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
