using System;

namespace Diccionario
{

    class Atributo
    {
        private char[] nombre;
        private char[] tipo;
        private int longitud;
        private long dir_atrib;
        private int tipo_indice;
        private long dir_indice;
        private long ap_sig_atrib; //peso = 63
        public Atributo()
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

        //tipo
        public void setTipo(char[] type)
        {
            tipo = type;
        } 

        public char[] getTipo()
        {
            return tipo;
        }
        //longitud
        public void setLongitud(int longi)
        {
            longitud = longi;
        }
        
        public int getLongitud()
        {
            return longitud;
        }
        //dir_trib
        public void setDir_Atrib(long dir)
        {
            dir_atrib = dir;
        }

        public long getDir_Atrib()
        {
            return dir_atrib;
        }
        //tipo_indice
        public void setTipo_Indice(int ti)
        {
            tipo_indice = ti;
        }

        public int getTipo_Indice()
        {
            return tipo_indice;
        }
        //dir_indice
        public void serDir_Indice(long di)
        {
            dir_indice = di;
        }

        public long getDir_Inice()
        {
            return dir_indice;
        }
        //apt_sig_atrib
        public void setAp_Sig_Atrib(long apa)
        {
            ap_sig_atrib = apa;
        }

        public long getAp_Sig_Atrib()
        {
            return ap_sig_atrib;
        }
    }
}
