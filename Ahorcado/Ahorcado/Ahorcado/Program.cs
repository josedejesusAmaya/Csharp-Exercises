using System;
using System.Collections.Generic;


namespace Ahorcado
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> palabras;
            int lenght = 0;
            palabras = new List<string>();

            palabras.Add("espacio");
            palabras.Add("ingenieria");
            palabras.Add("computacion");
            palabras.Add("electron");
            palabras.Add("filosofia");
            palabras.Add("cerebro");
            palabras.Add("humanidad");

            lenght = palabras[0].Length;
            //Console.WriteLine(lenght);
            Console.WriteLine("");
            for (int i = 0; i < lenght; i++)
                Console.Write(" _ ");
            
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Escribe una letra:> ");
            Console.ReadKey();
        }
    }
}
