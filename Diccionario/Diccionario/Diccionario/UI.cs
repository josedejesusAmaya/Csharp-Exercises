using System;
using System.Collections.Generic;

namespace Diccionario
{
    class UI
    {
        string opcion;
        List<Entidad> entidades = new List<Entidad>();
        List<Atributo> atributo = new List<Atributo>();
        public UI()
        {
            portada();
            menu();
            opcion = Console.ReadLine();

        }

        public void portada()
        {
            Console.WriteLine("Universidad Autonoma de San Luis Potosi");
            Console.WriteLine("Facultad de Ingenieria");
            Console.WriteLine("Area de Computacion e Informatica");
            Console.WriteLine("Estructuras de Archivos");
            Console.WriteLine("Diccionario de Datos");
            Console.WriteLine("Jose de Jesus Amaya Garcia");
        }

        public void menu()
        {
            Console.WriteLine("Elige una opcion:>");
            Console.WriteLine("1. Entidad");
            Console.WriteLine("2. Atributo");
        }

        public void Entidad()
        {
            Console.WriteLine("ENTIDAD");
            Console.WriteLine("Nombre:> ");

        }
        
    }
}
