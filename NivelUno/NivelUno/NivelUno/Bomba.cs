using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NivelUno
{
    class Bomba
    {
        Bitmap bomba1 = new Bitmap((Bitmap)Image.FromFile("bomba3.png"));
        Bitmap bomba2 = new Bitmap((Bitmap)Image.FromFile("bomba1.png"));
        Bitmap bomba3 = new Bitmap((Bitmap)Image.FromFile("bomba4.png"));
        Bitmap bomba4 = new Bitmap((Bitmap)Image.FromFile("bomba5.png"));

        Bitmap mina = new Bitmap((Bitmap)Image.FromFile("mina2.png"));
        public int x, y;
        public int tipo;
        public int cont = 0;
        public Bomba()
        {

        }

        public Bitmap getImage()
        {
            Bitmap ret = new Bitmap((Bitmap)Image.FromFile("bomba3.png"));
            switch(tipo)
            {
                case 1:
                    ret = bomba1;
                    break;
                case 2:
                    ret = bomba2;
                    break;
                case 3:
                    ret = bomba3;
                    break;
                case 4:
                    ret = bomba4;
                    break;
                case 5:
                    ret = mina;
                    break;
                case 6:
                    ret = bomba2;
                    break;
            }
            return ret;
        }
    }
}
