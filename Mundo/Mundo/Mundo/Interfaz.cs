using System;


namespace Mundo
{
    public delegate void delPrint(int tope, int m, int f, int poblacion);
    public delegate void delPrint2(int hab, int muertos);
    public delegate void delPrint3(int enfermos);

    public class Interfaz
    {
        private Mundo mundo;

        public Interfaz()
        {
            mundo = new Mundo(printBorn,printLive,printSick);
        }

        public void printBorn(int tope, int m, int f, int poblacion)
        {
            Console.WriteLine("nacieron:> " + tope + " personas");
            Console.WriteLine("hombres:> " + m);
            Console.WriteLine("mujeres:> " + f);
        }

        public void printLive(int poblacion, int muertos)
        {
            Console.WriteLine("poblacion:> " + poblacion);
            Console.WriteLine("muertos:> " + muertos);
        }

        public void printSick(int enfermos)
        {
            Console.WriteLine("enfermos:> " + enfermos);
        }
    }
}
