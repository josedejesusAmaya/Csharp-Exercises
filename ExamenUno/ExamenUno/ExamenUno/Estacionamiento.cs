using System;
using System.Collections.Generic;
using System.Timers;

namespace ExamenUno
{
    class Estacionamiento
    {
        private List<Auto> estacionamiento;
        private List<Auto> espera;
        private Timer tiempo;
        private Random r;
        private int tiempo_trascurrido = 0;
        private delPrint delEntrada;
        private delPrint2 delEspera;
        private int i = 0;
        private int s = 0;
        private int descartados = 0;
        public Estacionamiento(delPrint de, delPrint1 ds, delPrint2 desp)
        {
            delEntrada = de;
            delEspera = desp; 
            estacionamiento = new List<Auto>();
            espera = new List<Auto>();
            r = new Random();
            tiempo = new Timer();
            tiempo.Interval = r.Next(500,5001);
            tiempo.Elapsed += Entrar;
            tiempo.Elapsed += Salir;
            tiempo.Start();
        }

        public void Entrar(object o, ElapsedEventArgs args)
        {
            Random r1 = new Random();
            Random r2 = new Random();
            int t = 0;
            tiempo_trascurrido++;
    
            if (estacionamiento.Count < 15)
            {
      
                if (espera.Count == 0)
                {
                    estacionamiento.Add(new Auto());
                    estacionamiento[i].setTiempo_Entrada(tiempo_trascurrido);
                    estacionamiento[i].setTiempo_Salida(r1.Next(5, 30));
                    i++;
                }
                else
                { 
                    foreach (Auto auto in espera)
                    {
                        estacionamiento.Add(auto);
                        estacionamiento[i].setTiempo_Entrada(tiempo_trascurrido);
                        estacionamiento[i].setTiempo_Salida(r1.Next(5, 30));
                        i++;
                        espera.RemoveAt(t);
                        t++;
                    }
                }
            }
            else
            {
                switch (r2.Next(1, 3))
                {
                    case 1:
                        descartados++;
                        break;
                    case 2:
                        espera.Add(new Auto());
                        break;
                }
            }
            delEntrada(tiempo_trascurrido,estacionamiento.Count);
            delEspera(espera.Count,descartados);
        }

        public void Salir(object o, ElapsedEventArgs args)
        {       
            for (int e = 0; e < estacionamiento.Count; e++)
            {
                if (estacionamiento[e].getTiempo_Salida() == (tiempo_trascurrido - estacionamiento[e].getTiempo_Entrada()))
                {
                    estacionamiento.RemoveAt(e);
                    i--;
                }
            }
        }
    }
}
