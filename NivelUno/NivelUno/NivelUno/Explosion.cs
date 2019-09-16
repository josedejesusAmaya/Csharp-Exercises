using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NivelUno
{
    class Explosion
    {
        Bitmap explosion = new Bitmap((Bitmap)Image.FromFile("explosion1B.png"));
        Bitmap explosion2 = new Bitmap((Bitmap)Image.FromFile("tnt1.png"));
        Bitmap explosion3 = new Bitmap((Bitmap)Image.FromFile("explosion2B.png"));

        public int x, y, tipo;

        public Explosion()
        {

        }

        public Bitmap getImage()
        {
            Bitmap ret = new Bitmap((Bitmap)Image.FromFile("explosion1B.png"));
            switch(tipo)
            {
                case 1:
                    ret = explosion;
                    break;
                case 2:
                    ret = explosion2;
                    break;
                case 3:
                    ret = explosion3;
                    break;
                case 4:
                    ret = explosion;
                    break;
            }
            return ret;
        }
    }
}
