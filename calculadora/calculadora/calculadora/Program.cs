using System;

namespace calculadora
{
    public class Calculadora
    {
        private int op1, op2;
        private double resul;

        public void sum()
        {
            resul = op1 + op2;
        }

        public void res()
        {
            resul = op1 - op2;
        }

        public void div()
        {
            if(op2 != 0)
                resul = op1 / op2;
            else
            {
                Console.WriteLine("No se puede dividir entre cero");
                resul = 0;
            }
        }

        public void fibonacci()
        {
            int b, aux, a;
            a = 0;
            b = 1;
            if (op1 == 1)
                resul = 0;
            else
            {
                for (int i = 1; i < op1; i++)
                {
                    aux = a;
                    a = b;
                    b = aux + a;
                }
            }
            resul = a;
        }

        public void potencia()
        {
            resul = Math.Pow(op1, op2);
        }

        public void raiz()
        {
            double potencia = 1.0 / op2;
            resul = Math.Pow(op1,potencia);
        }

        public void mult()
        {
            resul = op1 * op2;
        }

        public int operator1
        {
            get { return op1; }
            set { op1 = value; }
        }

        public int operator2
        {
            get{ return op2; }
            set{ op2 = value; }
        }

        public double operatorRes
        {
            get { return resul; }
        }

        static void Main(string[] args)
        {
            Calculadora cal = new Calculadora();
            string operacion;
            int operation;
            bool band = true;
            Console.WriteLine("Calculadora.");
            Console.WriteLine("Amaya Garcia Jose de Jesus.");
            Console.WriteLine("Programacion Visual.");
            Console.WriteLine("1.- Suma");
            Console.WriteLine("2.- Resta");
            Console.WriteLine("3.- Multiplicacion");
            Console.WriteLine("4.- Division");
            Console.WriteLine("5.- Fibonacci");
            Console.WriteLine("6.- Potencia");
            Console.WriteLine("7.- Raiz");
            Console.WriteLine("8.- Salir");
            while (band)
            {
                //band = false;
                Console.WriteLine("Escribe el numero de la accion que deseas hacer.");
                Console.WriteLine("Enter para continuar.");
                operacion = Console.ReadLine();
                operation = int.Parse(operacion);
                switch (operation)
                {
                    case 1:
                        Console.WriteLine("Primer numero a sumar:");
                        operacion = Console.ReadLine();
                        operation = int.Parse(operacion);
                        cal.operator1 = operation;

                        Console.WriteLine("Segundo numero a sumar:");
                        operacion = Console.ReadLine();
                        operation = int.Parse(operacion);
                        cal.operator2 = operation;
                        cal.sum();
                        break;
                    case 2:
                        Console.WriteLine("Primer numero a restar:");
                        operacion = Console.ReadLine();
                        operation = int.Parse(operacion);
                        cal.operator1 = operation;

                        Console.WriteLine("Segundo numero a restar:");
                        operacion = Console.ReadLine();
                        operation = int.Parse(operacion);
                        cal.operator2 = operation;
                        cal.res();
                        break;
                    case 3:
                        Console.WriteLine("Primer factor:");
                        operacion = Console.ReadLine();
                        operation = int.Parse(operacion);
                        cal.operator1 = operation;

                        Console.WriteLine("Segundo factor:");
                        operacion = Console.ReadLine();
                        operation = int.Parse(operacion);
                        cal.operator2 = operation;
                        cal.mult();
                        break;
                    case 4:
                        Console.WriteLine("Dividendo:");
                        operacion = Console.ReadLine();
                        operation = int.Parse(operacion);
                        cal.operator1 = operation;

                        Console.WriteLine("Divisor:");
                        operacion = Console.ReadLine();
                        operation = int.Parse(operacion);
                        cal.operator2 = operation;
                        cal.div();
                        break;
                    case 5:
                        Console.WriteLine("Ingrese el numero a calcular:");
                        operacion = Console.ReadLine();
                        operation = int.Parse(operacion);
                        cal.operator1 = operation;
                        cal.fibonacci();
                        break;
                    case 6:
                        Console.WriteLine("Base:");
                        operacion = Console.ReadLine();
                        operation = int.Parse(operacion);
                        cal.operator1 = operation;

                        Console.WriteLine("Exponente:");
                        operacion = Console.ReadLine();
                        operation = int.Parse(operacion);
                        cal.operator2 = operation;
                        cal.potencia();
                        break;
                    case 7:
                        Console.WriteLine("Radicando:");
                        operacion = Console.ReadLine();
                        operation = int.Parse(operacion);
                        cal.operator1 = operation;

                        Console.WriteLine("Indice:");
                        operacion = Console.ReadLine();
                        operation = int.Parse(operacion);
                        cal.operator2 = operation;
                        cal.raiz();
                        break;
                    case 8:
                        band = false;
                        break;
                }
                if (band)
                {
                    double resultado;
                    resultado = cal.operatorRes;
                    Console.WriteLine("Resultado:" + resultado);
                    Console.ReadKey();
                }
            }
        }
    }
}
