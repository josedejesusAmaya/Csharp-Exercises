using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace examen4
{
    class Hilos
    {
        Random r;
        List<Alumno> alumnos = new List<Alumno>();
        Alumno alumno;
        int rand;
        int tExamen = 30;
        bool terminar = false;
        int ct = 1; // examen> 1) bien 2) mal
        bool revision = false;
        bool salir = false;
        public Hilos()
        {
            creaAlumnos();
            Thread tiempo = new Thread(hiloUno);
            Thread profesor = new Thread(hiloDos);

            tiempo.Start();
            profesor.Start();
        }

        public void creaAlumnos()
        {
            r = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int x = 0; x < 15; x++)
                    rand = r.Next(10, 41);
                alumno = new Alumno();
                alumno.duracion = rand;
                alumnos.Add(alumno);
                Console.WriteLine("Duracion del alumno " + i + "> " + alumnos[i].duracion);
                
            }
            Console.WriteLine("------------------------------------------------------");
        }

        public void hiloUno()
        {
            for (int time = 1; time <= tExamen; time++)
            {
                Console.WriteLine("time:> " + time);
                for (int y = 0; y < alumnos.Count; y++)
                {
                    alumnos[y].time++;
                    if (alumnos[y].time >= alumnos[y].duracion && !alumnos[y].termino)
                    {
                        Console.WriteLine("Alumno:> " + y + " entrego el examen");
                        alumnos[y].termino = true;
                    }
                }
            }
            revision = true;
        }

        public void hiloDos()
        {
            while (terminar == false)
            {
                for (int i = 0; i < alumnos.Count; i++)
                {
                    if (alumnos[i].termino && alumnos[i].duracion < 41)
                    {
                        Console.WriteLine("Profesor revizando el examen del alumno:> " + i);
                        alumnos[i].duracion = 100;
                        alumnos[i].contestado = ct;
                        if (ct == 1)
                            ct = 2;
                        else
                            ct = 1;
                        if (alumnos[i].contestado == 2) //mal contestado
                        {
                            Console.WriteLine("El examen del alumno " + i + " esta incorrecto");
                            alumnos[i].termino = false;
                            alumnos[i].duracion = 100;
                        }
                        else
                            Console.WriteLine("El examen del alumno " + i + " esta correcto");
                    }
                }
                if (revision)
                {
                    //Console.WriteLine("ya puedes imprimir");
                    int sinTerminar = 0;
                    int reprobados = 0;
                    for (int i = 0; i < alumnos.Count; i++)
                    {
                        if (!alumnos[i].termino && alumnos[i].duracion == 100)
                            reprobados++;
                        if (alumnos[i].duracion < 41)
                            sinTerminar++;
                    }
                    Console.WriteLine("Examen Terminado!!");
                    Console.WriteLine("Alumnos que no terminaron por falta de tiempo:> " + sinTerminar);
                    Console.WriteLine("Alumnos que reprobaron:> " + reprobados);
                    revision = false;
                }
            }
        }

        public void terminarHilo()
        {
            terminar = true;
        }
    }
}
