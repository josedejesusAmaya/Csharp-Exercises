namespace diccionarioVisual_II
{
    partial class Form6
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            this.textNomNuevoEntidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Cancelar = new System.Windows.Forms.Button();
            this.Aceptar = new System.Windows.Forms.Button();
            this.textNomEntid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboEntidad = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textNomNuevoEntidad
            // 
            this.textNomNuevoEntidad.Location = new System.Drawing.Point(112, 76);
            this.textNomNuevoEntidad.Name = "textNomNuevoEntidad";
            this.textNomNuevoEntidad.Size = new System.Drawing.Size(100, 20);
            this.textNomNuevoEntidad.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nuevo nombre:";
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(159, 179);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 13;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            // 
            // Aceptar
            // 
            this.Aceptar.Location = new System.Drawing.Point(60, 179);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(75, 23);
            this.Aceptar.TabIndex = 12;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = true;
            // 
            // textNomEntid
            // 
            this.textNomEntid.Location = new System.Drawing.Point(112, 37);
            this.textNomEntid.Name = "textNomEntid";
            this.textNomEntid.Size = new System.Drawing.Size(100, 20);
            this.textNomEntid.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "Entidad:";
            // 
            // comboEntidad
            // 
            this.comboEntidad.FormattingEnabled = true;
            this.comboEntidad.Location = new System.Drawing.Point(112, 119);
            this.comboEntidad.Name = "comboEntidad";
            this.comboEntidad.Size = new System.Drawing.Size(100, 21);
            this.comboEntidad.TabIndex = 50;
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboEntidad);
            this.Controls.Add(this.textNomNuevoEntidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.textNomEntid);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form6";
            this.Text = "Form6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textNomNuevoEntidad;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button Cancelar;
        public System.Windows.Forms.Button Aceptar;
        public System.Windows.Forms.TextBox textNomEntid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox comboEntidad;
    }
}