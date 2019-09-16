using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static bool var = false;
        static int jarraA = 0;
        static int jarraB = 0;
        static int capacidadA = 4;
        static int capacidadB = 3;
        static int referente = -10; 
        static string opcion;
        static int edo;
        static int auxEdo;
        static void Main(string[] args)
        {
            Console.WriteLine("presione cualquier tecla para empezar?");
            opcion = Console.ReadLine();
            //se llena jarra A
            jarraA = 4;
            //vaciar el contenido de A a B
            while (referente != 0)
            {
                cambiarA(ref jarraA, ref jarraB);
                edo = (capacidadA - jarraA) - 2;
                auxEdo = edo;
                if (referente == -10)
                    referente = edo;
                else
                {
                    if (edo == 0)
                    {
                        referente = edo;
                        Console.WriteLine("El programa ha terminado");
                        Console.WriteLine("La jarra A tiene " + jarraA);
                        Console.WriteLine("La jarra B tiene " + jarraB);
                        Console.WriteLine("Referente = " + referente);
                        Console.ReadLine();
                        return;
                    }
                    if (referente > edo)
                        referente = edo;
                }
                //se llena la segunda jarra
                int antJarraA = 0;
                int antJarraB = 3;
                cambiarB(ref antJarraA, ref antJarraB);
                edo = (capacidadA - antJarraA) - 2;
                if (edo > auxEdo)
                {
                    referente = edo;
                    jarraA = antJarraA;
                    jarraB = antJarraB;
                }
                else
                {
                    antJarraA = jarraA;
                    antJarraB = jarraB;
                    referente = auxEdo;
                    if (!var) //aqui se vacia una jarra
                    {
                        //vaciar una 
                        jarraA = 0;
                        edo = (capacidadA - jarraA) - 2;
                        auxEdo = edo;

                        jarraA = antJarraA;
                        jarraB = 0;
                        edo = (capacidadA - jarraA) - 2;
                        if (auxEdo > edo)
                            referente = edo;
                        else
                        {
                            jarraA = antJarraA;
                            jarraB = antJarraB;
                            referente = auxEdo;
                        }

                        var = !var;
                    }
                    else //aqui se llena una de las jarras
                    {
                        //se llena A
                        jarraA = 4;
                        antJarraA = jarraA;

                        edo = (capacidadA - jarraA) - 2;
                        auxEdo = edo;

                        jarraA = 0;
                        antJarraB = jarraB;
                        jarraB = 4;
                        edo = (capacidadA - jarraA) - 2;
                        
                        if (auxEdo < edo)
                        {
                            jarraB = antJarraB;
                            referente = auxEdo;
                            jarraA = antJarraA;
                            jarraB = antJarraB;
                        }
                        var = !var;
                    }
                }
            }
        }

        private static void cambiarA(ref int jarraA, ref int jarraB)
        {
            int b = jarraB;
            jarraB = jarraA;
            if (jarraB > 3)
                jarraB--;

            if (jarraA < 4)
                jarraA = 0;
            else
                jarraA = (jarraA - (capacidadB - b));
        }

        private static void cambiarB(ref int jarraA, ref int jarraB)
        {
            jarraA = jarraB;
            jarraB = 0;
        }
    }
}
