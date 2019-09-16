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

//editor de grafos viii

namespace editorGrafos_III
{
    public partial class Form1 : Form
    {
        private bool insertaNodo = false;
        private bool insertaFlecha = false;
        private bool insertaLinea = false;
        private bool arrastrar = false;
        
        int[,] array;
        List<List<Nodo>> grafoLista = new List<List<Nodo>>();

        bool eliminar = false;
        Point antiguoP;
        bool moverGrafo = false;
        string nombreArchivo = "";
        FileStream fs;
        BinaryWriter bw;
        BinaryReader br;
        List<int> iniciales = new List<int>();
        bool arista; //true = linea       false = flecha
        int num = 0;
        List<Grafo> grafos; //esta es la lista de grafos
        int idGrafo = -1;
        bool seleccionarGrafo = false;
        Grafo selGrafo = new Grafo();
        int currentGrafo;
        bool draw = false;
        Point pInicial;
        Point pFinal;
        Pen pen;
        Rectangle rec;
        bool flecha = false;
        SolidBrush brush = new SolidBrush(Color.Red);
        bool mueveNodo = false;

        public Form1()
        {
            InitializeComponent();
            grafos = new List<Grafo>();
        }

        //activa los nodos
        private void NodoBoton_Click(object sender, EventArgs e)
        {
            insertaNodo = true;
            eliminar = false;
            arrastrar = false;
            seleccionarGrafo = false;
        }

        //activa las aristas dirigidas
        private void FlechaBoton_Click(object sender, EventArgs e)
        {
            insertaFlecha = true;
            AristaBoton.Enabled = false;
            insertaNodo = false;
            arista = false;
            //tipo = 1;
            grafos[currentGrafo].Tipo = 1;
            eliminar = false;
            arrastrar = false;
            seleccionarGrafo = false;
            
        }

        //activa las aristas simples
        private void AristaBoton_Click(object sender, EventArgs e)
        {
            insertaLinea = true;
            FlechaBoton.Enabled = false;
            insertaNodo = false;
            arista = true;
            //tipo = 0;
            grafos[currentGrafo].Tipo = 0;
            eliminar = false;
            arrastrar = false;
            seleccionarGrafo = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (draw)
            {
                e.Graphics.DrawLine(pen, pInicial, pFinal);
                if (flecha)
                {
                    rec = new Rectangle(pFinal.X - 5, pFinal.Y - 5, 2 * 5, 2 * 5);
                    e.Graphics.DrawEllipse(pen, rec);
                    e.Graphics.FillEllipse(brush, rec);
                }
            }
            //pinta todos los nodos
            for (int i = 0; i < grafos.Count; i++)
                grafos[i].pintaGrafo(e.Graphics);
        }

        //para crear un nodo
        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!insertaNodo) return;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point punto = new Point();
                punto = e.Location;
                currentGrafo = Convert.ToInt32(identidadGrafo.Text);
                grafos[currentGrafo].creaNodo(punto);
                Invalidate();
                //grafoLista.Add(new List<Nodo>());
                //grafoLista[grafoLista.Count - 1].Add(nodos[nodos.Count - 1]);

