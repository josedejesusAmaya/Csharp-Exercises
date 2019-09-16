using System;
using System.IO;
namespace ArchivosDos
{
    class Program
    {
        public static void mostrarFichero(String fichero)
        {
            BinaryReader br = null; //flujo entrada de datos
            try
            {
                //verificar si el fichero existe
                if (File.Exists(fichero))
                {
                    //si existe, abrir un flujo desde el mismo para leer 
                    br = new BinaryReader(new FileStream(fichero, FileMode.Open, FileAccess.Read));

                    //declarar los datos a leer desde el fichero
                    String nombre, direccion;
                    //long telefono;
                    do
                    {
                        //leer un nombre, una direccion y un telefino desde el fichero. Cuando se alance el final del fichero C#
                        //lanzara una excepcion del tipo EndOfStreamException.
                        nombre = br.ReadString();
                        direccion = br.ReadString();
                        //telefono = br.ReadInt64();

                        //mostrar los datos nombre, direccion y telefono
                        Console.WriteLine(nombre);
                        Console.WriteLine(direccion);
                        //Console.WriteLine(telefono);
                        Console.WriteLine();
                        Console.ReadKey();
                    }
                    while (true);
                }
                else
                    Console.WriteLine("El fichero no existe");
            }
            catch (EndOfStreamException)
            {
                Console.WriteLine("Fin del listado");
            }
            finally
            {
                //cerrar el flujo
                if (br != null) br.Close();
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    //obtener el nombre del fichero
                    Console.Write("Nombre del fichero: ");
                    string nombreFichero = Console.ReadLine();
                    mostrarFichero(nombreFichero);
                }
                else
                {
                    mostrarFichero(args[0]);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
