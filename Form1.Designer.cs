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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "LLENADO DE BOMBAS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Apellido:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tipo de abastecimiento:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(227, 122);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(150, 22);
            this.txtNombre.TabIndex = 5;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(227, 153);
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
            this.comboBoxTipoAbastecimiento.Location = new System.Drawing.Point(227, 186);
            this.comboBoxTipoAbastecimiento.Name = "comboBoxTipoAbastecimiento";
            this.comboBoxTipoAbastecimiento.Size = new System.Drawing.Size(150, 24);
            this.comboBoxTipoAbastecimiento.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Cantidad a Abastecer:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(227, 225);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(150, 22);
            this.txtCantidad.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(504, 213);
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
            this.radioButtonBomba1.Location = new System.Drawing.Point(16, 29);
            this.radioButtonBomba1.Name = "radioButtonBomba1";
            this.radioButtonBomba1.Size = new System.Drawing.Size(103, 20);
            this.radioButtonBomba1.TabIndex = 13;
            this.radioButtonBomba1.TabStop = true;
            this.radioButtonBomba1.Text = "radioButton1";
            this.radioButtonBomba1.UseVisualStyleBackColor = true;
            // 
            // radioButtonBomba2
            // 
            this.radioButtonBomba2.AutoSize = true;
            this.radioButtonBomba2.Location = new System.Drawing.Point(16, 57);
            this.radioButtonBomba2.Name = "radioButtonBomba2";
            this.radioButtonBomba2.Size = new System.Drawing.Size(103, 20);
            this.radioButtonBomba2.TabIndex = 14;
            this.radioButtonBomba2.TabStop = true;
            this.radioButtonBomba2.Text = "radioButton2";
            this.radioButtonBomba2.UseVisualStyleBackColor = true;
            // 
            // radioButtonBomba3
            // 
            this.radioButtonBomba3.AutoSize = true;
            this.radioButtonBomba3.Location = new System.Drawing.Point(16, 83);
            this.radioButtonBomba3.Name = "radioButtonBomba3";
            this.radioButtonBomba3.Size = new System.Drawing.Size(103, 20);
            this.radioButtonBomba3.TabIndex = 15;
            this.radioButtonBomba3.TabStop = true;
            this.radioButtonBomba3.Text = "radioButton3";
            this.radioButtonBomba3.UseVisualStyleBackColor = true;
            // 
            // radioButtonBomba4
            // 
            this.radioButtonBomba4.AutoSize = true;
            this.radioButtonBomba4.Location = new System.Drawing.Point(16, 109);
            this.radioButtonBomba4.Name = "radioButtonBomba4";
            this.radioButtonBomba4.Size = new System.Drawing.Size(103, 20);
            this.radioButtonBomba4.TabIndex = 16;
            this.radioButtonBomba4.TabStop = true;
            this.radioButtonBomba4.Text = "radioButton4";
            this.radioButtonBomba4.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Fecha";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonBomba1);
            this.groupBox1.Controls.Add(this.radioButtonBomba2);
            this.groupBox1.Controls.Add(this.radioButtonBomba3);
            this.groupBox1.Controls.Add(this.radioButtonBomba4);
            this.groupBox1.Location = new System.Drawing.Point(177, 269);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 158);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione la bomba";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 457);
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
    }
}

