using System;

namespace Diccionario
{
    class Entidad
    {
        private char[] nombre;
        private long dir_entidad;
        private long dir_datos;
        private long dir_atributos;
        private long dir_sig_entidad; //peso = 62
        public Entidad()
        {
            nombre = new char[30];
            
        }
        //nombre
        public void setNombre(char[] name)
        {
            nombre = name;
        }

        public char[] getNombre()
        {
            return nombre;
        }
        //dir_entidad
        public void setDir_Entidad(long dir)
        {
            dir_entidad = dir;
        }

        public long getDir_Entidad()
        {
            return dir_entidad;
        }
        //dir_datos
        public void setDir_Datos(long dir)
        {
            dir_datos = dir;
        }

        public long getDir_Datos()
        {
            return dir_datos;
        }
        //dir_atributos
        public void setDir_Atributos(long dir)
        {
            dir_atributos = dir;
        }

        public long getDir_Atributos()
        {
            return dir_atributos;
        }
        //dir_sig_entidad
        public void setDir_Sig_Entidad(long dir)
        {
            dir_sig_entidad = dir;
        }

        public long getDir_Sig_Entidad()
        {
            return dir_sig_entidad;
        }
    }
}
