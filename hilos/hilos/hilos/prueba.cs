using System;
using System.Threading;

namespace hilos
{
    class prueba
    {
        bool salir = false;
        bool puedoimprimir = false;
        int a = 0;
        public prueba()
        {
            Thread t = new Thread(hilo);
            Thread t1 = new Thread(hilo2);

            t.Start();
            t1.Start();
            //while (true) { }
            
        }

        public void terminoHilo()
        {
            salir = true;
        }

        public void hilo()
        {
            //   for (int i = 0; i < 100; i++)
            //       Console.WriteLine("hilo1: " + i);
            //a = 100; no siempre imprime el 100
            
            while(salir == false)
            {
                /*     if (escien == true)
                     {
                         Console.WriteLine("llego a cien con a = " + a);
                         escien = false;
                     }*/
                if (puedoimprimir == true)
                {
                    Console.WriteLine(a);
                    puedoimprimir = false;
                }
            }
        }

        public void hilo2()
        {
            //for (int i = 0; i < 100; i++)
            //    Console.WriteLine("hilo2: " + i);
            for (int i = 0; i < 20;  i++)
            {
                while(puedoimprimir) { }
                a = i;
                puedoimprimir = true;
                //if (a == 100) escien = true;
            }
        }
    }
}
