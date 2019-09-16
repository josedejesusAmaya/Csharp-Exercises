using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiccionarioVisual
{
    class Atributo
    {
        private string nombre;
        private char tipo;
        private int longitud;
        private long dir_atrib;
        private int tipo_indice;
        private long dir_indice;
        private long dir_sig_atrib; 
        public Atributo()
        {
            
        }
        //nombre
        public void setNombre(string name)
        {
            nombre = name;
        }

        public string getNombre()
        {
            return nombre;
        }

        //tipo
        public void setTipo(char type)
        {
            tipo = type;
        }

        public char getTipo()
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
        public void setDir_Indice(long di)
        {
            dir_indice = di;
        }

        public long getDir_Indice()
        {
            return dir_indice;
        }
        //apt_sig_atrib
        public void setDir_Sig_Atrib(long apa)
        {
            dir_sig_atrib = apa;
        }

        public long getDir_Sig_Atrib()
        {
            return dir_sig_atrib;
        }
    }
}
