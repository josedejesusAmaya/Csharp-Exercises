using System;


namespace ExamenUno
{
    class Auto
    {
        private int tiempo_salida; //registra el tiempo en el que debe salir
        private int tiempo_entrada; //registra el tiempo en el que ingreso al estacionamiento 
        public Auto()
        {

        }

        public int getTiempo_Entrada()
        {
            return tiempo_entrada;
        }

        public void setTiempo_Entrada(int te)
        {
            tiempo_entrada = te;
        }

        public int getTiempo_Salida()
        {
            return tiempo_salida;
        }

        public void setTiempo_Salida(int ts)
        {
            tiempo_salida = ts;
        }
    }
}
