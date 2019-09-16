namespace editorGrafos_III
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NodoBoton = new System.Windows.Forms.Button();
            this.AristaBoton = new System.Windows.Forms.Button();
            this.FlechaBoton = new System.Windows.Forms.Button();
            this.EliminarBoton = new System.Windows.Forms.Button();
            this.dragBoton = new System.Windows.Forms.Button();
            this.moverBoton = new System.Windows.Forms.Button();
            this.grafoBoton = new System.Windows.Forms.Button();
            this.selecGrafo = new System.Windows.Forms.Button();
            this.identidadGrafo = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(971, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.guardarComoToolStripMenuItem.Text = "Guardar como...";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.guardarComoToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // NodoBoton
            // 
            this.NodoBoton.Location = new System.Drawing.Point(205, 1);
            this.NodoBoton.Name = "NodoBoton";
            this.NodoBoton.Size = new System.Drawing.Size(44, 23);
            this.NodoBoton.TabIndex = 3;
            this.NodoBoton.Text = "Nodo";
            this.NodoBoton.UseVisualStyleBackColor = true;
            this.NodoBoton.Click += new System.EventHandler(this.NodoBoton_Click);
            // 
            // AristaBoton
            // 
            this.AristaBoton.Location = new System.Drawing.Point(301, 1);
            this.AristaBoton.Name = "AristaBoton";
            this.AristaBoton.Size = new System.Drawing.Size(40, 23);
            this.AristaBoton.TabIndex = 7;
            this.AristaBoton.Text = "-------";
            this.AristaBoton.UseVisualStyleBackColor = true;
            this.AristaBoton.Click += new System.EventHandler(this.AristaBoton_Click);
            // 
            // FlechaBoton
            // 
            this.FlechaBoton.Location = new System.Drawing.Point(255, 1);
            this.FlechaBoton.Name = "FlechaBoton";
            this.FlechaBoton.Size = new System.Drawing.Size(40, 23);
            this.FlechaBoton.TabIndex = 6;
            this.FlechaBoton.Text = "------>";
            this.FlechaBoton.UseVisualStyleBackColor = true;
            this.FlechaBoton.Click += new System.EventHandler(this.FlechaBoton_Click);
            // 
            // EliminarBoton
            // 
            this.EliminarBoton.Location = new System.Drawing.Point(347, 0);
            this.EliminarBoton.Name = "EliminarBoton";
            this.EliminarBoton.Size = new System.Drawing.Size(53, 23);
            this.EliminarBoton.TabIndex = 8;
            this.EliminarBoton.Text = "Eliminar";
            this.EliminarBoton.UseVisualStyleBackColor = true;
            this.EliminarBoton.Click += new System.EventHandler(this.EliminarBoton_Click);
            // 
            // dragBoton
            // 
            this.dragBoton.Location = new System.Drawing.Point(407, 1);
            this.dragBoton.Name = "dragBoton";
            this.dragBoton.Size = new System.Drawing.Size(55, 23);
            this.dragBoton.TabIndex = 9;
            this.dragBoton.Text = "Arrastrar";
            this.dragBoton.UseVisualStyleBackColor = true;
            this.dragBoton.Click += new System.EventHandler(this.dragBoton_Click);
            // 
            // moverBoton
            // 
            this.moverBoton.Location = new System.Drawing.Point(468, 1);
            this.moverBoton.Name = "moverBoton";
            this.moverBoton.Size = new System.Drawing.Size(55, 23);
            this.moverBoton.TabIndex = 10;
            this.moverBoton.Text = "Mover";
            this.moverBoton.UseVisualStyleBackColor = true;
            this.moverBoton.Click += new System.EventHandler(this.moverBoton_Click);
            // 
            // grafoBoton
            // 
            this.grafoBoton.Location = new System.Drawing.Point(69, 1);
            this.grafoBoton.Name = "grafoBoton";
            this.grafoBoton.Size = new System.Drawing.Size(44, 23);
            this.grafoBoton.TabIndex = 11;
            this.grafoBoton.Text = "Grafo";
            this.grafoBoton.UseVisualStyleBackColor = true;
            this.grafoBoton.Click += new System.EventHandler(this.grafoBoton_Click);
            // 
            // selecGrafo
            // 
            this.selecGrafo.Location = new System.Drawing.Point(155, 1);
            this.selecGrafo.Name = "selecGrafo";
            this.selecGrafo.Size = new System.Drawing.Size(44, 23);
            this.selecGrafo.TabIndex = 12;
            this.selecGrafo.Text = "Selec";
            this.selecGrafo.UseVisualStyleBackColor = true;
            this.selecGrafo.Click += new System.EventHandler(this.selecGrafo_Click);
            // 
            // identidadGrafo
            // 
            this.identidadGrafo.Location = new System.Drawing.Point(120, 2);
            this.identidadGrafo.Name = "identidadGrafo";
            this.identidadGrafo.Size = new System.Drawing.Size(29, 20);
            this.identidadGrafo.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 461);
            this.Controls.Add(this.identidadGrafo);
            this.Controls.Add(this.selecGrafo);
            this.Controls.Add(this.grafoBoton);
            this.Controls.Add(this.moverBoton);
            this.Controls.Add(this.dragBoton);
            this.Controls.Add(this.EliminarBoton);
            this.Controls.Add(this.AristaBoton);
            this.Controls.Add(this.FlechaBoton);
            this.Controls.Add(this.NodoBoton);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Editor de Grafos";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Button NodoBoton;
        private System.Windows.Forms.Button AristaBoton;
        private System.Windows.Forms.Button FlechaBoton;
        private System.Windows.Forms.Button EliminarBoton;
        private System.Windows.Forms.Button dragBoton;
        private System.Windows.Forms.Button moverBoton;
        private System.Windows.Forms.Button grafoBoton;
        private System.Windows.Forms.Button selecGrafo;
        private System.Windows.Forms.TextBox identidadGrafo;
    }
}

