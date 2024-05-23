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
        public FormInicio()
        {
            InitializeComponent();
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

            if (radioButtonBomba1.Checked)
            {
                numeroBomba = 1;
            }
            else if (radioButtonBomba2.Checked)
            {
                numeroBomba = 2;
            }
            else if (radioButtonBomba3.Checked)
            {
                numeroBomba = 3;
            }
            else if (radioButtonBomba4.Checked)
            {
                numeroBomba = 4;
            }


            var abastecimiento = new
            {
                Nombre = nombre,
                Apellido = apellido,
                Abastecimiento= tipoAbastecimiento1,
                NumeroBomba = numeroBomba,
                //CantidadGasolina = cantidadGasolina,
                Fecha= DateTime.Now
            };

            List<dynamic> Abastecimientos1 = new List<dynamic>();
            if(File.Exists("abastecimientos1.json"))
            {
                string json = File.ReadAllText("abastecimientos1.json");
                Abastecimientos1= JsonConvert.DeserializeObject<dynamic>(json);
            }
            else
            {
                Abastecimientos1 = new List<dynamic>();
            }

            Abastecimientos1.Add(abastecimiento);

            string otrojson= JsonConvert.SerializeObject(Abastecimientos1, Formatting.Indented);
            File.WriteAllText("abastecimientos1.json", otrojson);

            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            comboBoxTipoAbastecimiento.SelectedIndex = -1;
            radioButtonBomba1.Checked = false;
            radioButtonBomba2.Checked = false;
            radioButtonBomba3.Checked = false;
            radioButtonBomba4.Checked = false;
            txtCantidad.Text = string.Empty;

            MessageBox.Show("Abastecimiento registrado exitosamente.");







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

        private void radioButtonBomba1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
