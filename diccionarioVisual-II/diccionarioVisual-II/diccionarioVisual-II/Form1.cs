using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

/*
 * **** Falta ****
 * Abrir un archivo.
 * Deshacer de atributos.
 * Eliminar atributo medio.
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

        List<long> apts;
        List<long> apts2; //lista de apuntadores para cada entidad
        List<List<long>> listaApsts2;
        List<string> listaNomEntidades;
        List<MetaReg> metaRegs;
        List<string> listBufReg;
        List<string> listaSecOrdenada;
        List<string> listaSecIndexadaPrimaria;
        List<string> listaContenidoNodo;
        long tamCajonPrimaria = 128;
        Form3 reg;
        Form2 modificar;
        int tamReg;
        long dirRaiz = -1;
        bool band = true;
        int ie2 = -1;
        string auxSecOrd;
        int ie; //para saber cual fue la ultima entidad para un nuevo atributo
        bool bandCajon = true;

        public Form1()
        {
            InitializeComponent();
            listaContenidoNodo = new List<string>(); //lista para ordenar cada nodo
            listaSecOrdenada = new List<string>(); //lista para la clave de busqueda 3
            listaSecIndexadaPrimaria = new List<string>(); //lista para la clave 1
            listBufReg = new List<string>(); //lista para datos de los registros
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
                imprimir2();
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
                imprimir2(); //actualiza la dataGrid
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
                entidades[iE].nombre = nuevoNom;
                listaNomEntidades[iE] = nuevoNom;
                comboEntidad.Items.RemoveAt(iE);
                comboEntidad.Items.Add(nuevoNom2);

                comboEntidad2.Items.RemoveAt(iE);
                comboEntidad2.Items.Add(nuevoNom2);
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
            imprimir2();
            modificarAtrib.Enabled = eliminarAtrib.Enabled = deshacerAtrib.Enabled = true;
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
        private void imprimir2()
        {
            dataGridAtributos.Rows.Clear(); //limpia toda la dataGrid de atributos
            for (int i = 0; i < listaApsts2.Count; i++)
            {
                for (int w = 0; w < listaApsts2[i].Count; w++)
                {
                    fs.Position = listaApsts2[i][w];
                    string[] row2 = {br.ReadString(), br.ReadChar().ToString(), br.ReadInt32().ToString(),
                                br.ReadInt64().ToString(), br.ReadInt32().ToString(),  br.ReadInt64().ToString(),
                                br.ReadInt64().ToString()};
                    dataGridAtributos.Rows.Add(row2); //se agregan los renglones a la dataGrid
                }
            }
            modificarAtrib.Enabled = eliminarAtrib.Enabled = true;
        }

        private void escribeAtributos()
        {
            int cont = 0;
            for (int i = 0; i < listaApsts2.Count; i++)
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
            imprimir2();
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
                        if (i > 0 && listaApsts2[iE].Count > 2)
                        {
                            Console.WriteLine(atributos[search2((int)listaApsts2[iE][i - 1])].dir_sig_atrib);
                            Console.WriteLine(atributos[search2((int)listaApsts2[iE][i + 1])].dir_atrib);
                            atributos[search2((int)listaApsts2[iE][i - 1])].dir_sig_atrib = atributos[search2((int)listaApsts2[iE][i + 1])].dir_atrib;
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
                imprimir2(); //muestra los cambios en atributos
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
                imprimir2();
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
            fs = new FileStream(nombreArchivo, FileMode.Open);
            bw = new BinaryWriter(fs);
            br = new BinaryReader(fs);
            int i = 0;
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
                listaSecIndexadaPrimaria.Clear();
                listaContenidoNodo.Clear();
                ie2 = iE;
                bandCajon = true; //el cajon se vuelve a insetar si se cambia de entidad
            }
                
            
            for (int y = 0; y < metaRegs.Count; y++)
            {
                if (metaRegs[y].clave == 3) //organizacion secuencial ordenada
                {
                    if (metaRegs[y].tipo == 'C')
                    {
                        string nameReg = metaRegs[y].text;
                        int tamName = nameReg.Length;
                        if (tamName < metaRegs[y].longitud - 1) //aqui rellenar la cadena hasta alcanzar la longitud especificada
                        {
                            for (int w = 0; w < ((metaRegs[y].longitud - 1) - tamName); w++)
                                nameReg += " ";
                        }
                        listaSecOrdenada.Add(nameReg);
                        
                    }
                    else
                        listaSecOrdenada.Add(metaRegs[y].text);
                    entidades[iE].banSO = true;
                }
                //organizacion secuencial indexada
                if (metaRegs[y].clave == 1) //llave primaria
                {
                    //MessageBox.Show("El atributo que contiene la llave primaria es " + metaRegs[y].text);
                    if (metaRegs[y].tipo == 'C')
                    {
                        string nameReg = metaRegs[y].text;
                        int tamName = nameReg.Length;
                        if (tamName < metaRegs[y].longitud - 1) //aqui rellenar la cadena hasta alcanzar la longitud especificada
                        {
                            for (int w = 0; w < ((metaRegs[y].longitud - 1) - tamName); w++)
                                nameReg += " ";
                        }
                        listaSecIndexadaPrimaria.Add(nameReg);
                        //int tam = listaSecIndexadaPrimaria[0].Length;
                    }
                    else
                        listaSecIndexadaPrimaria.Add(metaRegs[y].text);
                    //for (int x = 0; x < listaSecIndexadaPrimaria.Count; x++)
                    //    MessageBox.Show(listaSecIndexadaPrimaria[x]);
                    entidades[iE].banSIP = true;

                }

                if (metaRegs[y].clave == 2) //llave secundaria
                {
                    //MessageBox.Show("El atributo que contiene la llave secundaria es " + metaRegs[y].text);
                }

                if (metaRegs[y].clave == 5) //arbol 
                {
                    //MessageBox.Show("El atributo que contiene la clave del arbol es " + metaRegs[y].text);
                    listaContenidoNodo.Add(metaRegs[y].text);
                    entidades[iE].banArbol = true;
                    /*for (int p = 0; p < listaContenidoNodo.Count; p++)
                        MessageBox.Show(listaContenidoNodo[p]);*/
                }
            }

            if (entidades[iE].banSIP)
            {
                escribeRegLlavePrimaria(); //escibe reg dejando un directorio de indices
                //fs.Position = 273;
                //MessageBox.Show(br.ReadInt64().ToString());
                consulta();
                fs.Close();
                bw.Close();
                br.Close();
            }
            else
            {                     
                fs.Close(); //cierre del archivo 
                bw.Close(); //cierre del flujo
                br.Close();

                fs = new FileStream(nombreArchivo, FileMode.Open);
                bw = new BinaryWriter(fs);
                br = new BinaryReader(fs);
                escribeReg(); //escribe el registro en el archivo
                consulta();
                fs.Close(); //cierre del archivo 
                bw.Close(); //cierre del flujo
                br.Close();
            }

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
                escrituraIndicePrimario();
                fs.Close(); //cierre del archivo 
                bw.Close(); //cierre del flujo

                fs = new FileStream(nombreArchivo, FileMode.Open);
                br = new BinaryReader(fs);
                consulta2(); 
                fs.Close(); //cierre del archivo 
                br.Close();
            }

            /*if (entidades[iE].banArbol)
            {
                for (int z = 0; z < listaApsts2[iE].Count; z++)
                {
                    int iA = search2((int)listaApsts2[iE][z]); //indice en la lista de atributos de dicho apt
                    if (atributos[iA].tipo_indice == 5 && atributos[iA].dir_indice == -1) //primer hoja a meter
                    {
                        fs = new FileStream(nombreArchivo, FileMode.Open);
                        bw = new BinaryWriter(fs);
                        br = new BinaryReader(fs);
                        atributos[iA].dir_indice = dirRaiz; //133
                        escribeAtributos();
                        imprimir2();
                        fs.Close(); //cierre del archivo 
                        br.Close();
                        bw.Close();
                    }
                }
            }*/

            metaRegs.Clear(); //se limpia la lista de metadatos de los registro
        }

        private void nuevoNodo()
        {
            
            Nodo nodo = new Nodo();

            nodo.dir_nodo = fs.Length;
            dirRaiz = nodo.dir_nodo;
            bw.Write(nodo.dir_nodo);
            MessageBox.Show("Direccion del nodo " + nodo.dir_nodo);

            nodo.tipo = 'H';
            bw.Write(nodo.tipo);

            nodo.apt1 = (long)-1;
            bw.Write(nodo.apt1);

            nodo.val1 = -1;
            bw.Write(nodo.val1);

            nodo.apt2 = (long)-1;
            bw.Write(nodo.apt2);

            nodo.val2 = -1;
            bw.Write(nodo.val2);

            nodo.apt3 = (long)-1;
            bw.Write(nodo.apt3);

            nodo.val3 = -1;
            bw.Write(nodo.val3);

            nodo.apt4 = (long)-1;
            bw.Write(nodo.apt4);

            nodo.val4 = -1;
            bw.Write(nodo.val4);

            bw.Write(nodo.dir_nodo_sig);
            
        }

        //este metodo sirve para mostrar el directorio de indices
        private void consulta2()
        {
            long position = -1;
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            char tipoDato = ' ';
            long aptAux = -1;    
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
                    dataGridLlave1.Rows.Add(row);
                }

                if (tipoDato == 'E')
                {
                    string[] row = { br.ReadInt32().ToString(), br.ReadInt64().ToString() };
                    dataGridLlave1.Rows.Add(row);
                }
                long pos = fs.Position;
                //MessageBox.Show(pos.ToString());
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
            listaSecIndexadaPrimaria.Sort();
            
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
                }
            }

            fs.Position = position;
            for (int e = 0; e < listaSecIndexadaPrimaria.Count; e++)
            {
                //MessageBox.Show("se escribe en la posicion:> " + fs.Position);
                if (tipoDato == 'C')
                {
                    //bw.Write(listaSecIndexadaPrimaria[e]);
                    string nameReg = listaSecIndexadaPrimaria[e];
                    int tamName = nameReg.Length;
                    if (tamName < longitud - 1)
                    {
                        for (int y = 0; y < (longitud - 1) - tamName; y++)
                            nameReg += " ";
                        bw.Write(nameReg);
                        aptAux = search4(listaSecIndexadaPrimaria[e]);
                        bw.Write(aptAux);

                    }
                    else
                    {
                        if (tamName == longitud - 1)
                        {
                            bw.Write(nameReg);
                            aptAux = search4(listaSecIndexadaPrimaria[e]);
                            bw.Write(aptAux);
                        }
                        else
                        {
                            MessageBox.Show("El dato sobrepasa la longitud");
                            bw.Write("Error");
                            bw.Write((long)-1);
                        }
                    }
                }
                if (tipoDato == 'E')
                {
                    entero = Int32.Parse(listaSecIndexadaPrimaria[e]);
                    bw.Write(entero);
                    //MessageBox.Show("el dato:> " + entero.ToString());
                    aptAux = search4(listaSecIndexadaPrimaria[e]);
                    //MessageBox.Show("apt " + aptAux);
                    bw.Write(aptAux);
                }    
            }
            bw.Write((long)-1); //escritura del cierre del cajon
        }

        private void secuencialOrdenada(int ie)
        {
            int datos = tamReg + 8;
            long Up = 0;
            listaSecOrdenada.Sort(); //ordenacion de los reg por la clave de busqueda
            entidades[ie].dir_datos = search4(listaSecOrdenada[0]);
            escribeEntidades();
            imprimir();
            
            if (listaSecOrdenada.Count > 1)
            {
                fs.Position = entidades[ie].dir_datos;
                long aptI = br.ReadInt64();

                for (int i = 1; i < listaSecOrdenada.Count; i++)
                {
                    Up = aptI + datos;
                    long aptFAux = search4(listaSecOrdenada[i]);
                    fs.Position = Up;
                    bw.Write(aptFAux);
                    fs.Position = aptFAux;
                    aptI = br.ReadInt64();
                }
            }

            long aptFAux2 = search4(listaSecOrdenada[listaSecOrdenada.Count - 1]);
            long down = aptFAux2 + datos;
            fs.Position = down;
            bw.Write((long)-1);
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

        private void escribeRegLlavePrimaria()
        {
            tamReg = 0;
            //tamReg2 = 0;
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

            for (int i = 0; i < listaApsts2[index].Count; i++)
            {
                int iA = search2((int)listaApsts2[index][i]); //indice en la lista de atributos de dicho apt
                if (atributos[iA].tipo_indice == 1 && atributos[iA].dir_indice == -1)
                    atributos[iA].dir_indice = fs.Length;
            }
            if (bandCajon)
            {
                fs.Position = fs.Length + tamCajonPrimaria; //espacio para el directorio
                bandCajon = false;
            }
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
            imprimir2();
        }   

        private void escribeReg()
        {
            tamReg = 0;
            //tamReg2 = 0;
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
            /*
            if (entidades[index].banArbol)
            {
                if (contReg == 0)
                {
                    nuevoNodo();
                    fs.Position = fs.Length + 65;
                }
                else
                    fs.Position = fs.Length;
            }*/
            fs.Position = fs.Length;
            contReg++;
            if (contReg > 5)
                contReg = 0;
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

            //if (entidades[index].banArbol)
            //    escribeNodo();
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
            fs = new FileStream(nombreArchivo, FileMode.Open);
            bw = new BinaryWriter(fs);
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

            if (entidades[iE].banSO)
                escribeRegModificadoSecOrdenada();
            else
                escribeRegModificado();
            reg.Close(); //cierre de la forma
            fs.Close();
            bw.Close();
            
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
            }

            fs = new FileStream(nombreArchivo, FileMode.Open);
            br = new BinaryReader(fs);
            consulta();
            fs.Close(); //cierre del archivo 
            br.Close();

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
            if (listBufReg.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a eliminar");
                return;
            }
            fs = new FileStream(nombreArchivo, FileMode.Open);
            br = new BinaryReader(fs);
            bw = new BinaryWriter(fs);
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int iE = search(nameEntidad); //indice de los atributos correspondientes a dicha entidad

            if (entidades[iE].banSO)
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
                    //MessageBox.Show("haz entrado a la eliminacion del una llave primaria ");
                    //aqui se elimina de el registro y tambien se elimina lo correspondiente al directorio de indices
                    //despues de debe reordenar el direcctorio usando la funcion escribeIndice
                    
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
                        dataGridLlave1.Rows.Clear();

                    fs.Close(); //cierre del archivo 
                    bw.Close(); //cierre del flujo

                    fs = new FileStream(nombreArchivo, FileMode.Open);
                    br = new BinaryReader(fs);
                    consulta2();
                    fs.Close(); //cierre del archivo 
                    br.Close();
                }
                else
                    eliminacionSimpleReg(iE);

            }
            if (consultaReg.Enabled && entidades[iE].banSIP)
            {
                fs = new FileStream(nombreArchivo, FileMode.Open);
                br = new BinaryReader(fs);
                consulta();
                fs.Close(); //cierre del archivo 
                br.Close();
            }

            if (consultaReg.Enabled && !entidades[iE].banSIP)
                consulta();

            fs.Close();
            br.Close();
            bw.Close();
        }

        //aqui se elimina el reg del directorio de indices de la clave primaria
        

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
            if (aptI == aptIAux && aptF == -1)
            {
                entidades[iE].dir_datos = (long)-1;
                escribeEntidades();
                imprimir();
                consultaReg.Enabled = false;
                dataGridRegistros.Rows.Clear();
            }
            if (aptI == aptIAux)
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
                } while (aptFAux != aptI);
                fs.Position = uP;
                if (aptF == -1)
                    bw.Write((long)-1);
                else
                {
                    fs.Position = uP + tamReg;
                    long aptFAux2 = br.ReadInt64();
                    fs.Position = uP;
                    bw.Write(aptFAux2);
                }
            }
        }

        private void consultaReg_Click(object sender, EventArgs e)
        {
            fs = new FileStream(nombreArchivo, FileMode.Open);
            br = new BinaryReader(fs);
            consulta();
            string nameEntidad = comboEntidad2.Text;
            int textoTam = nameEntidad.Length;
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            int iE = search(nameEntidad); //indice de los atributos correspondientes a dicha entidad
            if (entidades[iE].banSIP)
                consulta2();
            fs.Close();
            br.Close();
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
            listaSecIndexadaPrimaria.Clear(); //quita los elementos guardados en la lista de llave primaria
            bandCajon = true; //para habilitar la insercion de otro cajon

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
    }
}