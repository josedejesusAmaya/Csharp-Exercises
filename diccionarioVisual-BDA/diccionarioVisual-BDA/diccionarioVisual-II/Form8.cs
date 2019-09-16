using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diccionarioVisual_II
{
    public partial class Form8 : Form
    {
        List<String> nomAtrib;
        int iE1 = -1;
        int iE2 = -1;
        int iA1 = -1;
        int iA2 = -1; 
        public Form8(List<string> atrib)
        {
            InitializeComponent();
            nomAtrib = atrib;
        }

        private void comboEntidad1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemUno = comboEntidad1.SelectedItem.ToString();
            //Console.WriteLine(itemUno);
            for (int i = 0; i < nomAtrib.Count; i++)
                comboAtributo1.Items.Add(nomAtrib[i]);
            
        }

        private void comboEntidad2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemDos = comboEntidad2.SelectedItem.ToString();
            //Console.WriteLine(itemDos);
            for (int i = 0; i < nomAtrib.Count; i++)
                comboAtributo2.Items.Add(nomAtrib[i]);
        }

        private void comboAtributo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemUno = comboAtributo1.SelectedItem.ToString();
            for (int i = 0; i < nomAtrib.Count; i++)
                if (itemUno == nomAtrib[i])
                    iA1 = i;

            Form1 forma = new Form1(iA1, -1);
        }

        private void comboAtributo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemsDos = comboAtributo2.SelectedItem.ToString();
            for (int i = 0; i < nomAtrib.Count; i++)
                if (itemsDos == nomAtrib[i])
                    iA2 = i;

            Form1 forma = new Form1(-1, iA2);
        }
    }
}
