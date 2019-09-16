using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    class Program
    {
        static Hilos hilos;
        static string nCajas;
        static void Main(string[] args)
        {
            Console.Write("Cuantas cajas?:> ");
            nCajas = Console.ReadLine();
     
            hilos = new Hilos();
            hilos.creaCajas(Convert.ToInt32(nCajas));
            hilos.start();
            Console.ReadKey();
            hilos.terminarHilo();
        }
    }
}

