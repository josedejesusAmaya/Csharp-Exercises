using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiccionarioVisual
{
    class Entidad
    {
        private string nombre;
        private long dir_entidad;
        private long dir_datos; 
        private long dir_atributos;
        private long dir_sig_entidad;

        public Entidad()
        {
            
        }

        //direccion de datos
        public long getDirDatos()
        {
            return dir_datos;
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
        //dir_entidad
        public void setDir_Entidad(long dir)
        {
            dir_entidad = dir;
        }

        public long getDir_Entidad()
        {
            return dir_entidad;
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

        public void setDir_Datos(long dd)
        {
            dir_datos = dd;
        }

        public long getDir_Datos()
        {
            return dir_datos;
        }
    }
}
