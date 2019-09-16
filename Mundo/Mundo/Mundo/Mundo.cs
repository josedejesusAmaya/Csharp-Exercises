using System;
using System.Collections.Generic;
using System.Timers;

namespace Mundo
{
    class Mundo
    {
        private List<Persona> poblacion;
        private Timer tiempo;
        private int years = 1;
        private int hombres = 0;
        private int mujeres = 0;
        private delPrint delBorn;
        private delPrint2 delDead;
        private delPrint3 delSick;
        private int e = 0;
        private int numEnfermos = 0;

        public Mundo(delPrint db, delPrint2 dd, delPrint3 ds)
        {
            delBorn = db;
            delDead = dd;
            delSick = ds;
            poblacion = new List<Persona>();
            tiempo = new Timer();
            tiempo.Interval = 500;
            tiempo.Elapsed += Born; 
            tiempo.Elapsed += Dead;
            tiempo.Elapsed += Sick;
            tiempo.Start();
        }

        public void Born(object o, ElapsedEventArgs args)
        {
            Random r = new Random();
            Random r2 = new Random();
            Random r3 = new Random();
            int top = r.Next(1, 10);
            int top2;
            int top3;
            
            Console.WriteLine("años transcurridos: " + years++);
            for(int i= 0; i<top; i++)
            {
                poblacion.Add(new Persona());
                top2 = r2.Next(1, 3);
                switch (r2.Next(1, 3)) //asignacion de sexo 50%
                {
                    case 1:
                        poblacion[e].setSexo('f');
                        mujeres++;
                        break;
                    case 2:
                        poblacion[e].setSexo('m');
                        hombres++;
                        break;
                }
                poblacion[e].setNacimiento(years); //asignacion del año de nacimiento
                top3 = r3.Next(50, 101);
                poblacion[e].setEsperanza_Vida(top3); //asignacion de esperanza de vida
                e++;
            }/*
            for (int i = 0; i < poblacion.Count; i++)
            {
                switch(r4.Next(0, 10))
                {
                    case 1:
                        if(poblacion[i].getSalud())
                        {
                            poblacion[i].setSalud(false); //asignacion de enfermedad 20%
                            poblacion[i].setEsperanza_Vida(poblacion[i].getEsperanza_Vida() / 2); //reduccion de la esperanza de vida por enfermedad
                            numEnfermos++;
                        }
                        break;
                    case 3:
                        if (!poblacion[i].getSalud())
                        {
                            poblacion[i].setSalud(true); //asignacion de la cura 20%
                            poblacion[i].setEsperanza_Vida(poblacion[i].getEsperanza_Vida() * 2); //recuperacion de la esperanza de vida por cura
                            numEnfermos--;
                        }
                        break;
                    case 4:
                        if (!poblacion[i].getSalud())
                        {
                            poblacion[i].setSalud(true);
                            poblacion[i].setEsperanza_Vida(poblacion[i].getEsperanza_Vida() * 2);
                            numEnfermos--;
                        }
                        break;
                }
                delSick(numEnfermos);
            }*/
            delBorn(top,hombres,mujeres,hombres+mujeres);
            hombres = mujeres = 0;
        }
        
        public void Dead(object o, ElapsedEventArgs args)
        {
            int muertos = 0;
            for (int i = 0; i < poblacion.Count; i++) //condicion para la mortalidad
            {
                if (poblacion[i].getEsperanza_Vida() == (years+1 - poblacion[i].getNacimiento()))
                    poblacion[i].setVivo(false);
            }

            for (int i = 0; i < poblacion.Count; i++)
                if (!poblacion[i].getVivo())
                    muertos++; //numero de muertos
            delDead(poblacion.Count-muertos,muertos); 
        }

        public void Sick(object o, ElapsedEventArgs args)
        {
            Random r4 = new Random();
            for (int i = 0; i < poblacion.Count; i++)
            {
                switch (r4.Next(0, 10))
                {
                    case 1:
                        if (poblacion[i].getSalud())
                        {
                            poblacion[i].setSalud(false); //asignacion de enfermedad 20%
                            poblacion[i].setEsperanza_Vida(poblacion[i].getEsperanza_Vida() / 2); //reduccion de la esperanza de vida por enfermedad
                            numEnfermos++;
                        }
                        break;
                    case 3:
                        if (!poblacion[i].getSalud())
                        {
                            poblacion[i].setSalud(true); //asignacion de la cura 20%
                            poblacion[i].setEsperanza_Vida(poblacion[i].getEsperanza_Vida() * 2); //recuperacion de la esperanza de vida por cura
                            numEnfermos--;
                        }
                        break;
                    case 4:
                        if (!poblacion[i].getSalud())
                        {
                            poblacion[i].setSalud(true);
                            poblacion[i].setEsperanza_Vida(poblacion[i].getEsperanza_Vida() * 2);
                            numEnfermos--;
                        }
                        break;
                }
            }
            delSick(numEnfermos);
        }
    }
}
