using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraVisual
{
    public partial class Form1 : Form
    {
        Double resultado = 0;
        String oper = "";
        public Form1()
        {
            InitializeComponent();
            this.Text = "Calculator";
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text = textBox1.Text + button.Text;
        }

        private void buttonC(object sender, EventArgs e)
        {
            textBox1.Clear();
            resultado = 0;
        }

        private void operacion(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            oper = button.Text;
            resultado = Double.Parse(textBox1.Text);
            textBox1.Clear();
        }

        private void button_igual(object sender, EventArgs e)
        {
            switch(oper)
            {
                case "+":
                    textBox1.Text = (resultado + Double.Parse(textBox1.Text)).ToString();
                    break;
                case "--":
                    textBox1.Text = (resultado - Double.Parse(textBox1.Text)).ToString();
                    break;
                case "/":
                    if (Double.Parse(textBox1.Text) != 0)
                        textBox1.Text = (resultado / Double.Parse(textBox1.Text)).ToString();
                    else
                        textBox1.Text = "Error";
                    break;
                case "x":
                    textBox1.Text = (resultado * Double.Parse(textBox1.Text)).ToString();
                    break;
                case "x^y":
                    textBox1.Text = Math.Pow(resultado, Double.Parse(textBox1.Text)).ToString();
                    break;
                case "Raiz":
                    double potencia = 1.0 / Double.Parse(textBox1.Text);
                    textBox1.Text = Math.Pow(resultado, potencia).ToString();
                    break;
            }
        }

        private void fibonacci(object sender, EventArgs e)
        {
            double b, aux, a;
            a = 0;
            b = 1;
            resultado = Double.Parse(textBox1.Text);
            textBox1.Clear();
            if (resultado == 1)
                textBox1.Text = "0";
            else
            {
                for (int i = 1; i < resultado; i++)
                {
                    aux = a;
                    a = b;
                    b = aux + a;
                }
            }
            textBox1.Text = a.ToString();
        }
    }
}
