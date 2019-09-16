using System;
using System.IO;

/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace Archivos
{
    class Program
    {
        static void Main(string[] args)
        {
            String nombreFichero = null; //nombre del fichero
            try
            {
                //obtener el nombre del fichero
                Console.Write("Nombre del fichero: ");
                nombreFichero = Console.ReadLine();

                //verificar si el fichero existe
                char resp = 's';
                if (File.Exists(nombreFichero));
                {
                    Console.Write("El fichero existe. Desea sobreescribirlo? (s/n) ");
                    resp = (char)Console.Read();
                    //eliminar los caracteres sobrantes en el flujo de entrada
                    Console.ReadLine();
                }
                if (resp == 's') crearFichero(nombreFichero);
            }
            catch (IOException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public static void crearFichero(String fichero)
        {
            BinaryWriter bw = null; //salida de los datos hacia el fichero
            char resp;
            try
            {
                //crear un flujo hacia el fichero que permita escribir
                //datos de tipos primitivos y cadenas de caracteres.
                bw = new BinaryWriter(new FileStream(fichero, FileMode.Create, FileAccess.Write));

                //declarar los datos a escribir en el fichero
                String nombre, direccion;
                //long telefono;

                //leer datos de la entrada estandar y escribirlos en el fichero
                do
                {
                    Console.Write("nombre:  "); nombre = Console.ReadLine();
                    Console.Write("direccion:  "); direccion = Console.ReadLine();
                    //Console.Write("telefono:  "); telefono = Leer.datoLong();

                    //almacenar un nombre, una direccion y un telefono en el fichero
                    bw.Write(nombre);
                    bw.Write(direccion);
                    //bw.Write(telefono);

                    Console.Write("desea escribir otro registro? (s/n) ");
                    resp = (char)Console.Read();
                    //eliminar los caracteres sobrantes en el flujo de entrada
                    Console.ReadLine();
                }
                while (resp == 's');
            }
            finally
            {
                //cerrar el flujo
                if (bw != null) bw.Close();
            }
        }
    }
}
