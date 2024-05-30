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
        const decimal precioL=10M;
        int CANTIDAD_INICIAL = 1000;
        System.Windows.Forms.ProgressBar currentProgressBar;

        public FormInicio()
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            btnBorrar.Click -= btnBorrar_Click;
            btnBorrar.Click += btnBorrar_Click;
            progressBarRegular.Value = progressBarRegular.Maximum;
            progressBarDiesel.Value = progressBarDiesel.Maximum;
            progressBarSuper.Value = progressBarSuper.Maximum;
            progressBarVpower.Value = progressBarVpower.Maximum;

            CargarDatos();
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

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string tipoAbastecimiento1 = comboBoxTipoAbastecimiento.Text;
            string cantidad = txtCantidad.Text;
            string nombreBomba = "";
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
            if (!radioButtonBombaRegular.Checked && !radioButtonBombaSuper.Checked && !radioButtonBombaDiesel.Checked && !radioButtonBombaVPower.Checked)
            {
                MessageBox.Show("Seleccione una bomba.");
                return;
            }

            if (radioButtonBombaRegular.Checked)
            {
                nombreBomba = "Regular";
                currentProgressBar = progressBarRegular;
            }
            else if (radioButtonBombaSuper.Checked)
            {
                nombreBomba = "Super";
                currentProgressBar = progressBarSuper;
            }
            else if (radioButtonBombaDiesel.Checked)
            {
                nombreBomba = "Diesel";
                currentProgressBar = progressBarDiesel;
            }
            else if (radioButtonBombaVPower.Checked)
            {
                nombreBomba = "VPower";
                currentProgressBar = progressBarVpower;
            }

            if (tipoAbastecimiento1 == "Tanque lleno")
            {
                cantidadProgreso = currentProgressBar.Maximum - currentProgressBar.Value;
                NotificarPanelCentral(new Cliente { Nombre = nombre, Apellido = apellido }, cantidadProgreso);

               
                decimal precioPorLitro = ObtenerPrecioDelDia();
                decimal totalPagar = cantidadProgreso * precioPorLitro;
                MessageBox.Show($"Total a pagar: Q{totalPagar}");
            }
            else
            {
                if (!decimal.TryParse(txtCantidad.Text, out decimal montoPagado))
                {
                    MessageBox.Show("Por favor, ingrese una cantidad válida.");
                    return;
                }

                cantidadProgreso = (int)CalcularCantidadGasolina(montoPagado);

                if (cantidadProgreso > currentProgressBar.Value)
                {
                    int cantidadRestante = cantidadProgreso - currentProgressBar.Value;
                    ActualizarRegistroPrepago(new Cliente
                    {
                        Nombre = nombre,
                        Apellido = apellido,
                        TipoAbastecimiento = tipoAbastecimiento1,
                        BombaSeleccionada = nombreBomba,
                        CantidadAbastecer = cantidadRestante.ToString(),
                        Fecha = DateTime.Now
                    }, cantidadRestante);
                    cantidadProgreso = currentProgressBar.Value;
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
                BombaSeleccionada = nombreBomba,
                CantidadAbastecer = cantidad,
                Fecha = DateTime.Now
            };

            List<Cliente> abastecimientos1 = LeerArchivoAbastecimientos();
            abastecimientos1.Add(abastecimiento);
            GuardarArchivoAbastecimientos(abastecimientos1);

            // Actualizar barra de progreso y labels
            ReducirBarraDeProgreso(cantidadProgreso);

            MessageBox.Show("Información Guardada");
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            comboBoxTipoAbastecimiento.SelectedIndex = -1;
            radioButtonBombaRegular.Checked = false;
            radioButtonBombaSuper.Checked = false;
            radioButtonBombaDiesel.Checked = false;
            radioButtonBombaVPower.Checked = false;
            txtCantidad.Text = string.Empty;

            ObtenerPrecioDelDia();

        }

        private decimal ObtenerPrecioDelDia()
        {
       
            decimal precioPorLitro = 10M;

            return precioPorLitro;
        }


        private void ReducirBarraDeProgreso(int cantidad)
        {
            if (currentProgressBar != null)
            {
                int nuevaCantidad = currentProgressBar.Value - cantidad;
                currentProgressBar.Value = Math.Max(0, nuevaCantidad);

                switch (currentProgressBar.Name)
                {
                    case "progressBarRegular":
                        label7.Text = $"{currentProgressBar.Value} lts";
                        break;
                    case "progressBarDiesel":
                        label12.Text = $"{currentProgressBar.Value} lts";
                        break;
                    case "progressBarSuper":
                        label13.Text = $"{currentProgressBar.Value} lts";
                        break;
                    case "progressBarVpower":
                        label14.Text = $"{currentProgressBar.Value} lts";
                        break;
                    default:
                        break;
                }
            }
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

        private decimal CalcularCantidadGasolina(decimal montoPagado)
        {
            return montoPagado / precioL;
        }

        private void ActualizarRegistroPrepago(Cliente cliente, int cantidadRestante)
        {
            List<Cliente> clientes = LeerArchivoAbastecimientos();
            var clienteExistente = clientes.FirstOrDefault(c => c.Nombre == cliente.Nombre && c.Apellido == cliente.Apellido && c.Fecha.Date == cliente.Fecha.Date);

            if (clienteExistente != null)
            {
                clienteExistente.CantidadAbastecer = cantidadRestante.ToString();
            }
            else
            {
                cliente.CantidadAbastecer = cantidadRestante.ToString();
                clientes.Add(cliente);
            }

            GuardarArchivoAbastecimientos(clientes);
        }


        private void NotificarPanelCentral(Cliente cliente, int cantidadServida)
        {
            MessageBox.Show($"Cliente: {cliente.Nombre} {cliente.Apellido}, Cantidad Servida: {cantidadServida} litros.");
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

            if (currentProgressBar == progressBarRegular)
            {
                currentProgressBar = progressBarDiesel;
            }
            else if (currentProgressBar == progressBarDiesel)
            {
                currentProgressBar = progressBarSuper;
            }
            else if (currentProgressBar == progressBarSuper)
            {
                currentProgressBar = progressBarVpower;
            }
            else
            {
                currentProgressBar = progressBarRegular;
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            GuardarDatos();
            FormIngreso regresar = new FormIngreso();
            regresar.Show();
            this.Hide();
        }
        private void AgregarMonto(string monto)
        {
            txtCantidad.Text += monto;
        }

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
                    case "Regular":
                        progressBarRegular.Value = Math.Max(0, progressBarRegular.Value - int.Parse(abastecimiento.CantidadAbastecer));
                        label7.Text = $"{progressBarRegular.Value} lts";
                        break;
                    case "Diesel":
                        progressBarDiesel.Value = Math.Max(0, progressBarDiesel.Value - int.Parse(abastecimiento.CantidadAbastecer));
                        label12.Text = $"{progressBarDiesel.Value} lts";
                        break;
                    case "Super":
                        progressBarSuper.Value = Math.Max(0, progressBarSuper.Value - int.Parse(abastecimiento.CantidadAbastecer));
                        label13.Text = $"{progressBarSuper.Value} lts";
                        break;
                    case "VPower":
                        progressBarVpower.Value = Math.Max(0, progressBarVpower.Value - int.Parse(abastecimiento.CantidadAbastecer));
                        label14.Text = $"{progressBarVpower.Value} lts";
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

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
