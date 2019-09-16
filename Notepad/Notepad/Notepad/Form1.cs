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
/*
 * Nota: para abir los archivos creados necesita cerrar la aplicacion y volver a correrla 
 * sé que el error esta en que no abró y cierro bien el archivo pero ya no entendí cómo hacerlo.
 * Saludos!!! 
 * 
 */


namespace Notepad
{
    public partial class Form1 : Form
    {
        SaveFileDialog saveFile = new SaveFileDialog();
        StreamWriter streamW = null;

        OpenFileDialog openFile = new OpenFileDialog();
        StreamReader streamR = null;
        string buff;
        string def = "Untitled - Notepad";
        bool band = false;
        public Form1()
        {
            InitializeComponent();
            this.Text = def;
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = def;
            texto.Clear();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile.InitialDirectory = @"C:\Users\Owner\Documents\Visual Studio 2015\Projects\Notepad\Notepad\bin\Debug\";
            openFile.Filter = "PP Files (.pp)|*.pp|All Files (*.*)|*.*"; //extencion personalizada
            openFile.CheckFileExists = true;
            openFile.Title = "Abrir";
            openFile.ShowDialog(this);
            this.Text = openFile.SafeFileName;
            try
            {
                openFile.OpenFile();
                streamR = File.OpenText(openFile.FileName);
                texto.Text = streamR.ReadToEnd();
                buff = streamR.ReadToEnd();
            }
            catch (Exception) { }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guardarComo();
        }

        private void guardarComo()
        {
            saveFile.InitialDirectory = @"C:\Users\Owner\Documents\Visual Studio 2015\Projects\Notepad\Notepad\bin\Debug\";
            saveFile.Filter = "PP Files (.pp)|*.pp|All Files (*.*)|*.*";
            saveFile.CheckPathExists = true;
            saveFile.Title = "Guardar como";
            saveFile.ShowDialog(this);
            try
            {
                streamW = File.AppendText(saveFile.FileName);
                streamW.Write(texto.Text);
                streamW.Flush();
            }   
            catch (Exception) { }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (buff != null)
            {
                if (!buff.Equals(texto.Text, StringComparison.Ordinal))
                    MessageBox.Show("Guarde los cambios antes de salir");
            }
            Close();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //si el nombre no se ha dado.
            if (def.Equals(this.Text, StringComparison.Ordinal))
                guardarComo();
            else
            {
                //si existe solo agregar los cambios al documento.
                string nombre = this.Text;
                //streamW.Close();
                streamR.Close();
                File.WriteAllText(@"C:\Users\Owner\Documents\Visual Studio 2015\Projects\Notepad\Notepad\bin\Debug\" + 
                                  nombre, texto.Text);
                streamR = File.OpenText(openFile.FileName);
                buff = streamR.ReadToEnd();
            }
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textB.Visible = true;
            buscar.Visible = true;
            
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            band = true;
            if (band)
            {
                string search = textB.Text;
                string nombre = this.Text;
                
                //if (def) 
            }
        }
    }
}
