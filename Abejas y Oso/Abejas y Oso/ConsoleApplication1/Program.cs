using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static string nAbejas;
        static string tarro;
        static Hilos hilos;
        static void Main(string[] args)
        {
            Console.Write("Cuantas abejas?:> ");
            nAbejas = Console.ReadLine();
            Console.Write("Tama;o del tarro:> ");
            tarro = Console.ReadLine();

            hilos = new Hilos();
            hilos.creaAbejas(Convert.ToInt32(nAbejas));
            hilos.setTarro(Convert.ToInt32(tarro));
            hilos.start();
            Console.ReadKey();
            hilos.terminaHilo();
        }
    }
}
