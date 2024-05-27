using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Proyecto_Final
{
    //List<Cliente> clientes = new List<Cliente>();
    public partial class FormInicio : Form
    {

        int CANTIDAD_INICIAL = 1000;
        System.Windows.Forms.ProgressBar currentProgressBar;

        public FormInicio()
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            btnBorrar.Click -= btnBorrar_Click;
            btnBorrar.Click += btnBorrar_Click;
            progressBar1.Value = progressBar1.Maximum;
            progressBar2.Value = progressBar2.Maximum;
            progressBar3.Value = progressBar3.Maximum;
            progressBar4.Value = progressBar4.Maximum;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatos();

        }
        private void FormInicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            GuardarDatos();
            Application.Exit();
        }



        private int ObtenerCantidadIngresada()
        {
            int cantidad;
            if (!int.TryParse(txtCantidad.Text, out cantidad))
            {
                MessageBox.Show("Por favor, ingrese una cantidad válida.");
                return 0;
            }
            return cantidad;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string tipoAbastecimiento1 = comboBoxTipoAbastecimiento.Text;
            string cantidad = txtCantidad.Text;
            int numeroBomba = 0;

            int cantidadGasolina;
            int cantidadProgreso = 0;

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Ingrese un nombre");
                txtNombre.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(apellido))
            {
                MessageBox.Show("Ingrese un apellido");
                txtApellido.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(tipoAbastecimiento1))
            {
                MessageBox.Show("Ingrese un tipo de abastecimiento.");
                comboBoxTipoAbastecimiento.Focus();
                return;
            }
            if (!radioButtonBomba1.Checked && !radioButtonBomba2.Checked && !radioButtonBomba3.Checked && !radioButtonBomba4.Checked)
            {
                MessageBox.Show("Seleccione una bomba.");
                return;
            }

            if (radioButtonBomba1.Checked)
            {
                numeroBomba = 1;
                currentProgressBar = progressBar1;
            }
            else if (radioButtonBomba2.Checked)
            {
                numeroBomba = 2;
                currentProgressBar = progressBar2;
            }
            else if (radioButtonBomba3.Checked)
            {
                numeroBomba = 3;
                currentProgressBar = progressBar3;
            }
            else if (radioButtonBomba4.Checked)
            {
                numeroBomba = 4;
                currentProgressBar = progressBar4;
            }
            if (tipoAbastecimiento1 == "Tanque lleno")
            {
                cantidadProgreso = 100;
            }
            else
            {
                if (!int.TryParse(txtCantidad.Text, out cantidadProgreso))
                {
                    MessageBox.Show("Por favor, ingrese una cantidad válida.");
                    return;
                }
            }

            if (ObtenerCantidadIngresada() > currentProgressBar.Value)
            {
                MessageBox.Show("No se puede ingresar esa cantidad, el tanque ya está vacío.");
                return;
            }


            var abastecimiento = new Cliente
            {
                Nombre = nombre,
                Apellido = apellido,
                TipoAbastecimiento = tipoAbastecimiento1,
                BombaSeleccionada = numeroBomba,
                CantidadAbastecer = cantidad,
                Fecha = DateTime.Now
            };

            List<Cliente> abastecimientos1 = LeerArchivoAbastecimientos();
            abastecimientos1.Add(abastecimiento);
            GuardarArchivoAbastecimientos(abastecimientos1);

            if (radioButtonBomba1.Checked)
            {
                progressBar1.Value = Math.Max(0, progressBar1.Value - ObtenerCantidadIngresada());
                label7.Text = $"{progressBar1.Value}%";
            }
            else if (radioButtonBomba2.Checked)
            {
                progressBar2.Value = Math.Max(0, progressBar2.Value - ObtenerCantidadIngresada());
                label12.Text = $"{progressBar2.Value}%";
            }
            else if (radioButtonBomba3.Checked)
            {
                progressBar3.Value = Math.Max(0, progressBar3.Value - ObtenerCantidadIngresada());
                label13.Text = $"{progressBar3.Value}%";
            }
            else if (radioButtonBomba4.Checked)
            {
                progressBar4.Value = Math.Max(0, progressBar4.Value - ObtenerCantidadIngresada());
                label14.Text = $"{progressBar4.Value}%";
            }

            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            comboBoxTipoAbastecimiento.SelectedIndex = -1;
            radioButtonBomba1.Checked = false;
            radioButtonBomba2.Checked = false;
            radioButtonBomba3.Checked = false;
            radioButtonBomba4.Checked = false;
            txtCantidad.Text = string.Empty;
        }
      

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCantidad.Clear();

            comboBoxTipoAbastecimiento.Items.Clear();
            comboBoxTipoAbastecimiento.Text = "";
            comboBoxTipoAbastecimiento.Items.Add("Prepago");
            comboBoxTipoAbastecimiento.Items.Add("Tanque lleno");

            if (currentProgressBar == progressBar1)
            {
                currentProgressBar = progressBar2;
            }
            else if (currentProgressBar == progressBar2)
            {
                currentProgressBar = progressBar3;
            }
            else if (currentProgressBar == progressBar3)
            {
                currentProgressBar = progressBar4;
            }
            else
            {
                currentProgressBar = progressBar1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GuardarDatos();
            FormIngreso regresar = new FormIngreso();
            regresar.Show();
            this.Hide();
        }

        /*
        private void GuardarAbast()
        {
            string json = JsonConvert.SerializeObject(abas, Formatting.Indented);
            File.WriteAllText("abastecimientos.json", json);
        }
        */

        private void button4_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "1";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "2";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "3";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "4";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "5";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "6";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "7";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "8";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "9";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "0";
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonBomba1_CheckedChanged(object sender, EventArgs e)

        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCantidad.Text = string.Empty;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCantidad.Text))
            {
                txtCantidad.Text = txtCantidad.Text.Substring(0, txtCantidad.Text.Length - 1);
            }

        }

        private void GuardarDatos()
        {
            List<Cliente> abastecimientos = LeerArchivoAbastecimientos();
            GuardarArchivoAbastecimientos(abastecimientos);
        }
        private void CargarDatos()
        {
            List<Cliente> abastecimientos = LeerArchivoAbastecimientos();
            foreach (var abastecimiento in abastecimientos)
            {
                switch (abastecimiento.BombaSeleccionada)
                {
                    case 1:
                        progressBar1.Value = Math.Max(0, progressBar1.Value - int.Parse(abastecimiento.CantidadAbastecer));
                        label7.Text = $"{progressBar1.Value}%";
                        break;
                    case 2:
                        progressBar2.Value = Math.Max(0, progressBar2.Value - int.Parse(abastecimiento.CantidadAbastecer));
                        label12.Text = $"{progressBar2.Value}%";
                        break;
                    case 3:
                        progressBar3.Value = Math.Max(0, progressBar3.Value - int.Parse(abastecimiento.CantidadAbastecer));
                        label13.Text = $"{progressBar3.Value}%";
                        break;
                    case 4:
                        progressBar4.Value = Math.Max(0, progressBar4.Value - int.Parse(abastecimiento.CantidadAbastecer));
                        label14.Text = $"{progressBar4.Value}%";
                        break;
                }
            }
        }
        private List<Cliente> LeerArchivoAbastecimientos()
        {
            if (File.Exists("abastecimientos1.json"))
            {
                string json = File.ReadAllText("abastecimientos1.json");
                return JsonConvert.DeserializeObject<List<Cliente>>(json) ?? new List<Cliente>();
            }
            return new List<Cliente>();
        }

        private void GuardarArchivoAbastecimientos(List<Cliente> abastecimientos)
        {
            string json = JsonConvert.SerializeObject(abastecimientos, Formatting.Indented);
            File.WriteAllText("abastecimientos1.json", json);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        
        private void buttonCierreCaja_Click(object sender, EventArgs e)
        {
            GuardarDatos();
            FormInformes formCrear2 = new FormInformes();
            formCrear2.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
