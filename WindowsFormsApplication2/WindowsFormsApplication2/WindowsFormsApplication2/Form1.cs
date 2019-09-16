using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox1.SelectedIndex.ToString()); //dice el indice que se selecciono
            MessageBox.Show(comboBox1.SelectedItem.ToString()); //manda la cadena que se selecciono
            string texto = comboBox1.SelectedItem.ToString();
            for (int i = 0; i < texto.Length; i++)
                comboBox2.Items.Add(texto[i]);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //comboBox1.Items.Add("hola"); //muestra una lista con dos elementos
            //comboBox1.Items.Add("mundo"); //add agrega al final
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(textBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string texto = comboBox1.SelectedItem.ToString();
            comboBox1.Items.Remove(texto);
        }
    }
}
