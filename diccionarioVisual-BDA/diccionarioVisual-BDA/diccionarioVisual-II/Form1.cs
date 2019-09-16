using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace diccionarioVisual_II
{
    public partial class Form1 : Form
    {
        List<Entidad> entidades;
        List<Atributo> atributos;
        List<Relacion> relaciones;
        Entidad temporalEnt;
        Atributo temporalAtrib;
        Relacion temporalRelacion;
        MetaReg temporalMetaReg;
        FileStream fs;
        BinaryWriter bw;
        BinaryReader br;
        private string nombreArchivo;
        private long cab = -1;
        List<long> apts;
        List<long> apts2; //lista de apuntadores para cada entidad
        List<List<long>> listaApsts2;
        List<string> listaNomEntidades;
        List<MetaReg> metaRegs;
        MetaReg auxMetaReg;
        List<string> listBufReg;
        List<string> listBufAtrib;
        List<string> listaSecOrdenada;
        List<string> listaSecIndexadaPrimariaGlobal;
        List<Fk> listaSecIndexadaSecundaria;
        List<string> listaContenidoNodo;
        long tamDirecPrimaria = 128;
        long tamDirecSecudaria = 448;
        Form3 reg;
        Form2 formaE;
        Form4 formaModifE;
        Form5 formaNuevoAtrib;
        Form6 modificarAtributoForma;
        Form7 eliminarAtribForma;
        Form8 crearRelacion;
        Form9 Llave1 = new Form9();
        Form10 Llave2 = new Form10();
        int tamReg;
        List<long> dirNodos; 
        List<int> datosEliminados = new List<int>();
        int ie2 = -1;
        string auxSecOrd;
        int ie; //para saber cual fue la ultima entidad para un nuevo atributo
        bool bandDirec = true;
        bool bandDirec2 = true;
        List<int> aptIntermedios = new List<int>();
        bool enti = false;


        public Form1()
        {
            InitializeComponent();
            dirNodos = new List<long>();
            auxMetaReg = new MetaReg();
            listaContenidoNodo = new List<string>(); //lista para ordenar cada nodo
            listaSecOrdenada = new List<string>(); //lista para la clave de busqueda 3
            listaSecIndexadaPrimariaGlobal = new List<string>(); //lista para la clave 1
            listaSecIndexadaSecundaria = new List<Fk>(); //lista para la clave 2
            listBufReg = new List<string>(); //lista para datos de los registros
            listBufAtrib = new List<string>(); //lista para datos de los atributos
            entidades = new List<Entidad>(); //lista de las entidades 
            atributos = new List<Atributo>(); //lista de los atributos
            relaciones = new List<Relacion>(); //lista de las relaciones
            apts = new List<long>(); //lista de apuntadores para entidades
            listaApsts2 = new List<List<long>>(); //lista de apuntadores para entidades
            listaNomEntidades = new List<string>(); //lista de nombres de entidades para ordenar
            metaRegs = new List<MetaReg>(); //lista para la captura de los metadatos del registro
            this.Text = "SMBD> JJ Amaya";
        }

        public Form1(int A1, int A2)
        {

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save a File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                string[] ubicacion = saveFileDialog1.FileName.Split();

                for (int i = 0; i < ubicacion.Length; i++)
                    this.Text = (Path.GetFileName(ubicacion[i]));

                nombreArchivo = this.Text;
                crearArchivo(nombreArchivo);
            }
        }

        private void crearArchivo(string nomArchivo)
        {
            try
            {
                fs = new FileStream(nomArchivo, FileMode.Create);
                bw = new BinaryWriter(fs);
                this.Text = nomArchivo;
                bw.Write(cab); //escribe una cabecera con -1
                
            }
            finally
            {
                //cerrar el flujo
                if (bw != null)
                {
                    bw.Close();
                    fs.Close();
                }
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fs = null;
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
                            string[] ubicacion = openFileDialog1.FileName.Split();

                            for (int i = 0; i < ubicacion.Length; i++)
                                this.Text = (Path.GetFileName(ubicacion[i]));

                            nombreArchivo = this.Text;
                            br = new BinaryReader(fs);
                            fs.Position = 0;
                            if (br.ReadInt64() == -1) //lee la cabecera
                            {
                                MessageBox.Show("Archivo vacío");
                                
                            }
                            else
                            {
                                cargaEntidades();
                                cargaAtributos();
                            }
                            br.Close();
                            fs.Close();
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
        }

        private void cargaEntidades()
        {

        }

        private void cargaAtributos()
        {

        }

        private void setApuntadoresSig() 
        {
            listaNomEntidades.Sort(); //funcion que ordena alfabeticamente los nombres de las entidades
            for (int i = 0; i < listaNomEntidades.Count; i++)
            {
                if (i == 0)
                {


                    fs.Position = 0;
                    cab = entidades[search(listaNomEntidades[i])].dir_entidad;
                    bw.Write(cab); //actualizacion de la cabecera
                    //MessageBox.Show("cab " + cab);
                }


                if (i != listaNomEntidades.Count - 1)
                    entidades[search(listaNomEntidades[i])].dir_sig_entidad = entidades[search(listaNomEntidades[i + 1])].dir_entidad;
                else
                    entidades[search(listaNomEntidades[i])].dir_sig_entidad = -1;
            }
        }

        private void escribeEntidades()
        {
            for (int i = 0; i < entidades.Count; i++)
            {
                fs.Position = apts[i];
                bw.Write(entidades[i].nombre);
                bw.Write(entidades[i].dir_entidad);
                bw.Write(entidades[i].dir_datos);
                bw.Write(entidades[i].dir_atributos);
                bw.Write(entidades[i].dir_sig_entidad);
            }
        }

        //busca el indice coorrespondiente a nomEntidad en entidades
        private int search(string nomEntidad)
        {
            int ret = -1;
            for (int i = 0; i < entidades.Count; i++)
            {
                if (nomEntidad.Equals(entidades[i].nombre, StringComparison.Ordinal)) //compara dos string
                    ret = i;
            }
            return ret;
        }

        private void imprimir()
        {
            dataGridEntidades.Rows.Clear(); //limpia toda la dataGrid de entidades
            for (int i = 0; i < entidades.Count; i++)
            {
                fs.Position = apts[i]; //asignacion de la posicion en el archivo
                string[] row = {br.ReadString()};
                dataGridEntidades.Rows.Add(row); //se agregan los renglones a la dataGrid 
            }
        }

        //aceptar para modificar el nombre de una entidad
        private void Aceptar_Click1(object sender, EventArgs e)
        {
            string nuevoNom = formaModifE.textNomNuevoEntidad.Text;
            string nuevoNom2 = nuevoNom;
            int nuevoNomTam = nuevoNom.Length;

            int textoTam = formaModifE.textNomEntid.TextLength;
            string nameEntidad = formaModifE.textNomEntid.Text;
            int iE = -1;
            int indexNomEntid = 0;
            if (nuevoNomTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - nuevoNomTam); i++)
                    nuevoNom += " ";
            }
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int resp = search(nuevoNom);
            if (resp != -1)
            {
                formaModifE.Close();
                MessageBox.Show("Una entidad ya esta asignada con ese nombre");
                return;
            }

            if (string.IsNullOrEmpty(nameEntidad)) //validacion de la entrada de entidad
            {
                MessageBox.Show("Debe ingresar el nombre para la entidad");
                formaModifE.Close();
                return;
            }

            if (string.IsNullOrEmpty(nuevoNom)) //validacion de la entrada de nuevo nombre entidad
            {
                MessageBox.Show("Debe ingresar el nuevo nombre para la entidad");
                formaModifE.Close();
                return;
            }
            iE = search(nameEntidad);
            if (entidades[iE].atributos || entidades[iE].registros)
            {
                MessageBox.Show("La entidad no se puede modificar");
                formaModifE.Close();
                return;
            }
            if (iE == -1)
            {
                MessageBox.Show("El nombre de la entidad no se encuentra");
                formaModifE.Close();
                return;
            }
            else
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                bw = new BinaryWriter(fs);
                br = new BinaryReader(fs);
                string aux = entidades[iE].nombre;             
                entidades[iE].nombre = nuevoNom;

                for (int t = 0; t < listaNomEntidades.Count; t++)
                {
                    if (aux.Equals(listaNomEntidades[t], StringComparison.Ordinal))
                        indexNomEntid = t;
                }
                listaNomEntidades[indexNomEntid] = nuevoNom;
                comboEntidad2.Items[iE] = nuevoNom2;
                setApuntadoresSig();
                escribeEntidades();
                imprimir();
                fs.Close();
                br.Close();
                bw.Close();
            }
            formaModifE.Close();
        }

        private void Cancelar_Click1(object sender, EventArgs e)
        {
            formaE.Close();
        }

        //ingresas un apuntador y te debuelve el indice del atributo que lo contiene
        private int search2(int apt)
        {
            int resp = -1;
            for (int i = 0; i < atributos.Count; i++)
            {
                if (atributos[i].dir_atrib == apt)
                    resp = i;
            }
            return resp;
        }

        //imprime los atributos
        private void imprimir2(int ie)
        {
            if (ie == -1)
                return;
            dataGridAtributos.Rows.Clear(); //limpia toda la dataGrid de atributos
            if (listaApsts2.Count == 0)
                return;
            for (int w = 0; w < listaApsts2[ie].Count; w++)
            {
                fs.Position = listaApsts2[ie][w];
                string[] row2 = {br.ReadString(), br.ReadChar().ToString(), br.ReadInt32().ToString(),
                                br.ReadInt32().ToString()};
                dataGridAtributos.Rows.Add(row2); //se agregan los renglones a la dataGrid
            }
        }

        private void escribeAtributos()
        {
            int iA = -1;
            for (int x = 0; x < listaApsts2.Count; x++)
            {
                for (int i = 0; i < listaApsts2[x].Count; i++)
                {
                    iA = search2((int)listaApsts2[x][i]);
                    fs.Position = atributos[iA].dir_atrib;
                    bw.Write(atributos[iA].nombre);
                    bw.Write(atributos[iA].tipo);
                    bw.Write(atributos[iA].longitud);
                    bw.Write(atributos[iA].tipo_indice);
                    bw.Write(atributos[iA].dir_atrib);
                    bw.Write(atributos[iA].dir_indice);
                    bw.Write(atributos[iA].dir_sig_atrib);
                }
            }
        }

        private void Cancelar_Click2(object sender, EventArgs e)
        {
            formaE.Close();
        }


        //das un nombre y la lista de apts y regresa la direccion que tiene ese atributo
        private int search3(string name, List<long> listApts) 
        {
            int resp = -1;
            for (int i = 0; i < atributos.Count; i++)
            {
                if (name.Equals(atributos[i].nombre, StringComparison.Ordinal))
                    for (int y = 0; y < listApts.Count; y++)
                        if (atributos[i].dir_atrib == listApts[y])
                            resp = i; 
            }
            return resp;
        }

        //permite guardar el registro introducido por el usuario
        private void Aceptar_Click(object sender, EventArgs e)
        {
            int i = 0;
            int datoNodo = 0;
            long position = -1;
            List<string> numRepetidosPk = new List<string>();
            int repetidoPk = 0;
            int fuera = -1;
            List<string> numRepetidosHash = new List<string>();
            foreach (Control c in reg.Controls) //foreach para sacar todos los controles de la forma
            {
                if (c is TextBox) //si el control es un texBox captura el texto contenido
                    metaRegs[i++].text = c.Text;
            }
            reg.Close(); //cierre de la forma
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int w = 0; w < (29 - textoTam); w++)
                    nameEntidad += " ";
            }
            int iE = search(nameEntidad);
            if (ie2 != iE)
            {
                listaSecOrdenada.Clear();
                listaSecIndexadaPrimariaGlobal.Clear();
                listaSecIndexadaSecundaria.Clear();
                listaContenidoNodo.Clear();
                ie2 = iE;
                bandDirec = true; //el directorio se vuelve a insetar si se cambia de entidad
                bandDirec2 = true; //el directorio se vuele a insertar si se cambia de entidad
                Llave1.dataGridLlave1.Rows.Clear(); //llave primaria
                Llave2.dataGridLlave2.Rows.Clear(); //llave secundaria
            }
            
            for (int y = 0; y < metaRegs.Count; y++)
            {
                if (metaRegs[y].clave == 3) //organizacion secuencial ordenada
                {
                    entidades[iE].banSO = true;
                }
            
                if (metaRegs[y].clave == 1) //llave primaria
                {
                    entidades[iE].banSIP = true;

                    listaSecIndexadaPrimariaGlobal.Add(metaRegs[y].text);
                    for (int q = 0; q < listaSecIndexadaPrimariaGlobal.Count; q++)
                    {
                        if (numRepetidosPk.Count > 0)
                        {
                            for (int t = 0; t < numRepetidosPk.Count; t++)
                            {
                                if (listaSecIndexadaPrimariaGlobal[q].Equals(numRepetidosPk[t]))
                                {
                                    repetidoPk = 1;
                                    fuera = q;
                                }
                            }
                            if (repetidoPk == 0)
                                numRepetidosPk.Add(listaSecIndexadaPrimariaGlobal[q]);
                        }
                        else
                            numRepetidosPk.Add(listaSecIndexadaPrimariaGlobal[q]);
                    }
                    if (repetidoPk != 0)
                    {
                        MessageBox.Show("Ya se a ingresado un registro con esa clave Pk");
                        repetidoPk = 0;
                        numRepetidosPk.Clear();
                        listaSecIndexadaPrimariaGlobal.RemoveAt(fuera);
                        return;
                    }
                }

                if (metaRegs[y].clave == 2) //llave secundaria
                {
                    entidades[iE].banSIS = true;
                }
            }

            if (entidades[iE].banSIP)
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                bw = new BinaryWriter(fs);
                br = new BinaryReader(fs);
                position = escribeRegLlavePrimaria(); //escribe reg dejando un directorio de indices
                fs.Close();
                bw.Close();
                br.Close();
            }

            if (entidades[iE].banSIS)
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                bw = new BinaryWriter(fs);
                br = new BinaryReader(fs);
                position = escribeRegLlaveSecundaria(position); //escribe reg dejando un directorio de indices secundarios
                fs.Close();
                bw.Close();
                br.Close();
            }

            //escritura del registro
            fs = new FileStream(nombreArchivo, FileMode.Open);
            bw = new BinaryWriter(fs);
            br = new BinaryReader(fs);
            escribeReg(position); //escribe el registro en el archivo
            consulta();
            if (entidades[iE].banSIP)
            {
                escrituraIndicePrimario();
                consulta2();
            }
            if (entidades[iE].banSIS)
            {
                escrituraIndiceSecundario();
            }

            fs.Close(); //cierre del archivo 
            bw.Close(); //cierre del flujo
            br.Close();

            if (entidades[iE].banSO)
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                bw = new BinaryWriter(fs);
                br = new BinaryReader(fs);
                secuencialOrdenada(iE);
                fs.Close(); //cierre del archivo 
                bw.Close(); //cierre del flujo
                br.Close();

                fs = new FileStream(nombreArchivo, FileMode.Open);
                br = new BinaryReader(fs);
                consulta();
                fs.Close(); //cierre del archivo 
                br.Close();
            }
            metaRegs.Clear(); //se limpia la lista de metadatos de los registro
        }

        //este metodo sirve para mostrar el directorio de indices clave primaria
        private void consulta2()
        {
            long position = -1;
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            char tipoDato = ' ';
            long aptAux = -1;
            Llave1.dataGridLlave1.Rows.Clear(); //limpia toda la dataGrid de llavePrimaria

            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int iE = search(nameEntidad); //indice de los atributos correspondientes a dicha entidad
            for (int i = 0; i < listaApsts2[iE].Count; i++) //ciclo que obtiene cada atributo
            {
                int iA = search2((int)listaApsts2[iE][i]); //indice en la lista de atributos de dicho apt
                if (atributos[iA].tipo_indice == 1)
                {
                    position = atributos[iA].dir_indice;
                    tipoDato = atributos[iA].tipo;
                }
            }

            fs.Position = position;
            do
            {
                if (tipoDato == 'C')
                {
                    string[] row = { br.ReadString(), br.ReadInt64().ToString() };
                    Llave1.dataGridLlave1.Rows.Add(row);
                }

                if (tipoDato == 'E')
                {
                    string[] row = { br.ReadInt32().ToString(), br.ReadInt64().ToString() };
                    Llave1.dataGridLlave1.Rows.Add(row);
                }
                long pos = fs.Position;
            
                aptAux = br.ReadInt64();
                if (aptAux != (long)-1)
                    fs.Position = pos;
            } while (aptAux != (long)-1);
        }

        //este metodo sirve para leer ordenadamente los registros y mostrarlos en dataGridLlave1
        private void escrituraIndicePrimario()
        {
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            long position = -1;
            char tipoDato = ' ';
            int longitud = -1;
            string cadena = "";
            List<string> listaSecIndexadaPrimaria = new List<string>();
            List<string> numRepetidos = new List<string>();

            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int iE = search(nameEntidad); //indice de los atributos correspondientes a dicha entidad

            for (int i = 0; i < listaApsts2[iE].Count; i++) //ciclo que obtiene cada atributo
            {
                int iA = search2((int)listaApsts2[iE][i]); //indice en la lista de atributos de dicho apt
                if (atributos[iA].tipo_indice == 1)
                {
                    position = atributos[iA].dir_indice;
                    tipoDato = atributos[iA].tipo;
                    longitud = atributos[iA].longitud;
                    fs.Position = position;
                    for (int x = 0; x < dataGridRegistros.Rows.Count - 1; x++)
                        listaSecIndexadaPrimaria.Add(dataGridRegistros.Rows[x].Cells[i + 1].Value.ToString());
                    listaSecIndexadaPrimaria.Sort();
                    for (int p = 0; p < listaSecIndexadaPrimaria.Count; p++)
                    {
                        if (atributos[iA].tipo == 'C')
                        {
                            cadena = listaSecIndexadaPrimaria[p];
                            bw.Write(cadena);   
                        }
                        else
                        {
                            cadena = listaSecIndexadaPrimaria[p];
                            bw.Write(Int32.Parse(cadena));
                        }
                        for (int w = 0; w < dataGridRegistros.Rows.Count - 1; w++)
                        {
                            if (cadena.Equals(dataGridRegistros.Rows[w].Cells[i + 1].Value.ToString(), StringComparison.Ordinal))
                            {
                                long aux = Int64.Parse(dataGridRegistros.Rows[w].Cells[0].Value.ToString());
                                bw.Write(aux);
                            }
                        }
                    }
                }
            }
            bw.Write((long)-1);
        }

        //este metodo sirve para leer ordenadamente los registros y mostrarlos en dataGridLlave2
        private void escrituraIndiceSecundario()
        {
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            int entero; //para guardar el text convertido en entero
            int longitud = -1;
            string cadena = "";

            int repetido = 0;
            List<string> numRepetidos = new List<string>();
            List<string> listaSecIndexadaSecundariaOrdenada = new List<string>();
            
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }

            int iE = search(nameEntidad); //indice de los atributos correspondientes a dicha entidad

            for (int i = 0; i < listaApsts2[iE].Count; i++) //ciclo que obtiene cada atributo
            {
                int iA = search2((int)listaApsts2[iE][i]); //indice en la lista de atributos de dicho apt
                if (atributos[iA].tipo_indice == 2)
                {
                    fs.Position = atributos[iA].dir_indice;
                    longitud = atributos[iA].longitud;
                    for (int x = 0; x < dataGridRegistros.Rows.Count - 1; x++)
                        listaSecIndexadaSecundariaOrdenada.Add(dataGridRegistros.Rows[x].Cells[i + 1].Value.ToString());
                    listaSecIndexadaSecundariaOrdenada.Sort();
                    for (int q = 0; q < listaSecIndexadaSecundariaOrdenada.Count; q++)
                    {
                        if (atributos[iA].tipo == 'C')
                        {
                            if (numRepetidos.Count > 0)
                            {
                                for (int t = 0; t < numRepetidos.Count; t++)
                                {
                                    if (listaSecIndexadaSecundariaOrdenada[q].Equals(numRepetidos[t]))
                                        repetido = 1;
                                    else
                                        repetido = 0;
                                }
                                if (repetido == 0)
                                    numRepetidos.Add(listaSecIndexadaSecundariaOrdenada[q]);
                            }
                            else
                                numRepetidos.Add(listaSecIndexadaSecundariaOrdenada[q]);

                            if (repetido == 0)
                            {
                                cadena = listaSecIndexadaSecundariaOrdenada[q];
                                bw.Write(cadena);
                                for (int w = 0; w < dataGridRegistros.Rows.Count - 1; w++)
                                {
                                    if (cadena.Equals(dataGridRegistros.Rows[w].Cells[i + 1].Value.ToString(), StringComparison.Ordinal))
                                    {
                                        long aux = Int64.Parse(dataGridRegistros.Rows[w].Cells[0].Value.ToString());
                                        bw.Write(aux);
                                    }
                                } 
                            }
                        }

                        if (atributos[iA].tipo == 'E')
                        {
                            if (numRepetidos.Count > 0)
                            {
                                for (int t = 0; t < numRepetidos.Count; t++)
                                {
                                    if (listaSecIndexadaSecundariaOrdenada[q].Equals(numRepetidos[t]))
                                        repetido = 1;
                                    else
                                        repetido = 0;
                                }
                                if (repetido == 0)
                                    numRepetidos.Add(listaSecIndexadaSecundariaOrdenada[q]);
                            }
                            else
                                numRepetidos.Add(listaSecIndexadaSecundariaOrdenada[q]);

                            if (repetido == 0)
                            {
                                entero = Int32.Parse(listaSecIndexadaSecundariaOrdenada[q]);
                                bw.Write(entero);
                                for (int w = 0; w < dataGridRegistros.Rows.Count - 1; w++)
                                {
                                    if (Int32.Parse(dataGridRegistros.Rows[w].Cells[i + 1].Value.ToString()) == entero)
                                    {
                                        long aux = Int64.Parse(dataGridRegistros.Rows[w].Cells[0].Value.ToString());
                                        bw.Write(aux);
                                    }
                                }
                            }
                        }
                    }
                    listaSecIndexadaSecundariaOrdenada.Clear();
                    bw.Write((long)-1); //escritura del cierre del cajon
                    
                }
                numRepetidos.Clear(); //para limpiar la lista de numRepetidos para cada cajon
                repetido = 0;   
            }
        }
        
        private void secuencialOrdenada(int ie)
        {
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            string cadena = "";
            int longitudTotal = 0;
            long position = -1;

            List<string> numRepetidos = new List<string>();
            List<string> listaSecOrdenada = new List<string>();

            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }

            int iE = search(nameEntidad); //indice de los atributos correspondientes a dicha entidad

            for (int i = 0; i < listaApsts2[iE].Count; i++)
            {
                int iA = search2((int)listaApsts2[iE][i]); //indice en la lista de atributos de dicho apt
                longitudTotal += atributos[iA].longitud;
            }

            for (int i = 0; i < listaApsts2[iE].Count; i++) //ciclo que obtiene cada atributo
            {
                int iA = search2((int)listaApsts2[iE][i]); //indice en la lista de atributos de dicho apt
                if (atributos[iA].tipo_indice == 3)
                {
                    for (int x = 0; x < dataGridRegistros.Rows.Count - 1; x++)
                        listaSecOrdenada.Add(dataGridRegistros.Rows[x].Cells[i + 1].Value.ToString());
                    listaSecOrdenada.Sort();

                    for (int p = 0; p < listaSecOrdenada.Count; p++)
                    {
                            cadena = listaSecOrdenada[p];
                            for (int w = 0; w < dataGridRegistros.Rows.Count - 1; w++)
                            {
                                if (cadena.Equals(dataGridRegistros.Rows[w].Cells[i + 1].Value.ToString(), StringComparison.Ordinal))
                                {      
                                    long aux = Int64.Parse(dataGridRegistros.Rows[w].Cells[0].Value.ToString());         
                                    if (p == 0) //condicion para el primero
                                    {
                                        entidades[iE].dir_datos = aux;
                                    }
                                    if (p >= 1)
                                    {
                                        fs.Position = position + longitudTotal + 8;
                                        bw.Write(aux);
                                    }
                                    if (p == listaSecOrdenada.Count -1) //condicion para el unico
                                    {
                                        fs.Position = aux + longitudTotal + 8;
                                        bw.Write((long)-1);
                                    }
                                    position = aux;
                                }
                            }
                   }
                }
            }
            escribeEntidades();
            imprimir();
            }

        private long search4(string aux)
        {   
            long resp = -1;
            for (int y = 0; y < dataGridRegistros.Rows.Count; y++)
            {
                DataGridViewRow row = dataGridRegistros.Rows[y];
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (aux.Equals(Convert.ToString(row.Cells[i].Value), StringComparison.Ordinal))
                       resp = (long)row.Cells[0].Value;
                }
            }
            return resp;
        }

        private long search5(string aux)
        {
            long resp = -1;
            for (int y = 0; y < dataGridRegistros.Rows.Count; y++)
            {
                DataGridViewRow row = dataGridRegistros.Rows[y];
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (aux.Equals(Convert.ToString(row.Cells[i].Value), StringComparison.Ordinal))
                        resp = (long)row.Cells[row.Cells.Count - 1].Value;
                }
            }
            return resp;
        }

        
        private long escribeRegLlavePrimaria()
        {
            long position = -1;
            tamReg = 0;
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int index = search(nameEntidad);

            for (int i = 0; i < listaApsts2[index].Count; i++)
            {
                int iA = search2((int)listaApsts2[index][i]); //indice en la lista de atributos de dicho apt
                if (atributos[iA].tipo_indice == 1 && atributos[iA].dir_indice == -1)
                    atributos[iA].dir_indice = fs.Length;
            }
            if (bandDirec)
            {
                position = fs.Length + tamDirecPrimaria;
                fs.Position = position; //espacio para el directorio
                bandDirec = false;
                MessageBox.Show("Se inserto un directorio Pk");
            }
            else
                position = fs.Length;
            return position;
        }

        private long escribeRegLlaveSecundaria(long pos)
        {
            tamReg = 0;
            long position = -1;
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;

            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int index = search(nameEntidad);

            if (pos == -1)
                position = fs.Length;
            else
                position = pos;

            if (bandDirec2)
            {
                for (int i = 0; i < listaApsts2[index].Count; i++)
                {
                    int iA = search2((int)listaApsts2[index][i]); //indice en la lista de atributos de dicho apt
                    if (atributos[iA].tipo_indice == 2 && atributos[iA].dir_indice == -1)
                    {
                        atributos[iA].dir_indice = position;
                        position = position + tamDirecSecudaria; //espacio para el directorio
                        MessageBox.Show("Se inserto un cajon Fk");
                    }
                }
                bandDirec2 = false;
            }
            return position;
        }

        private void escribeReg(long position)
        {
            tamReg = 0;
            long aptI = -1;
            long aptF = -1;
            long aptFAux = -1;
            long aptIAux = -1;
            long datos;
            long uP;
            int entero; //para guardar el text convertido en entero
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;

            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int index = search(nameEntidad);
            if (position != -1)
                fs.Position = position;
            else
                fs.Position = fs.Length;
            aptI = fs.Position;

            bw.Write(aptI); //escritura de los apts (inicial)

            for (int i = 0; i < metaRegs.Count; i++)
            {
                tamReg += metaRegs[i].longitud; //suma de la longitud del registro
                if (metaRegs[i].tipo == 'C') //en caso de ser de tipo cadena
                {
                    string nameReg = metaRegs[i].text;
                    int tamName = nameReg.Length;
                    if (tamName < metaRegs[i].longitud - 1) //aqui rellenar la cadena hasta alcanzar la longitud especificada
                    {
                        for (int y = 0; y < ((metaRegs[i].longitud - 1) - tamName); y++)
                            nameReg += " ";
                        bw.Write(nameReg);
                    }
                    else
                    {
                        MessageBox.Show("El dato sobrepasa la longitud");
                        bw.Write("Error");
                    }
                }
                if (metaRegs[i].tipo == 'E') //en caso de ser de tipo entero
                {
                    entero = Int32.Parse(metaRegs[i].text);
                    bw.Write(entero);
                }
            }
            bw.Write(aptF); //escritura de los apts (final)
            if (entidades[index].dir_datos == -1)
                entidades[index].dir_datos = aptI;
            else
            {
                tamReg += 16;
                 
                datos = tamReg - 8;
                fs.Position = entidades[index].dir_datos;
                aptIAux = br.ReadInt64();
                do
                {
                    fs.Position = aptIAux + datos;
                    aptFAux = br.ReadInt64();
                    uP = aptIAux + datos;
                    aptIAux = aptFAux;
                } while (aptFAux != -1);
                fs.Position = uP;
                bw.Write(aptI);
                tamReg -= 16;
            }
            entidades[index].registros = true;
            escribeEntidades();
            imprimir();
            escribeAtributos();
            imprimir2(index);
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            reg.Close();
        }

        private void Aceptar_Click3(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Control c in reg.Controls) //foreach para sacar todos los controles de la forma
            {
                if (c is TextBox) //si el control es un texBox captura el texto contenido
                    metaRegs[i++].text = c.Text;
            }
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int w = 0; w < (29 - textoTam); w++)
                    nameEntidad += " ";
            }
            int iE = search(nameEntidad); //indice de los atributos correspondientes a dicha entidad
            reg.Close(); //cierre de la forma

            fs = new FileStream(nombreArchivo, FileMode.Open);
            bw = new BinaryWriter(fs);
            br = new BinaryReader(fs);
            escribeRegModificado();
            consulta();
            fs.Close();
            bw.Close();
            br.Close();

            if (entidades[iE].banSO)
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                bw = new BinaryWriter(fs);
                br = new BinaryReader(fs);
                secuencialOrdenada(iE);
                fs.Close(); //cierre del archivo 
                bw.Close(); //cierre del flujo
                br.Close();

                fs = new FileStream(nombreArchivo, FileMode.Open);
                br = new BinaryReader(fs);
                consulta();
                fs.Close(); //cierre del archivo 
                br.Close();
            }
            if (entidades[iE].banSIP)
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                bw = new BinaryWriter(fs);
                br = new BinaryReader(fs);
                escrituraIndicePrimario();
                consulta2();
                fs.Close(); //cierre del archivo 
                bw.Close(); //cierre del flujo
                br.Close();
            }
            if (entidades[iE].banSIS)
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                bw = new BinaryWriter(fs);
                br = new BinaryReader(fs);
                escrituraIndiceSecundario();
                fs.Close(); //cierre del archivo 
                bw.Close(); //cierre del flujo
                br.Close();
            }
        }

        private void escribeRegModificadoSecOrdenada()
        {
            long aptI = Convert.ToInt64(listBufReg[0]);
            long aptF = Convert.ToInt64(listBufReg[listBufReg.Count - 1]);
            int tamReg = 0;
            int entero; //para guardar el text convertido en entero
            fs.Position = aptI;
            bw.Write(aptI); //escritura de los apts (inicial)

            for (int i = 0; i < metaRegs.Count; i++)
            {
                tamReg += metaRegs[i].longitud; //suma de la longitud del registro
                if (metaRegs[i].tipo == 'C') //en caso de ser de tipo cadena
                {
                    if (metaRegs[i].clave == 3)
                    {
                        string nameReg2 = metaRegs[i].text;
                        int tamName2 = nameReg2.Length;
                        if (tamName2 < metaRegs[i].longitud - 1) //aqui rellenar la cadena hasta alcanzar la longitud especificada
                        {
                            for (int y = 0; y < ((metaRegs[i].longitud - 1) - tamName2); y++)
                                nameReg2 += " ";
                        }
            
                        listaSecOrdenada.Add(nameReg2);
                        listaSecOrdenada.Remove(auxSecOrd);
                    }

                    string nameReg = metaRegs[i].text;
                    int tamName = nameReg.Length;
                    if (tamName < metaRegs[i].longitud - 1) //aqui rellenar la cadena hasta alcanzar la longitud especificada
                    {
                        for (int y = 0; y < ((metaRegs[i].longitud - 1) - tamName); y++)
                            nameReg += " ";
                        bw.Write(nameReg);
                    }
                    else
                    {
                        if (tamName == metaRegs[i].longitud - 1)
                            bw.Write(nameReg);
                        else
                        {
                            MessageBox.Show("El dato sobrepasa la longitud");
                            bw.Write("Error");
                        }
                    }
                }
                if (metaRegs[i].tipo == 'E') //en caso de ser de tipo entero
                {
                    if (metaRegs[i].clave == 3)
                    {
                        listaSecOrdenada.Add(metaRegs[i].text);
                        listaSecOrdenada.Remove(auxSecOrd);
                    }
                    entero = Int32.Parse(metaRegs[i].text);
                    bw.Write(entero);
                }
            }
            bw.Write(aptF); //escritura de los apts (final)
        }

        private void escribeRegModificado()
        {
            long aptI = Convert.ToInt64(listBufReg[0]);
            long aptF = Convert.ToInt64(listBufReg[listBufReg.Count - 1]);
            int tamReg = 0;
            int entero; //para guardar el text convertido en entero
            fs.Position = aptI;
            bw.Write(aptI); //escritura de los apts (inicial)

            for (int i = 0; i < metaRegs.Count; i++)
            {
                tamReg += metaRegs[i].longitud; //suma de la longitud del registro
                if (metaRegs[i].tipo == 'C') //en caso de ser de tipo cadena
                {
                    string nameReg = metaRegs[i].text;
                    int tamName = nameReg.Length;
                    if (tamName < metaRegs[i].longitud - 1) //aqui rellenar la cadena hasta alcanzar la longitud especificada
                    {
                        for (int y = 0; y < ((metaRegs[i].longitud - 1) - tamName); y++)
                            nameReg += " ";
                        bw.Write(nameReg);
                    }
                    else
                    {
                        if (tamName == metaRegs[i].longitud - 1)
                            bw.Write(nameReg);
                        else
                        {
                            MessageBox.Show("El dato sobrepasa la longitud");
                            bw.Write("Error");
                        }
                    }
                }
                if (metaRegs[i].tipo == 'E') //en caso de ser de tipo entero
                {
                    entero = Int32.Parse(metaRegs[i].text);
                    bw.Write(entero);
                }
            }
            bw.Write(aptF); //escritura de los apts (final)
        }

        //aqui se elimina un registro cualquiera
        private void eliminacionSimpleReg(int iE)
        {
            long aptI = Convert.ToInt64(listBufReg[0]);
            long aptF = Convert.ToInt64(listBufReg[listBufReg.Count - 1]);
            long uP;
            
            int datos = tamReg + 8;
            fs.Position = entidades[iE].dir_datos;

            long aptIAux = br.ReadInt64();

            long aptFAux;
            if (aptI == aptIAux && aptF == -1) //condicion para el unico
            {
                entidades[iE].dir_datos = -1;
                escribeEntidades();
                imprimir();
                dataGridRegistros.Rows.Clear();
            }
            if (aptI == aptIAux) //condicion para el primero
            {
                entidades[iE].dir_datos = aptF;
                escribeEntidades();
                imprimir();
            }
            else
            {
                do
                {
                    fs.Position = aptIAux + datos;
                    aptFAux = br.ReadInt64();
                    uP = aptIAux + datos;
                    aptIAux = aptFAux;
                } while (aptFAux != aptI); //hasta que encuentre el aptI: escribe el aptF
                fs.Position = uP;
                bw.Write(aptF);
            }
        }

        //este metodo sirve para mostrar el directorio de indices clave secundaria
        private void consulta3()
        {
            if (listBufAtrib.Count == 0)
            {
                MessageBox.Show("Seleccione el atributo");
                return;
            }
            long aptI = Convert.ToInt64(listBufAtrib[3]);
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            char tipoDato = ' ';
            int cont = 0;
            string[] rowAux = { };
            int repetido = 0;
            List<string> numRepetidos = new List<string>();
            List<string> listaSecIndexadaSecundariaOrdenada = new List<string>();
            Llave2.dataGridLlave2.Rows.Clear(); //limpia toda la dataGrid de llavePrimaria

            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int iE = search(nameEntidad); //indice de los atributos correspondientes a dicha entidad
            
            for (int i = 0; i < listaApsts2[iE].Count; i++)
            {
                int iA = search2((int)listaApsts2[iE][i]); //indice en la lista de atributos de dicho apt
                if (aptI == atributos[iA].dir_atrib && atributos[iA].tipo_indice == 2)
                {
                    fs.Position = atributos[iA].dir_indice;
                    tipoDato = atributos[iA].tipo;
                    for (int x = 0; x < dataGridRegistros.Rows.Count - 1; x++)
                    {
                        listaSecIndexadaSecundariaOrdenada.Add(dataGridRegistros.Rows[x].Cells[i + 1].Value.ToString());
                    }
                    listaSecIndexadaSecundariaOrdenada.Sort();

                    for (int q = 0; q < listaSecIndexadaSecundariaOrdenada.Count; q++)
                    {
                        string num = listaSecIndexadaSecundariaOrdenada[q];
                        if (numRepetidos.Count > 0)
                        {
                            for (int t = 0; t < numRepetidos.Count; t++)
                            {
                                if (num.Equals(numRepetidos[t]))
                                    repetido = 1;
                                else
                                    repetido = 0;
                            }
                            if (repetido == 0)
                                numRepetidos.Add(num);
                        }
                        else
                            numRepetidos.Add(num);
                        
                        for (int p = 0; p < listaSecIndexadaSecundariaOrdenada.Count; p++)
                            if (num.Equals(listaSecIndexadaSecundariaOrdenada[p], StringComparison.Ordinal))
                                cont++;
                        if (repetido == 0)
                        {
                            if (tipoDato == 'C')
                            {
                                switch(cont)
                                {
                                    case 1:
                                        string[] row = { br.ReadString(), br.ReadUInt64().ToString() };
                                        rowAux = row;
                                        break;
                                    case 2:
                                        string[] row2 = { br.ReadString(), br.ReadUInt64().ToString(), br.ReadUInt64().ToString() };
                                        rowAux = row2;
                                        break;
                                    case 3:
                                        string[] row3 = { br.ReadString(), br.ReadUInt64().ToString(), br.ReadUInt64().ToString(), br.ReadUInt64().ToString() };
                                        rowAux = row3;
                                        break;
                                    case 4:
                                        string[] row4 = { br.ReadString(), br.ReadUInt64().ToString(), br.ReadUInt64().ToString(), br.ReadUInt64().ToString(), br.ReadUInt64().ToString() };
                                        rowAux = row4;
                                        break;
                                }
                                Llave2.dataGridLlave2.Rows.Add(rowAux);
                            }

                            if (tipoDato == 'E')
                            {
                                switch (cont)
                                {
                                    case 1:
                                        string[] row = { br.ReadUInt32().ToString(), br.ReadUInt64().ToString() };
                                        rowAux = row;
                                        break;
                                    case 2:
                                        string[] row2 = { br.ReadUInt32().ToString(), br.ReadUInt64().ToString(), br.ReadUInt64().ToString() };
                                        rowAux = row2;
                                        break;
                                    case 3:
                                        string[] row3 = { br.ReadUInt32().ToString(), br.ReadUInt64().ToString(), br.ReadUInt64().ToString(), br.ReadUInt64().ToString() };
                                        rowAux = row3;
                                        break;
                                    case 4:
                                        string[] row4 = { br.ReadUInt32().ToString(), br.ReadUInt64().ToString(), br.ReadUInt64().ToString(), br.ReadUInt64().ToString(), br.ReadUInt64().ToString() };
                                        rowAux = row4;
                                        break;
                                }
                                Llave2.dataGridLlave2.Rows.Add(rowAux);
                            }
                        }
                        cont = 0;
                    }    
                }
                numRepetidos.Clear();
                repetido = 0;
            }   
        }

        private void consulta()
        {
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            int contRow = 0;
            int contRows = 0;
            long aptFAux = -1;
            dataGridRegistros.Columns.Clear();
            dataGridRegistros.Rows.Clear();
            DataGridViewTextBoxColumn column;
            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "aptI";
            column.Width = 50;
            dataGridRegistros.Columns.Add(column);
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int iE = search(nameEntidad); //indice de los atributos correspondientes a dicha entidad
            for (int i = 0; i < listaApsts2[iE].Count; i++) //ciclo que obtiene cada atributo
            {
                int iA = search2((int)listaApsts2[iE][i]); //indice en la lista de atributos de dicho apt
                column = new DataGridViewTextBoxColumn();
                column.HeaderText = atributos[iA].nombre;
                column.Width = 50;
                dataGridRegistros.Columns.Add(column);
            }
            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "aptF";
            column.Width = 50;
            dataGridRegistros.Columns.Add(column);
            DataGridViewRow row;

            fs.Position = entidades[iE].dir_datos;
            do
            {
                row = (DataGridViewRow)dataGridRegistros.Rows[contRows++].Clone();
                row.Cells[0].Value = br.ReadInt64();
                for (int i = 0; i < listaApsts2[iE].Count; i++)
                {
                    int iA = search2((int)listaApsts2[iE][i]);
                    switch (atributos[iA].tipo)
                    {
                        case 'E':
                            row.Cells[i + 1].Value = br.ReadInt32();
                            break;
                        case 'C':
                            row.Cells[i + 1].Value = br.ReadString();
                            break;
                    }
                    contRow = i + 1;
                }
                aptFAux = br.ReadInt64();
                if (aptFAux != -1)
                    fs.Position = aptFAux;
                row.Cells[contRow + 1].Value = aptFAux;
                dataGridRegistros.Rows.Add(row);
            } while (aptFAux != -1);
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Diccionario de Datos> JJ Amaya";
            comboEntidad2.Items.Clear();

            comboEntidad2.ResetText();

            dataGridEntidades.Rows.Clear(); //limpiar las datagrid entidades
            dataGridAtributos.Rows.Clear(); //limpiar las datagrid atributos
            dataGridRegistros.Rows.Clear();

            //llave primaria
            Llave1.dataGridLlave1.Rows.Clear(); //limpia las filas de la llave primaria
            listaSecIndexadaPrimariaGlobal.Clear(); //quita los elementos guardados en la lista de llave primaria
            bandDirec = true; //para habilitar la insercion de otro cajon

            //llave secundaria
            Llave2.dataGridLlave2.Rows.Clear(); //limpia las filas de la llave secundaria
            listaSecIndexadaSecundaria.Clear(); //quita los elementos guardados en la lista de llave secundaria
            bandDirec2 = true; //para habilitar la insercion de otro cajon

            dataGridRegistros.Columns.Clear();
            apts.Clear(); //reinicia la lista de apuntadores
            if (enti)
                apts2.Clear();
            enti = false;
            listaNomEntidades.Clear();
            listaApsts2.Clear();
            entidades.Clear(); //reinicia la lista de entidades
            atributos.Clear();
            cab = -1;
            metaRegs.Clear();
            listaNomEntidades.Clear(); //reinicia la lista de nombres de entidades
        }

        private void dataGridRegistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridRegistros.Rows[e.RowIndex];
            List<string> BufReg = new List<string>();
            for (int i = 0; i < row.Cells.Count; i++)
                BufReg.Add(Convert.ToString(row.Cells[i].Value));
            listBufReg = BufReg;   
        }

        private void dataGridAtributos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridAtributos.Rows[e.RowIndex];
            List<string> BufAtrib = new List<string>();
            for (int i = 0; i < row.Cells.Count; i++)
                BufAtrib.Add(Convert.ToString(row.Cells[i].Value));
            listBufAtrib = BufAtrib;
        }

        private void dataGridEntidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridEntidades.Rows[e.RowIndex];
            if (string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
            {
                MessageBox.Show("Debe elegir una entidad");
                return;
            }
            string nameEntidad = row.Cells[0].Value.ToString();
            int textoTam = nameEntidad.Length;
            int iE = -1;
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
                iE = search(nameEntidad); //indice de los atributos correspondientes a dicha entidad
            }
            else
            {
                if (textoTam == 29)
                    iE = search(nameEntidad); //indice de los atributos correspondientes a dicha entidad
            }
           
            fs = new FileStream(nombreArchivo, FileMode.Open);
            bw = new BinaryWriter(fs);
            br = new BinaryReader(fs);
            imprimir2(iE);
            fs.Close();
            bw.Close();
            br.Close();
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            formaE = new Form2();
            formaE.Text = "Nueva Entidad";
            formaE.Cancelar.Click += Cancelar_Click1;
            formaE.Aceptar.Click += Aceptar_Click4; 
            formaE.Show();
        }

        //aceptar para asignar el nombre de una nueva entidad
        private void Aceptar_Click4(object sender, EventArgs e)
        {
            temporalEnt = new Entidad();
            string nameEntidad = formaE.textNomEntid.Text;
            int textoTam = nameEntidad.Length;

            if (string.IsNullOrEmpty(nameEntidad)) //validacion de la entrada de entidad
            {
                MessageBox.Show("Debe ingresar un nombre para la nueva entidad");
                return;
            }

            comboEntidad2.Items.Add(nameEntidad); //aqui se agrega el nombre a la lista para registros
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            bool existe = false;
            for (int i = 0; i < entidades.Count; i++)
                if (entidades[i].nombre == nameEntidad)
                    existe = true;

            if (!existe) 
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                bw = new BinaryWriter(fs);
                br = new BinaryReader(fs);
                temporalEnt.nombre = nameEntidad;
                temporalEnt.dir_entidad = fs.Length;
                temporalEnt.dir_datos = -1;
                temporalEnt.dir_atributos = -1;
                temporalEnt.dir_sig_entidad = -1;

                entidades.Add(temporalEnt); //aqui se agrega el temporal a la lista de entidades
                listaNomEntidades.Add(temporalEnt.nombre); //aqui se agrega a la lista los nombres
                apts.Add(temporalEnt.dir_entidad); //aqui se agregan los apuntadores
                setApuntadoresSig(); //define el orden de las entidades y cabecera
                escribeEntidades(); //escribe en el archivo las entidades actualizadas
                apts2 = new List<long>(); //se crea una lista para almacenar los apuntadores de los atributos
                enti = true;                          //correspondientes a dicha entidad  
                listaApsts2.Add(apts2); //se agrega a la lista de atributos
                imprimir();
                fs.Close();
                bw.Close();
                br.Close();
            }
            else
                MessageBox.Show("La entidad ya existe, no se puede crear.");
            formaE.Close();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formaModifE = new Form4();
            formaModifE.Cancelar.Click += Cancelar_Click3;
            formaModifE.Aceptar.Click += Aceptar_Click1;
            formaModifE.Show();
        }

        //cancelar de la forma modificar entidad
        private void Cancelar_Click3(object sender, EventArgs e)
        {
            formaModifE.Close();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formaE = new Form2();
            formaE.Text = "Eliminar Entidad";
            formaE.Cancelar.Click += Cancelar_Click1;
            formaE.Aceptar.Click += Aceptar_Click5; 
            formaE.Show();
        }

        //aceptar para asignar el nombre de una entidad que se quiere remover
        private void Aceptar_Click5(object sender, EventArgs e)
        {
            string nameEntidad2 = formaE.textNomEntid.Text;
            string nameEntidad = nameEntidad2;
            int textoTam = nameEntidad2.Length; //obtiene el nombre de la entidad a eliminar
            int resp = -1;
            
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad2 += " ";
            }
            int iE = search(nameEntidad2); //indice de los atributos correspondientes a dicha entidad

            fs = new FileStream(nombreArchivo, FileMode.Open);
            bw = new BinaryWriter(fs);
            br = new BinaryReader(fs);

            for (int i = 0; i < entidades.Count; i++) //ciclo para buscar el nombre de la entidad 
            {
                if (nameEntidad2.Equals(entidades[i].nombre, StringComparison.Ordinal)) //condicion de igualdad strings
                {
                    for (int x = 0; x < listaApsts2[i].Count; x++) //ciclo que obtiene cada atributo
                    {
                        int iA = search2((int)listaApsts2[i][x]); //indice en la lista de atributos de dicho apt
                        atributos.RemoveAt(iA);
                    }
                    comboEntidad2.Items.Remove(nameEntidad); //elimina el item del comboBox de registros
                    apts.Remove(entidades[i].dir_entidad); //remover el apuntador
                    listaNomEntidades.Remove(entidades[i].nombre); //remover el nombre
                    MessageBox.Show("Entidad removida: " + entidades[i].nombre);
                    entidades.RemoveAt(i); //remover de la lista entidades
                    listaApsts2.RemoveAt(i); //remueve la lista completa de atributos
                    dataGridEntidades.Rows.RemoveAt(i); //eliminacion de la datagrid entidad
                    if (entidades.Count == 1) //si queda una entidad limpiar apt_sig_entidad
                        entidades[0].dir_sig_entidad = -1;
                    if (entidades.Count == 0) //si no quedan entidades limpiar cabecera
                    {
                        fs.Position = (long)0;
                        bw.Write((long)-1);
                        dataGridEntidades.Rows.Clear(); //limpia toda la dataGrid

                    }
                    if (entidades.Count > 1)
                        entidades[entidades.Count - 1].dir_sig_entidad = (long)-1; //limpia el apuntador sig de la ultima entidad
                    resp = 1; //indica que se removio una entidad
                }
            }
            if (resp == -1 && entidades.Count != 0)
                MessageBox.Show("No se ha registrado dicha entidad");
            else
            {
                setApuntadoresSig(); //define el orden de las entidades y cabecera
                escribeEntidades(); //escribe en el archivo las entidades actualizadas
                imprimir(); //actualiza la dataGrid
                imprimir2(iE); //actualiza la dataGrid
            }
            fs.Close();
            bw.Close();
            br.Close();
            formaE.Close();
        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuevoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            formaNuevoAtrib = new Form5();
            formaNuevoAtrib.Text = "Nuevo Atributo";
            formaNuevoAtrib.Cancelar.Click += Cancelar_Click4;

            for (int i = 0; i < entidades.Count; i++)
                formaNuevoAtrib.comboEntidad.Items.Add(entidades[i].nombre);

            formaNuevoAtrib.comboTipo.Items.Add("E");
            formaNuevoAtrib.comboTipo.Items.Add("C");

            formaNuevoAtrib.comboCL.Items.Add("0"); //clave sin orden
            formaNuevoAtrib.comboCL.Items.Add("1"); //clave primaria
            formaNuevoAtrib.comboCL.Items.Add("2"); //clave secundaria
            formaNuevoAtrib.comboCL.Items.Add("3"); //clave ordenada
            formaNuevoAtrib.comboCL.Items.Add("4"); //clave foranea

            formaNuevoAtrib.Aceptar.Click += Aceptar_Click6;
            formaNuevoAtrib.Show();
        }

        //aceptar de la forma nuevo atributo
        private void Aceptar_Click6(object sender, EventArgs e)
        {
            //agregarReg.Enabled = true;
            string entidadSelect;
            temporalAtrib = new Atributo();
            int textoTam = formaNuevoAtrib.textNomAtrib.TextLength;
            int iE = formaNuevoAtrib.comboEntidad.SelectedIndex;
            ie = iE;
            string nameAtrib = formaNuevoAtrib.textNomAtrib.Text;
            if (string.IsNullOrEmpty(nameAtrib)) //validacion del nombre del atributo
            {
                MessageBox.Show("Debe ingresar un nombre para el nuevo atributo");
                return;
            }
            if (entidades[iE].registros)
            {
                MessageBox.Show("No se pueden agregar mas atributos");
                return;
            }
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameAtrib += " ";
            }
            char tipo = formaNuevoAtrib.comboTipo.SelectedItem.ToString()[0];
            if (tipo == 'E')
                temporalAtrib.longitud = 4;
            else
                temporalAtrib.longitud = Convert.ToInt32(formaNuevoAtrib.numericLong.Text);
            temporalAtrib.nombre = nameAtrib;
            temporalAtrib.tipo = tipo;
            fs = new FileStream(nombreArchivo, FileMode.Open);
            bw = new BinaryWriter(fs);
            br = new BinaryReader(fs);
            temporalAtrib.dir_atrib = fs.Length;
            int indice = Convert.ToInt32(formaNuevoAtrib.comboCL.SelectedItem.ToString());
            temporalAtrib.tipo_indice = indice;
            temporalAtrib.dir_indice = -1;
            temporalAtrib.dir_sig_atrib = -1;
            entidadSelect = formaNuevoAtrib.comboEntidad.Text;
            int entidadTam = entidadSelect.Length;
            if (entidadTam != 29)
            {
                for (int i = 0; i < (29 - entidadTam); i++)
                    entidadSelect += " ";
            }
            listaApsts2[iE].Add(temporalAtrib.dir_atrib);
            if (entidades[iE].dir_atributos == -1)
                entidades[iE].dir_atributos = temporalAtrib.dir_atrib;
            else
                atributos[search2((int)listaApsts2[iE][listaApsts2[iE].Count - 2])].dir_sig_atrib = temporalAtrib.dir_atrib;
            entidades[iE].atributos = true;
            atributos.Add(temporalAtrib); //aqui se agrega el temporal a la lista de atributos
            escribeEntidades();
            escribeAtributos();
            imprimir();
            imprimir2(iE);
            fs.Close();
            bw.Close();
            br.Close();
            formaNuevoAtrib.Close();
        }

        //cancelar de la forma nuevo atributo
        private void Cancelar_Click4(object sender, EventArgs e)
        {
            formaNuevoAtrib.Close();
        }

        //modificar atributo
        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            modificarAtributoForma = new Form6();
            modificarAtributoForma.Text = "Modificar Atributo";
            modificarAtributoForma.Cancelar.Click += Cancelar_Click5;

            for (int i = 0; i < entidades.Count; i++)
                modificarAtributoForma.comboEntidad.Items.Add(entidades[i].nombre);

            modificarAtributoForma.Aceptar.Click += Aceptar_Click7;
            modificarAtributoForma.Show();
        }

        //cerrar forma de modificar atributo
        private void Cancelar_Click5(object sender, EventArgs e)
        {
            modificarAtributoForma.Close();
        }

        //modificar el atributo con forma
        private void Aceptar_Click7(object sender, EventArgs e)
        {
            string nuevoNom = modificarAtributoForma.textNomNuevoEntidad.Text;
            string nuevoNom2 = nuevoNom;
            int nuevoNomTam = nuevoNom.Length;
            string nameAtrib = modificarAtributoForma.textNomEntid.Text;
            int textoTam = modificarAtributoForma.textNomEntid.TextLength;
            int iE = -1;
            iE = modificarAtributoForma.comboEntidad.SelectedIndex;
            if (iE == -1)
            {
                MessageBox.Show("Debe seleccionar la entidad del atributo");
                formaE.Close();
                return;
            }
            else
            {
                if (entidades[iE].registros)
                {
                    MessageBox.Show("No se puede modificar el atributo");
                    formaE.Close();
                    return;
                }
            }
            if (string.IsNullOrEmpty(nameAtrib)) //validacion del nombre del atributo
            {
                MessageBox.Show("Debe ingresar el nombre para el atributo");
                formaE.Close();
                return;
            }
            if (string.IsNullOrEmpty(nuevoNom)) //validacion del nombre del atributo
            {
                MessageBox.Show("Debe ingresar el nuevo nombre para el nuevo atributo");
                formaE.Close();
                return;
            }
            fs = new FileStream(nombreArchivo, FileMode.Open);
            bw = new BinaryWriter(fs);
            br = new BinaryReader(fs);
            if (nuevoNomTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - nuevoNomTam); i++)
                    nuevoNom += " ";
            }

            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameAtrib += " ";
            }

            for (int y = 0; y < listaApsts2[iE].Count; y++)
            {
                int iA = search2((int)listaApsts2[iE][y]); //indice en la lista de atributos de dicho apt
                if (nameAtrib.Equals(atributos[iA].nombre, StringComparison.Ordinal))
                    atributos[iA].nombre = nuevoNom;
            }
            escribeAtributos();
            imprimir2(iE);
            listaNomEntidades.Clear(); //reinicia la lista de nombres de entidades
            fs.Close();
            bw.Close();
            br.Close();
            modificarAtributoForma.Close();
        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            eliminarAtribForma = new Form7();
            eliminarAtribForma.Text = "Eliminar Atributo";
            eliminarAtribForma.Cancelar.Click += Cancelar_Click6;

            for (int i = 0; i < entidades.Count; i++)
                eliminarAtribForma.comboEntidad.Items.Add(entidades[i].nombre);

            eliminarAtribForma.Aceptar.Click += Aceptar_Click8;
            eliminarAtribForma.Show();
        }

        //cancelar de la forma eliminar atributo
        private void Cancelar_Click6(object sender, EventArgs e)
        {
            eliminarAtribForma.Close();
        }

        //aceptar de la forma eliminar atributo
        private void Aceptar_Click8(object sender, EventArgs e)
        {
            int textoAtribTam = eliminarAtribForma.textNomEntid.TextLength; //tama;o a rellenar 
            string nameAtrib = eliminarAtribForma.textNomEntid.Text; //obtiene el nombre del atributo a eliminar
            int iE = eliminarAtribForma.comboEntidad.SelectedIndex; //indice de la entidad seleccionada
            int resp = -1;
            int i2 = -1;
            fs = new FileStream(nombreArchivo, FileMode.Open);
            bw = new BinaryWriter(fs);
            br = new BinaryReader(fs);
            if (textoAtribTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoAtribTam); i++)
                    nameAtrib += " ";
            }
            int index = search3(nameAtrib, listaApsts2[iE]); //optimizacion de search2
            if (index != -1) //encontro el atributo en la lista de atributos
            {
                resp = 1;
                for (int i = 0; i < listaApsts2[iE].Count; i++)
                {
                    if (atributos[index].dir_atrib == listaApsts2[iE][i]) //ahora encuentro el apuntador en la lista de listas
                    {
                        if (i == 0 && listaApsts2[iE].Count == 1) // <- condicion para quitar la liga de la entidad cuando ya no tiene atributos
                            entidades[iE].dir_atributos = -1;

                        if (i == 0 && listaApsts2[iE].Count > 1) //condicion para quitar la liga de la entidad cuando queda un atributo
                            entidades[iE].dir_atributos = atributos[search2((int)listaApsts2[iE][i + 1])].dir_atrib;

                        if (i > 0 && listaApsts2[iE].Count > 2 && i != listaApsts2[iE].Count - 1) //condicion para atributo intermedio
                            atributos[search2((int)listaApsts2[iE][i - 1])].dir_sig_atrib = atributos[search2((int)listaApsts2[iE][i + 1])].dir_atrib;
                       
                        if (i > 0 && listaApsts2[iE].Count > 2 && i == listaApsts2[iE].Count - 1) //condicion para el ultimo atributo
                            atributos[search2((int)listaApsts2[iE][i - 1])].dir_sig_atrib = -1;
                        listaApsts2[iE].RemoveAt(i);
                        i2 = i;
                    }
                }
                if (listaApsts2[iE].Count == 1) //condicion para cuando queda solo un atributo de la entidad
                    atributos[search2((int)listaApsts2[iE][0])].dir_sig_atrib = -1;
                atributos.RemoveAt(index);
                MessageBox.Show("Atributo removido");
            }

            if (resp == -1)
                MessageBox.Show("No se ha registrado dicho atributo");
            else
            {
                escribeEntidades(); //escribe las entidades actualizadas
                escribeAtributos(); //escribe los atributos actualizados
                imprimir2(iE); //muestra los cambios en atributos
                imprimir(); //muestra los cambios en entidades
            }
            fs.Close();
            bw.Close();
            br.Close();
            eliminarAtribForma.Close();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<String> nombresAtrib = new List<string>();
            foreach (Atributo item in atributos)
                nombresAtrib.Add(item.nombre);

            crearRelacion = new Form8(nombresAtrib);
            crearRelacion.Text = "Crear Relacion";
            if (entidades.Count > 0)
            {
                for (int i = 0; i < entidades.Count; i++)
                {
                    crearRelacion.comboEntidad1.Items.Add(entidades[i].nombre);
                    crearRelacion.comboEntidad2.Items.Add(entidades[i].nombre);
                }
            }
 
            crearRelacion.Cancelar.Click += Cancelar_Click7;
            crearRelacion.Aceptar.Click += Aceptar_Click2;
            crearRelacion.Show();
        }

        //aceptar de la forma crear relacion
        private void Aceptar_Click2(object sender, EventArgs e)
        {
            string nomRelacion = crearRelacion.nombreRelacion.Text;
            string entidadUno = crearRelacion.comboEntidad1.SelectedItem.ToString();
            string entidadDos = crearRelacion.comboEntidad2.SelectedItem.ToString();
            string atributoUno = crearRelacion.comboAtributo1.SelectedItem.ToString();
            string atributoDos = crearRelacion.comboAtributo2.SelectedItem.ToString();
            int textoTam = nomRelacion.Length;

            temporalRelacion = new Relacion();

            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nomRelacion += " ";
            }

            temporalRelacion.nombreRel = nomRelacion;
            temporalRelacion.nombreE1 = entidadUno;
            temporalRelacion.nombreE2 = entidadDos;

            foreach(Entidad item in entidades)
            {
                if (entidadUno == item.nombre)
                    temporalRelacion.dir_e1 = item.dir_entidad;
                if (entidadDos == item.nombre)
                    temporalRelacion.dir_e2 = item.dir_entidad;
            }

            for (int i = 0; i < entidades.Count; i++)
            {
                if (entidadUno == entidades[i].nombre)
                {
                    long aptAtrib = entidades[i].dir_atributos;
                }
            }

            if (relaciones.Count == 0)
                temporalRelacion.dir_sig_rel = -1;


            relaciones.Add(temporalRelacion);
            crearRelacion.Close();
        }

        //cancelar de la forma crear relacion
        private void Cancelar_Click7(object sender, EventArgs e)
        {
            crearRelacion.Close();
        }

        private void nuevoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            reg = new Form3();
            metaRegs.Clear();
            reg.Text = "Agregar"; //nombre de la forma
            int dP = 35;
            int xP = 10;
            int yP = 10;
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            List<Label> nAtributos = new List<Label>(); //lista para agregar los Label
            List<TextBox> nTextBox = new List<TextBox>(); //lista para agregar los TextBox
            Label atrib;
            TextBox tB;
            if (string.IsNullOrEmpty(nameEntidad))
            {
                MessageBox.Show("Debe ingresar un nombre para la entidad");
                return;
            }

            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int iE = search(nameEntidad); //indice de los atributos correspondientes a dicha entidad
            for (int i = 0; i < listaApsts2[iE].Count; i++) //ciclo que obtiene cada atributo
            {
                int iA = search2((int)listaApsts2[iE][i]); //indice en la lista de atributos de dicho apt
                temporalMetaReg = new MetaReg(); //aux para los metadatos del registro
                temporalMetaReg.longitud = atributos[iA].longitud;
                atrib = new Label();
                tB = new TextBox();
                temporalMetaReg.tipo = atributos[iA].tipo;
                temporalMetaReg.clave = atributos[iA].tipo_indice; //secuecial ordenada/indexada
                atrib.Text = atributos[search2((int)listaApsts2[iE][i])].nombre;
                atrib.Location = new System.Drawing.Point(xP, yP);
                tB.Location = new System.Drawing.Point(xP + 150, yP);
                yP += dP;
                nTextBox.Add(tB);
                nAtributos.Add(atrib);
                metaRegs.Add(temporalMetaReg);
            }
            for (int y = 0; y < nAtributos.Count; y++) //ciclo para agregar los controles a la forma
            {
                reg.Controls.Add(nAtributos[y]);
                reg.Controls.Add(nTextBox[y]);
            }
            Button aceptar = new Button();
            Button cancelar = new Button();
            aceptar.Location = new System.Drawing.Point(xP + 350, 20);
            cancelar.Location = new System.Drawing.Point(xP + 350, 60);
            aceptar.Text = "Aceptar";
            cancelar.Text = "Cancelar";
            reg.Controls.Add(aceptar); //aqui se agrega el boton aceptar
            cancelar.Click += Cancelar_Click;
            aceptar.Click += Aceptar_Click;
            reg.Controls.Add(cancelar); //aqui se agrega el boton cancelar
            reg.Show(); //permite mostrar la forma
        }

        private void modificarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (listBufReg.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a modificar");
                return;
            }
            reg = new Form3();
            reg.Text = "Modificar"; //nombre de la forma
            int dP = 35;
            int xP = 10;
            int yP = 10;
            metaRegs.Clear();
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            List<Label> nAtributos = new List<Label>(); //lista para agregar los Label
            List<TextBox> nTextBox = new List<TextBox>(); //lista para agregar los TextBox
            Label atrib;
            TextBox tB;
            if (string.IsNullOrEmpty(nameEntidad))
            {
                MessageBox.Show("Debe ingresar un nombre para la entidad");
                return;
            }

            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int iE = search(nameEntidad); //indice de los atributos correspondientes a dicha entidad

            for (int i = 0; i < listaApsts2[iE].Count; i++) //ciclo que obtiene cada atributo
            {
                int iA = search2((int)listaApsts2[iE][i]); //indice en la lista de atributos de dicho apt
                temporalMetaReg = new MetaReg(); //aux para los metadatos del registro
                temporalMetaReg.longitud = atributos[iA].longitud;

                temporalMetaReg.clave = atributos[iA].tipo_indice;

                atrib = new Label();
                tB = new TextBox();
                temporalMetaReg.tipo = atributos[iA].tipo;
                atrib.Text = atributos[search2((int)listaApsts2[iE][i])].nombre;
                atrib.Location = new System.Drawing.Point(xP, yP);
                tB.Location = new System.Drawing.Point(xP + 150, yP);
                tB.Text = listBufReg[i + 1];
                if (atributos[search2((int)listaApsts2[iE][i])].tipo_indice == 3)
                    auxSecOrd = tB.Text;
                yP += dP;
                nTextBox.Add(tB);
                nAtributos.Add(atrib);
                metaRegs.Add(temporalMetaReg);
            }
            for (int y = 0; y < nAtributos.Count; y++) //ciclo para agregar los controles a la forma
            {
                reg.Controls.Add(nAtributos[y]);
                reg.Controls.Add(nTextBox[y]);
            }

            Button aceptar = new Button();
            Button cancelar = new Button();
            aceptar.Location = new System.Drawing.Point(xP + 350, 20);
            cancelar.Location = new System.Drawing.Point(xP + 350, 60);
            aceptar.Text = "Aceptar";
            cancelar.Text = "Cancelar";
            reg.Controls.Add(aceptar); //aqui se agrega el boton aceptar
            cancelar.Click += Cancelar_Click;

            aceptar.Click += Aceptar_Click3;

            reg.Controls.Add(cancelar); //aqui se agrega el boton cancelar
            reg.Show(); //permite mostrar la forma
        }

        private void eliminarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (listBufReg.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a eliminar");
                return;
            }
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int iE = search(nameEntidad); //indice de los atributos correspondientes a dicha entidad


            fs = new FileStream(nombreArchivo, FileMode.Open);
            br = new BinaryReader(fs);
            bw = new BinaryWriter(fs);
            eliminacionSimpleReg(iE);
            if (entidades[iE].dir_datos != -1)
                consulta();
            fs.Close();
            br.Close();
            bw.Close();

            if (entidades[iE].banSO)
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                bw = new BinaryWriter(fs);
                br = new BinaryReader(fs);
                secuencialOrdenada(iE);
                fs.Close(); //cierre del archivo 
                bw.Close(); //cierre del flujo
                br.Close();

                fs = new FileStream(nombreArchivo, FileMode.Open);
                br = new BinaryReader(fs);
                if (entidades[iE].dir_datos != -1)
                    consulta();
                fs.Close(); //cierre del archivo 
                br.Close();
            }
            if (entidades[iE].banSIP)
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                bw = new BinaryWriter(fs);
                br = new BinaryReader(fs);
                escrituraIndicePrimario();
                if (entidades[iE].dir_datos != -1)
                    consulta2();
                else
                    Llave1.dataGridLlave1.Rows.Clear();
                fs.Close(); //cierre del archivo 
                bw.Close(); //cierre del flujo
                br.Close();
            }

            if (entidades[iE].banSIS)
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                bw = new BinaryWriter(fs);
                br = new BinaryReader(fs);
                if (entidades[iE].dir_datos != -1)
                    escrituraIndiceSecundario();
                else
                    Llave2.dataGridLlave2.Rows.Clear();
                fs.Close(); //cierre del archivo 
                bw.Close(); //cierre del flujo
                br.Close();
            }
        }

        private void verToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fs = new FileStream(nombreArchivo, FileMode.Open);
            br = new BinaryReader(fs);
            consulta();
            fs.Close();
            br.Close();

            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int iE = search(nameEntidad); //indice de los atributos correspondientes a dicha entidad
            if (entidades[iE].banSIP && entidades[iE].registros)
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                br = new BinaryReader(fs);
                consulta2();
                fs.Close();
                br.Close();
            }
            else
                Llave1.dataGridLlave1.Rows.Clear();

            if (entidades[iE].banSIS && entidades[iE].registros)
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                br = new BinaryReader(fs);
                consulta3();
                fs.Close();
                br.Close();
            }
            else
                Llave2.dataGridLlave2.Rows.Clear();
        }

        private void botonPrimaria_Click(object sender, EventArgs e)
        {
            Llave1.Show();
        }

        private void L_Secundaria_Click(object sender, EventArgs e)
        {
            fs = new FileStream(nombreArchivo, FileMode.Open);
            br = new BinaryReader(fs);
            consulta3();
            fs.Close();
            br.Close();
            Llave2.Show();
        }
    }
}