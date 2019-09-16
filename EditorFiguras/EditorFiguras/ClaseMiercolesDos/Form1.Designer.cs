namespace ClaseMiercolesDos
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
            this.red = new System.Windows.Forms.NumericUpDown();
            this.green = new System.Windows.Forms.NumericUpDown();
            this.blue = new System.Windows.Forms.NumericUpDown();
            this.alpha = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.alpha2 = new System.Windows.Forms.NumericUpDown();
            this.red2 = new System.Windows.Forms.NumericUpDown();
            this.green2 = new System.Windows.Forms.NumericUpDown();
            this.blue2 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alpha2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.red2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.green2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blue2)).BeginInit();
            this.SuspendLayout();
            // 
            // red
            // 
            this.red.Location = new System.Drawing.Point(52, 367);
            this.red.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.red.Name = "red";
            this.red.Size = new System.Drawing.Size(46, 20);
            this.red.TabIndex = 0;
            // 
            // green
            // 
            this.green.Location = new System.Drawing.Point(52, 393);
            this.green.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.green.Name = "green";
            this.green.Size = new System.Drawing.Size(46, 20);
            this.green.TabIndex = 1;
            // 
            // blue
            // 
            this.blue.Location = new System.Drawing.Point(52, 419);
            this.blue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.blue.Name = "blue";
            this.blue.Size = new System.Drawing.Size(46, 20);
            this.blue.TabIndex = 2;
            // 
            // alpha
            // 
            this.alpha.Location = new System.Drawing.Point(52, 341);
            this.alpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.alpha.Name = "alpha";
            this.alpha.Size = new System.Drawing.Size(46, 20);
            this.alpha.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(170, 343);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(75, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Alpha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "R";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 400);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "G";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 426);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "V";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Relleno:";
            // 
            // alpha2
            // 
            this.alpha2.Location = new System.Drawing.Point(105, 341);
            this.alpha2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.alpha2.Name = "alpha2";
            this.alpha2.Size = new System.Drawing.Size(46, 20);
            this.alpha2.TabIndex = 11;
            // 
            // red2
            // 
            this.red2.Location = new System.Drawing.Point(105, 367);
            this.red2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.red2.Name = "red2";
            this.red2.Size = new System.Drawing.Size(46, 20);
            this.red2.TabIndex = 12;
            // 
            // green2
            // 
            this.green2.Location = new System.Drawing.Point(104, 393);
            this.green2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.green2.Name = "green2";
            this.green2.Size = new System.Drawing.Size(46, 20);
            this.green2.TabIndex = 13;
            // 
            // blue2
            // 
            this.blue2.Location = new System.Drawing.Point(104, 419);
            this.blue2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.blue2.Name = "blue2";
            this.blue2.Size = new System.Drawing.Size(46, 20);
            this.blue2.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(102, 308);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Linea:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(167, 308);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Figura:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(167, 374);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Acción:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(170, 400);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(75, 21);
            this.comboBox2.TabIndex = 18;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 466);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.blue2);
            this.Controls.Add(this.green2);
            this.Controls.Add(this.red2);
            this.Controls.Add(this.alpha2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.alpha);
            this.Controls.Add(this.blue);
            this.Controls.Add(this.green);
            this.Controls.Add(this.red);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alpha2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.red2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.green2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blue2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown red;
        private System.Windows.Forms.NumericUpDown green;
        private System.Windows.Forms.NumericUpDown blue;
        private System.Windows.Forms.NumericUpDown alpha;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown alpha2;
        private System.Windows.Forms.NumericUpDown red2;
        private System.Windows.Forms.NumericUpDown green2;
        private System.Windows.Forms.NumericUpDown blue2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}

