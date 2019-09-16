using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Pelota
    {
        public int x, y; //coordenadas de la pelota
        public int vel = 5; //velocidad a la que se mueve la pelota
        public int dirx = 1, diry = 1; //direccion en la que se mueve la pelota
        public Rectangle e; //figura utilizada
        public Pelota(int x, int y)
        {
            this.x = x;
            this.y = y;
            e = new Rectangle(x, y, 25, 25);
        }

        
    }
}
