using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace proyecto
{
    class Bloque
    {
        public int x = 0, y = 0;
        public int tipo = -1;
        public Bitmap concreto = (Bitmap)Image.FromFile("concreto.png");
        public Bitmap ladrillo = (Bitmap)Image.FromFile("ladrillo.png");
        public Bloque()
        {

        }
    }
}
