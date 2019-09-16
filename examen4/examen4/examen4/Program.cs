using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen4
{
    class Program
    {
        static Hilos hilos;
        static void Main(string[] args)
        {
            hilos = new Hilos();
            Console.ReadKey();
            hilos.terminarHilo();
        }
    }
}
