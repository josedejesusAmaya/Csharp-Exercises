using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones
{
    class UI
    {
        private static UI ui; //este valor lo comparten todas las instancias

        private UI()
        {
            ui = null;
        }

        public static UI getInstance()
        {
            //return new UI();
            if (ui == null) ui = new UI(); //simepre voy a regresar una instancia
            return ui;
        }

    }
}
