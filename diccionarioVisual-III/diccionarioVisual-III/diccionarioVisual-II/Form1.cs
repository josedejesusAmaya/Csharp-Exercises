using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

/*
 * **** Falta ****
 * Abrir un archivo.
 */

namespace diccionarioVisual_II
{
    public partial class Form1 : Form
    {
        List<Entidad> entidades;
        List<Atributo> atributos;
        List<Nodo> nodos;
        Entidad temporalEnt;
        Atributo temporalAtrib;
        MetaReg temporalMetaReg;
        FileStream fs;
        BinaryWriter bw;
        BinaryReader br;
        private string nombreArchivo;
        private long cab = -1;
        int contReg = 0;
        int N; 
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
        List<string> listaHashGlobal;
        List<Fk> listaSecIndexadaSecundaria;
        List<string> listaContenidoNodo;
        long tamDirecPrimaria = 128;
        long tamDirecSecudaria = 448;
        long tamDirecHash = 24;
        long tamCajonHashInt = 56; //cajon de cuatro registros
        Form3 reg;
        Form2 modificar;
        int tamReg;
         
        //long dirRaiz = -1;
        bool band = true;
        int ie2 = -1;
        string auxSecOrd;
        int ie; //para saber cual fue la ultima entidad para un nuevo atributo
        bool bandDirec = true;
        bool bandDirec2 = true;
        bool bandDirec3 = true;

        bool bandCajonUno = true;
        bool bandCajonDos = true;
        bool bandCajonTres = true;
        bool cajonLlenoUno = false;
        bool cajonLlenoDos = false;
        bool cajonLlenoTres = false;
        bool gridUnoVacia = false;
        bool gridDosVacia = false;
        bool gridTresVacia = false;

        public Form1()
        {
            InitializeComponent();
            N = 2;
            auxMetaReg = new MetaReg();
            listaContenidoNodo = new List<string>(); //lista para ordenar cada nodo
            listaSecOrdenada = new List<string>(); //lista para la clave de busqueda 3
            listaSecIndexadaPrimariaGlobal = new List<string>(); //lista para la clave 1
            listaHashGlobal = new List<string>(); //lista para hash
            listaSecIndexadaSecundaria = new List<Fk>(); //lista para la clave 2
            listBufReg = new List<string>(); //lista para datos de los registros
            listBufAtrib = new List<string>(); //lista para datos de los atributos
            entidades = new List<Entidad>(); //lista de las entidades 
            atributos = new List<Atributo>(); //lista de los atributos
            nodos = new List<Nodo>(); //lista de los nodos
            apts = new List<long>(); //lista de apuntadores para entidades
            listaApsts2 = new List<List<long>>(); //lista de apuntadores para entidades
            listaNomEntidades = new List<string>(); //lista de nombres de entidades para ordenar
            metaRegs = new List<MetaReg>(); //lista para la captura de los metadatos del registro
            
            comboTipo.Items.Add("E");
            comboTipo.Items.Add("C");
            comboCL.Items.Add("0");
            comboCL.Items.Add("1");
            comboCL.Items.Add("2");
            comboCL.Items.Add("3");
            comboCL.Items.Add("4");
            comboCL.Items.Add("5");
            this.Text = "Diccionario de Datos> JJ Amaya";
            //inhabilitar los botones entidades
            nuevoEntid.Enabled = modificarEntid.Enabled = eliminarEntid.Enabled = deshacerEntid.Enabled = false;
            nuevoAtrib.Enabled = modificarAtrib.Enabled = eliminarAtrib.Enabled = deshacerAtrib.Enabled = false;
            agregarReg.Enabled = modificarReg.Enabled = eliminarReg.Enabled = consultaReg.Enabled = false;
            cerrarArch.Enabled = false;
        }

        private void nuevoArch_Click(object sender, EventArgs e)
        {
            nombreArchivo = textNomArch.Text; //obtener el nombre del fichero
            textNomArch.Clear(); //limpio el nombre del archivo            
            if (string.IsNullOrEmpty(nombreArchivo)) //validacion de la entrada de nuevo
            {
                MessageBox.Show("Debe ingresar un nombre para el archivo.");
                return;
            }
            if (File.Exists(nombreArchivo)) //verificar si el fichero existe
            {
                MessageBox.Show("El archivo ya existe");
                return;
            }
                
            else
            {
                crearArchivo(nombreArchivo);
                nuevoEntid.Enabled = cerrarArch.Enabled = true;
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
                nuevoEntid.Enabled = true;
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

        private void abrirArch_Click(object sender, EventArgs e)
        {
            nombreArchivo = textNomArch.Text; //obtener el nombre del fichero
            textNomArch.Clear(); //limpia el textBox
            if (string.IsNullOrEmpty(nombreArchivo))
            {
                MessageBox.Show("Debe ingresar el nombre de archivo existente."); //validacion de la entrada abrir
                return;
            }
            try
            {
                if (File.Exists(nombreArchivo))
                {
                    this.Text = nombreArchivo;
                    fs = new FileStream(nombreArchivo, FileMode.Open);
                    br = new BinaryReader(fs);
                    fs.Position = 0;
                    if (br.ReadInt64() == -1) //lee la cabecera
                    {
                        MessageBox.Show("Archivo vacío");
                        nuevoEntid.Enabled = true;
                    }
                    else
                    {
                        cargaEntidades();
                        cargaAtributos();
                    }
                    br.Close();
                    fs.Close();
                }
                else
                    MessageBox.Show("El archivo no existe");
            }
            finally
            {
                if (br != null) br.Close();
            }
        }

        private void cargaEntidades()
        {

        }

        private void cargaAtributos()
        {

        }

        private void nuevoEntid_Click(object sender, EventArgs e)
        { 
            temporalEnt = new Entidad(); 
            int textoTam = textNomEntid.TextLength;
            string nameEntidad = textNomEntid.Text;
            if (string.IsNullOrEmpty(nameEntidad)) //validacion de la entrada de entidad
            {
                MessageBox.Show("Debe ingresar un nombre para la nueva entidad");
                return;
            }
            //index me dice si el nombre ya se encuentra en el comboBox
            int index = comboEntidad.FindStringExact(nameEntidad);
            if (index == -1) //-1 si no se encuentra, lo agrega
            {
                comboEntidad.Items.Add(nameEntidad);
                comboEntidad2.Items.Add(nameEntidad); //aqui se agrega el nombre a la lista para registros
                if (textoTam != 29) //si la cadena es menor a 29: rellenar
                {
                    for (int i = 0; i < (29 - textoTam); i++)
                        nameEntidad += " ";
                }
                fs = new FileStream(nombreArchivo, FileMode.Open);
                bw = new BinaryWriter(fs);
                br = new BinaryReader(fs);
                temporalEnt.nombre = nameEntidad;
                //temporalEnt.dir_entidad = (long)8 + temporalEnt.pesoEntidad * contOrden++;
                temporalEnt.dir_entidad = fs.Length;
                temporalEnt.dir_datos = (long)-1;
                temporalEnt.dir_atributos = (long)-1;
                temporalEnt.dir_sig_entidad = (long)-1;

                entidades.Add(temporalEnt); //aqui se agrega el temporal a la lista de entidades
                listaNomEntidades.Add(temporalEnt.nombre); //aqui se agrega a la lista los nombres
                apts.Add(temporalEnt.dir_entidad); //aqui se agregan los apuntadores
                setApuntadoresSig(); //define el orden de las entidades y cabecera
                escribeEntidades(); //escribe en el archivo las entidades actualizadas
                apts2 = new List<long>(); //se crea una lista para almacenar los apuntadores de los atributos
                                          //correspondientes a dicha entidad  
                listaApsts2.Add(apts2); //se agrega a la lista de atributos
                imprimir();
                fs.Close();
                bw.Close();
                br.Close();
                modificarEntid.Enabled = eliminarEntid.Enabled = deshacerEntid.Enabled = true;
                nuevoAtrib.Enabled = true;
            }
            else
               MessageBox.Show("La entidad ya existe, no se puede crear.");
            textNomEntid.Clear();
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
                    MessageBox.Show("cab " + cab);
                }


                if (i != listaNomEntidades.Count - 1)
                    entidades[search(listaNomEntidades[i])].dir_sig_entidad = entidades[search(listaNomEntidades[i + 1])].dir_entidad;
                else
                    entidades[search(listaNomEntidades[i])].dir_sig_entidad = (long)-1;
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
                string[] row = {br.ReadString(), br.ReadInt64().ToString(), br.ReadInt64().ToString(),
                                br.ReadInt64().ToString(), br.ReadInt64().ToString()};
                dataGridEntidades.Rows.Add(row); //se agregan los renglones a la dataGrid 
            }
            modificarEntid.Enabled = eliminarEntid.Enabled = true; //habilita los botones
        }

        //elimina la ultima entidad agregada
        private void deshacerEntid_Click(object sender, EventArgs e) 
        {
            fs = new FileStream(nombreArchivo, FileMode.Open);
            bw = new BinaryWriter(fs);
            br = new BinaryReader(fs);
            string nameEntidad = comboEntidad.Text;
            int textoTam = nameEntidad.Length;
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int iE = search(nameEntidad); //indice de los atributos correspondientes a dicha entidad

            string cNom = comboEntidad.Items[comboEntidad.Items.Count - 1].ToString();
            string cNomAux = cNom;
            int tamcNom = cNomAux.Length;
            //MessageBox.Show("cNom " + cNom);
            //MessageBox.Show("cNom.Length " + cNom.Length);
            comboEntidad.Items.RemoveAt(comboEntidad.Items.Count - 1); //elimina el ultimo item del comboBox de entidades
            comboEntidad2.Items.RemoveAt(comboEntidad2.Items.Count - 1); //elimina el ultimo item del comboBox de registros
            if (tamcNom != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - tamcNom); i++)
                    cNom += " ";
            }
            //**
            for (int i = 0; i < listaApsts2[entidades.Count - 1].Count; i++) //ciclo que obtiene cada atributo
            {
                int iA = search2((int)listaApsts2[entidades.Count - 1][i]); //indice en la lista de atributos de dicho apt
                atributos.RemoveAt(iA);
            }

