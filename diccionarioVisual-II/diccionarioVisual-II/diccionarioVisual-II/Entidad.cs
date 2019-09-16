using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diccionarioVisual_II
{
    class Entidad
    {
        public string nombre;
        public long dir_entidad;
        public long dir_datos;
        public long dir_atributos;
        public long dir_sig_entidad;
        public long pesoEntidad = 62;
        public bool atributos = false;
        public bool registros = false;
        public bool banSO = false;
        public bool banSIP = false;
        public bool banArbol = false;

        public Entidad()
        {

        }
    }
}
