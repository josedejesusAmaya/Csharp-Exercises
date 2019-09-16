using System;

namespace EventosDos
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator c = new Calculator();
            c.Add(new EventHandler(Result)); //convierto un metodo a un tipo de dato para poder mandarlo como parametro por Add
            //c.Add(new EventHandler(Result1));
        }

        public static void Result(object o, EventArgs a)
        {
            Console.WriteLine((int)o);
            Console.ReadKey();
        }
    }
}
