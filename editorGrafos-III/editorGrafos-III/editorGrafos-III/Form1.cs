using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace editorGrafos_III
{
    public partial class Form1 : Form
    {
        private bool insertaNodo = false;
        private bool insetaFlecha = false;
        private bool insertaLinea = false;
        private bool arrastrar = false;
        
        List<Nodo> nodos = new List<Nodo>();
        const int RADIO = 20;
        Nodo selNodo;
        Nodo selDestino;
        private int archivoX;
        private int archivoY;
        private int numNodos = 0;

        List<Flecha> flechas = new List<Flecha>();
        List<Linea> lineas = new List<Linea>();

        List<int> coords = new List<int>();

        string nombreArchivo = "";
        FileStream fs;
        BinaryWriter bw;
        BinaryReader br;

        public Form1()
        {
            InitializeComponent();
        }

        private void NodoBoton_Click(object sender, EventArgs e)
        {
            insertaNodo = true;
        }

        private void FlechaBoton_Click(object sender, EventArgs e)
        {
            insetaFlecha = true;
            AristaBoton.Enabled = false;
        }

        private void AristaBoton_Click(object sender, EventArgs e)
        {
            insertaLinea = true;
            FlechaBoton.Enabled = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Linea item in lineas)
            {
                item.dibujaLinea(e.Graphics);
            }

            foreach(Flecha item in flechas)
            {
                item.dibujaFlecha(e.Graphics);
            }

            foreach (Nodo item in nodos)
            {
                item.dibujaNodo(e.Graphics);
                // Console.WriteLine("x " + item.centro.X + " y " + item.centro.Y);
            }
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!insertaNodo) return;
            
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                nodos.Add(new Nodo(e.X, e.Y, RADIO));
                numNodos = nodos.Count;
                coords.Add(e.X);
                coords.Add(e.Y);
                Console.WriteLine("e.X " + e.X);
                Console.WriteLine("e.Y " + e.Y);
                Invalidate();
            }
        }

        private void EliminarBoton_Click(object sender, EventArgs e)
        {
            //elimina el nodos seleccionado
            if (selNodo != null)
            {
                foreach(Linea item in lineas)
                {
                    if (selNodo.letra == item.origen.letra || selNodo.letra == item.destino.letra)
                        item.conectar = false;
                }

                foreach (Flecha item in flechas)
                {
                    if (selNodo.letra == item.origen.letra || selNodo.letra == item.destino.letra)
                        item.conectar = false;
                }

                nodos.Remove(selNodo);
                selNodo = null;
                Invalidate();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Nodo n = null;    
               
            foreach (Nodo item in nodos)
            {
                if (item.adentro(e.Location))
                {
                    n = item;
                    break;
                }
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Left && n != null)
            {
                if (selNodo != null)
                    selDestino = n;
                else
                    selNodo = n;
            }

            if (selNodo != null && selDestino != null && insertaLinea)
            {
                lineas.Add(new Linea(selNodo, selDestino));
                selDestino = null;
                selNodo = null;
                Invalidate();
            }
            
            if (selNodo != null && selDestino != null && insetaFlecha)
            {
                flechas.Add(new Flecha(selNodo, selDestino));
                selDestino = null;
                selNodo = null;
                Invalidate();
            }             
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (selNodo == null) return;

            // mueve nodo
            if (e.Button == System.Windows.Forms.MouseButtons.Right && arrastrar)
            {
                selNodo.posicion(e.Location);
                Invalidate();
            }   
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (arrastrar)
                selNodo = null;
            arrastrar = false;
        }

        private void dragBoton_Click(object sender, EventArgs e)
        {
            arrastrar = true;
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save a File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                nombreArchivo = saveFileDialog1.FileName;
                creaArchivo(nombreArchivo);
            }
        }

        private void creaArchivo(string nombFile)
        {
            fs = new FileStream(nombFile, FileMode.Create);
            bw = new BinaryWriter(fs);

            string[] ubicacion = nombFile.Split();

            for (int i = 0; i < ubicacion.Length; i++)
                this.Text = (Path.GetFileName(ubicacion[i]));

            nombreArchivo = this.Text;
            fs.Position = 0;
            bw.Write(numNodos);
            
            bw.Close();
            fs.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Ya guardo su trabajo?");
            numNodos = 0;
            coords.Clear();
            this.Close();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int numNodos = 0;
            fs = null;
            List<int> coordsX = new List<int>();
            List<int> coordsY = new List<int>();

            nodos.Clear();

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Open a File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((fs = (FileStream)openFileDialog1.OpenFile()) != null)
                    {
                        using (fs)
                        {
                            nombreArchivo = openFileDialog1.FileName;
                            string[] ubicacion = nombreArchivo.Split();

                            for (int i = 0; i < ubicacion.Length; i++)
                                this.Text = (Path.GetFileName(ubicacion[i]));

                            nombreArchivo = this.Text;

                            fs.Position = 0;
                            br = new BinaryReader(fs);

                            numNodos = br.ReadInt32(); //numero de nodos en el archivo
                            //leeNodos(coordsX, coordsY);
                            for (int i = 0; i < numNodos; i++)
                            {
                                coordsX.Add(br.ReadInt32());
                                coordsY.Add(br.ReadInt32());
                            }
                            fs.Close();
                            br.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

            //creaNodos(coordsX, coordsY);
            for (int i = 0; i < numNodos; i++)
            {
                nodos.Add(new Nodo(coordsX[i], coordsY[i], RADIO));
                coords.Add(coordsX[i]);
                coords.Add(coordsY[i]);
            }
            Invalidate();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fs = new FileStream(nombreArchivo, FileMode.Create);
            bw = new BinaryWriter(fs);
            fs.Position = 0;

            bw.Write(numNodos);

            for (int i = 0; i < coords.Count; i++)
            {
                bw.Write(coords[i]);
            }
            bw.Close();
            fs.Close();
            MessageBox.Show("El archivo se ha guardado");
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save as";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                nombreArchivo = saveFileDialog1.FileName;
                creaArchivo(nombreArchivo);
            }

            fs = new FileStream(nombreArchivo, FileMode.Create);
            bw = new BinaryWriter(fs);
            fs.Position = 0;

            bw.Write(numNodos);

            for (int i = 0; i < coords.Count; i++)
            {
                bw.Write(coords[i]);
            }
            bw.Close();
            fs.Close();
        }
    }
}
