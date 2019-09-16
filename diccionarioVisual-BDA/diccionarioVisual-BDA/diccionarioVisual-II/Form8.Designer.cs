namespace diccionarioVisual_II
{
    partial class Form8
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form8));
            this.label4 = new System.Windows.Forms.Label();
            this.comboEntidad1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboEntidad2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboAtributo1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboAtributo2 = new System.Windows.Forms.ComboBox();
            this.Cancelar = new System.Windows.Forms.Button();
            this.Aceptar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.nombreRelacion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Entidad:";
            // 
            // comboEntidad1
            // 
            this.comboEntidad1.FormattingEnabled = true;
            this.comboEntidad1.Location = new System.Drawing.Point(50, 104);
            this.comboEntidad1.Name = "comboEntidad1";
            this.comboEntidad1.Size = new System.Drawing.Size(100, 21);
            this.comboEntidad1.TabIndex = 52;
            this.comboEntidad1.SelectedIndexChanged += new System.EventHandler(this.comboEntidad1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Entidad:";
            // 
            // comboEntidad2
            // 
            this.comboEntidad2.FormattingEnabled = true;
            this.comboEntidad2.Location = new System.Drawing.Point(179, 104);
            this.comboEntidad2.Name = "comboEntidad2";
            this.comboEntidad2.Size = new System.Drawing.Size(100, 21);
            this.comboEntidad2.TabIndex = 54;
            this.comboEntidad2.SelectedIndexChanged += new System.EventHandler(this.comboEntidad2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Atributo:";
            // 
            // comboAtributo1
            // 
            this.comboAtributo1.FormattingEnabled = true;
            this.comboAtributo1.Location = new System.Drawing.Point(55, 167);
            this.comboAtributo1.Name = "comboAtributo1";
            this.comboAtributo1.Size = new System.Drawing.Size(100, 21);
            this.comboAtributo1.TabIndex = 56;
            this.comboAtributo1.SelectedIndexChanged += new System.EventHandler(this.comboAtributo1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Atributo:";
            // 
            // comboAtributo2
            // 
            this.comboAtributo2.FormattingEnabled = true;
            this.comboAtributo2.Location = new System.Drawing.Point(179, 167);
            this.comboAtributo2.Name = "comboAtributo2";
            this.comboAtributo2.Size = new System.Drawing.Size(100, 21);
            this.comboAtributo2.TabIndex = 58;
            this.comboAtributo2.SelectedIndexChanged += new System.EventHandler(this.comboAtributo2_SelectedIndexChanged);
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(179, 217);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 61;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            // 
            // Aceptar
            // 
            this.Aceptar.Location = new System.Drawing.Point(80, 217);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(75, 23);
            this.Aceptar.TabIndex = 60;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 62;
            this.label5.Text = "Nombre:";
            // 
            // nombreRelacion
            // 
            this.nombreRelacion.Location = new System.Drawing.Point(112, 44);
            this.nombreRelacion.Name = "nombreRelacion";
            this.nombreRelacion.Size = new System.Drawing.Size(100, 20);
            this.nombreRelacion.TabIndex = 63;
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(347, 261);
            this.Controls.Add(this.nombreRelacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboAtributo2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboAtributo1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboEntidad2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboEntidad1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form8";
            this.Text = "Form8";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox comboEntidad1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboEntidad2;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox comboAtributo1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox comboAtributo2;
        public System.Windows.Forms.Button Cancelar;
        public System.Windows.Forms.Button Aceptar;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox nombreRelacion;
    }
}