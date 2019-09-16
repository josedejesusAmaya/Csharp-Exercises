using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseMiercolesDos
{
    class Figura
    {
        private int type;
        private int x;
        private int y;
        private int[] relleno = new int[4];
        private int[] contorno = new int[4];
        public Figura()
        {

        }

        public void setRelleno(int[] relleno)
        {
            for (int i = 0; i < relleno.Count(); i++)
                this.relleno[i] = relleno[i];
        }

        public void setContorno(int[] contorno)
        {
            for (int i = 0; i < contorno.Count(); i++)
                this.contorno[i] = contorno[i];
        }

        public void setCoord(int x, int y, int type)
        {
            this.x = x;
            this.y = y;
            this.type = type; 
        }

        public void setX(int x)
        {
            this.x = x;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public int gX()
        {
            return x;
        }

        public int gY()
        {
            return y;
        }

        public int gT()
        {
            return type;
        }
        
        public int rA()
        {
            return relleno[0];
        }
        
        public int rR()
        {
            return relleno[1];
        }

        public int rG()
        {
            return relleno[2];
        }

        public int rB()
        {
            return relleno[3];
        }

        public int cA()
        {
            return contorno[0];
        }

        public int cR()
        {
            return contorno[1];
        }

        public int cG()
        {
            return contorno[2];
        }

        public int cB()
        {
            return contorno[3];
        }
    }
}
