using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Banco
{   
    class Hilos
    {
        Thread cajero;
        Thread hCliente;
        bool terminar = false;
        Caja caja;
        Cliente cliente;
        List<Caja> cajas = new List<Caja>();
        List<Cliente> clientes = new List<Cliente>();
        bool abreCajas = false;
        public Hilos()
        {
            cajero = new Thread(hiloUno);
            hCliente = new Thread(hiloDos);    
        }

        public void hiloUno()
        {
            Random r = new Random();
            int i = 0;
            int auxTime = 1;
            int idCont = 1;
            while (terminar == false)
            {
                if (i == auxTime)
                {
                    cliente = new Cliente();                    
                    cliente.id = idCont++;
                    Console.WriteLine("Llego el cliente:> " + cliente.id + " al tiempo:> " + i);
                    clientes.Add(cliente);                   
                    auxTime = r.Next(1, 6);
                    auxTime += i;
                }
                i++;
                Console.WriteLine("Time>: " + i);

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
                if (clientes.Count > 0)
                {
                    abreCajas = true;
                    //Console.WriteLine("Se han abierto las cajas");
                }
            }
        }

        public void hiloDos()
        {
            Random r = new Random();
            while (terminar == false)
            {
                while (abreCajas == false) { }
                for (int i = 0; i < cajas.Count; i++)
                {
                    if (cajas[i].cliente == -1)
                    {
                        if (clientes.Count > 0)
                        {
                            cajas[i].cliente = clientes[0].id;
                            clientes.RemoveAt(0);
                            cajas[i].duracion = r.Next(3, 9); 
                            Console.WriteLine("La caja:> " + i + " esta atendiendo al cliente:> " + cajas[i].cliente);
                            Console.WriteLine("El cliente:> " + cajas[i].cliente + " tarda:> " + cajas[i].duracion + " en la caja:> " + i);
                            Console.WriteLine("Num de clientes:> " + clientes.Count);
                        }
                        else
                        {
                            Console.WriteLine("La fila esta vacia");
                            abreCajas = false;
                            //Console.WriteLine("Se han cerrado las cajas");
                        }
                    }
                }
            }
        }

        public void start()
        {
            cajero.Start();
            hCliente.Start();
        }

        public void creaCajas(int nCajas)
        {
            Random r = new Random();
            for (int i = 0; i < nCajas; i++)
            {
                caja = new Caja();
                cajas.Add(caja);
            }
        }

        public void terminarHilo()
        {
            terminar = true;
        }
    }
}
