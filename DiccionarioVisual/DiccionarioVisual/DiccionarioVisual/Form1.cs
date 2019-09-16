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

/**
 * Falta establecer los apuntadores.
 * Limpiar comboBox
 **/
namespace DiccionarioVisual
{
    public partial class Form1 : Form
    {
        String nombreFichero = null; //nombre del fichero
        List<Entidad> entidad = new List<Entidad>(); //lista de las entidades 
        List<Atributo> atributo = new List<Atributo>(); //lista de los atributos
        Entidad temporalEnt; //entidad auxiliar
        Atributo temporalAtrib; //atributo auxiliar 
        private int contEntidades = 0; //para llevar la cuenta de entidades impresas
        private int contAtributos = 0;
        List<string> listaNomEntidades = new List<string>(); //lista de nombres de entidades para ordenar 
        long pesoEnti = (long)62;
        long cab = (long)-1;
        List<long> apts = new List<long>();
        public Form1()
        {
            InitializeComponent();
            //inicializacion de los comboBox
            listaTipo.Items.Add("e");
            listaTipo.Items.Add("c");
            listaClave.Items.Add(0);
            listaClave.Items.Add(1);
            listaClave.Items.Add(2);
            listaClave.Items.Add(3);
            //inhabilitar los botones
            //entidades
            modificarEntidad.Enabled = false; //Modificar
            eliminarEntidad.Enabled = false; //Eliminar
            deshacerEntidad.Enabled = false; //Deshacer
            imprimirEntidades.Enabled = false; //imprimir entidades
            grabarEntidad.Enabled = false; //grabar entidades
            //atributos
            modificarAtrib.Enabled = false; //Modificar
            eliminarAtrib.Enabled = false; //Eliminar
            deshacerAtrib.Enabled = false; //Deshacer
            imprimirAtrib.Enabled = false; //imprimir atributos
            grabarAtrib.Enabled = false; //grabar atributos
            this.Text = "Diccionario de Datos> JJ Amaya";
        }
        //nuevoArchivo
        private void button12_Click(object sender, EventArgs e)
        {
            modificarEntidad.Enabled = false; //Modificar
            eliminarEntidad.Enabled = false; //Eliminar
            deshacerEntidad.Enabled = false; //Deshacer
            imprimirEntidades.Enabled = false; //imprimir entidades
            grabarEntidad.Enabled = false; //grabar entidades

            listaEntidad.Items.Clear(); //para limpiar la lista cada que abro un archivo nuevo
            //para limpiar las datagrid cada vez que se abre un nuevo archivo
            dataGridEntidades.Rows.Clear();
            dataGridAtributos.Rows.Clear();
            //obtener el nombre del fichero
            nombreFichero = textNomArchivo.Text;
            textNomArchivo.Clear(); //limpia el textBox
            //verificar si el fichero existe
            if (string.IsNullOrEmpty(nombreFichero)) //validacion de la entrada de nuevo
            {
                MessageBox.Show("Debe ingresar un nombre al archivo nuevo.");
                return;
            }
            if (File.Exists(nombreFichero))
            {
                MessageBox.Show("El fichero existe");
            }
            else
            {
                crearFichero(nombreFichero);
            }
        }
        //crea el archivo
        private void crearFichero(String fichero)
        {
            BinaryWriter bw = null; //salida de los datos hacia el fichero
            FileStream fs = new FileStream(fichero, FileMode.Create, FileAccess.Write);
            try
            {
                this.Text = fichero;
                bw = new BinaryWriter(fs);
                bw.Write(cab); //escribe una cabecera con -1
            }
            finally
            {
                //cerrar el flujo
                if (bw != null)
                {
                    bw.Close();
                }
            }
        }
        //abrirArchivo
        private void button11_Click(object sender, EventArgs e)
        {
            string fichero = textNomArchivo.Text;
            textNomArchivo.Clear();
            this.Text = fichero;
            long apt = 8;
            int i = 0;
            if (string.IsNullOrEmpty(fichero))
            {
                MessageBox.Show("Debe ingresar el nombre de archivo existente."); //validacion de la entrada abrir
                return;
            }
            try
            {
                FileStream fs = new FileStream(fichero, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs); //salida de los datos hacia el fichero
                //do
                //{
                    entidad.Add(new Entidad());
                    fs.Position = apt;
                    entidad[i].setNombre(br.ReadString());
                    entidad[i].setDir_Entidad(br.ReadInt64());
                    entidad[i].setDir_Datos(br.ReadInt64());
                    entidad[i].setDir_Atributos(br.ReadInt64());
                    entidad[i].setDir_Sig_Entidad(br.ReadInt64());
                    fs.Position = apt;
                    entidad[i].setNombre(br.ReadString());
                    entidad[i].setDir_Entidad(br.ReadInt64());
                    entidad[i].setDir_Datos(br.ReadInt64());
                    entidad[i].setDir_Atributos(br.ReadInt64());
                    entidad[i].setDir_Sig_Entidad(br.ReadInt64());

                //apt = entidad[i].getDir_Sig_Entidad();
                //i++;
                //} while (apt != (long)-1);
            }
            catch (FileNotFoundException ioEx)
            {
                MessageBox.Show(ioEx.Message);
            }
            imprimirEntidades.Enabled = true;
        }
        //nuevo de entidad temporal 
        private void button1_Click(object sender, EventArgs e)
        {
            int contOrden = 0;
            temporalEnt = new Entidad();
            //activar botones 
            imprimirEntidades.Enabled = true;
            modificarEntidad.Enabled = true;
            eliminarEntidad.Enabled = true;
            deshacerEntidad.Enabled = true;

            int textoTam = textNomEntidad.TextLength;
            string nameEntidad = textNomEntidad.Text;

            if (string.IsNullOrEmpty(nameEntidad)) //validacion de la entrada de entidad
            {
                MessageBox.Show("Debe ingresar un nombre para la nueva entidad");
                return;
            }
            
            //index me dice si el nombre ya se encuentra en el comboBox
            int index = listaEntidad.FindStringExact(nameEntidad); 
            if (index == -1) //-1 si no se encuentra, lo agrega
            {
                listaEntidad.Items.Add(nameEntidad);
                
                if (textoTam != 29) //si la cadena es menor a 29: rellenar
                {
                    for (int i = 0; i < (29 - textoTam); i++)
                        nameEntidad += " ";
                }
                temporalEnt.setNombre(nameEntidad);
                temporalEnt.setDir_Entidad((long)-1);
                temporalEnt.setDir_Datos((long)-1);
                temporalEnt.setDir_Atributos((long)-1);
                temporalEnt.setDir_Sig_Entidad((long)-1);
                entidad.Add(temporalEnt); //aqui se agrega el temporal a la lista de entidades
                listaNomEntidades.Add(temporalEnt.getNombre()); //aqui se agrega a la lista los nombres
                listaNomEntidades.Sort(); //orden alfabetico de las entidades
                for (int i = 0; i < listaNomEntidades.Count; i++)
                {
                    for (int y = 0; y < entidad.Count; y++)
                    {
                        if (listaNomEntidades[i].Equals(entidad[y].getNombre(), StringComparison.Ordinal))
                        {
                            entidad[y].setDir_Entidad((long)8 + pesoEnti * contOrden++);
                            apts.Add(entidad[y].getDir_Entidad());
                        }
                    }
                }
                /*
                for (int z = 0; z < entidad.Count; z++)
                {
                    if (z + 1 == entidad.Count)
                        entidad[z].setDir_Sig_Entidad((long)-1);
                    entidad[z].setDir_Sig_Entidad(apts[z + 1]);
                }*/
            }
            else
                MessageBox.Show("La entidad ya existe, no se puede crear.");
            textNomEntidad.Clear();
        }   
        //nuevo en atributo temporal
        private void button6_Click(object sender, EventArgs e)
        {
            temporalAtrib = new Atributo();
            //activar botones
            imprimirAtrib.Enabled = true;
            modificarAtrib.Enabled = true;
            eliminarAtrib.Enabled = true;
            deshacerAtrib.Enabled = true;

            int textoTam = textNomAtrib.TextLength;
            string nameAtrib = textNomAtrib.Text;
            
            //validacion del nombre de la entidad o de la longitud
            if (string.IsNullOrEmpty(nameAtrib) || string.IsNullOrEmpty(textLongitud.Text)) 
            {
                MessageBox.Show("Faltan datos por ingresar");
                return;
            }

            if (textoTam != 29) //si la cadena es menor a 30: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameAtrib += " ";
            }
            temporalAtrib.setNombre(nameAtrib);
            char tipo = listaTipo.SelectedItem.ToString()[0];
            temporalAtrib.setTipo(tipo);
            temporalAtrib.setLongitud(Convert.ToInt32(textLongitud.Text));
            temporalAtrib.setDir_Atrib((long)-1);
            temporalAtrib.setTipo_Indice(Convert.ToInt32(listaClave.SelectedItem.ToString()));
            temporalAtrib.setDir_Indice((long)-1);
            temporalAtrib.setDir_Sig_Atrib((long)-1);
            atributo.Add(temporalAtrib); //aqui se agrega el temporal a la lista de atributos
            textNomAtrib.Clear();
            textLongitud.Clear();
        }
        //grabar entidad auxiliar y agrega al comboBox entidad
        private void button4_Click(object sender, EventArgs e)
        {
            deshacerEntidad.Enabled = false; //desactiva deshacer
            imprimirEntidades.Enabled = false; //activa imprimir entidades
            nuevoEntidad.Enabled = false; //desactiva la funcion de nueva entidad
            modificarEntidad.Enabled = false; //desactivar la funcion de modificar entidad
            eliminarEntidad.Enabled = false; //desactivar la funcion de eliminar entidad
            FileStream fs = new FileStream(nombreFichero, FileMode.Append, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(fs);
            //MessageBox.Show("Tama;o del archivo" + fs.Length);
            //MessageBox.Show("Posicion del archivo" + fs.Position);
            try
            {      
                for (int i = 0; i < entidad.Count; i++)
                {
                    writer.Write(entidad[i].getNombre());
                    //writer.Write(fs.Length); //da como direccion de la entidad el tama;o de la cab
                    writer.Write(entidad[i].getDir_Entidad());
                    writer.Write(entidad[i].getDirDatos());
                    writer.Write(entidad[i].getDir_Atributos());
                    writer.Write(entidad[i].getDir_Sig_Entidad());
                }
                writer.Close();
                fs.Close();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
        //grabar atributos auxiliar 
        private void button9_Click(object sender, EventArgs e)
        {
            deshacerAtrib.Enabled = false;
            imprimirAtrib.Enabled = true;
            nuevoAtrib.Enabled = false;
            modificarAtrib.Enabled = false;
            eliminarAtrib.Enabled = false;
            FileStream fs = new FileStream(nombreFichero, FileMode.Append, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(fs);
            try
            {
                for (int i = 0; i < atributo.Count; i++)
                {
                    writer.Write(atributo[i].getNombre());
                    writer.Write(atributo[i].getTipo());
                    writer.Write(atributo[i].getLongitud());
                    writer.Write(atributo[i].getDir_Atrib());
                    writer.Write(atributo[i].getTipo_Indice());
                    writer.Write(atributo[i].getDir_Indice());
                    writer.Write(atributo[i].getDir_Sig_Atrib());
                }
                writer.Close();
                fs.Close();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
        //boton deshacer; elimina la ultima entidad
        private void deshacerEntidad_Click(object sender, EventArgs e)
        {
            entidad.RemoveAt(entidad.Count - 1); //elimina el elemento de la lista de entidades
            //elimina la ultima fila agregada de entidades
            dataGridEntidades.Rows.RemoveAt(entidad.Count - dataGridEntidades.CurrentRow.Index); 
            listaEntidad.Items.RemoveAt(listaEntidad.Items.Count-1); //elimina el elemento de la lista del comboBox
        }
        //boton deshacer; elimina el ultimo atributo
        private void deshacerAtrib_Click(object sender, EventArgs e)
        {
            atributo.RemoveAt(atributo.Count - 1); //elimina el elemento de la lista de atributos
            //elimina la ultima fila agregada de atributos
            dataGridAtributos.Rows.RemoveAt(atributo.Count - dataGridAtributos.CurrentRow.Index);
        }
        //imprimir entidades en datagrid
        private void imprimirEntidades_Click(object sender, EventArgs e)
        {
            grabarEntidad.Enabled = true;
            deshacerEntidad.Enabled = true;
            modificarEntidad.Enabled = true;
            nuevoEntidad.Enabled = true;
            eliminarEntidad.Enabled = true;
            //permite llevar la cuenta de las entidades que se han impreso
            for (; contEntidades < entidad.Count; contEntidades++) 
            {
                string[] row = {entidad[contEntidades].getNombre(), entidad[contEntidades].getDir_Entidad().ToString(),
                                entidad[contEntidades].getDir_Datos().ToString(), entidad[contEntidades].getDir_Atributos().ToString(),
                                entidad[contEntidades].getDir_Sig_Entidad().ToString()};
                dataGridEntidades.Rows.Add(row);
            }
        }
        //imprimir atributos en detagrid
        private void imprimirAtrib_Click(object sender, EventArgs e)
        {
            grabarAtrib.Enabled = true;
            deshacerAtrib.Enabled = true;
            modificarAtrib.Enabled = true;
            nuevoAtrib.Enabled = true;
            eliminarAtrib.Enabled = true;
            //permite llevar la cuenta de los atributos que se han impreso
            for (; contAtributos < atributo.Count; contAtributos++)
            {
                string[] row = {atributo[contAtributos].getNombre(), atributo[contAtributos].getTipo().ToString(), atributo[contAtributos].getLongitud().ToString(),
                                atributo[contAtributos].getDir_Atrib().ToString(), atributo[contAtributos].getTipo_Indice().ToString(),
                                atributo[contAtributos].getDir_Indice().ToString(), atributo[contAtributos].getDir_Sig_Atrib().ToString()};
                dataGridAtributos.Rows.Add(row);
            }
        }
        //elimina cualquier entidad en la lista
        private void eliminarEntidad_Click(object sender, EventArgs e)
        {
            int textoTam = textNomEntidad.TextLength;
            string nameEntidad = textNomEntidad.Text;
            listaEntidad.Items.Remove(nameEntidad); //elimina el item de la lista de entidades
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameEntidad += " ";
            }
            for (int i = 0; i < entidad.Count; i++) //ciclo para buscar el nombre de la entidad 
            {
                if (nameEntidad.Equals(entidad[i].getNombre(), StringComparison.Ordinal)) //condicion de igualdad strings
                {
                    MessageBox.Show("Entidad removida: " + entidad[i].getNombre());
                    entidad.RemoveAt(i);
                    dataGridEntidades.Rows.RemoveAt(i); //eliminacion de la datagrid entidad
                }
            }
            textNomEntidad.Clear();
        }
        //elimina cualquier atributo en la lista
        private void eliminarAtrib_Click(object sender, EventArgs e)
        {
            int textoTam = textNomAtrib.TextLength;
            string nameAtrib = textNomAtrib.Text;
            if (textoTam != 29) //si la cadena es menor a 29: rellenar
            {
                for (int i = 0; i < (29 - textoTam); i++)
                    nameAtrib += " ";
            }
            for (int i = 0; i < atributo.Count; i++) //ciclo para buscar el nombre del atributo 
            {
                if (nameAtrib.Equals(atributo[i].getNombre(), StringComparison.Ordinal)) //condicion de igualdad strings
                {
                    MessageBox.Show("Atributo removido: " + atributo[i].getNombre());
                    atributo.RemoveAt(i);
                    dataGridAtributos.Rows.RemoveAt(i); //eliminacion de la datarid atributo 
                }
            }
            textNomAtrib.Clear();
        }
    }
}