            apts.RemoveAt(apts.Count - 1); //remover el ultimo apuntador
            
            listaNomEntidades.Remove(cNom); //remover el ultimo nombre
            MessageBox.Show("Ultima entidad removida");
            listaApsts2.RemoveAt(entidades.Count - 1); //remueve la lista completa de atributos
            entidades.RemoveAt(entidades.Count - 1); //remover de la lista la ultima entidad
            dataGridEntidades.Rows.RemoveAt(entidades.Count - dataGridEntidades.CurrentRow.Index); //eliminacion de la ultima datagrid entidad agregada
            if (listaApsts2.Count == 0) //reinicia los controles de atributos
            {
                nuevoAtrib.Enabled = modificarAtrib.Enabled = deshacerAtrib.Enabled = eliminarAtrib.Enabled = false;
                dataGridAtributos.Rows.Clear();
            }

            if (entidades.Count == 1) //si queda una entidad limpiar apt_sig_entidad
                entidades[0].dir_sig_entidad = (long)-1;
            if (entidades.Count > 1)
                entidades[entidades.Count - 1].dir_sig_entidad = (long)-1; //limpia el apuntador sig de la ultima entidad
            if (entidades.Count == 0) //si no quedan entidades limpiar cabecera
            {
                fs.Position = (long)0;
                bw.Write((long)-1);
                dataGridEntidades.Rows.Clear(); //limpia toda la dataGrid
            }
            else
            {
                setApuntadoresSig(); //define el orden de las entidades y cabecera
                escribeEntidades(); //escribe en el archivo las entidades actualizadas
                imprimir(); //actualiza la dataGrid
                imprimir2(iE);
                //modificarAtrib.Enabled = eliminarAtrib.Enabled = true;
            }
            if (entidades.Count == 0)
            {
                eliminarEntid.Enabled = modificarEntid.Enabled = deshacerEntid.Enabled = false;
                modificarAtrib.Enabled = eliminarAtrib.Enabled = false;
            }
            imprimir();
            fs.Close();
            bw.Close();
            br.Close();
            deshacerEntid.Enabled = false;
        }

        private void eliminarEntid_Click(object sender, EventArgs e)
        {
            int textoTam = textNomEntid.TextLength; //obtiene el nombre de la entidad a eliminar
            string nameEntidad = textNomEntid.Text;
            string nombEntid = nameEntidad;
            int resp = -1;
            string nameEntidad2 = comboEntidad.Text;
            int textoTam2 = nameEntidad.Length;
            if (textoTam2 != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam2); i++)
                    nameEntidad2 += " ";
            }
            int iE = search(nameEntidad2); //indice de los atributos correspondientes a dicha entidad


            fs = new FileStream(nombreArchivo, FileMode.Open);
            bw = new BinaryWriter(fs);
            br = new BinaryReader(fs);
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            for (int i = 0; i < entidades.Count; i++) //ciclo para buscar el nombre de la entidad 
            {
                if (nameEntidad.Equals(entidades[i].nombre, StringComparison.Ordinal)) //condicion de igualdad strings
                {
                    //**
                    for (int x = 0; x < listaApsts2[i].Count; x++) //ciclo que obtiene cada atributo
                    {
                        int iA = search2((int)listaApsts2[i][x]); //indice en la lista de atributos de dicho apt
                        atributos.RemoveAt(iA);
                    }


                    comboEntidad.Items.Remove(nombEntid); //elimina el item del comboBox de entidades
                    comboEntidad2.Items.Remove(nombEntid); //elimina el item del comboBox de registros
                    apts.Remove(entidades[i].dir_entidad); //remover el apuntador
                    listaNomEntidades.Remove(entidades[i].nombre); //remover el nombre
                    MessageBox.Show("Entidad removida : " + entidades[i].nombre); 
                    entidades.RemoveAt(i); //remover de la lista entidades
                    listaApsts2.RemoveAt(i); //remueve la lista completa de atributos
                    if (listaApsts2.Count == 0) //reinicia los controles de atributos
                        nuevoAtrib.Enabled = modificarAtrib.Enabled = deshacerAtrib.Enabled = eliminarAtrib.Enabled = false;
                    dataGridEntidades.Rows.RemoveAt(i); //eliminacion de la datagrid entidad
                    textNomEntid.Clear(); //limpia el textB donde se ingreso el nombre de la entidad
                    if (entidades.Count == 1) //si queda una entidad limpiar apt_sig_entidad
                        entidades[0].dir_sig_entidad = (long)-1;
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
                //modificarAtrib.Enabled = eliminarAtrib.Enabled = true;
            }
            if (entidades.Count == 0)
            {
                eliminarEntid.Enabled = modificarEntid.Enabled = deshacerEntid.Enabled = false;
                modificarAtrib.Enabled = eliminarAtrib.Enabled = false;
            }
            fs.Close();
            bw.Close();
            br.Close();
        }

        private void modificarEntid_Click(object sender, EventArgs e)
        {
            modificar = new Form2();
            modificar.Cancelar.Click += Cancelar_Click1;
            modificar.Aceptar.Click += Aceptar_Click1;
            modificar.Show();
        }

        private void Aceptar_Click1(object sender, EventArgs e)
        {
            string nuevoNom = modificar.textNomNuevoEntid.Text;
            string nuevoNom2 = nuevoNom;
            int nuevoNomTam = nuevoNom.Length;
            int textoTam = textNomEntid.TextLength;
            string nameEntidad = textNomEntid.Text;
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
                textNomEntid.Clear();
                modificar.Close();
                MessageBox.Show("Una entidad ya esta asignada con ese nombre");
                return;
            }

            if (string.IsNullOrEmpty(nameEntidad)) //validacion de la entrada de entidad
            {
                MessageBox.Show("Debe ingresar el nombre para la entidad");
                textNomEntid.Clear();
                modificar.Close();
                return;
            }

            if (string.IsNullOrEmpty(nuevoNom)) //validacion de la entrada de nuevo nombre entidad
            {
                MessageBox.Show("Debe ingresar el nuevo nombre para la entidad");
                modificar.Close();
                return;
            }
            iE = search(nameEntidad);
            if (entidades[iE].atributos || entidades[iE].registros)
            {
                MessageBox.Show("La entidad no se puede modificar");
                textNomEntid.Clear();
                modificar.Close();
                return;
            }
            if (iE == -1)
            {
                MessageBox.Show("El nombre de la entidad no se encuentra");
                textNomEntid.Clear();
                modificar.Close();
                return;
            }
            else
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                bw = new BinaryWriter(fs);
                br = new BinaryReader(fs);
                /*if (nuevoNomTam != 29) //si la cadena es menor a 29: rellenar
                {
                    for (int i = 0; i < (29 - nuevoNomTam); i++)
                        nuevoNom += " ";
                }*/
                
                string aux = entidades[iE].nombre;             
                entidades[iE].nombre = nuevoNom;

                for (int t = 0; t < listaNomEntidades.Count; t++)
                {
                    if (aux.Equals(listaNomEntidades[t], StringComparison.Ordinal))
                        indexNomEntid = t;
                }
                listaNomEntidades[indexNomEntid] = nuevoNom;
                //comboEntidad.Items.RemoveAt(iE);
                //comboEntidad.Items.Add(nuevoNom2);

                comboEntidad.Items[iE] = nuevoNom2;

                //comboEntidad2.Items.RemoveAt(iE);
                //comboEntidad2.Items.Add(nuevoNom2);
                comboEntidad2.Items[iE] = nuevoNom2;

                setApuntadoresSig();
                escribeEntidades();
                imprimir();
                deshacerEntid.Enabled = false;
                fs.Close();
                br.Close();
                bw.Close();
            }
            textNomEntid.Clear();
            modificar.Close();
        }

        private void Cancelar_Click1(object sender, EventArgs e)
        {
            modificar.Close();
        }

        private void nuevoAtrib_Click(object sender, EventArgs e)
        {
            agregarReg.Enabled = true;
            numericLong.Enabled = true;
            string entidadSelect;
            temporalAtrib = new Atributo();
            int textoTam = textNomAtrib.TextLength;
            int iE = comboEntidad.SelectedIndex;

            ie = iE;

            string nameAtrib = textNomAtrib.Text;
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
            char tipo = comboTipo.SelectedItem.ToString()[0];
            if (tipo == 'E')
                temporalAtrib.longitud = 4;
            else
                temporalAtrib.longitud = Convert.ToInt32(numericLong.Text);
            temporalAtrib.nombre = nameAtrib;
            temporalAtrib.tipo = tipo;
            fs = new FileStream(nombreArchivo, FileMode.Open);
            bw = new BinaryWriter(fs);
            br = new BinaryReader(fs);
            temporalAtrib.dir_atrib = fs.Length;
            int indice = Convert.ToInt32(comboCL.SelectedItem.ToString());
            temporalAtrib.tipo_indice = indice;
            temporalAtrib.dir_indice = (long)-1;
            temporalAtrib.dir_sig_atrib = (long)-1;
            entidadSelect = comboEntidad.Text;
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

            textNomAtrib.Clear(); //limpia el nombre del atributo
            comboEntidad.ResetText(); //limpia la lista de las entidades
            comboTipo.ResetText(); //limpia el tipo del atributo
            comboCL.ResetText(); //limpia la clave o llave
            if (numericLong.Value != 1)
                numericLong.Value = 1; //establece el valor predeterminado
            imprimir();
            imprimir2(iE);
            //modificarAtrib.Enabled = eliminarAtrib.Enabled = deshacerAtrib.Enabled = true;
            fs.Close();
            bw.Close();
            br.Close();
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
            //for (int i = 0; i < listaApsts2.Count; i++)
            //{
                for (int w = 0; w < listaApsts2[ie].Count; w++)
                {
                    fs.Position = listaApsts2[ie][w];
                    string[] row2 = {br.ReadString(), br.ReadChar().ToString(), br.ReadInt32().ToString(),
                                br.ReadInt64().ToString(), br.ReadInt32().ToString(),  br.ReadInt64().ToString(),
                                br.ReadInt64().ToString()};
                    dataGridAtributos.Rows.Add(row2); //se agregan los renglones a la dataGrid
                }
            //}
            modificarAtrib.Enabled = eliminarAtrib.Enabled = true;
        }

        private void escribeAtributos()
        {
            int iA = -1;
            //int cont = 0;
            /*for (int i = 0; i < listaApsts2.Count; i++)
            {
                for (int w = 0; w < listaApsts2[i].Count; w++)
                {
                    fs.Position = listaApsts2[i][w];
                    bw.Write(atributos[cont].nombre);
                    bw.Write(atributos[cont].tipo);
                    bw.Write(atributos[cont].longitud);
                    bw.Write(atributos[cont].dir_atrib);
                    bw.Write(atributos[cont].tipo_indice);
                    bw.Write(atributos[cont].dir_indice);
                    bw.Write(atributos[cont].dir_sig_atrib);
                    cont++; 
                }
            }*/
            //int iE = comboEntidad.SelectedIndex; //indice de la entidad seleccionada
            for (int x = 0; x < listaApsts2.Count; x++)
            {
                for (int i = 0; i < listaApsts2[x].Count; i++)
                {
                    iA = search2((int)listaApsts2[x][i]);
                    fs.Position = atributos[iA].dir_atrib;
                    bw.Write(atributos[iA].nombre);
                    bw.Write(atributos[iA].tipo);
                    bw.Write(atributos[iA].longitud);
                    bw.Write(atributos[iA].dir_atrib);
                    bw.Write(atributos[iA].tipo_indice);
                    bw.Write(atributos[iA].dir_indice);
                    bw.Write(atributos[iA].dir_sig_atrib);
                }
            }
            
        }

        private void modificarAtrib_Click(object sender, EventArgs e)
        {
            modificar = new Form2();
            modificar.Cancelar.Click += Cancelar_Click2;
            modificar.Aceptar.Click += Aceptar_Click2;
            modificar.Show();
        }

        private void Aceptar_Click2(object sender, EventArgs e)
        {
            string nuevoNom = modificar.textNomNuevoEntid.Text;
            string nuevoNom2 = nuevoNom;
            int nuevoNomTam = nuevoNom.Length;
            string nameAtrib = textNomAtrib.Text;
            int textoTam = textNomAtrib.TextLength;
            int iE = -1;
            iE = comboEntidad.SelectedIndex;
            if (iE == -1)
            {
                MessageBox.Show("Debe seleccionar la entidad del atributo");
                modificar.Close();
                return;
            }
            else
            {
                if (entidades[iE].registros)
                {
                    MessageBox.Show("No se puede modificar el atributo");
                    modificar.Close();
                    return;
                }
            }
            if (string.IsNullOrEmpty(nameAtrib)) //validacion del nombre del atributo
            {
                MessageBox.Show("Debe ingresar el nombre para el atributo");
                modificar.Close();
                return;
            }
            if (string.IsNullOrEmpty(nuevoNom)) //validacion del nombre del atributo
            {
                MessageBox.Show("Debe ingresar el nuevo nombre para el nuevo atributo");
                modificar.Close();
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
            //modificarAtrib.Enabled = eliminarAtrib.Enabled = true;
            listaNomEntidades.Clear(); //reinicia la lista de nombres de entidades
            textNomAtrib.Clear(); //limpia el nombre del atributo
            fs.Close();
            bw.Close();
            br.Close();
            modificar.Close();
        }

        private void Cancelar_Click2(object sender, EventArgs e)
        {
            modificar.Close();
        }

        private void eliminarAtrib_Click(object sender, EventArgs e)
        {
            int textoAtribTam = textNomAtrib.TextLength; //tama;o a rellenar 
            string nameAtrib = textNomAtrib.Text; //obtiene el nombre del atributo a eliminar
            int iE = comboEntidad.SelectedIndex; //indice de la entidad seleccionada
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
                            entidades[iE].dir_atributos = (long)-1;
                        if (i == 0 && listaApsts2[iE].Count > 1) //condicion para quitar la liga de la entidad cuando queda un atributo
                            entidades[iE].dir_atributos = atributos[search2((int)listaApsts2[iE][i + 1])].dir_atrib;

                        if (i > 0 && listaApsts2[iE].Count > 2 && i != listaApsts2[iE].Count - 1) //condicion para atributo intermedio
                        {
                            atributos[search2((int)listaApsts2[iE][i - 1])].dir_sig_atrib = atributos[search2((int)listaApsts2[iE][i + 1])].dir_atrib;
                        }

                        if (i > 0 && listaApsts2[iE].Count > 2 && i == listaApsts2[iE].Count - 1) //condicion para el ultimo atributo
                        {
                            atributos[search2((int)listaApsts2[iE][i - 1])].dir_sig_atrib = (long)-1;
                        }

                        listaApsts2[iE].RemoveAt(i);
                        i2 = i;
                    }
                }
                //if (listaApsts2[iE].Count > 1 && i2 != 0) //condicion para quitar la liga del atributo eliminado
                //    atributos[index - 1].dir_sig_atrib = (long)-1;
                if (listaApsts2[iE].Count == 1) //condicion para cuando queda solo un atributo de la entidad
                    atributos[search2((int)listaApsts2[iE][0])].dir_sig_atrib = (long)-1;
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
                //modificarAtrib.Enabled = eliminarAtrib.Enabled = true;
                imprimir(); //muestra los cambios en entidades
            }
            if (atributos.Count == 0)
                eliminarAtrib.Enabled = modificarAtrib.Enabled = deshacerAtrib.Enabled = false;
            fs.Close();
            bw.Close();
            br.Close();
            textNomAtrib.Clear(); //limpia el nombre del atributo
            comboEntidad.ResetText(); //limpia la lista de las entidades
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

        //elimina el ultimo atributo registrado
        private void deshacerAtrib_Click(object sender, EventArgs e)
        {
            fs = new FileStream(nombreArchivo, FileMode.Open);
            bw = new BinaryWriter(fs);
            br = new BinaryReader(fs);
            int inde = -1;
            for (int i = 0; i < listaApsts2[ie].Count; i++)
            {
                if (i == listaApsts2[ie].Count - 1)
                {
                    MessageBox.Show("el atributo a borrar es " + atributos[search2((int)listaApsts2[ie][i])].nombre);
                    int iA = search2((int)listaApsts2[ie][i]);
                    //MessageBox.Show("iA " + iA);
                    listaApsts2[ie].Remove(atributos[iA].dir_atrib);
                    atributos.RemoveAt(iA);
                    inde = i;
                    dataGridAtributos.Rows.RemoveAt(atributos.Count - dataGridAtributos.CurrentRow.Index); //eliminacion de la ultima datagrid atrib agregada
                }
            }
            if (listaApsts2[ie].Count == 0)
            {
                entidades[ie].dir_atributos = (long)-1;
                escribeEntidades();
                imprimir();
            }
            else
            {
                int iA = search2((int)listaApsts2[ie][inde - 1]);
                atributos[iA].dir_sig_atrib = (long)-1;
                escribeAtributos();
                imprimir2(ie);
                //modificarAtrib.Enabled = eliminarAtrib.Enabled = true;
            }
            fs.Close();
            bw.Close();
            br.Close();
        }

        private void agregarReg_Click(object sender, EventArgs e)
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
                atrib.Location = new System.Drawing.Point(xP,yP);
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
            modificarReg.Enabled = eliminarReg.Enabled = true;
        }

        //permite guardar el registro introducido por el usuario
        private void Aceptar_Click(object sender, EventArgs e)
        {
            consultaReg.Enabled = true;
            int i = 0;
            long position = -1;
            List<string> numRepetidosPk = new List<string>();
            int repetidoPk = 0;
            int fuera = -1;
            List<string> numRepetidosHash = new List<string>();
            int repetidoH = 0;
            int fueraH = -1;
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
                listaHashGlobal.Clear();
                listaSecIndexadaSecundaria.Clear();
                listaContenidoNodo.Clear();
                ie2 = iE;
                bandDirec = true; //el directorio se vuelve a insetar si se cambia de entidad
                bandDirec2 = true; //el directorio se vuele a insertar si se cambia de entidad
                bandDirec3 = true; //el directorio se vuelve a insertar si se cambia de entidad
                bandCajonUno = true;
                bandCajonDos = true;
                bandCajonTres = true;
                cajonLlenoUno = false;
                cajonLlenoDos = false;
                cajonLlenoTres = false;
                gridUnoVacia = false;
                gridDosVacia = false;
                gridTresVacia = false;
                dataGridLlave1.Rows.Clear(); //llave primaria
                dataGridLlave2.Rows.Clear(); //llave secundaria
                //hash
                dataGridHashDir.Rows.Clear();
                dataGridHashUno.Rows.Clear();
                dataGridHashDos.Rows.Clear();
                dataGridHashTres.Rows.Clear();
            }
            
            for (int y = 0; y < metaRegs.Count; y++)
            {
                if (metaRegs[y].clave == 3) //organizacion secuencial ordenada
                {
                    entidades[iE].banSO = true;
                }
                //organizacion secuencial indexada

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

                if (metaRegs[y].clave == 4) //hash
                {
                    entidades[iE].bandHash = true;
                    //*******
                    listaHashGlobal.Add(metaRegs[y].text);
                    for (int q = 0; q < listaHashGlobal.Count; q++)
                    {
                        if (numRepetidosHash.Count > 0)
                        {
                            for (int t = 0; t < numRepetidosHash.Count; t++)
                            {
                                if (listaHashGlobal[q].Equals(numRepetidosHash[t]))
                                {
                                    repetidoH = 1;
                                    fueraH = q;
                                }
                            }
                            if (repetidoH == 0)
                                numRepetidosHash.Add(listaHashGlobal[q]);
                        }
                        else
                            numRepetidosHash.Add(listaHashGlobal[q]);
                    }
                    if (repetidoH != 0)
                    {
                        MessageBox.Show("Ya se a ingresado un registro con esa clave Hash");
                        repetidoH = 0;
                        numRepetidosHash.Clear();
                        listaHashGlobal.RemoveAt(fueraH);
                        return;
                    }
                    //*******
                }

                if (metaRegs[y].clave == 5) //arboles
                {
                    entidades[iE].banArbol = true;
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

            if (entidades[iE].bandHash)
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                bw = new BinaryWriter(fs);
                br = new BinaryReader(fs);
                position = escribeRegHash(position); //escribe reg dejando un directorio de indices para la funcion hash
                fs.Close();
                bw.Close();
                br.Close();

                fs = new FileStream(nombreArchivo, FileMode.Open);
                bw = new BinaryWriter(fs);
                br = new BinaryReader(fs);
                position = funcionModulo(position); //aqui se saca el modulo del valor del registro y se deja un cajon de 4 registros
                fs.Close();
                bw.Close();
                br.Close();
            }

            if (entidades[iE].banArbol)
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                bw = new BinaryWriter(fs);
                br = new BinaryReader(fs);
                position = nuevoNodo(position); //aqui se crea el primer nodo del arbol
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
            if (entidades[iE].banArbol)
            {
                llenaArbol();
                leeArbol();
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
            if (entidades[iE].bandHash)
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                bw = new BinaryWriter(fs);
                br = new BinaryReader(fs);
                if (!bandCajonUno && !cajonLlenoUno)
                {
                    escribeCajon1();
                    if (!gridUnoVacia)
                        leeCajon1();
                }
                if (!bandCajonDos && !cajonLlenoDos)
                {
                    escribeCajon2();
                    if (!gridDosVacia)
                        leeCajon2();
                }
                if (!bandCajonTres && !cajonLlenoTres)
                {
                    escribeCajon3();
                    if (!gridTresVacia)
                        leeCajon3();
                }
                fs.Close(); //cierre del archivo 
                bw.Close(); //cierre del flujo
                br.Close();
            }
            metaRegs.Clear(); //se limpia la lista de metadatos de los registro
        }

        private void llenaArbol()
        {
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            long position = -1;
            List<string> listaArbol = new List<string>();
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int iE = search(nameEntidad); //indice de los atributos correspondientes a dicha entidad
            for (int i = 0; i < listaApsts2[iE].Count; i++) //ciclo que obtiene cada atributo
            {
                int iA = search2((int)listaApsts2[iE][i]); //indice en la lista de atributos de dicho apt
                if (atributos[iA].tipo_indice == 5)
                {
                    position = atributos[iA].dir_indice;
                    fs.Position = position;
                    for (int x = 0; x < dataGridRegistros.Rows.Count - 1; x++)
                    {
                        listaArbol.Add(dataGridRegistros.Rows[x].Cells[i + 1].Value.ToString());
                    }
                    listaArbol.Sort();
                    for (int p = 0; p < listaArbol.Count; p++)
                    {

                    }
                }
            }
        }

        private void leeArbol()
        {

        }

        private long nuevoNodo(long pos)
        {
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;

            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int iE = search(nameEntidad);

            long posicion = -1;

            if (pos == -1)
                posicion = fs.Length;
            else
                posicion = pos;

            for (int i = 0; i < listaApsts2[iE].Count; i++)
            {
                int iA = search2((int)listaApsts2[iE][i]); //indice en la lista de atributos de dicho apt
                if (atributos[iA].tipo_indice == 5 && atributos[iA].dir_indice == -1)
                {
                    atributos[iA].dir_indice = posicion;
                    
                    MessageBox.Show("Se inserto el primer nodo del arbol");

                    Nodo nodo = new Nodo(); //estructura del nodo

                    nodo.dir_nodo = posicion;
                    nodo.tipo = 'H';

                    nodo.apt1 = (long)-1;
                    nodo.val1 = -1;

                    nodo.apt2 = (long)-1;
                    nodo.val2 = -1;

                    nodo.apt3 = (long)-1;
                    nodo.val3 = -1;

                    nodo.apt4 = (long)-1;
                    nodo.val4 = -1;

                    nodo.dir_nodo_sig = (long)-1;
                    
                    escribeNodo(nodo, posicion);
                }
            }
            posicion = posicion + (long)65; //espacio para el primer nodo
            return posicion;
        }

        private void escribeNodo(Nodo nodoAux, long pos)
        {
            fs.Position = pos;
            bw.Write(nodoAux.dir_nodo);
            bw.Write(nodoAux.tipo);
            bw.Write(nodoAux.apt1);
            bw.Write(nodoAux.val1);

            bw.Write(nodoAux.apt2);
            bw.Write(nodoAux.val2);

            bw.Write(nodoAux.apt3);
            bw.Write(nodoAux.val3);

            bw.Write(nodoAux.apt4);
            bw.Write(nodoAux.val4);

            bw.Write(nodoAux.dir_nodo_sig);
        }

        //esta funcion escribe en el cajon uno los datos correspondientes
        private void escribeCajon1()
        {
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            int entero = 0;
            int modulo = 0;
            char tipoDato = ' ';
            long dirDirectorio;
            long dirCajon;
            string cadena = "";
            int contCajon = 0;
            List<string> listaCajonUno = new List<string>();
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int index = search(nameEntidad);
            for (int i = 0; i < listaApsts2[index].Count; i++)
            {
                int iA = search2((int)listaApsts2[index][i]); //indice en la lista de atributos de dicho apt
                if (atributos[iA].tipo_indice == 4)
                {
                    dirDirectorio = atributos[iA].dir_indice;
                    fs.Position = dirDirectorio;
                    dirCajon = br.ReadInt64();
                    if (dirCajon == -1)
                        return;
                    fs.Position = dirCajon;
                    tipoDato = atributos[iA].tipo;                    
                    for (int x = 0; x < dataGridRegistros.Rows.Count - 1; x++)
                    {
                        //MessageBox.Show(dataGridRegistros.Rows[x].Cells[iA + 1].Value.ToString());
                        listaCajonUno.Add(dataGridRegistros.Rows[x].Cells[i + 1].Value.ToString());
                    }
                    for (int p = 0; p < listaCajonUno.Count; p++)
                    {
                        if (atributos[iA].tipo == 'C')
                        {
                            if (contCajon < 4)
                            {
                                string auxString = listaCajonUno[p];
                                for (int w = 0; w < auxString.Length; w++)
                                {
                                    char myChar = auxString[w];
                                    if (myChar != ' ')
                                        entero += myChar;
                                }
                                modulo = (entero % 3);
                                if (modulo == 0)
                                {
                                    cadena = listaCajonUno[p];
                                    bw.Write(cadena);
                                    for (int w = 0; w < dataGridRegistros.Rows.Count - 1; w++)
                                    {
                                        if (cadena.Equals(dataGridRegistros.Rows[w].Cells[i + 1].Value.ToString(), StringComparison.Ordinal))
                                        {
                                            long aux = Int64.Parse(dataGridRegistros.Rows[w].Cells[0].Value.ToString());
                                            bw.Write(aux);
                                            contCajon++;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("El cajon uno esta lleno");
                                cajonLlenoUno = true;

                                DataGridViewTextBoxColumn column;
                                column = new DataGridViewTextBoxColumn();
                                column.HeaderText = "Dat";
                                column.Width = 50;
                                dataGridHashUno.Columns.Add(column);

                                column = new DataGridViewTextBoxColumn();
                                column.HeaderText = "Dir1";
                                column.Width = 50;
                                dataGridHashUno.Columns.Add(column);
                            }
                        }
                        else
                        {
                            if (contCajon < 4)
                            {
                                entero = Int32.Parse(listaCajonUno[p]);
                                cadena = listaCajonUno[p];
                                modulo = (entero % 3);
                                if (modulo == 0)
                                {
                                    bw.Write(entero);
                                    for (int w = 0; w < dataGridRegistros.Rows.Count - 1; w++)
                                    {
                                        if (cadena.Equals(dataGridRegistros.Rows[w].Cells[i + 1].Value.ToString(), StringComparison.Ordinal))
                                        {
                                            long aux = Int64.Parse(dataGridRegistros.Rows[w].Cells[0].Value.ToString());
                                            bw.Write(aux);
                                            contCajon++;
                                        }
                                    }
                                    /*if (contCajon == 0)
                                    {
                                        dataGridHashUno.Rows.Clear();
                                        return;
                                    }*/
                                }
                            }
                            else
                            {
                                MessageBox.Show("El cajon uno esta lleno");
                                cajonLlenoUno = true;

                                DataGridViewTextBoxColumn column;
                                column = new DataGridViewTextBoxColumn();
                                column.HeaderText = "Dat";
                                column.Width = 50;
                                dataGridHashUno.Columns.Add(column);

                                column = new DataGridViewTextBoxColumn();
                                column.HeaderText = "Dir1";
                                column.Width = 50;
                                dataGridHashUno.Columns.Add(column);
                            }
                        }
                        entero = 0;
                    }
                }
            }
            if (contCajon == 0)
            {
                dataGridHashUno.Rows.Clear();
                gridUnoVacia = true;
            }
            else
                gridUnoVacia = false;
            bw.Write((long)-1);
        }

        //esta funcion lee el contenido en el cajon uno
        private void leeCajon1()
        {
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            char tipoDato = ' ';
            long dirDirectorio;
            long dirCajon;
            long up;
            long aptAux;
            dataGridHashUno.Rows.Clear();
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int index = search(nameEntidad);
            for (int i = 0; i < listaApsts2[index].Count; i++)
            {
                int iA = search2((int)listaApsts2[index][i]); //indice en la lista de atributos de dicho apt
                if (atributos[iA].tipo_indice == 4)
                {
                    dirDirectorio = atributos[iA].dir_indice;
                    fs.Position = dirDirectorio;
                    dirCajon = br.ReadInt64();
                    if (dirCajon == -1)
                        return;
                    fs.Position = dirCajon;
                    tipoDato = atributos[iA].tipo;
                    if (tipoDato == 'E')
                    {
                        do
                        {
                            string[] row = { br.ReadInt32().ToString(), br.ReadInt64().ToString() };
                            dataGridHashUno.Rows.Add(row);
                            up = fs.Position;
                            aptAux = br.ReadInt64();
                            if (aptAux != -1)
                                fs.Position = up;
                        } while (aptAux != -1);
                    }
                    if (tipoDato == 'C')
                    {
                        do
                        {
                            string[] row = { br.ReadString(), br.ReadInt64().ToString() };
                            dataGridHashUno.Rows.Add(row);
                            up = fs.Position;
                            aptAux = br.ReadInt64();
                            if (aptAux != -1)
                                fs.Position = up;
                        } while (aptAux != -1);
                    }
                }
            }
        }

        //esta funcio escribe en el cajon dos los datos correspondientes
        private void escribeCajon2()
        {
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            int entero = 0;
            int modulo = 0;
            char tipoDato = ' ';
            long dirDirectorio;
            long dirCajon;
            string cadena = "";
            int contCajon = 0;
            List<string> listaCajonDos = new List<string>();
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int index = search(nameEntidad);
            for (int i = 0; i < listaApsts2[index].Count; i++)
            {
                int iA = search2((int)listaApsts2[index][i]); //indice en la lista de atributos de dicho apt
                if (atributos[iA].tipo_indice == 4)
                {
                    dirDirectorio = atributos[iA].dir_indice;
                    fs.Position = dirDirectorio;
                    dirCajon = br.ReadInt64();
                    dirCajon = br.ReadInt64();
                    if (dirCajon == -1)
                        return;
                    fs.Position = dirCajon;
                    tipoDato = atributos[iA].tipo;

                    for (int x = 0; x < dataGridRegistros.Rows.Count - 1; x++)
                    {
                        //MessageBox.Show(dataGridRegistros.Rows[x].Cells[iA + 1].Value.ToString());
                        listaCajonDos.Add(dataGridRegistros.Rows[x].Cells[i + 1].Value.ToString());
                    }
                    for (int p = 0; p < listaCajonDos.Count; p++)
                    {
                        if (atributos[iA].tipo == 'C')
                        {
                            if (contCajon < 4)
                            {
                                string auxString = listaCajonDos[p];
                                for (int w = 0; w < auxString.Length; w++)
                                {
                                    char myChar = auxString[w];
                                    if (myChar != ' ')
                                        entero += myChar;
                                }
                                modulo = (entero % 3);
                                if (modulo == 1)
                                {
                                    cadena = listaCajonDos[p];
                                    bw.Write(cadena);
                                    for (int w = 0; w < dataGridRegistros.Rows.Count - 1; w++)
                                    {
                                        if (cadena.Equals(dataGridRegistros.Rows[w].Cells[i + 1].Value.ToString(), StringComparison.Ordinal))
                                        {
                                            long aux = Int64.Parse(dataGridRegistros.Rows[w].Cells[0].Value.ToString());
                                            bw.Write(aux);
                                            contCajon++;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("El cajon dos esta lleno");
                                cajonLlenoDos = true;

                                DataGridViewTextBoxColumn column;
                                column = new DataGridViewTextBoxColumn();
                                column.HeaderText = "Dat";
                                column.Width = 50;
                                dataGridHashDos.Columns.Add(column);

                                column = new DataGridViewTextBoxColumn();
                                column.HeaderText = "Dir2";
                                column.Width = 50;
                                dataGridHashDos.Columns.Add(column);
                            }
                        }
                        else
                        {
                            if (contCajon < 4)
                            {
                                entero = Int32.Parse(listaCajonDos[p]);
                                cadena = listaCajonDos[p];
                                modulo = (entero % 3);
                                if (modulo == 1)
                                {
                                    bw.Write(entero);
                                    for (int w = 0; w < dataGridRegistros.Rows.Count - 1; w++)
                                    {
                                        if (cadena.Equals(dataGridRegistros.Rows[w].Cells[i + 1].Value.ToString(), StringComparison.Ordinal))
                                        {
                                            long aux = Int64.Parse(dataGridRegistros.Rows[w].Cells[0].Value.ToString());
                                            bw.Write(aux);
                                            contCajon++;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("El cajon dos esta lleno");
                                cajonLlenoDos = true;

                                DataGridViewTextBoxColumn column;
                                column = new DataGridViewTextBoxColumn();
                                column.HeaderText = "Dat";
                                column.Width = 50;
                                dataGridHashDos.Columns.Add(column);

                                column = new DataGridViewTextBoxColumn();
                                column.HeaderText = "Dir2";
                                column.Width = 50;
                                dataGridHashDos.Columns.Add(column);
                            }
                                
                        }
                        entero = 0;
                    }
                }
            }
            if (contCajon == 0)
            {
                dataGridHashDos.Rows.Clear();
                gridDosVacia = true;
            }
            else
                gridDosVacia = false;
            bw.Write((long)-1);
        }

        //esta funcion lee el contenido del cajon dos
        private void leeCajon2()
        {
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            char tipoDato = ' ';
            long dirDirectorio;
            long dirCajon;
            long up;
            long aptAux;
            dataGridHashDos.Rows.Clear();
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int index = search(nameEntidad);
            for (int i = 0; i < listaApsts2[index].Count; i++)
            {
                int iA = search2((int)listaApsts2[index][i]); //indice en la lista de atributos de dicho apt
                if (atributos[iA].tipo_indice == 4)
                {
                    dirDirectorio = atributos[iA].dir_indice;
                    fs.Position = dirDirectorio;
                    dirCajon = br.ReadInt64();
                    dirCajon = br.ReadInt64();
                    if (dirCajon == -1)
                        return;
                    fs.Position = dirCajon;
                    tipoDato = atributos[iA].tipo;
                    if (tipoDato == 'E')
                    {
                        do
                        {
                            string[] row = { br.ReadInt32().ToString(), br.ReadInt64().ToString() };
                            dataGridHashDos.Rows.Add(row);
                            up = fs.Position;
                            aptAux = br.ReadInt64();
                            if (aptAux != -1)
                                fs.Position = up;
                        } while (aptAux != -1);
                    }
                    if (tipoDato == 'C')
                    {
                        do
                        {
                            string[] row = { br.ReadString(), br.ReadInt64().ToString() };
                            dataGridHashDos.Rows.Add(row);
                            up = fs.Position;
                            aptAux = br.ReadInt64();
                            if (aptAux != -1)
                                fs.Position = up;
                        } while (aptAux != -1);
                    }
                }
            }
        }

        //esta funcion escribe en el cajon tres los datos correspondientes
        private void escribeCajon3()
        {
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            int entero = 0;
            int modulo = 0;
            char tipoDato = ' ';
            long dirDirectorio;
            long dirCajon;
            string cadena = "";
            int contCajon = 0;
            List<string> listaCajonTres = new List<string>();
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int index = search(nameEntidad);
            for (int i = 0; i < listaApsts2[index].Count; i++)
            {
                int iA = search2((int)listaApsts2[index][i]); //indice en la lista de atributos de dicho apt
                if (atributos[iA].tipo_indice == 4)
                {
                    dirDirectorio = atributos[iA].dir_indice;
                    fs.Position = dirDirectorio;
                    dirCajon = br.ReadInt64();
                    dirCajon = br.ReadInt64();
                    dirCajon = br.ReadInt64();
                    if (dirCajon == -1)
                        return;
                    fs.Position = dirCajon;
                    tipoDato = atributos[iA].tipo;

                    for (int x = 0; x < dataGridRegistros.Rows.Count - 1; x++)
                    {
                        //MessageBox.Show(dataGridRegistros.Rows[x].Cells[iA + 1].Value.ToString());
                        listaCajonTres.Add(dataGridRegistros.Rows[x].Cells[i + 1].Value.ToString());
                    }
                    for (int p = 0; p < listaCajonTres.Count; p++)
                    {
                        if (atributos[iA].tipo == 'C')
                        {
                            if (contCajon < 4)
                            {
                                string auxString = listaCajonTres[p];
                                for (int w = 0; w < auxString.Length; w++)
                                {
                                    char myChar = auxString[w];
                                    if (myChar != ' ')
                                        entero += myChar;
                                }
                                modulo = (entero % 3);
                                if (modulo == 2)
                                {
                                    cadena = listaCajonTres[p];
                                    bw.Write(cadena);
                                    for (int w = 0; w < dataGridRegistros.Rows.Count - 1; w++)
                                    {
                                        if (cadena.Equals(dataGridRegistros.Rows[w].Cells[i + 1].Value.ToString(), StringComparison.Ordinal))
                                        {
                                            long aux = Int64.Parse(dataGridRegistros.Rows[w].Cells[0].Value.ToString());
                                            bw.Write(aux);
                                            contCajon++;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("El cajon tres esta lleno");
                                cajonLlenoTres = true;

                                DataGridViewTextBoxColumn column;
                                column = new DataGridViewTextBoxColumn();
                                column.HeaderText = "Dat";
                                column.Width = 50;
                                dataGridHashTres.Columns.Add(column);

                                column = new DataGridViewTextBoxColumn();
                                column.HeaderText = "Dir3";
                                column.Width = 50;
                                dataGridHashTres.Columns.Add(column);
                            }
                        }
                        else
                        {
                            if (contCajon < 4)
                            {
                                entero = Int32.Parse(listaCajonTres[p]);
                                cadena = listaCajonTres[p];
                                modulo = (entero % 3);
                                if (modulo == 2)
                                {
                                    bw.Write(entero);
                                    for (int w = 0; w < dataGridRegistros.Rows.Count - 1; w++)
                                    {
                                        if (cadena.Equals(dataGridRegistros.Rows[w].Cells[i + 1].Value.ToString(), StringComparison.Ordinal))
                                        {
                                            long aux = Int64.Parse(dataGridRegistros.Rows[w].Cells[0].Value.ToString());
                                            bw.Write(aux);
                                            contCajon++;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("El cajon tres esta lleno");
                                cajonLlenoTres = true;

                                DataGridViewTextBoxColumn column;
                                column = new DataGridViewTextBoxColumn();
                                column.HeaderText = "Dat";
                                column.Width = 50;
                                dataGridHashTres.Columns.Add(column);

                                column = new DataGridViewTextBoxColumn();
                                column.HeaderText = "Dir3";
                                column.Width = 50;
                                dataGridHashTres.Columns.Add(column);
                            }
                                
                        }
                        entero = 0;
                    }
                }
            }
            if (contCajon == 0)
            {
                dataGridHashTres.Rows.Clear();
                gridTresVacia = true;
            }
            else
                gridTresVacia = false;
            bw.Write((long)-1);
        }

        //esta funcion lee el contenido en el cajon tres
        private void leeCajon3()
        {
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            char tipoDato = ' ';
            long dirDirectorio;
            long dirCajon;
            long up;
            long aptAux;
            dataGridHashTres.Rows.Clear();
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int index = search(nameEntidad);
            for (int i = 0; i < listaApsts2[index].Count; i++)
            {
                int iA = search2((int)listaApsts2[index][i]); //indice en la lista de atributos de dicho apt
                if (atributos[iA].tipo_indice == 4)
                {
                    dirDirectorio = atributos[iA].dir_indice;
                    fs.Position = dirDirectorio;
                    dirCajon = br.ReadInt64();
                    dirCajon = br.ReadInt64();
                    dirCajon = br.ReadInt64();
                    if (dirCajon == -1)
                        return;
                    fs.Position = dirCajon;
                    tipoDato = atributos[iA].tipo;
                    if (tipoDato == 'E')
                    {
                        do
                        {
                            string[] row = { br.ReadInt32().ToString(), br.ReadInt64().ToString() };
                            dataGridHashTres.Rows.Add(row);
                            up = fs.Position;
                            aptAux = br.ReadInt64();
                            if (aptAux != -1)
                                fs.Position = up;
                        } while (aptAux != -1);
                    }
                    if (tipoDato == 'C')
                    {
                        do
                        {
                            string[] row = { br.ReadString(), br.ReadInt64().ToString() };
                            dataGridHashTres.Rows.Add(row);
                            up = fs.Position;
                            aptAux = br.ReadInt64();
                            if (aptAux != -1)
                                fs.Position = up;
                        } while (aptAux != -1);
                    }
                }
            }
        }

        //esta funcion solo sirve para dejar los espacios para los cajones y la actualizacion del directorio
        private long funcionModulo(long pos)
        {
            long position = -1;
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            int entero = 0;
            int modulo = 0;
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int index = search(nameEntidad);

            for (int i = 0; i < listaApsts2[index].Count; i++)
            {
                int iA = search2((int)listaApsts2[index][i]); //indice en la lista de atributos de dicho apt
                if (atributos[iA].tipo_indice == 4)
                {
                    if (atributos[iA].tipo == 'E') //se obtiene el modulo 3 de los numeros
                        entero = Int32.Parse(metaRegs[i].text);
                    if (atributos[iA].tipo == 'C') //se obtiene el modulo 3 del tama;o del texto escrito
                    {
                        string auxString = metaRegs[i].text;
                        for (int w = 0; w < auxString.Length; w++)
                        {
                            char myChar = auxString[w];
                            if (myChar != ' ')
                                entero += myChar;
                        }
                    }
                    modulo = (entero % 3);
                    if (modulo == 0 && bandCajonUno)
                    {
                        position = pos;
                        if (atributos[iA].tipo == 'E')
                            position = position + tamCajonHashInt;
                        if (atributos[iA].tipo == 'C')
                        {
                            long tamDirecHash2 = 0;
                            tamDirecHash2 = atributos[iA].longitud * 4 + 40;
                            position = position + tamDirecHash2;
                        }
                        bandCajonUno = false;
                        fs.Position = atributos[iA].dir_indice;
                        bw.Write(pos);
                    }

                    if (modulo == 1 && bandCajonDos)
                    {
                        position = pos;
                        if (atributos[iA].tipo == 'E')
                            position = position + tamCajonHashInt;
                        if (atributos[iA].tipo == 'C')
                        {
                            long tamDirecHash2 = 0;
                            tamDirecHash2 = atributos[iA].longitud * 4 + 40;
                            position = position + tamDirecHash2;
                        }
                        bandCajonDos = false;
                        fs.Position = atributos[iA].dir_indice + (long)8;
                        bw.Write(pos);
                    }

                    if (modulo == 2 && bandCajonTres) 
                    {
                        position = pos;
                        if (atributos[iA].tipo == 'E')
                        position = position + tamCajonHashInt;
                        if (atributos[iA].tipo == 'C')
                        {
                            long tamDirecHash2 = 0;
                            tamDirecHash2 = atributos[iA].longitud * 4 + 40;
                            position = position + tamDirecHash2;
                        }
                        bandCajonTres = false;
                        fs.Position = atributos[iA].dir_indice + (long)16;
                        bw.Write(pos);
                    }
                    //actualizacion del directorio de hash
                    dataGridHashDir.Rows.Clear();
                    fs.Position = atributos[iA].dir_indice;
                    string[] row = { br.ReadInt64().ToString(), br.ReadInt64().ToString(), br.ReadInt64().ToString() };
                    dataGridHashDir.Rows.Add(row);
                }    
            }
            return position;
        }

        private long escribeRegHash(long pos)
        {
            long position = -1;
            long escribe = -1;
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

            if (bandDirec3)
            {
                for (int i = 0; i < listaApsts2[index].Count; i++)
                {
                    int iA = search2((int)listaApsts2[index][i]); //indice en la lista de atributos de dicho apt
                    if (atributos[iA].tipo_indice == 4 && atributos[iA].dir_indice == -1)
                    {
                        atributos[iA].dir_indice = position;
                        escribe = atributos[iA].dir_indice;
                        position = position + tamDirecHash; //espacio para el directorio 
                        MessageBox.Show("Se inserto un directorio Hash");
                    }
                }
                bandDirec3 = false;
                fs.Position = escribe;
                bw.Write((long)-1);
                bw.Write((long)-1);
                bw.Write((long)-1);
            }
            return position;
        }

        //este metodo sirve para mostrar el directorio de indices clave primaria
        private void consulta2()
        {
            long position = -1;
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            char tipoDato = ' ';
            long aptAux = -1;
            //string[] aux;
            dataGridLlave1.Rows.Clear(); //limpia toda la dataGrid de llavePrimaria

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
            //for (int w = 0; w < listaSecIndexadaPrimaria.Count; w++)
            do
            {
                if (tipoDato == 'C')
                {
                    string[] row = { br.ReadString(), br.ReadInt64().ToString() };
                    //aux = row;
                    dataGridLlave1.Rows.Add(row);
                }

                if (tipoDato == 'E')
                {
                    string[] row = { br.ReadInt32().ToString(), br.ReadInt64().ToString() };
                    //aux = row;
                    dataGridLlave1.Rows.Add(row);
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
            int entero; //para guardar el text convertido en entero
            long aptAux = -1;
            int longitud = -1;
            string cadena = "";
            int repetido = 0;
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
                    {
                        //MessageBox.Show(dataGridRegistros.Rows[x].Cells[iA + 1].Value.ToString());
                        listaSecIndexadaPrimaria.Add(dataGridRegistros.Rows[x].Cells[i + 1].Value.ToString());

                        /*int q = listaSecIndexadaPrimaria.Count - 1;
                        if (numRepetidos.Count > 0)
                        {
                            for (int t = 0; t < numRepetidos.Count; t++)
                            {
                                if (listaSecIndexadaPrimaria[q].Equals(numRepetidos[t]))
                                    repetido = 1;
                                else
                                    repetido = 0;
                            }
                            if (repetido == 0)
                                numRepetidos.Add(listaSecIndexadaPrimaria[q]);
                        }
                        else
                            numRepetidos.Add(listaSecIndexadaPrimaria[q]);

                        if (repetido != 0)
                        {
                            MessageBox.Show("Ya se a ingresado un registro con esa clave Pk");
                            eliminacionSimpleReg2(iE);
                            if (entidades[iE].dir_datos != -1)
                                consulta();
                            return;
                        }*/
                        
                    }
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
            long positionIndice = -1;
            char tipoDato = ' ';
            int entero; //para guardar el text convertido en entero
            long aptAux = -1;
            int longitud = -1;
            string cellReg = "";
            string cadena = "";

            int adentro = 0;
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
                    {
                        //MessageBox.Show(dataGridRegistros.Rows[x].Cells[iA + 1].Value.ToString());
                        listaSecIndexadaSecundariaOrdenada.Add(dataGridRegistros.Rows[x].Cells[i + 1].Value.ToString());
                    }
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
            long positionIndice = -1;
            char tipoDato = ' ';
            int entero; //para guardar el text convertido en entero
            long aptAux = -1;
            int longitud = -1;
            string cellReg = "";
            string cadena = "";
            int longitudTotal = 0;
            long position = -1;
            int adentro = 0;
            int repetido = 0;

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
                    //longitud = atributos[iA].longitud;
                    for (int x = 0; x < dataGridRegistros.Rows.Count - 1; x++)
                    {
                        //MessageBox.Show(dataGridRegistros.Rows[x].Cells[iA + 1].Value.ToString());
                        listaSecOrdenada.Add(dataGridRegistros.Rows[x].Cells[i + 1].Value.ToString());
                    }
                    listaSecOrdenada.Sort();

                    for (int p = 0; p < listaSecOrdenada.Count; p++)
                    {
                        //if (atributos[iA].tipo == 'C')
                        //{
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
                        //}
                        //if (atributos[iA].tipo == 'E')
                        //{
                        //    cadena = listaSecOrdenada[p];
                        //}
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
                //fs.Position = fs.Length;
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
            //fs.Position = position;

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
            //fs.Position = fs.Length;
            if (position != -1)
                fs.Position = position;
            else
                fs.Position = fs.Length;
            aptI = fs.Position;

            bw.Write(aptI); //escritura de los apts (inicial)

            for (int i = 0; i < metaRegs.Count; i++)
            {
                tamReg += metaRegs[i].longitud; //suma de la longitud del registro
                //tamReg2 += metaRegs[i].longitud;
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
            //modificarAtrib.Enabled = eliminarAtrib.Enabled = true;
        }

        private void escribeNodo()
        {
            fs = new FileStream(nombreArchivo, FileMode.Open);
            bw = new BinaryWriter(fs);
            br = new BinaryReader(fs);
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;


            listaContenidoNodo.Sort();
            //fs.Position
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int index = search(nameEntidad);
            for (int i = 0; i < listaApsts2[index].Count; i++)
            {
                int iA = search2((int)listaApsts2[index][i]); //indice en la lista de atributos de dicho apt
                if (atributos[iA].tipo_indice == 5 && atributos[iA].dir_indice == -1)
                    atributos[iA].dir_indice = fs.Length;
            }



            MessageBox.Show("posicion");
        }

        private void consultaArbol()
        {

        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            reg.Close();
        }

        private void modificarReg_Click(object sender, EventArgs e)
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
                tB.Text = listBufReg[i+1];
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

            if (entidades[iE].bandHash)
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                bw = new BinaryWriter(fs);
                br = new BinaryReader(fs);
                escribeCajon1();
                if (!gridUnoVacia)
                    leeCajon1();

                escribeCajon2();
                if (!gridDosVacia)
                    leeCajon2();

                escribeCajon3();
                if (!gridTresVacia)
                    leeCajon3();

                fs.Close(); //cierre del archivo 
                bw.Close(); //cierre del flujo
                br.Close();
            }

            /*if (entidades[iE].banSO)
                escribeRegModificadoSecOrdenada();
            else
            {
                if (entidades[iE].banSIP)
                {
                    br = new BinaryReader(fs);
                    escribeRegModificado();
                    consulta();
                    fs.Close();
                    bw.Close();
                    br.Close();

                    for (int w = 0; w < listBufReg.Count; w++)
                    {
                        for (int d = 0; d < listaSecIndexadaPrimaria.Count; d++)
                        {
                            if (listBufReg[w].Equals(listaSecIndexadaPrimaria[d], StringComparison.Ordinal))
                            {
                                listaSecIndexadaPrimaria.RemoveAt(d);
                            }
                        }
                    }
                    //insertar el la lista al nuevo elemento
                    for (int t = 0; t < metaRegs.Count; t++)
                    {
                        if (metaRegs[t].clave == 1)
                        {
                            if (metaRegs[t].tipo == 'C')
                            {
                                string nameReg = metaRegs[t].text;
                                int tam = nameReg.Length;
                                if (tam < metaRegs[t].longitud - 1) //aqui rellenar la cadena hasta alcanzar la longitud especificada
                                {
                                    for (int w = 0; w < ((metaRegs[t].longitud - 1) - tam); w++)
                                        nameReg += " ";

                                    listaSecIndexadaPrimaria.Add(nameReg);
                                }
                                else
                                {
                                    if (tam == metaRegs[t].longitud - 1)
                                        listaSecIndexadaPrimaria.Add(nameReg);
                                }
                            }
                            else
                                listaSecIndexadaPrimaria.Add(metaRegs[t].text);
                        }
                    }
                    
                    fs = new FileStream(nombreArchivo, FileMode.Open);
                    bw = new BinaryWriter(fs);

                    escrituraIndicePrimario();
                    fs.Close(); //cierre del archivo 
                    bw.Close(); //cierre del flujo

                    fs = new FileStream(nombreArchivo, FileMode.Open);
                    br = new BinaryReader(fs);
                    consulta2();
                    fs.Close(); //cierre del archivo 
                    br.Close();
                }
                else
                {
                    if (entidades[iE].banSIS)
                    {
                        escribeRegModificado();
                        br = new BinaryReader(fs);
                        consulta();
                        fs.Close();
                        bw.Close();
                        br.Close();

                        fs = new FileStream(nombreArchivo, FileMode.Open);
                        bw = new BinaryWriter(fs);
                        escrituraIndiceSecundario();
                        fs.Close(); //cierre del archivo 
                        bw.Close(); //cierre del flujo

                        fs = new FileStream(nombreArchivo, FileMode.Open);
                        br = new BinaryReader(fs);
                        consulta3();
                        fs.Close(); //cierre del archivo 
                        br.Close();
                    }
                    else
                        escribeRegModificado();

                }
            }
                
            reg.Close(); //cierre de la forma
            if (!entidades[iE].banSIP && !entidades[iE].banSIS)
            {
                fs.Close();
                bw.Close();
            }

            fs = new FileStream(nombreArchivo, FileMode.Open);
            br = new BinaryReader(fs);
            consulta();
            fs.Close(); //cierre del archivo 
            br.Close();

            if (entidades[iE].banSO)
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                br = new BinaryReader(fs);
                bw = new BinaryWriter(fs);
                secuencialOrdenada(iE);
                fs.Close();
                br.Close();
                bw.Close();
            }*/
        }

        private void escribeRegModificadoSecOrdenada()
        {
            //MessageBox.Show("Registro de sec. ordenada");
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

        private void eliminarReg_Click(object sender, EventArgs e)
        {
            bool lectura = true;
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
                    dataGridLlave1.Rows.Clear();
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
                    dataGridLlave2.Rows.Clear();
                fs.Close(); //cierre del archivo 
                bw.Close(); //cierre del flujo
                br.Close();
            }

            if (entidades[iE].bandHash)
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                bw = new BinaryWriter(fs);
                br = new BinaryReader(fs);
                //if (!bandCajonUno && !cajonLlenoUno)
                //{
                    escribeCajon1();
                    if (!gridUnoVacia)
                        leeCajon1();
                //}
                //if (!bandCajonDos && !cajonLlenoDos)
                //{
                    escribeCajon2();
                    if (!gridDosVacia)
                        leeCajon2();
                //}
                //if (!bandCajonTres && !cajonLlenoTres)
                //{
                    escribeCajon3();
                    if (!gridTresVacia)
                        leeCajon3();
                //}
                fs.Close(); //cierre del archivo 
                bw.Close(); //cierre del flujo
                br.Close();
            }

            /*if (entidades[iE].banSO)
            {
                //MessageBox.Show("Entidad con clave de busqueda");
                long aptI = Convert.ToInt64(listBufReg[0]);
                long aptF = Convert.ToInt64(listBufReg[listBufReg.Count - 1]);
                int datos = tamReg + 8;
                bool bUnico = false;
                if (listaSecOrdenada.Count == 1)
                    bUnico = true;
                if (aptI == entidades[iE].dir_datos && !bUnico) //condicion para el primero
                {
                    fs.Position = entidades[iE].dir_datos;
                    long aptIAux = br.ReadInt64();
                    fs.Position = aptIAux + datos;
                    bw.Write((long)-1);
                    listaSecOrdenada.RemoveAt(0);
                    entidades[iE].dir_datos = search4(listaSecOrdenada[0]);
                    escribeEntidades();
                    imprimir();
                }
                else
                {
                    if (aptF == -1 && !bUnico) //condicion para el ultimo
                    {
                        listaSecOrdenada.RemoveAt(listaSecOrdenada.Count - 1);
                        fs.Position = search4(listaSecOrdenada[listaSecOrdenada.Count - 1]);
                        long aptIAux = br.ReadInt64();
                        fs.Position = aptIAux + datos;
                        bw.Write((long)-1);
                    }
                    else
                    {
                        if (aptI != entidades[iE].dir_datos && aptF != -1) //condicion para el de en medio
                        {
                            long aptFAux = 0;
                            long uP;
                            int index = 0;
                            fs.Position = aptI;
                            long aptIAux = br.ReadInt64();
                            fs.Position = aptIAux + datos;
                            bw.Write((long)-1);

                            fs.Position = entidades[iE].dir_datos;
                            aptIAux = br.ReadInt64();
                            do
                            {
                                index++;
                                fs.Position = aptIAux + datos;
                                aptFAux = br.ReadInt64();
                                uP = aptIAux + datos;
                                aptIAux = aptFAux;
                            } while (aptFAux != aptI);
                            fs.Position = uP;
                            bw.Write(aptF);
                            //MessageBox.Show("El elemento que se borra es " + listaSecOrdenada[index]);
                            listaSecOrdenada.RemoveAt(index);
                        }
                        else
                        {
                            if (bUnico) //condicion para el unico elemento
                            {
                                listaSecOrdenada.Clear();
                                entidades[iE].dir_datos = (long)-1;
                                escribeEntidades();
                                imprimir();
                                dataGridRegistros.Rows.Clear();
                                consultaReg.Enabled = false;
                            }
                        }
                    }
                }
            }
            else
            {
                if (entidades[iE].banSIP)
                {
                    eliminacionSimpleReg(iE);
                    
                    fs.Close();
                    bw.Close();
                    br.Close();

                    fs = new FileStream(nombreArchivo, FileMode.Open);
                    bw = new BinaryWriter(fs);

                    for (int w = 0; w < listBufReg.Count; w++)
                    {
                        for (int d = 0; d < listaSecIndexadaPrimaria.Count; d++)
                        {
                            if (listBufReg[w].Equals(listaSecIndexadaPrimaria[d], StringComparison.Ordinal))
                            {
                                listaSecIndexadaPrimaria.RemoveAt(d);
                            }
                        }
                        
                    }
                    if (listaSecIndexadaPrimaria.Count > 0)
                        escrituraIndicePrimario();
                    else
                    {
                        dataGridLlave1.Rows.Clear();
                        lectura = false;
                    }
                        

                    fs.Close(); //cierre del archivo 
                    bw.Close(); //cierre del flujo

                    if (lectura)
                    {
                        fs = new FileStream(nombreArchivo, FileMode.Open);
                        br = new BinaryReader(fs);
                        consulta2();
                        fs.Close(); //cierre del archivo 
                        br.Close();
                    }
                }
                else
                {
                    if (entidades[iE].banSIS) //eliminacion de un registro de clave secudaria
                    {
                        eliminacionSimpleReg(iE);
                        if (consultaReg.Enabled)
                            consulta();
                        else
                            dataGridRegistros.Rows.Clear();
                        fs.Close();
                        bw.Close();
                        br.Close();


                        if (consultaReg.Enabled)
                        {
                            fs = new FileStream(nombreArchivo, FileMode.Open);
                            bw = new BinaryWriter(fs);
                            escrituraIndiceSecundario();
                            fs.Close(); //cierre del archivo 
                            bw.Close(); //cierre del flujo

                            fs = new FileStream(nombreArchivo, FileMode.Open);
                            br = new BinaryReader(fs);
                            consulta3();
                            fs.Close(); //cierre del archivo 
                            br.Close();
                        }
                        else
                            dataGridLlave2.Rows.Clear();
                        
                    }
                    else
                        eliminacionSimpleReg(iE);

                }

            }
            if (consultaReg.Enabled && entidades[iE].banSIP)
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                br = new BinaryReader(fs);
                consulta();
                fs.Close(); //cierre del archivo 
                br.Close();
            }

            if (consultaReg.Enabled && !entidades[iE].banSIP && !entidades[iE].banSIS)
                consulta();

            fs.Close();
            br.Close();
            bw.Close();*/
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
                entidades[iE].dir_datos = (long)-1;
                escribeEntidades();
                imprimir();
                consultaReg.Enabled = false;
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

        private void consultaReg_Click(object sender, EventArgs e)
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
                dataGridLlave1.Rows.Clear();

            if (entidades[iE].banSIS && entidades[iE].registros)
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                br = new BinaryReader(fs);
                consulta3();
                fs.Close();
                br.Close();
            }
            else
                dataGridLlave2.Rows.Clear();

            if (entidades[iE].bandHash && entidades[iE].registros)
            {

                fs = new FileStream(nombreArchivo, FileMode.Open);
                bw = new BinaryWriter(fs);
                br = new BinaryReader(fs);

                for (int i = 0; i < listaApsts2[iE].Count; i++)
                {
                    int iA = search2((int)listaApsts2[iE][i]); //indice en la lista de atributos de dicho apt
                    if (atributos[iA].tipo_indice == 4)
                    {
                        dataGridHashDir.Rows.Clear();
                        fs.Position = atributos[iA].dir_indice;
                        string[] row = { br.ReadInt64().ToString(), br.ReadInt64().ToString(), br.ReadInt64().ToString() };
                        dataGridHashDir.Rows.Add(row); 
                    }
                }

                if (!bandCajonUno && !cajonLlenoUno)
                {
                    escribeCajon1();
                    if (!gridUnoVacia)
                        leeCajon1();
                }
                if (!bandCajonDos && !cajonLlenoDos)
                {
                    escribeCajon2();
                    if (!gridDosVacia)
                        leeCajon2();
                }
                if (!bandCajonTres && !cajonLlenoTres)
                {
                    escribeCajon3();
                    if (!gridTresVacia)
                        leeCajon3();
                }
                fs.Close(); //cierre del archivo 
                bw.Close(); //cierre del flujo
                br.Close();
            }
            else
            {
                dataGridHashDir.Rows.Clear();
                dataGridHashUno.Rows.Clear();
                dataGridHashDos.Rows.Clear();
                dataGridHashTres.Rows.Clear();
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
            int adentro = 0;
            int repetido = 0;
            List<string> numRepetidos = new List<string>();
            List<string> listaSecIndexadaSecundariaOrdenada = new List<string>();
            dataGridLlave2.Rows.Clear(); //limpia toda la dataGrid de llavePrimaria

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
                        //repetido = 0;
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
                                dataGridLlave2.Rows.Add(rowAux);
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
                                dataGridLlave2.Rows.Add(rowAux);
                            }
                        }
                        //Console.WriteLine("el numero de elementos es " + cont);
                        cont = 0;
                        //repetido = 0;
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

            //fs.Position = 133;
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
                //Console.WriteLine(fs.Position);
                aptFAux = br.ReadInt64();
                if (aptFAux != -1)
                    fs.Position = aptFAux;
                row.Cells[contRow + 1].Value = aptFAux;
                dataGridRegistros.Rows.Add(row);
            } while (aptFAux != -1);
        }

        private void cerrarArch_Click(object sender, EventArgs e)
        {
            //fs.Close();
            //bw.Close();
            this.Text = "Diccionario de Datos> JJ Amaya";
            eliminarEntid.Enabled = deshacerEntid.Enabled = modificarEntid.Enabled = nuevoEntid.Enabled = false;
            eliminarAtrib.Enabled = deshacerAtrib.Enabled = modificarAtrib.Enabled = false;
            comboEntidad.Items.Clear(); //para limpiar la lista cada que abro un archivo nuevo
            comboEntidad2.Items.Clear();

            comboEntidad.ResetText();
            comboEntidad2.ResetText();

            dataGridEntidades.Rows.Clear(); //limpiar las datagrid entidades
            dataGridAtributos.Rows.Clear(); //limpiar las datagrid atributos
            dataGridRegistros.Rows.Clear();

            //llave primaria
            dataGridLlave1.Rows.Clear(); //limpia las filas de la llave primaria
            listaSecIndexadaPrimariaGlobal.Clear(); //quita los elementos guardados en la lista de llave primaria
            bandDirec = true; //para habilitar la insercion de otro cajon

            //llave secundaria
            dataGridLlave2.Rows.Clear(); //limpia las filas de la llave secundaria
            listaSecIndexadaSecundaria.Clear(); //quita los elementos guardados en la lista de llave secundaria
            bandDirec2 = true; //para habilitar la insercion de otro cajon

            //hash
            dataGridHashDir.Rows.Clear(); //para limpiar el contenido de
            dataGridHashUno.Rows.Clear(); //para limpiar el contenido del cajon uno
            dataGridHashDos.Rows.Clear(); //para limpiar el contenido del cajon dos
            dataGridHashTres.Rows.Clear(); //para limpiar el contenido del cajon tres
            listaHashGlobal.Clear();
            bandDirec3 = true;
            bandCajonUno = true;
            bandCajonDos = true;
            bandCajonTres = true;
            cajonLlenoUno = false;
            cajonLlenoDos = false;
            cajonLlenoTres = false;
            gridUnoVacia = false;
            gridDosVacia = false;
            gridTresVacia = false;


            dataGridRegistros.Columns.Clear();
            apts.Clear(); //reinicia la lista de apuntadores
            apts2.Clear();
            listaNomEntidades.Clear();
            listaApsts2.Clear();
            entidades.Clear(); //reinicia la lista de entidades
            atributos.Clear();
            cab = -1;
            metaRegs.Clear();
            listaNomEntidades.Clear(); //reinicia la lista de nombres de entidades
            textNomAtrib.Clear(); //limpia el nombre del atributo
            comboEntidad.ResetText(); //limpia la lista de las entidades
            comboTipo.ResetText(); //limpia el tipo del atributo
            comboCL.ResetText(); //limpia la clave o llave
            numericLong.Value = 1; //establece el valor predeterminado
            //listaBufReg.Clear(); //limpia el buffer de los datos para los registros
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
    }
}