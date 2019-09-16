using System;
//using otraprueba; /*otraprueba es el nombre de espacio donde se encuentra la clase PruebaDos*/

namespace prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            otraprueba.PruebaDos op = new otraprueba.PruebaDos();
            /*agregando using otraprueba:
            PruebaDos op = new PruebaDos(); */
            op.metodoUno();
            for(int i=1; i<=10; i++)
                Console.WriteLine(i);
            Console.ReadKey(); //detiene el programa
        }
    }
}
