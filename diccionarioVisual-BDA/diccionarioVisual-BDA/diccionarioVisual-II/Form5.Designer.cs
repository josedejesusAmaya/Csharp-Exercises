namespace diccionarioVisual_II
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.label4 = new System.Windows.Forms.Label();
            this.comboEntidad = new System.Windows.Forms.ComboBox();
            this.comboCL = new System.Windows.Forms.ComboBox();
            this.numericLong = new System.Windows.Forms.NumericUpDown();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textNomAtrib = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Cancelar = new System.Windows.Forms.Button();
            this.Aceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericLong)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Entidad:";
            // 
            // comboEntidad
            // 
            this.comboEntidad.FormattingEnabled = true;
            this.comboEntidad.Location = new System.Drawing.Point(126, 71);
            this.comboEntidad.Name = "comboEntidad";
            this.comboEntidad.Size = new System.Drawing.Size(100, 21);
            this.comboEntidad.TabIndex = 48;
            // 
            // comboCL
            // 
            this.comboCL.FormattingEnabled = true;
            this.comboCL.Location = new System.Drawing.Point(126, 193);
            this.comboCL.Name = "comboCL";
            this.comboCL.Size = new System.Drawing.Size(100, 21);
            this.comboCL.TabIndex = 47;
            // 
            // numericLong
            // 
            this.numericLong.Location = new System.Drawing.Point(126, 155);
            this.numericLong.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericLong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericLong.Name = "numericLong";
            this.numericLong.Size = new System.Drawing.Size(100, 20);
            this.numericLong.TabIndex = 46;
            this.numericLong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboTipo
            // 
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Location = new System.Drawing.Point(126, 115);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(100, 21);
            this.comboTipo.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(83, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "Clave:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Longitud:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(89, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Tipo:";
            // 
            // textNomAtrib
            // 
            this.textNomAtrib.Location = new System.Drawing.Point(126, 30);
            this.textNomAtrib.Name = "textNomAtrib";
            this.textNomAtrib.Size = new System.Drawing.Size(100, 20);
            this.textNomAtrib.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Nombre Atributo:";
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(182, 238);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 51;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            // 
            // Aceptar
            // 
            this.Aceptar.Location = new System.Drawing.Point(83, 238);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(75, 23);
            this.Aceptar.TabIndex = 50;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = true;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(331, 283);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboEntidad);
            this.Controls.Add(this.comboCL);
            this.Controls.Add(this.numericLong);
            this.Controls.Add(this.comboTipo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textNomAtrib);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form5";
            this.Text = "Form5";
            ((System.ComponentModel.ISupportInitialize)(this.numericLong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button Cancelar;
        public System.Windows.Forms.Button Aceptar;
        public System.Windows.Forms.ComboBox comboEntidad;
        public System.Windows.Forms.ComboBox comboCL;
        public System.Windows.Forms.NumericUpDown numericLong;
        public System.Windows.Forms.ComboBox comboTipo;
        public System.Windows.Forms.TextBox textNomAtrib;
    }
}