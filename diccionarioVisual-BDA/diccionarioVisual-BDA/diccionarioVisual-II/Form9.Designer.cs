namespace diccionarioVisual_II
{
    partial class Form9
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form9));
            this.dataGridLlave1 = new System.Windows.Forms.DataGridView();
            this.dato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dirDato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLlave1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridLlave1
            // 
            this.dataGridLlave1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLlave1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dato,
            this.dirDato});
            this.dataGridLlave1.Location = new System.Drawing.Point(65, 31);
            this.dataGridLlave1.Name = "dataGridLlave1";
            this.dataGridLlave1.Size = new System.Drawing.Size(149, 265);
            this.dataGridLlave1.TabIndex = 51;
            // 
            // dato
            // 
            this.dato.HeaderText = "Dat";
            this.dato.Name = "dato";
            this.dato.Width = 50;
            // 
            // dirDato
            // 
            this.dirDato.HeaderText = "Dir";
            this.dirDato.Name = "dirDato";
            this.dirDato.Width = 50;
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(284, 324);
            this.Controls.Add(this.dataGridLlave1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form9";
            this.Text = "Llave Primaria";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLlave1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn dato;
        private System.Windows.Forms.DataGridViewTextBoxColumn dirDato;
        public System.Windows.Forms.DataGridView dataGridLlave1;
    }
}