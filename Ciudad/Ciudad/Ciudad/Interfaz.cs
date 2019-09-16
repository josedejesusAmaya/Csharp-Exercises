using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Ciudad
{
    public delegate void DelPrint(int h);

    public class Interfaz
    {
        private Ciudad ciudad;

        public Interfaz()
        {
            ciudad = new Ciudad(PrintBuilt,PrintDestroyed);
        }

        public void PrintBuilt(int h)
        {
            Console.WriteLine("Se construyeron " +h);
        }

        public void PrintDestroyed(int h)
        {
            Console.WriteLine("Se destruyeron " +h);
        }
    }        
}
