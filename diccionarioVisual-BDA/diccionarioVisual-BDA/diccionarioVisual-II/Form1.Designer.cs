namespace diccionarioVisual_II
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridEntidades = new System.Windows.Forms.DataGridView();
            this.nombreE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridAtributos = new System.Windows.Forms.DataGridView();
            this.nomAtrib = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoAtrib = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longAtrib = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoIndice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboEntidad2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridRegistros = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atributosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deshacerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.registrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.relacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.botonPrimaria = new System.Windows.Forms.Button();
            this.L_Secundaria = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEntidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAtributos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRegistros)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridEntidades
            // 
            this.dataGridEntidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEntidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreE});
            this.dataGridEntidades.Location = new System.Drawing.Point(100, 104);
            this.dataGridEntidades.Name = "dataGridEntidades";
            this.dataGridEntidades.Size = new System.Drawing.Size(151, 156);
            this.dataGridEntidades.TabIndex = 29;
            this.dataGridEntidades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridEntidades_CellClick);
            // 
            // nombreE
            // 
            this.nombreE.HeaderText = "Nombre";
            this.nombreE.Name = "nombreE";
            // 
            // dataGridAtributos
            // 
            this.dataGridAtributos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAtributos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomAtrib,
            this.tipoAtrib,
            this.longAtrib,
            this.tipoIndice});
            this.dataGridAtributos.Location = new System.Drawing.Point(272, 104);
            this.dataGridAtributos.Name = "dataGridAtributos";
            this.dataGridAtributos.Size = new System.Drawing.Size(245, 156);
            this.dataGridAtributos.TabIndex = 30;
            this.dataGridAtributos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridAtributos_CellClick);
            // 
            // nomAtrib
            // 
            this.nomAtrib.HeaderText = "Nombre";
            this.nomAtrib.Name = "nomAtrib";
            this.nomAtrib.Width = 50;
            // 
            // tipoAtrib
            // 
            this.tipoAtrib.HeaderText = "Tipo";
            this.tipoAtrib.Name = "tipoAtrib";
            this.tipoAtrib.Width = 50;
            // 
            // longAtrib
            // 
            this.longAtrib.HeaderText = "Longitud";
            this.longAtrib.Name = "longAtrib";
            this.longAtrib.Width = 50;
            // 
            // tipoIndice
            // 
            this.tipoIndice.HeaderText = "Índice";
            this.tipoIndice.Name = "tipoIndice";
            this.tipoIndice.Width = 50;
            // 
            // comboEntidad2
            // 
            this.comboEntidad2.FormattingEnabled = true;
            this.comboEntidad2.Location = new System.Drawing.Point(153, 41);
            this.comboEntidad2.Name = "comboEntidad2";
            this.comboEntidad2.Size = new System.Drawing.Size(98, 21);
            this.comboEntidad2.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(99, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Registros:";
            // 
            // dataGridRegistros
            // 
            this.dataGridRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRegistros.Location = new System.Drawing.Point(99, 290);
            this.dataGridRegistros.Name = "dataGridRegistros";
            this.dataGridRegistros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridRegistros.Size = new System.Drawing.Size(418, 235);
            this.dataGridRegistros.TabIndex = 42;
            this.dataGridRegistros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRegistros_CellClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(154, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 46;
            this.label10.Text = "Entidades";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(367, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 47;
            this.label11.Text = "Atributos";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(280, 268);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 48;
            this.label12.Text = "Registros";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.entidadesToolStripMenuItem,
            this.atributosToolStripMenuItem,
            this.registrosToolStripMenuItem,
            this.relacionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(617, 24);
            this.menuStrip1.TabIndex = 52;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.cerrarToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // entidadesToolStripMenuItem
            // 
            this.entidadesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem1,
            this.modificarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.verToolStripMenuItem});
            this.entidadesToolStripMenuItem.Name = "entidadesToolStripMenuItem";
            this.entidadesToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.entidadesToolStripMenuItem.Text = "Entidades";
            // 
            // nuevoToolStripMenuItem1
            // 
            this.nuevoToolStripMenuItem1.Name = "nuevoToolStripMenuItem1";
            this.nuevoToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.nuevoToolStripMenuItem1.Text = "Nuevo";
            this.nuevoToolStripMenuItem1.Click += new System.EventHandler(this.nuevoToolStripMenuItem1_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.verToolStripMenuItem.Text = "Ver";
            this.verToolStripMenuItem.Click += new System.EventHandler(this.verToolStripMenuItem_Click);
            // 
            // atributosToolStripMenuItem
            // 
            this.atributosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem2,
            this.modificarToolStripMenuItem1,
            this.eliminarToolStripMenuItem1,
            this.deshacerToolStripMenuItem1});
            this.atributosToolStripMenuItem.Name = "atributosToolStripMenuItem";
            this.atributosToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.atributosToolStripMenuItem.Text = "Atributos";
            // 
            // nuevoToolStripMenuItem2
            // 
            this.nuevoToolStripMenuItem2.Name = "nuevoToolStripMenuItem2";
            this.nuevoToolStripMenuItem2.Size = new System.Drawing.Size(125, 22);
            this.nuevoToolStripMenuItem2.Text = "Nuevo";
            this.nuevoToolStripMenuItem2.Click += new System.EventHandler(this.nuevoToolStripMenuItem2_Click);
            // 
            // modificarToolStripMenuItem1
            // 
            this.modificarToolStripMenuItem1.Name = "modificarToolStripMenuItem1";
            this.modificarToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.modificarToolStripMenuItem1.Text = "Modificar";
            this.modificarToolStripMenuItem1.Click += new System.EventHandler(this.modificarToolStripMenuItem1_Click);
            // 
            // eliminarToolStripMenuItem1
            // 
            this.eliminarToolStripMenuItem1.Name = "eliminarToolStripMenuItem1";
            this.eliminarToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.eliminarToolStripMenuItem1.Text = "Eliminar";
            this.eliminarToolStripMenuItem1.Click += new System.EventHandler(this.eliminarToolStripMenuItem1_Click);
            // 
            // deshacerToolStripMenuItem1
            // 
            this.deshacerToolStripMenuItem1.Name = "deshacerToolStripMenuItem1";
            this.deshacerToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.deshacerToolStripMenuItem1.Text = "Ver";
            // 
            // registrosToolStripMenuItem
            // 
            this.registrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem3,
            this.modificarToolStripMenuItem2,
            this.eliminarToolStripMenuItem2,
            this.verToolStripMenuItem1});
            this.registrosToolStripMenuItem.Name = "registrosToolStripMenuItem";
            this.registrosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.registrosToolStripMenuItem.Text = "Registros";
            // 
            // nuevoToolStripMenuItem3
            // 
            this.nuevoToolStripMenuItem3.Name = "nuevoToolStripMenuItem3";
            this.nuevoToolStripMenuItem3.Size = new System.Drawing.Size(125, 22);
            this.nuevoToolStripMenuItem3.Text = "Nuevo";
            this.nuevoToolStripMenuItem3.Click += new System.EventHandler(this.nuevoToolStripMenuItem3_Click);
            // 
            // modificarToolStripMenuItem2
            // 
            this.modificarToolStripMenuItem2.Name = "modificarToolStripMenuItem2";
            this.modificarToolStripMenuItem2.Size = new System.Drawing.Size(125, 22);
            this.modificarToolStripMenuItem2.Text = "Modificar";
            this.modificarToolStripMenuItem2.Click += new System.EventHandler(this.modificarToolStripMenuItem2_Click);
            // 
            // eliminarToolStripMenuItem2
            // 
            this.eliminarToolStripMenuItem2.Name = "eliminarToolStripMenuItem2";
            this.eliminarToolStripMenuItem2.Size = new System.Drawing.Size(125, 22);
            this.eliminarToolStripMenuItem2.Text = "Eliminar";
            this.eliminarToolStripMenuItem2.Click += new System.EventHandler(this.eliminarToolStripMenuItem2_Click);
            // 
            // verToolStripMenuItem1
            // 
            this.verToolStripMenuItem1.Name = "verToolStripMenuItem1";
            this.verToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.verToolStripMenuItem1.Text = "Ver";
            this.verToolStripMenuItem1.Click += new System.EventHandler(this.verToolStripMenuItem1_Click);
            // 
            // relacionesToolStripMenuItem
            // 
            this.relacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearToolStripMenuItem});
            this.relacionesToolStripMenuItem.Name = "relacionesToolStripMenuItem";
            this.relacionesToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.relacionesToolStripMenuItem.Text = "Relaciones";
            // 
            // crearToolStripMenuItem
            // 
            this.crearToolStripMenuItem.Name = "crearToolStripMenuItem";
            this.crearToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.crearToolStripMenuItem.Text = "Crear";
            this.crearToolStripMenuItem.Click += new System.EventHandler(this.crearToolStripMenuItem_Click);
            // 
            // botonPrimaria
            // 
            this.botonPrimaria.Location = new System.Drawing.Point(259, 39);
            this.botonPrimaria.Name = "botonPrimaria";
            this.botonPrimaria.Size = new System.Drawing.Size(65, 23);
            this.botonPrimaria.TabIndex = 53;
            this.botonPrimaria.Text = "L_Primaria";
            this.botonPrimaria.UseVisualStyleBackColor = true;
            this.botonPrimaria.Click += new System.EventHandler(this.botonPrimaria_Click);
            // 
            // L_Secundaria
            // 
            this.L_Secundaria.Location = new System.Drawing.Point(332, 39);
            this.L_Secundaria.Name = "L_Secundaria";
            this.L_Secundaria.Size = new System.Drawing.Size(85, 23);
            this.L_Secundaria.TabIndex = 54;
            this.L_Secundaria.Text = "L_Secundaria";
            this.L_Secundaria.UseVisualStyleBackColor = true;
            this.L_Secundaria.Click += new System.EventHandler(this.L_Secundaria_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(617, 648);
            this.Controls.Add(this.L_Secundaria);
            this.Controls.Add(this.botonPrimaria);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridRegistros);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboEntidad2);
            this.Controls.Add(this.dataGridAtributos);
            this.Controls.Add(this.dataGridEntidades);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Diccionario";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEntidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAtributos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRegistros)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridEntidades;
        private System.Windows.Forms.DataGridView dataGridAtributos;
        private System.Windows.Forms.ComboBox comboEntidad2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridRegistros;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atributosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deshacerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem registrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem relacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreE;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomAtrib;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoAtrib;
        private System.Windows.Forms.DataGridViewTextBoxColumn longAtrib;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoIndice;
        private System.Windows.Forms.Button botonPrimaria;
        private System.Windows.Forms.Button L_Secundaria;
    }
}

