namespace proyecto
{
    partial class Forma1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forma1));
            this.boton_cerrar = new System.Windows.Forms.Button();
            this.boton_instruc = new System.Windows.Forms.Button();
            this.boton_jugar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // boton_cerrar
            // 
            this.boton_cerrar.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton_cerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.boton_cerrar.Location = new System.Drawing.Point(721, 410);
            this.boton_cerrar.Name = "boton_cerrar";
            this.boton_cerrar.Size = new System.Drawing.Size(184, 93);
            this.boton_cerrar.TabIndex = 1;
            this.boton_cerrar.Text = "Cerrar";
            this.boton_cerrar.UseVisualStyleBackColor = true;
            this.boton_cerrar.Click += new System.EventHandler(this.boton_cerrar_Click);
            // 
            // boton_instruc
            // 
            this.boton_instruc.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton_instruc.ForeColor = System.Drawing.Color.Red;
            this.boton_instruc.Location = new System.Drawing.Point(504, 410);
            this.boton_instruc.Name = "boton_instruc";
            this.boton_instruc.Size = new System.Drawing.Size(184, 93);
            this.boton_instruc.TabIndex = 2;
            this.boton_instruc.Text = "Instrucciones";
            this.boton_instruc.UseVisualStyleBackColor = true;
            this.boton_instruc.Click += new System.EventHandler(this.boton_instruc_Click);
            // 
            // boton_jugar
            // 
            this.boton_jugar.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton_jugar.ForeColor = System.Drawing.Color.Blue;
            this.boton_jugar.Location = new System.Drawing.Point(287, 410);
            this.boton_jugar.Name = "boton_jugar";
            this.boton_jugar.Size = new System.Drawing.Size(184, 93);
            this.boton_jugar.TabIndex = 4;
            this.boton_jugar.Text = "Jugar";
            this.boton_jugar.UseVisualStyleBackColor = true;
            this.boton_jugar.Click += new System.EventHandler(this.boton_jugar_Click);
            // 
            // Forma1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1084, 571);
            this.Controls.Add(this.boton_jugar);
            this.Controls.Add(this.boton_instruc);
            this.Controls.Add(this.boton_cerrar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Forma1";
            this.Text = "Super_Bombirijilla_Pro_Bomb";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Forma1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button boton_cerrar;
        private System.Windows.Forms.Button boton_instruc;
        private System.Windows.Forms.Button boton_jugar;
    }
}

