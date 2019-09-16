using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clasemiercoles
{
    public partial class Form1 : Form
    {
        private string texto = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //checkBox1.Checked = true;
            comboBox1.Items.Add("hola");
            comboBox1.Items.Add(1254);
            comboBox1.Items.Add("nuevo");
            comboBox1.Items.Add(7894);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            texto = comboBox1.SelectedItem.ToString();
            //MessageBox.Show(texto);
            byte[] asciiBytes = Encoding.ASCII.GetBytes(texto);
            if (asciiBytes[0] >= 65 && asciiBytes[0] <= 90 || asciiBytes[0] >= 97 && asciiBytes[0] <= 122)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = true;
            }
            else
            {
                checkBox1.Checked = true;
                checkBox2.Checked = false;
            }
        }
    }
}