                //Console.WriteLine("-----" + grafoLista.Count);
                /*Console.WriteLine("-------------------------------");
                for (int i = 0; i < grafoLista.Count; i++)
                {
                    for (int y = 0; y < grafoLista[i].Count; y++)
                        Console.WriteLine("grafoLista[" + i + "]" + "[" + y + "] = " + grafoLista[i][y].letra);
                }*/
            }
        }

        //elimina el elemento seleccionado
        private void EliminarBoton_Click(object sender, EventArgs e)
        {
            eliminar = true;
            arrastrar = false;
        }
        
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int t = -1;
            Point p = new Point();
            p = e.Location;
            for (int i = 0; i < grafos.Count; i++)
            {
                if (grafos[i].dNodo(p))
                {
                    selGrafo = grafos[i];
                    identidadGrafo.Text = i.ToString();
                }
            }
            currentGrafo = Convert.ToInt32(identidadGrafo.Text);
            t = grafos[currentGrafo].Tipo;
            if (t != 2)
            {
                if (t == 0)
                {
                    FlechaBoton.Enabled = false;
                    AristaBoton.Enabled = true;
                    pen = new Pen(Color.Blue, 3);
                }

                if (t == 1)
                {
                    AristaBoton.Enabled = false;
                    FlechaBoton.Enabled = true;
                    pen = new Pen(Color.Red, 3);
                    flecha = true;
                }
            }
            else
            {
                AristaBoton.Enabled = true;
                FlechaBoton.Enabled = true;
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right && t != 2)
            {
                pInicial = new Point();
                pInicial = e.Location;
                if (selGrafo.nodoInicial(pInicial))
                    draw = true;
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Left && eliminar)
            {
                pInicial = new Point();
                pInicial = e.Location;
                selGrafo.eliminaNodo(pInicial);
                Invalidate();
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right && arrastrar)
                mueveNodo = true;

            /*
            //detecta la arista seleccionada
            if ((insertaLinea|| insertaFlecha) && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (insertaLinea)
                {
                    foreach (Linea item in lineas)
                    {
                        if (item.adentro(e.Location))
                        {
                            linea = item;
                            break;
                        }
                    }
                }
                if (insertaFlecha)
                {
                    foreach (Flecha item in flechas)
                    {
                        if (item.adentro(e.Location))
                        {
                            flecha = item;
                            break;
                        }
                    }
                }
            }

            //aqui se elimina la linea seleccionada
            if (eliminar && selLinea != null)
            {
                lineas.Remove(selLinea);
                for (int i = 0; i < grafoLista.Count; i++)
                {
                    if (grafoLista[i][0] == selLinea.origen)
                        grafoLista[i].Remove(selLinea.destino);
                    if (grafoLista[i][0] == selLinea.destino && selLinea.origen != selLinea.destino)
                        grafoLista[i].Remove(selLinea.origen);
                }
                selLinea = null;
                Invalidate();
            }

            //aqui se elimina la flecha seleccionada
            if (eliminar && selFlecha != null)
            {
                flechas.Remove(selFlecha);
                for (int i = 0; i < grafoLista.Count; i++)
                {
                    if (grafoLista[i][0] == selFlecha.origen)
                        grafoLista[i].Remove(selFlecha.destino);
                }
                selFlecha = null;
                Invalidate();
            }*/
        }

        //para arrastrar los elementos
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && draw)
            {
                pFinal = new Point();
                pFinal = e.Location;
                Invalidate();
            }

            if (mueveNodo)
            {
                pInicial = new Point();
                pInicial = e.Location;
                selGrafo.mueve(true);
                selGrafo.mueveNodo(pInicial);
                Invalidate();
            }

            /*
            //mueve todo el grafo y aristas
            if (selNodo != null && e.Button == System.Windows.Forms.MouseButtons.Right && arrastrar && moverGrafo && nodos.Count > 1)
            {
                Point nuevoP = e.Location;
                antiguoP = selNodo.centro;
                int a = nuevoP.X - antiguoP.X;
                int b = nuevoP.Y - antiguoP.Y;      
                foreach(Nodo item in nodos)
                {
                    if (item.centro != antiguoP)
                    {
                        item.centro.X = item.centro.X + a;
                        item.centro.Y = item.centro.Y + b;
                    }  
                }
                selNodo.posicion(e.Location);
                Invalidate();               
            }                
            }*/
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                pFinal = e.Location;
                selGrafo.nodoFinal(pFinal);
                draw = false;
                flecha = false;
                Invalidate();
            }

            if (mueveNodo)
            {
                mueveNodo = false;
                //selGrafo.mueve(false);
            }

            /*    
            //para detectar el final de la arista
            if (e.Button == System.Windows.Forms.MouseButtons.Right && (insertaLinea || insertaFlecha) && selNodo != null)
            {
                    if (insertaLinea)
                    {
                        //establece la relacion en un grafo simple
                        for (int i = 0; i < grafoLista.Count; i++)
                        {
                            if (grafoLista[i][0] == selNodo)
                                grafoLista[i].Add(selDestino);
                            if (grafoLista[i][0] == selDestino && selNodo != selDestino)
                                grafoLista[i].Add(selNodo);
                        }
                    }
                    
                    if (insertaFlecha)
                    {
                        
                        //establece la relacion en un digrafo
                        for (int i = 0; i < grafoLista.Count; i++)
                            if (grafoLista[i][0] == selNodo)
                                grafoLista[i].Add(selDestino);
                    }
                }  
            }

                for (int i = 0; i < grafoLista.Count; i++)
                    if (grafoLista[i][0] == selNodo)
                        grafoLista.RemoveAt(i);
            }*/
        }

        //para activar la funcion de arrastre
        private void dragBoton_Click(object sender, EventArgs e)
        {
            arrastrar = true;
            moverGrafo = false;
            eliminar = false;
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {/*
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save a File";
            saveFileDialog1.ShowDialog();
            
            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                creaArchivo(saveFileDialog1.FileName);
                coords.Clear();
                nodos.Clear();
                lineas.Clear();
                flechas.Clear();
                iniciales.Clear();
                grafoLista.Clear(); 
                AristaBoton.Enabled = true;
                FlechaBoton.Enabled = true;
                insertaNodo = false;
                insertaFlecha = false;
                insertaLinea = false;
                tipo = 2;
                ord = 65;
                Invalidate();
            }*/
        }

        private void creaArchivo(string nombFile)
        {/*
            fs = new FileStream(nombFile, FileMode.Create);
            bw = new BinaryWriter(fs);

            string[] ubicacion = nombFile.Split();

            for (int i = 0; i < ubicacion.Length; i++)
                this.Text = (Path.GetFileName(ubicacion[i]));

            nombreArchivo = this.Text;
  
            bw.Close();
            fs.Close();*/
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {/*
            iniciales.Clear();
            fs = null;
            int n = 0;
            List<int> coordsX = new List<int>();
            List<int> coordsY = new List<int>();
            int numNodos = 0;
            
            nodos.Clear();
            lineas.Clear();
            flechas.Clear();
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

                            //lee el tipo de nodo que es
                            tipo = br.ReadInt32();

                            if (tipo == 0) //para un grafo simple
                            {
                                arista = true;
                                insertaLinea = true;
                                FlechaBoton.Enabled = false;
                                AristaBoton.Enabled = true;
                            }

                            if (tipo == 1) //para un grafo dirigido
                            {
                                arista = false;
                                insertaFlecha = true;
                                AristaBoton.Enabled = false;
                                FlechaBoton.Enabled = true;
                            }

                            //lee el numero de nodos por el que esta compuesto el grafo
                            numNodos = br.ReadInt32();

                            //lee las iniciales de cada vertice
                            for (int i = 0; i < numNodos; i++)
                                iniciales.Add(br.ReadInt32());

                            //leeNodos(coordsX, coordsY);
                            for (int i = 0; i < numNodos; i++)
                            {
                                coordsX.Add(br.ReadInt32());
                                coordsY.Add(br.ReadInt32());
                            }

                            if (tipo != 2) //para un grafo con aristas
                            {
                                n = numNodos;
                                array = new int[n, n];
                                //leer array del archivo
                                for (int x = 0; x < n; x++)
                                    for (int y = 0; y < n; y++)
                                        array[x, y] = br.ReadInt32();
                            }

                            fs.Close();
                            br.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: No se pudo leer el archivo desde el disco: " + ex.Message);
                    return;
                }
            }
            else
                return;

            //creaNodos(coordsX, coordsY);
            for (int i = 0; i < numNodos; i++)
            {
                nodos.Add(new Nodo(coordsX[i], coordsY[i], iniciales[i]));
                coords.Add(coordsX[i]);
                coords.Add(coordsY[i]);

                grafoLista.Add(new List<Nodo>());
                grafoLista[grafoLista.Count - 1].Add(nodos[nodos.Count - 1]);
            }

            ord = iniciales[iniciales.Count - 1];
            ord++;
            if (tipo == 0) //crea aristas simples
            {
                List<int> Lx = new List<int>();
                List<int> Ly = new List<int>();
                bool resp = true;

                for (int x = 0; x < n; x++)
                    for (int y = 0; y < n; y++)
                        if (array[x, y] == 1)
                        {
                            resp = true; 
                            for (int i = 0; i < Lx.Count; i++)
                            {
                                if (x == Ly[i] && y == Lx[i])
                                {
                                    resp = false;
                                    break;
                                }
                            }
                            if (resp)
                            {
                                //si pasa el filtro crea la arista
                                Lx.Add(x); //me pueden servir como indices
                                Ly.Add(y);
                                Linea l = new Linea();
                                l.setInicio(nodos[x]);
                                l.setFinal(nodos[y]);
                                lineas.Add(l);

                                for (int i = 0; i < grafoLista.Count; i++)
                                {
                                    if (grafoLista[i][0] == nodos[x])
                                        grafoLista[i].Add(nodos[y]);
                                    if (grafoLista[i][0] == nodos[y] && nodos[x] != nodos[y])
                                        grafoLista[i].Add(nodos[x]);
                                }
                            }
                        }
                Console.WriteLine("-------------------------------");
                for (int i = 0; i < grafoLista.Count; i++)
                {
                    for (int y = 0; y < grafoLista[i].Count; y++)
                        Console.WriteLine("grafoLista[" + i + "]" + "[" + y + "] = " + grafoLista[i][y].letra);
                }
            }

            if (tipo == 1) //crea aristas flechas
            {
                for (int x = 0; x < n; x++)
                    for (int y = 0; y < n; y++)
                        if (array[x, y] == 1)
                        {
                            Flecha f = new Flecha();
                            f.setInicio(nodos[x]);
                            f.setFinal(nodos[y]);
                            flechas.Add(f);

                            for (int i = 0; i < grafoLista.Count; i++)
                                if (grafoLista[i][0] == nodos[x])
                                    grafoLista[i].Add(nodos[y]);
                        }
                Console.WriteLine("-------------------------------");
                for (int i = 0; i < grafoLista.Count; i++)
                {
                    for (int y = 0; y < grafoLista[i].Count; y++)
                        Console.WriteLine("grafoLista[" + i + "]" + "[" + y + "] = " + grafoLista[i][y].letra);
                }
            }
            num = iniciales[iniciales.Count - 1];
            Invalidate();*/
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {/*
            fs = new FileStream(nombreArchivo, FileMode.Create);
            bw = new BinaryWriter(fs);

            iniciales.Clear();
            for (int i = 0; i < nodos.Count; i++)
                iniciales.Add(nodos[i].letra);

            fs.Position = 0;
            escribirGrafo(bw);
            bw.Close();
            fs.Close();
            MessageBox.Show("El archivo se ha guardado");*/
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {/*
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
            escribirGrafo(bw);

            bw.Close();
            fs.Close();
            MessageBox.Show("El archivo se ha guardado");*/
        }

        private void escribirGrafo(BinaryWriter bw)
        {/*
            //escribe tipo de grafo
            bw.Write(tipo);
            //escribe numero de nodos 
            bw.Write(nodos.Count);

            //escribe las letras que tiene cada nodo
            for (int i = 0; i < iniciales.Count; i++)
                bw.Write(iniciales[i]);

            //escribe las coordenadas de cada nodo
            foreach (Nodo item in nodos)
            {
                bw.Write(item.centro.X);
                bw.Write(item.centro.Y);
            }

            if (tipo != 2)
            {
                //creacion de la matriz 
                int n = nodos.Count;
                array = new int[n, n];
                int auxLet = 0;
                int auxLet2 = 0;
                int o = 0;
                int j = 0;

                //establecer relaciones
                for (int w = 0; w < lineas.Count; w++) //********
                {
                    if (lineas[w].conectar)
                    {
                        auxLet = lineas[w].origen.letra;
                        auxLet2 = lineas[w].destino.letra;
                        
                        //busqueda del indice en lista iniciales
                        for (int i = 0; i < iniciales.Count; i++)
                        {
                            if (auxLet == iniciales[i])
                                j = i;
                            if (auxLet2 == iniciales[i])
                                o = i;
                        }
                        array[j, o] = 1;
                        if (tipo == 0)
                            array[o, j] = 1;
                    }
                }

                for (int w = 0; w < flechas.Count; w++)
                {
                    if (flechas[w].conectar)
                    {
                        auxLet = flechas[w].origen.letra;
                        auxLet2 = flechas[w].destino.letra;
                        //busqueda del indice en lista iniciales
                        for (int i = 0; i < iniciales.Count; i++)
                        {
                            if (auxLet == iniciales[i])
                                j = i;
                            if (auxLet2 == iniciales[i])
                                o = i;
                        }
                        array[j, o] = 1;
                        if (tipo == 0)
                            array[o, j] = 1;
                    }
                }

                //busqueda del indice en lista iniciales
                for (int i = 0; i < iniciales.Count; i++)
                {
                    if (auxLet == iniciales[i])
                        j = i;
                    if (auxLet2 == iniciales[i])
                        o = i;
                }
                array[j, o] = 1;
                if (tipo == 0)
                    array[o, j] = 1;

                //escribir array en el archivo
                for (int x = 0; x < n; x++)
                    for (int y = 0; y < n; y++)
                        bw.Write(array[x, y]);
            }*/
        }

        private void moverBoton_Click(object sender, EventArgs e)
        {/*
            moverGrafo = true;
            arrastrar = true;
            eliminar = false;*/
        }
        
        private void grafoBoton_Click(object sender, EventArgs e)
        {
            idGrafo++;
            Color color = new Color();
            switch (idGrafo)
            {
                case 0:
                    color = Color.Black;
                    break;
                case 1:
                    color = Color.Green;
                    break;
                case 2:
                    color = Color.Purple;
                    break;
                case 3:
                    color = Color.DarkRed;
                    break;
                case 4:
                    color = Color.Yellow;
                    break;
                case 5:
                    color = Color.Lime;
                    break;
                case 6:
                    color = Color.Gold;
                    break;
                case 7:
                    color = Color.Gray;
                    break;
                default:
                    color = Color.Black;
                    break;
            }
            grafos.Add(new Grafo(color));
            identidadGrafo.Text = idGrafo.ToString();
            FlechaBoton.Enabled = true;
            AristaBoton.Enabled = true;
        }

        private void selecGrafo_Click(object sender, EventArgs e)
        {
            seleccionarGrafo = true;
            insertaNodo = false;
        }
    }
}
