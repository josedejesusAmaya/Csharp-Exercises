using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BotonAmaya
{
    public partial class Form1 : Form
    {
        private bool op = false;
        private string texto = "";
        //private string textoDos = "";
        private string letras = "";
        private string numeros = "";
        private string simbolos = "";
        private string nombre = "";
        //private string soloLetras = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            op = true;
            if (op)
            {
                //label1.Text = "Hola mundo"; //primera actividad
                //MessageBox.Show("Hola, me presionaste");
                //MessageBox.Show(texto);
                //label1.Text = texto; //segunda actividad
                label1.Text = texto.ToUpper(); //tercera actividad
                byte[] asciiBytes = Encoding.ASCII.GetBytes(texto);
                foreach (byte b in asciiBytes) //cuarta actividad
                {
                    if (b >= 65 && b <= 90 || b >= 97 && b <= 122)
                        letras += Convert.ToChar(b).ToString();
                    textBox1.Text = letras.ToString();

                    if (b >= 48 && b <= 57)
                        numeros += Convert.ToChar(b).ToString();
                    textBox2.Text = numeros.ToString();

                    if (b >= 33 && b <= 47 || b >= 58 && b <= 64 || b >= 91 && b <= 96 || b >= 123 && b <= 126)
                        simbolos += Convert.ToChar(b).ToString();
                    textBox3.Text = simbolos.ToString();
                }
            }
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            texto = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void EventoN(object sender, KeyPressEventArgs e) //quinta actividad
        {
            if (Char.IsLetter(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            string curFile = @"C:\Users\Owner\Desktop\ejemplo.txt";
            //d.FileName
            if(File.Exists(curFile))
            {
                MessageBox.Show("El archvo ya existe");
            }
            else
            {
                File.WriteAllText(@"C:\Users\Owner\Desktop\ejemplo.txt", textBox6.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog d = new SaveFileDialog();
            d.Filter = "Archivos de texto|*.txt";
            DialogResult r = d.ShowDialog();
            if (r == DialogResult.OK) //para ver si en realidad se creo el archivo
            {
                //textBox6.Text = File.ReadAllText(@"C:\Users\Owner\Desktop\ejemplo.txt");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*OpenFileDialog d = new OpenFileDialog();
            nombre = textBox6.Text;
            File.WriteAllText(@"C:\Users\Owner\Desktop\" + nombre + ".txt","");
            label6.Text = nombre;*/
            Form2 f = new Form2();
            f.ShowDialog(); 
            //f.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog d = new SaveFileDialog();
            d.Filter = "Archivos de texto|*.txt";
            DialogResult r = d.ShowDialog();
            if(r == DialogResult.OK)
            {
                File.WriteAllText(@"C:\Users\Owner\Desktop\" + nombre + ".txt", textBox6.Text);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog d = new SaveFileDialog();
            d.Filter = "Archivos de texto |*.txt";
            DialogResult r = d.ShowDialog();
            if (r == DialogResult.OK)
                File.WriteAllText(d.FileName, textBox6.Text);
        }
        //abrir
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "Archivos de texto |*.txt";

            DialogResult r = d.ShowDialog();
            if (r == DialogResult.OK)
            {
                textBox6.Text = File.ReadAllText(d.FileName); 
            }
        }
    }
}