namespace GDI
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
            this.nodoB = new System.Windows.Forms.Button();
            this.flecha = new System.Windows.Forms.Button();
            this.arista = new System.Windows.Forms.Button();
            this.deleteB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nodoB
            // 
            this.nodoB.Location = new System.Drawing.Point(30, 3);
            this.nodoB.Name = "nodoB";
            this.nodoB.Size = new System.Drawing.Size(41, 23);
            this.nodoB.TabIndex = 0;
            this.nodoB.Text = "Nodo";
            this.nodoB.UseVisualStyleBackColor = true;
            this.nodoB.Click += new System.EventHandler(this.nodoB_Click);
            // 
            // flecha
            // 
            this.flecha.Location = new System.Drawing.Point(77, 2);
            this.flecha.Name = "flecha";
            this.flecha.Size = new System.Drawing.Size(46, 23);
            this.flecha.TabIndex = 1;
            this.flecha.Text = "-------->";
            this.flecha.UseVisualStyleBackColor = true;
            this.flecha.Click += new System.EventHandler(this.flecha_Click);
            // 
            // arista
            // 
            this.arista.Location = new System.Drawing.Point(130, 2);
            this.arista.Name = "arista";
            this.arista.Size = new System.Drawing.Size(46, 23);
            this.arista.TabIndex = 2;
            this.arista.Text = "--------";
            this.arista.UseVisualStyleBackColor = true;
            this.arista.Click += new System.EventHandler(this.arista_Click);
            // 
            // deleteB
            // 
            this.deleteB.Location = new System.Drawing.Point(183, 3);
            this.deleteB.Name = "deleteB";
            this.deleteB.Size = new System.Drawing.Size(57, 23);
            this.deleteB.TabIndex = 3;
            this.deleteB.Text = "Delete";
            this.deleteB.UseVisualStyleBackColor = true;
            this.deleteB.Click += new System.EventHandler(this.deleteB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 261);
            this.Controls.Add(this.deleteB);
            this.Controls.Add(this.arista);
            this.Controls.Add(this.flecha);
            this.Controls.Add(this.nodoB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nodoB;
        private System.Windows.Forms.Button flecha;
        private System.Windows.Forms.Button arista;
        private System.Windows.Forms.Button deleteB;
    }
}

