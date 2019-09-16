using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CuartoExamen
{
    class Hilos
    {
        Random r;
        Random n;
        bool terminar = false;
        int examen = 30;
        List<Alumno> alumnos = new List<Alumno>();
        Alumno alumno;
        int rand;
        bool resultados = false;
        bool revision = false;
        
        public Hilos()
        {
            r = new Random();
            for (int i = 0; i < 2; i++)
            {
                for (int x = 0; x < 15; x++)
                    rand = r.Next(10, 41);
                alumno = new Alumno();
                alumno.duracion = rand;
                alumnos.Add(alumno);
                //Console.WriteLine("duracion " + alumnos[i].duracion);
            }

            Thread tiempo = new Thread(hiloUno);
            Thread hProfesor = new Thread(hiloDos);
            tiempo.Start();
            hProfesor.Start();
        }

        public void hiloUno()
        {
            //while (terminar == true) { }
            if (!terminar)
            {
                for (int time = 1; time <= examen; time++)
                {
                    Console.WriteLine("Time:" + time);
                    for (int y = 0; y < alumnos.Count; y++)
                    {
                        alumnos[y].time++;

                        if (alumnos[y].time >= alumnos[y].duracion && !alumnos[y].termino)
                        {
                            alumnos[y].termino = true;
                            Console.WriteLine("Alumno " + y + " con duracion " + alumnos[y].duracion + " entrego el examen");
                            revision = true;
                        }
                    }
                }
                if (resultados == false)
                {
                    Console.WriteLine("El examen ha terminado!!!");
                    int nTerminaron = 0;
                    int terminaron = 0;
                    for (int w = 0; w < alumnos.Count; w++)
                    {
                        if (!alumnos[w].termino)
                            nTerminaron++;
                        else
                            terminaron++;
                    }
                    Console.WriteLine("No terminaron " + nTerminaron + " alumnos");
                    Console.WriteLine("Pasaron " + terminaron + " estudiantes");
                    Console.WriteLine("De " + (nTerminaron + terminaron) + " personas");
                }
                terminar = true;
            }
        }

        public void hiloDos()
        {
            //do
            //{
            /*for (int i = 0; i < alumnos.Count; i++)
            {
                if (alumnos[i].termino && alumnos[i].duracion < 41)
                {
                    n = new Random();
                    alumnos[i].contestado = n.Next(1, 3);
                    if (alumnos[i].contestado == 2) //mal contestado
                    {
                        Console.WriteLine("Profesor: El examen del alumno " + i + " esta mal contestado");
                        alumnos[i].termino = false;
                        alumnos[i].duracion = 100;
                    }
                }
            }*/
            //} while (!terminar);
            //while (terminar == true) { }
            while (revision == false) { }
            {
            //    for (int i = 0; i < alumnos.Count; i++)
                Console.WriteLine("Revision del alumno ");
                //resultados = true;
                revision = false;
            }
            
        }
    }
}
