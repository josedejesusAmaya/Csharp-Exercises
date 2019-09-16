using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenUno
{
    public delegate void delPrint(int tiempo, int estacionados);
    public delegate void delPrint1(int sal);
    public delegate void delPrint2(int wait, int went);

    class Interfaz
    {
        private Estacionamiento estacionamiento;
        public Interfaz()
        {
            estacionamiento = new Estacionamiento(printEntrada, printSalida, printEspera);
        }

        public void printEntrada(int tiempo, int estacionados)
        {
            Console.WriteLine("Tiempo transcurrido " + tiempo);
            Console.WriteLine("Autos estacionados " + estacionados);
        }

        public void printSalida(int sal)
        {
         
        }

        public void printEspera(int wait, int went)
        {
            Console.WriteLine("Autos en espera " + wait);
            Console.WriteLine("Autos que se fueron " + went);
            Console.WriteLine("-------------------------------------------------------");
        }
    }
}
