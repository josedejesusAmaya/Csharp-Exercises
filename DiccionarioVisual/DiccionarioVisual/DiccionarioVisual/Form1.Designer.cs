namespace DiccionarioVisual
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.etiquetaEntidad = new System.Windows.Forms.Label();
            this.textNomEntidad = new System.Windows.Forms.TextBox();
            this.nuevoEntidad = new System.Windows.Forms.Button();
            this.modificarEntidad = new System.Windows.Forms.Button();
            this.eliminarEntidad = new System.Windows.Forms.Button();
            this.grabarEntidad = new System.Windows.Forms.Button();
            this.deshacerEntidad = new System.Windows.Forms.Button();
            this.dataGridEntidades = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listaEntidad = new System.Windows.Forms.ComboBox();
            this.etiquetaNombre = new System.Windows.Forms.Label();
            this.textNomAtrib = new System.Windows.Forms.TextBox();
            this.listaTipo = new System.Windows.Forms.ComboBox();
            this.listaClave = new System.Windows.Forms.ComboBox();
            this.textLongitud = new System.Windows.Forms.TextBox();
            this.etiquetaTipo = new System.Windows.Forms.Label();
            this.etiquetaClave = new System.Windows.Forms.Label();
            this.etiquetaLongitud = new System.Windows.Forms.Label();
            this.nuevoAtrib = new System.Windows.Forms.Button();
            this.modificarAtrib = new System.Windows.Forms.Button();
            this.eliminarAtrib = new System.Windows.Forms.Button();
            this.grabarAtrib = new System.Windows.Forms.Button();
            this.deshacerAtrib = new System.Windows.Forms.Button();
            this.etiquetaAtributos = new System.Windows.Forms.Label();
            this.dataGridAtributos = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textNomArchivo = new System.Windows.Forms.TextBox();
            this.abrirArchivo = new System.Windows.Forms.Button();
            this.nuevoArchivo = new System.Windows.Forms.Button();
            this.imprimirEntidades = new System.Windows.Forms.Button();
            this.imprimirAtrib = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEntidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAtributos)).BeginInit();
            this.SuspendLayout();
            // 
            // etiquetaEntidad
            // 
            this.etiquetaEntidad.AutoSize = true;
            this.etiquetaEntidad.Location = new System.Drawing.Point(844, 89);
            this.etiquetaEntidad.Name = "etiquetaEntidad";
            this.etiquetaEntidad.Size = new System.Drawing.Size(43, 13);
            this.etiquetaEntidad.TabIndex = 2;
            this.etiquetaEntidad.Text = "Entidad";
            // 
            // textNomEntidad
            // 
            this.textNomEntidad.Location = new System.Drawing.Point(928, 86);
            this.textNomEntidad.MaxLength = 29;
            this.textNomEntidad.Name = "textNomEntidad";
            this.textNomEntidad.Size = new System.Drawing.Size(100, 20);
            this.textNomEntidad.TabIndex = 3;
            // 
            // nuevoEntidad
            // 
            this.nuevoEntidad.Location = new System.Drawing.Point(847, 122);
            this.nuevoEntidad.Name = "nuevoEntidad";
            this.nuevoEntidad.Size = new System.Drawing.Size(75, 23);
            this.nuevoEntidad.TabIndex = 4;
            this.nuevoEntidad.Text = "Nuevo";
            this.nuevoEntidad.UseVisualStyleBackColor = true;
            this.nuevoEntidad.Click += new System.EventHandler(this.button1_Click);
            // 
            // modificarEntidad
            // 
            this.modificarEntidad.Location = new System.Drawing.Point(943, 121);
            this.modificarEntidad.Name = "modificarEntidad";
            this.modificarEntidad.Size = new System.Drawing.Size(75, 23);
            this.modificarEntidad.TabIndex = 5;
            this.modificarEntidad.Text = "Modificar";
            this.modificarEntidad.UseVisualStyleBackColor = true;
            // 
            // eliminarEntidad
            // 
            this.eliminarEntidad.Location = new System.Drawing.Point(1046, 122);
            this.eliminarEntidad.Name = "eliminarEntidad";
            this.eliminarEntidad.Size = new System.Drawing.Size(75, 23);
            this.eliminarEntidad.TabIndex = 6;
            this.eliminarEntidad.Text = "Eliminar";
            this.eliminarEntidad.UseVisualStyleBackColor = true;
            this.eliminarEntidad.Click += new System.EventHandler(this.eliminarEntidad_Click);
            // 
            // grabarEntidad
            // 
            this.grabarEntidad.Location = new System.Drawing.Point(895, 174);
            this.grabarEntidad.Name = "grabarEntidad";
            this.grabarEntidad.Size = new System.Drawing.Size(75, 23);
            this.grabarEntidad.TabIndex = 7;
            this.grabarEntidad.Text = "Grabar";
            this.grabarEntidad.UseVisualStyleBackColor = true;
            this.grabarEntidad.Click += new System.EventHandler(this.button4_Click);
            // 
            // deshacerEntidad
            // 
            this.deshacerEntidad.Location = new System.Drawing.Point(1000, 174);
            this.deshacerEntidad.Name = "deshacerEntidad";
            this.deshacerEntidad.Size = new System.Drawing.Size(75, 23);
            this.deshacerEntidad.TabIndex = 8;
            this.deshacerEntidad.Text = "Deshacer";
            this.deshacerEntidad.UseVisualStyleBackColor = true;
            this.deshacerEntidad.Click += new System.EventHandler(this.deshacerEntidad_Click);
            // 
            // dataGridEntidades
            // 
            this.dataGridEntidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEntidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridEntidades.Location = new System.Drawing.Point(123, 77);
            this.dataGridEntidades.Name = "dataGridEntidades";
            this.dataGridEntidades.Size = new System.Drawing.Size(545, 161);
            this.dataGridEntidades.TabIndex = 9;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nombre";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Dir_Entidad";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Dir_Datos";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Dir_Atributos";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Dir_Sig_Entidad";
            this.Column5.Name = "Column5";
            // 
            // listaEntidad
            // 
            this.listaEntidad.FormattingEnabled = true;
            this.listaEntidad.Location = new System.Drawing.Point(899, 269);
            this.listaEntidad.Name = "listaEntidad";
            this.listaEntidad.Size = new System.Drawing.Size(121, 21);
            this.listaEntidad.TabIndex = 10;
            // 
            // etiquetaNombre
            // 
            this.etiquetaNombre.AutoSize = true;
            this.etiquetaNombre.Location = new System.Drawing.Point(836, 313);
            this.etiquetaNombre.Name = "etiquetaNombre";
            this.etiquetaNombre.Size = new System.Drawing.Size(44, 13);
            this.etiquetaNombre.TabIndex = 12;
            this.etiquetaNombre.Text = "Nombre";
            // 
            // textNomAtrib
            // 
            this.textNomAtrib.Location = new System.Drawing.Point(899, 306);
            this.textNomAtrib.MaxLength = 29;
            this.textNomAtrib.Name = "textNomAtrib";
            this.textNomAtrib.Size = new System.Drawing.Size(100, 20);
            this.textNomAtrib.TabIndex = 13;
            // 
            // listaTipo
            // 
            this.listaTipo.FormattingEnabled = true;
            this.listaTipo.Location = new System.Drawing.Point(899, 352);
            this.listaTipo.Name = "listaTipo";
            this.listaTipo.Size = new System.Drawing.Size(121, 21);
            this.listaTipo.TabIndex = 14;
            // 
            // listaClave
            // 
            this.listaClave.FormattingEnabled = true;
            this.listaClave.Location = new System.Drawing.Point(899, 449);
            this.listaClave.Name = "listaClave";
            this.listaClave.Size = new System.Drawing.Size(121, 21);
            this.listaClave.TabIndex = 15;
            // 
            // textLongitud
            // 
            this.textLongitud.Location = new System.Drawing.Point(899, 402);
            this.textLongitud.Name = "textLongitud";
            this.textLongitud.Size = new System.Drawing.Size(100, 20);
            this.textLongitud.TabIndex = 16;
            // 
            // etiquetaTipo
            // 
            this.etiquetaTipo.AutoSize = true;
            this.etiquetaTipo.Location = new System.Drawing.Point(833, 355);
            this.etiquetaTipo.Name = "etiquetaTipo";
            this.etiquetaTipo.Size = new System.Drawing.Size(28, 13);
            this.etiquetaTipo.TabIndex = 17;
            this.etiquetaTipo.Text = "Tipo";
            // 
            // etiquetaClave
            // 
            this.etiquetaClave.AutoSize = true;
            this.etiquetaClave.Location = new System.Drawing.Point(821, 452);
            this.etiquetaClave.Name = "etiquetaClave";
            this.etiquetaClave.Size = new System.Drawing.Size(65, 13);
            this.etiquetaClave.TabIndex = 18;
            this.etiquetaClave.Text = "Clave/Llave";
            // 
            // etiquetaLongitud
            // 
            this.etiquetaLongitud.AutoSize = true;
            this.etiquetaLongitud.Location = new System.Drawing.Point(836, 402);
            this.etiquetaLongitud.Name = "etiquetaLongitud";
            this.etiquetaLongitud.Size = new System.Drawing.Size(48, 13);
            this.etiquetaLongitud.TabIndex = 19;
            this.etiquetaLongitud.Text = "Longitud";
            // 
            // nuevoAtrib
            // 
            this.nuevoAtrib.Location = new System.Drawing.Point(1061, 276);
            this.nuevoAtrib.Name = "nuevoAtrib";
            this.nuevoAtrib.Size = new System.Drawing.Size(75, 23);
            this.nuevoAtrib.TabIndex = 20;
            this.nuevoAtrib.Text = "Nuevo";
            this.nuevoAtrib.UseVisualStyleBackColor = true;
            this.nuevoAtrib.Click += new System.EventHandler(this.button6_Click);
            // 
            // modificarAtrib
            // 
            this.modificarAtrib.Location = new System.Drawing.Point(1061, 313);
            this.modificarAtrib.Name = "modificarAtrib";
            this.modificarAtrib.Size = new System.Drawing.Size(75, 23);
            this.modificarAtrib.TabIndex = 21;
            this.modificarAtrib.Text = "Modificar";
            this.modificarAtrib.UseVisualStyleBackColor = true;
            // 
            // eliminarAtrib
            // 
            this.eliminarAtrib.Location = new System.Drawing.Point(1061, 352);
            this.eliminarAtrib.Name = "eliminarAtrib";
            this.eliminarAtrib.Size = new System.Drawing.Size(75, 23);
            this.eliminarAtrib.TabIndex = 22;
            this.eliminarAtrib.Text = "Eliminar";
            this.eliminarAtrib.UseVisualStyleBackColor = true;
            this.eliminarAtrib.Click += new System.EventHandler(this.eliminarAtrib_Click);
            // 
            // grabarAtrib
            // 
            this.grabarAtrib.Location = new System.Drawing.Point(1061, 392);
            this.grabarAtrib.Name = "grabarAtrib";
            this.grabarAtrib.Size = new System.Drawing.Size(75, 23);
            this.grabarAtrib.TabIndex = 23;
            this.grabarAtrib.Text = "Grabar";
            this.grabarAtrib.UseVisualStyleBackColor = true;
            this.grabarAtrib.Click += new System.EventHandler(this.button9_Click);
            // 
            // deshacerAtrib
            // 
            this.deshacerAtrib.Location = new System.Drawing.Point(1061, 430);
            this.deshacerAtrib.Name = "deshacerAtrib";
            this.deshacerAtrib.Size = new System.Drawing.Size(75, 23);
            this.deshacerAtrib.TabIndex = 24;
            this.deshacerAtrib.Text = "Deshacer";
            this.deshacerAtrib.UseVisualStyleBackColor = true;
            this.deshacerAtrib.Click += new System.EventHandler(this.deshacerAtrib_Click);
            // 
            // etiquetaAtributos
            // 
            this.etiquetaAtributos.AutoSize = true;
            this.etiquetaAtributos.Location = new System.Drawing.Point(836, 252);
            this.etiquetaAtributos.Name = "etiquetaAtributos";
            this.etiquetaAtributos.Size = new System.Drawing.Size(48, 13);
            this.etiquetaAtributos.TabIndex = 25;
            this.etiquetaAtributos.Text = "Atributos";
            // 
            // dataGridAtributos
            // 
            this.dataGridAtributos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAtributos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12});
            this.dataGridAtributos.Location = new System.Drawing.Point(32, 269);
            this.dataGridAtributos.Name = "dataGridAtributos";
            this.dataGridAtributos.Size = new System.Drawing.Size(744, 174);
            this.dataGridAtributos.TabIndex = 26;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Nombre";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Tipo";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Longitud";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Dir_Atrib";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Tipo_Indice";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Dir_Indice";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Ap_Sig_Atrib";
            this.Column12.Name = "Column12";
            // 
            // textNomArchivo
            // 
            this.textNomArchivo.Location = new System.Drawing.Point(928, 25);
            this.textNomArchivo.Name = "textNomArchivo";
            this.textNomArchivo.Size = new System.Drawing.Size(100, 20);
            this.textNomArchivo.TabIndex = 27;
            // 
            // abrirArchivo
            // 
            this.abrirArchivo.Location = new System.Drawing.Point(844, 48);
            this.abrirArchivo.Name = "abrirArchivo";
            this.abrirArchivo.Size = new System.Drawing.Size(75, 23);
            this.abrirArchivo.TabIndex = 28;
            this.abrirArchivo.Text = "Abrir";
            this.abrirArchivo.UseVisualStyleBackColor = true;
            this.abrirArchivo.Click += new System.EventHandler(this.button11_Click);
            // 
            // nuevoArchivo
            // 
            this.nuevoArchivo.Location = new System.Drawing.Point(844, 25);
            this.nuevoArchivo.Name = "nuevoArchivo";
            this.nuevoArchivo.Size = new System.Drawing.Size(75, 23);
            this.nuevoArchivo.TabIndex = 30;
            this.nuevoArchivo.Text = "Nuevo";
            this.nuevoArchivo.UseVisualStyleBackColor = true;
            this.nuevoArchivo.Click += new System.EventHandler(this.button12_Click);
            // 
            // imprimirEntidades
            // 
            this.imprimirEntidades.Location = new System.Drawing.Point(918, 215);
            this.imprimirEntidades.Name = "imprimirEntidades";
            this.imprimirEntidades.Size = new System.Drawing.Size(132, 23);
            this.imprimirEntidades.TabIndex = 32;
            this.imprimirEntidades.Text = "Imprimir Entidades";
            this.imprimirEntidades.UseVisualStyleBackColor = true;
            this.imprimirEntidades.Click += new System.EventHandler(this.imprimirEntidades_Click);
            // 
            // imprimirAtrib
            // 
            this.imprimirAtrib.Location = new System.Drawing.Point(1046, 467);
            this.imprimirAtrib.Name = "imprimirAtrib";
            this.imprimirAtrib.Size = new System.Drawing.Size(133, 23);
            this.imprimirAtrib.TabIndex = 33;
            this.imprimirAtrib.Text = "Imprimir Atributos";
            this.imprimirAtrib.UseVisualStyleBackColor = true;
            this.imprimirAtrib.Click += new System.EventHandler(this.imprimirAtrib_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(837, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Entidad";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 502);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imprimirAtrib);
            this.Controls.Add(this.imprimirEntidades);
            this.Controls.Add(this.nuevoArchivo);
            this.Controls.Add(this.abrirArchivo);
            this.Controls.Add(this.textNomArchivo);
            this.Controls.Add(this.dataGridAtributos);
            this.Controls.Add(this.etiquetaAtributos);
            this.Controls.Add(this.deshacerAtrib);
            this.Controls.Add(this.grabarAtrib);
            this.Controls.Add(this.eliminarAtrib);
            this.Controls.Add(this.modificarAtrib);
            this.Controls.Add(this.nuevoAtrib);
            this.Controls.Add(this.etiquetaLongitud);
            this.Controls.Add(this.etiquetaClave);
            this.Controls.Add(this.etiquetaTipo);
            this.Controls.Add(this.textLongitud);
            this.Controls.Add(this.listaClave);
            this.Controls.Add(this.listaTipo);
            this.Controls.Add(this.textNomAtrib);
            this.Controls.Add(this.etiquetaNombre);
            this.Controls.Add(this.listaEntidad);
            this.Controls.Add(this.dataGridEntidades);
            this.Controls.Add(this.deshacerEntidad);
            this.Controls.Add(this.grabarEntidad);
            this.Controls.Add(this.eliminarEntidad);
            this.Controls.Add(this.modificarEntidad);
            this.Controls.Add(this.nuevoEntidad);
            this.Controls.Add(this.textNomEntidad);
            this.Controls.Add(this.etiquetaEntidad);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEntidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAtributos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label etiquetaEntidad;
        private System.Windows.Forms.TextBox textNomEntidad;
        private System.Windows.Forms.Button nuevoEntidad;
        private System.Windows.Forms.Button modificarEntidad;
        private System.Windows.Forms.Button eliminarEntidad;
        private System.Windows.Forms.Button grabarEntidad;
        private System.Windows.Forms.Button deshacerEntidad;
        private System.Windows.Forms.DataGridView dataGridEntidades;
        private System.Windows.Forms.ComboBox listaEntidad;
        private System.Windows.Forms.Label etiquetaNombre;
        private System.Windows.Forms.TextBox textNomAtrib;
        private System.Windows.Forms.ComboBox listaTipo;
        private System.Windows.Forms.ComboBox listaClave;
        private System.Windows.Forms.TextBox textLongitud;
        private System.Windows.Forms.Label etiquetaTipo;
        private System.Windows.Forms.Label etiquetaClave;
        private System.Windows.Forms.Label etiquetaLongitud;
        private System.Windows.Forms.Button nuevoAtrib;
        private System.Windows.Forms.Button modificarAtrib;
        private System.Windows.Forms.Button eliminarAtrib;
        private System.Windows.Forms.Button grabarAtrib;
        private System.Windows.Forms.Button deshacerAtrib;
        private System.Windows.Forms.Label etiquetaAtributos;
        private System.Windows.Forms.DataGridView dataGridAtributos;
        private System.Windows.Forms.TextBox textNomArchivo;
        private System.Windows.Forms.Button abrirArchivo;
        private System.Windows.Forms.Button nuevoArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.Button imprimirEntidades;
        private System.Windows.Forms.Button imprimirAtrib;
        private System.Windows.Forms.Label label2;
    }
}

