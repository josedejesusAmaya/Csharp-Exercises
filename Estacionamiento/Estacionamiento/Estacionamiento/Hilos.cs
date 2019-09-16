using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Estacionamiento
{
    class Hilos
    {
        Thread fila;
        Thread estacionamiento;
        bool terminar = false;
        bool fullParking = false;
        Auto auto;
        Parking parking;
        List<Auto> autos = new List<Auto>();
        List<Parking> estaciones = new List<Parking>();
        public Hilos()
        {
            fila = new Thread(hiloUno);
            estacionamiento = new Thread(hiloDos);
        }

        public void hiloUno()
        {
            while (terminar == false)
            {
                int i = 0;
                int auxTime = 1;
                int idCont = 1;
                Random r = new Random();
                if (fullParking == false)
                {
                    if (i == auxTime)
                    {
                        auto = new Auto();
                        auto.id = idCont++;
                        auto.tipo = 1;
                        if (auto.tipo == 1)
                            Console.WriteLine("Llego un auto:> " + auto.id + " al tiempo:> " + i);
                        else
                            Console.WriteLine("Llego una camioneta:> " + auto.id + " al tiempo:> " + i);
                        autos.Add(auto);
                        auxTime = r.Next(1, 6);
                        auxTime += i;
                    }
                    i++;
                    for (int y = 0; y < cajas.Count; y++)
                    {
                        if (cajas[y].cliente != -1)
                        {
                            //Console.WriteLine("cajas [" + y + "].time :> " + cajas[y].time);
                            cajas[y].time++;
                            if (cajas[y].time >= cajas[y].duracion)
                            {
                                Console.WriteLine("Sale el cliente:> " + cajas[y].cliente);
                                cajas[y].cliente = -1;
                            }
                        }
                    }
                }
            } 
        }

        public void hiloDos()
        {

        }

        public void start()
        {
            fila.Start();
            estacionamiento.Start();
        }

        public void terminaHilo()
        {
            terminar = true;
        }
            
        public void creaLugares(int nLugares)
        {
            Random r = new Random();
            for (int i = 0; i < nLugares; i++)
            {
                parking = new Parking();
                estaciones.Add(parking);
            }
        }

    }
}
