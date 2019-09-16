namespace DiccionarioForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir_Atributos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir_Entidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir_Datos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir_Sig_Entidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.txtEntidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView_Entidad = new System.Windows.Forms.ListView();
            this.nombreEntidad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dir_atrib = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dirEntidad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dirDatos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.aptSig = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Dir_Atributos,
            this.Dir_Entidad,
            this.Dir_Datos,
            this.Dir_Sig_Entidad});
            this.dataGridView1.Location = new System.Drawing.Point(33, 175);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(290, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Dir_Atributos
            // 
            this.Dir_Atributos.HeaderText = "Dir_Atributos";
            this.Dir_Atributos.Name = "Dir_Atributos";
            // 
            // Dir_Entidad
            // 
            this.Dir_Entidad.HeaderText = "Dir_Entidad";
            this.Dir_Entidad.Name = "Dir_Entidad";
            // 
            // Dir_Datos
            // 
            this.Dir_Datos.HeaderText = "Dir_Datos";
            this.Dir_Datos.Name = "Dir_Datos";
            // 
            // Dir_Sig_Entidad
            // 
            this.Dir_Sig_Entidad.HeaderText = "Dir_Sig_Entidad";
            this.Dir_Sig_Entidad.Name = "Dir_Sig_Entidad";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Nuevo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(131, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Modificar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(236, 96);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Eliminar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(464, 96);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Grabar";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(588, 96);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Deshacer";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // txtEntidad
            // 
            this.txtEntidad.Location = new System.Drawing.Point(106, 27);
            this.txtEntidad.Name = "txtEntidad";
            this.txtEntidad.Size = new System.Drawing.Size(100, 20);
            this.txtEntidad.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Entidad:";
            // 
            // listView_Entidad
            // 
            this.listView_Entidad.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nombreEntidad,
            this.dir_atrib,
            this.dirDatos,
            this.dirEntidad,
            this.aptSig});
            this.listView_Entidad.Location = new System.Drawing.Point(341, 175);
            this.listView_Entidad.Name = "listView_Entidad";
            this.listView_Entidad.Size = new System.Drawing.Size(364, 87);
            this.listView_Entidad.TabIndex = 8;
            this.listView_Entidad.UseCompatibleStateImageBehavior = false;
            this.listView_Entidad.View = System.Windows.Forms.View.Details;
            this.listView_Entidad.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // nombreEntidad
            // 
            this.nombreEntidad.Text = "Nombre";
            // 
            // dir_atrib
            // 
            this.dir_atrib.Text = "Dir_Atributos";
            // 
            // dirEntidad
            // 
            this.dirEntidad.DisplayIndex = 2;
            this.dirEntidad.Text = "Dir_Entidad";
            // 
            // dirDatos
            // 
            this.dirDatos.DisplayIndex = 3;
            this.dirDatos.Text = "Dir_Datos";
            // 
            // aptSig
            // 
            this.aptSig.Text = "Apuntador_Sig";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(418, 138);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(105, 31);
            this.button6.TabIndex = 9;
            this.button6.Text = "imprimeEntidades";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 354);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.listView_Entidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEntidad);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dir_Atributos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dir_Entidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dir_Datos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dir_Sig_Entidad;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtEntidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView_Entidad;
        private System.Windows.Forms.ColumnHeader nombreEntidad;
        private System.Windows.Forms.ColumnHeader dir_atrib;
        private System.Windows.Forms.ColumnHeader dirDatos;
        private System.Windows.Forms.ColumnHeader dirEntidad;
        private System.Windows.Forms.ColumnHeader aptSig;
        private System.Windows.Forms.Button button6;
    }
}

