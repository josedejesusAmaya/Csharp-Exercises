using System;

namespace Mundo
{
    class Persona
    {
        private char sexo;
        private bool salud = true;
        private int esperanza_vida;
        private int nacimiento;
        private bool vivo = true;

        public Persona()
        {
            
        }

        public void setSexo(char sex)
        {
            sexo = sex;
        }

        public char getSexo()
        {
            return sexo;
        }

        public void setSalud(bool health)
        {
            salud = health; 
        }

        public bool getSalud()
        {
            return salud;
        }

        public void setEsperanza_Vida(int time)
        {
            esperanza_vida = time;
        }

        public int getEsperanza_Vida()
        {
            return esperanza_vida;
        }

        public void setNacimiento(int life)
        {
            nacimiento = life;
        }

        public int getNacimiento()
        {
            return nacimiento;
        }

        public void setVivo(bool live)
        {
            vivo = live;
        }

        public bool getVivo()
        {
            return vivo;
        }
    }
}
