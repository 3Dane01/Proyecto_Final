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
        int porcentajeBomba1 = 0;
        int porcentajeBomba2 = 0;
        int porcentajeBomba3 = 0;
        int porcentajeBomba4 = 0;
        System.Windows.Forms.ProgressBar currentProgressBar;

        public FormInicio()
        {
            InitializeComponent();
            btnBorrar.Click -= btnBorrar_Click;
            btnBorrar.Click += btnBorrar_Click;
            currentProgressBar = progressBar1; // Inicialmente, usamos la barra de progreso de Bomba 1
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string tipoAbastecimiento1 = comboBoxTipoAbastecimiento.Text;
            string cantidad = txtCantidad.Text ;
            int numeroBomba = 0;

            int cantidadGasolina;
            int cantidadProgreso = 0;

           

            string cantidadGasolin = txtCantidad.Text;


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
            // Si se selecciona "Tanque lleno", establecer la cantidadProgreso en el valor máximo
            if (tipoAbastecimiento1 == "Tanque lleno")
            {
                cantidadProgreso = 100;
            }
            else
            {
                // Si no se selecciona "Tanque lleno", intenta analizar la cantidad ingresada manualmente
                if (!int.TryParse(txtCantidad.Text, out cantidadProgreso))
                {
                    MessageBox.Show("Por favor, ingrese una cantidad válida.");
                    return;
                }
            }

            var abastecimiento = new Cliente
            {
                Nombre = nombre,
                Apellido = apellido,
                TipoAbastecimiento = tipoAbastecimiento1,
                BombaSeleccionada = numeroBomba,
                CantidadAbastecer = cantidadGasolin,
                Fecha = DateTime.Now

            };


            List<Cliente> Abastecimientos1 = new List<Cliente>();
            if (File.Exists("abastecimientos1.json"))
            {
                string json = File.ReadAllText("abastecimientos1.json");

                Abastecimientos1 = JsonConvert.DeserializeObject<List<Cliente>>(json) ?? new List<Cliente>();

            }
            

            Abastecimientos1.Add(abastecimiento);

            string otrojson = JsonConvert.SerializeObject(Abastecimientos1, Formatting.Indented);
            File.WriteAllText("abastecimientos1.json", otrojson);

            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            comboBoxTipoAbastecimiento.SelectedIndex = -1;
            radioButtonBomba1.Checked = false;
            radioButtonBomba2.Checked = false;
            radioButtonBomba3.Checked = false;
            radioButtonBomba4.Checked = false;
            txtCantidad.Text = string.Empty;

            // Actualizar la barra de progreso de la bomba seleccionada
            if (currentProgressBar == progressBar1)
            {
                porcentajeBomba1 += cantidadProgreso;
                progressBar1.Value = Math.Min(100, porcentajeBomba1);
                label7.Text = $"{progressBar1.Value}%";
            }
            else if (currentProgressBar == progressBar2)
            {
                porcentajeBomba2 += cantidadProgreso;
                progressBar2.Value = Math.Min(100, porcentajeBomba2);
                label12.Text = $"{progressBar2.Value}%";
            }
            else if (currentProgressBar == progressBar3)
            {
                porcentajeBomba3 += cantidadProgreso;
                progressBar3.Value = Math.Min(100, porcentajeBomba3);
                label13.Text = $"{progressBar3.Value}%";
            }
            else if (currentProgressBar == progressBar4)
            {
                porcentajeBomba4 += cantidadProgreso;
                progressBar4.Value = Math.Min(100, porcentajeBomba4);
                label14.Text = $"{progressBar4.Value}%";
            }
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
            /*
            radioButtonBomba1.Checked = false;
            radioButtonBomba2.Checked = false;
            radioButtonBomba3.Checked = false;
            radioButtonBomba4.Checked = false;*/

            // Vuelve a cargar los elementos en el combo box
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
            FormIngreso Regresar = new FormIngreso();
            Regresar.Show();
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FormInicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
