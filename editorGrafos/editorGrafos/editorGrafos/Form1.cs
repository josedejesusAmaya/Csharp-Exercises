using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;


//editorGrafos-I

namespace editorGrafos
{
    public partial class Form1 : Form
    {
        string nombreArchivo = "";
        FileStream fs;
        BinaryWriter bw;
        BinaryReader br;
        private bool insertarNodo = false; //variable que permite insetar un nodo
        private List<Nodo> nodos = new List<Nodo>();

        const int RADIO = 20;
        Nodo selOrig;
        Nodo selNodo;


        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            /*foreach (Nodo item in nodos)
            {
                item.DibujaArista(e.Graphics);
            }*/

            foreach (Nodo item in nodos)
            {
                item.DibujaNodo(e.Graphics);
            }
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
            bw.Write("Papus2");
            bw.Close();
            fs.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();    
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fs = new FileStream(nombreArchivo, FileMode.Open);
            fs = null;
            //Stream myStream = null;
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
                            MessageBox.Show(br.ReadString());
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
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (insertarNodo)
            {
                Nodo nodo = new Nodo();
                nodo.X = e.X - 20;
                nodo.Y = e.Y - 20;
                nodos.Add(nodo);

                Label label = new Label();
                label.Location = new Point(nodo.X + 8, nodo.Y + 8);
                label.Size = new Size(25, 25);
                label.Visible = true;
                label.Font = new Font(label.Font.FontFamily, 15);
                num = orden++;
                label.Text = Convert.ToChar(num).ToString();
                label.BackColor = Color.White;
                this.Controls.Add(label);
            }
            Invalidate();
        }

        private void NodoBoton_Click(object sender, EventArgs e)
        {
            insertarNodo = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            insertarNodo = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            insertarNodo = false;
        }
    }
}
