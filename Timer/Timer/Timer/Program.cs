using System;

namespace Timer
{
    class Program
    {
        static void Main(string[] args)
        {
            Contador t = new Contador();
            //t.Count(new EventHandler(resultado));
            t.Count(resultado);
        }

        public static void resultado(object o, EventArgs a)
        {
            Console.WriteLine("ya paso " + (int) o + " segundo");
            Console.ReadKey();
        }
    }
}
