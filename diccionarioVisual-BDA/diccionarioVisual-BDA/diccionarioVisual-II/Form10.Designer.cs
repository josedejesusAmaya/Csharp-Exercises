namespace diccionarioVisual_II
{
    partial class Form10
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form10));
            this.dataGridLlave2 = new System.Windows.Forms.DataGridView();
            this.dato2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direc2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direc3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direc4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direc5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLlave2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridLlave2
            // 
            this.dataGridLlave2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLlave2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dato2,
            this.direc1,
            this.direc2,
            this.direc3,
            this.direc4,
            this.direc5});
            this.dataGridLlave2.Location = new System.Drawing.Point(22, 21);
            this.dataGridLlave2.Name = "dataGridLlave2";
            this.dataGridLlave2.Size = new System.Drawing.Size(345, 238);
            this.dataGridLlave2.TabIndex = 52;
            // 
            // dato2
            // 
            this.dato2.HeaderText = "Dat";
            this.dato2.Name = "dato2";
            this.dato2.Width = 50;
            // 
            // direc1
            // 
            this.direc1.HeaderText = "Dir1";
            this.direc1.Name = "direc1";
            this.direc1.Width = 50;
            // 
            // direc2
            // 
            this.direc2.HeaderText = "Dir2";
            this.direc2.Name = "direc2";
            this.direc2.Width = 50;
            // 
            // direc3
            // 
            this.direc3.HeaderText = "Dir3";
            this.direc3.Name = "direc3";
            this.direc3.Width = 50;
            // 
            // direc4
            // 
            this.direc4.HeaderText = "Dir4";
            this.direc4.Name = "direc4";
            this.direc4.Width = 50;
            // 
            // direc5
            // 
            this.direc5.HeaderText = "Dir5";
            this.direc5.Name = "direc5";
            this.direc5.Width = 50;
            // 
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(401, 300);
            this.Controls.Add(this.dataGridLlave2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form10";
            this.Text = "Llave Secundaria";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLlave2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn dato2;
        private System.Windows.Forms.DataGridViewTextBoxColumn direc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn direc2;
        private System.Windows.Forms.DataGridViewTextBoxColumn direc3;
        private System.Windows.Forms.DataGridViewTextBoxColumn direc4;
        private System.Windows.Forms.DataGridViewTextBoxColumn direc5;
        public System.Windows.Forms.DataGridView dataGridLlave2;
    }
}