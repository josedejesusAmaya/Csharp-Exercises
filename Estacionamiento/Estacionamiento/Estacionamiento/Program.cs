using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamiento
{
    class Program
    {
        static Hilos hilos;
        static string nPlaces;
        static void Main(string[] args)
        {
            Console.Write("Cuantas lugares para el estacionamiento?:> ");
            nPlaces = Console.ReadLine();

            hilos = new Hilos();
            hilos.creaLugares(Convert.ToInt32(nPlaces));
            hilos.start();
            Console.ReadKey();
            hilos.terminaHilo();
        }
    }
}
