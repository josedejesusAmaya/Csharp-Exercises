using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase08
{
    class Clase
    {
        delegate int delMetInt(int a);
        delegate int delMetInt1(int a, float b);
        //delegate void EventHandler(object o, EventArgs srgs);

        //apuntador a funciones
        public Clase()
        {
            //a un eventHandler no puedo asignarse el metodo Metodo porque necesita dos parametros
            //puedo usar delegados para pasar metodos por parametros

            delMetInt d = new delMetInt(Metodo);
            delMetInt1 a = new delMetInt1(Metodo1);
         
        }

        public int Metodo(int a)
        {
            return 0;
        }

        public int Metodo1(int a, float c) { return 0; }
    }
}
