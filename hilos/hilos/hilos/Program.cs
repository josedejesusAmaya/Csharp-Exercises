using System;
using System.Threading;

namespace hilos
{
    class Program
    {
        static void Main(string[] args)
        {

            prueba p = new prueba();
            Console.ReadKey();
            p.terminoHilo(); 
        }
    }
}
