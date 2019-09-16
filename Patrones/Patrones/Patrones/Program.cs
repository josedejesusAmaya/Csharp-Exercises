using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones
{
    class Program
    {
        static void Main(string[] args)
        {
            //Singleton
            //es un patron de dise;o porque siempre es el mismo algoritmo.
            //UI ui = new UI();
            UI u = UI.getInstance();
            UI u1 = UI.getInstance();
            UI u2 = UI.getInstance(); //con esto hago que mi clase pueda ser instanciada por ella misma y tenga solo una instancia

            //Object Factory
            //me regresa cualquier objeto

            //Factory f = new Factory();
            //Factory.FactoryObject o = f.getNewObject();

            Console.ReadKey();
        }
    }
}
