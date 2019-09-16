using System;
using System.Collections.Generic;

namespace NumerosRandom
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lista = new List<int>();
            Random r = new Random();
            for (int i = 0; i < 10; i++)
                lista.Add(r.Next(0,10));
            lista.Sort();
            for (int i = 0; i < 10; i++)
                Console.WriteLine(lista[i]);
                Console.ReadKey();
        }
    }
}
