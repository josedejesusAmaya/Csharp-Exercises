using System;
using System.Collections.Generic;

namespace Colecciones
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> a;
            List<List<int>> l; //listas de listas

            a = new List<int>();
            a.Add(2);
            a.Add(21);
            a.Add(22);

            
            int y = a[1];
            a[1] = 8;

            Console.WriteLine("sin removeat");
            for (int i = 0; i < a.Count; i++)
                Console.WriteLine(i + " " + a[i]);
            Console.WriteLine("num de elementos " + a.Count);

            a.RemoveAt(1);
            Console.WriteLine("con reoveat");
            for (int i = 0; i < a.Count; i++)
                Console.WriteLine(i + " " + a[i]);
            Console.WriteLine("num de elementos " + a.Count);

            Console.ReadKey();


        }
    }
}
