using System;

namespace Timer
{
    public delegate void delegado(int cont);
    public class Program
    {
        static void Main(string[] args)
        {
            delegado d = new delegado(resultado);
            Contador c = new Contador();
            c.Count(d);
        }
        
        public static void resultado(int o)
        {
            Console.WriteLine("ya paso " + o + " segundo");
            //Console.ReadKey();
        }

    }
}
