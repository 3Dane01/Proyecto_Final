namespace Proyecto_Final
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.comboBoxTipoAbastecimiento = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButtonBomba1 = new System.Windows.Forms.RadioButton();
            this.radioButtonBomba2 = new System.Windows.Forms.RadioButton();
            this.radioButtonBomba3 = new System.Windows.Forms.RadioButton();
            this.radioButtonBomba4 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.progressBar4 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monospac821 BT", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "LLENADO DE BOMBAS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Apellido:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tipo de abastecimiento:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(349, 142);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(150, 22);
            this.txtNombre.TabIndex = 5;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(349, 179);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(150, 22);
            this.txtApellido.TabIndex = 6;
            // 
            // comboBoxTipoAbastecimiento
            // 
            this.comboBoxTipoAbastecimiento.FormattingEnabled = true;
            this.comboBoxTipoAbastecimiento.Items.AddRange(new object[] {
            "Prepago",
            "Tanque Lleno"});
            this.comboBoxTipoAbastecimiento.Location = new System.Drawing.Point(349, 214);
            this.comboBoxTipoAbastecimiento.Name = "comboBoxTipoAbastecimiento";
            this.comboBoxTipoAbastecimiento.Size = new System.Drawing.Size(150, 24);
            this.comboBoxTipoAbastecimiento.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Cantidad a Abastecer:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(349, 251);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(150, 22);
            this.txtCantidad.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(227, 482);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 51);
            this.button1.TabIndex = 12;
            this.button1.Text = "Iniciar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButtonBomba1
            // 
            this.radioButtonBomba1.AutoSize = true;
            this.radioButtonBomba1.Location = new System.Drawing.Point(16, 41);
            this.radioButtonBomba1.Name = "radioButtonBomba1";
            this.radioButtonBomba1.Size = new System.Drawing.Size(102, 22);
            this.radioButtonBomba1.TabIndex = 13;
            this.radioButtonBomba1.TabStop = true;
            this.radioButtonBomba1.Text = "BOMBA 1";
            this.radioButtonBomba1.UseVisualStyleBackColor = true;
            // 
            // radioButtonBomba2
            // 
            this.radioButtonBomba2.AutoSize = true;
            this.radioButtonBomba2.Location = new System.Drawing.Point(355, 41);
            this.radioButtonBomba2.Name = "radioButtonBomba2";
            this.radioButtonBomba2.Size = new System.Drawing.Size(102, 22);
            this.radioButtonBomba2.TabIndex = 14;
            this.radioButtonBomba2.TabStop = true;
            this.radioButtonBomba2.Text = "BOMBA 2";
            this.radioButtonBomba2.UseVisualStyleBackColor = true;
            // 
            // radioButtonBomba3
            // 
            this.radioButtonBomba3.AutoSize = true;
            this.radioButtonBomba3.Location = new System.Drawing.Point(16, 121);
            this.radioButtonBomba3.Name = "radioButtonBomba3";
            this.radioButtonBomba3.Size = new System.Drawing.Size(102, 22);
            this.radioButtonBomba3.TabIndex = 15;
            this.radioButtonBomba3.TabStop = true;
            this.radioButtonBomba3.Text = "BOMBA 3";
            this.radioButtonBomba3.UseVisualStyleBackColor = true;
            // 
            // radioButtonBomba4
            // 
            this.radioButtonBomba4.AutoSize = true;
            this.radioButtonBomba4.Location = new System.Drawing.Point(355, 121);
            this.radioButtonBomba4.Name = "radioButtonBomba4";
            this.radioButtonBomba4.Size = new System.Drawing.Size(102, 22);
            this.radioButtonBomba4.TabIndex = 16;
            this.radioButtonBomba4.TabStop = true;
            this.radioButtonBomba4.Text = "BOMBA 4";
            this.radioButtonBomba4.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1140, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 22);
            this.label7.TabIndex = 18;
            this.label7.Text = "FECHA:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.radioButtonBomba1);
            this.groupBox1.Controls.Add(this.radioButtonBomba2);
            this.groupBox1.Controls.Add(this.radioButtonBomba3);
            this.groupBox1.Controls.Add(this.radioButtonBomba4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(58, 297);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 158);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione la Bomba";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(602, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 620);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Monospac821 BT", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(729, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 21);
            this.label6.TabIndex = 21;
            this.label6.Text = "BOMBA 1";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Monospac821 BT", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(729, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 21);
            this.label8.TabIndex = 22;
            this.label8.Text = "BOMBA 2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Monospac821 BT", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(729, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 21);
            this.label9.TabIndex = 23;
            this.label9.Text = "BOMBA 3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Monospac821 BT", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(729, 310);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 21);
            this.label10.TabIndex = 24;
            this.label10.Text = "BOMBA 4";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(841, 123);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(303, 23);
            this.progressBar1.TabIndex = 25;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(841, 185);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(303, 23);
            this.progressBar2.TabIndex = 26;
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(841, 246);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(303, 23);
            this.progressBar3.TabIndex = 27;
            // 
            // progressBar4
            // 
            this.progressBar4.Location = new System.Drawing.Point(841, 310);
            this.progressBar4.Name = "progressBar4";
            this.progressBar4.Size = new System.Drawing.Size(303, 23);
            this.progressBar4.TabIndex = 28;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1338, 621);
            this.Controls.Add(this.progressBar4);
            this.Controls.Add(this.progressBar3);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxTipoAbastecimiento);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.ComboBox comboBoxTipoAbastecimiento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButtonBomba1;
        private System.Windows.Forms.RadioButton radioButtonBomba2;
        private System.Windows.Forms.RadioButton radioButtonBomba3;
        private System.Windows.Forms.RadioButton radioButtonBomba4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.ProgressBar progressBar4;
    }
}

