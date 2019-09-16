using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Jugador
    {
        public int x, y; //coordenadas para el jugador
        public Rectangle r; //figura utilizada para la raqueta
        public Jugador(int x, int y)
        {
            this.x = x;
            this.y = y;

            r = new Rectangle(x, y, 7, 60); 
        }

        public void mv_arriba() //metodo que permite mover la raqueta hacia arriba
        {
            r.Y -= 5;
        }

        public void mv_abajo() //metodo que permite mover la raqueta hacia abajo
        {
            r.Y += 5;
        }
    }
}
