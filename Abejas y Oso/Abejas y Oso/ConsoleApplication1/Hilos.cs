using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace ConsoleApplication1
{
    class Hilos
    {
        List<Abeja> abejas = new List<Abeja>();
        Abeja abeja;
        
        public int tamTarro = 0;
        public int tarro = 0;
        bool oso = false;
        bool salir = false;
        bool terminar = false;
        Thread productor;
        Thread consumidor;
        bool tarroLleno = false;
        bool imprimir = true;
        FileStream fs;
        BinaryWriter bw;
        string nombreArchivo = "Abejas-Oso";
        public Hilos()
        {
            crearArchivo(nombreArchivo);
            
            productor = new Thread(hiloUno);
            consumidor = new Thread(hiloDos);
            
        }

        private void crearArchivo(string nomArchivo)
        {
            try
            {
                fs = new FileStream(nomArchivo, FileMode.Create);
                bw = new BinaryWriter(fs);
               
            }
            finally
            {
                //cerrar el flujo
                if (bw != null)
                {
                    bw.Close();
                    fs.Close();
                }
            }
        }


        public void setTarro(int t)
        {
            tamTarro = t;
        }

        public void start()
        {
            productor.Start();
            consumidor.Start();
        }

        public void creaAbejas(int nAb)
        {
            fs = new FileStream(nombreArchivo, FileMode.Open);
            bw = new BinaryWriter(fs);

            Random r = new Random();
            for (int i = 0; i < nAb; i++)
            {   
                abeja = new Abeja();
                abeja.porcion = r.Next(1, 10);
                string salida = "La abeja " + i + " pone:> " + abeja.porcion;
                Console.WriteLine(salida);
                bw.Write(salida);
                abejas.Add(abeja);
            }
            fs.Close();
            bw.Close();
        }

        public void hiloUno()
        {

            
            bool producir = true;
            int i = 0;
            while (!terminar && !oso)
            {
                while (producir == true)
                {
                    //for (int i = 0; i < abejas.Count; i++)
                    if (i < abejas.Count)
                    {
                        if (tarro + abejas[i].porcion <= tamTarro)
                        {
                            string salida2 = "Abeja:> " + i + " agrega:> " + abejas[i].porcion;
                            Console.WriteLine(salida2);
                            tarro += abejas[i].porcion;
                            string salida3 = "Tarro:> " + tarro;
                            Console.WriteLine(salida3);
                            
                        }
                        else
                        {
                            producir = false;
                            tarroLleno = true;
                        }
                        i++;
                    }
                    else
                        i = 0;
                }
                string salida = "Tarro lleno";
                Console.WriteLine(salida);
                
                oso = true;
                while (tarroLleno == true) { }
                producir = true;
            }
            
        }

        public void hiloDos()
        {
            //fs = new FileStream(nombreArchivo, FileMode.Open);
            //bw = new BinaryWriter(fs);

            while (!terminar)
            {
                if (!oso && imprimir)
                {
                    string salida4 = "Oso dormido";
                    Console.WriteLine(salida4);
                    imprimir = false;
                }
                else
                {
                    if (oso)
                    {
                        string salida5 = "Oso despierto";
                        Console.WriteLine(salida5);
                        tarro = 0;
                        salida5 = "El oso se ha comido la miel";
                        Console.WriteLine(salida5);
                        salida5 = "Tam tarro " + tarro;
                        Console.WriteLine(salida5);
                        oso = false;
                        imprimir = true;
                        tarroLleno = false;
                    }
                }
            }
            //fs.Close();
            //bw.Close();
        }

        public void terminaHilo()
        {
            terminar = true;
        }
    }
}
