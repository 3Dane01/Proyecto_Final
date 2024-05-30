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
        private Timer reductionTimer;
        private int reductionAmount;


        private Timer timer;
        private int cantidadAConsumir;
        private int cantidadReducidaPorTick;

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

            timer = new Timer();
            timer.Interval = 1000; // Intervalo de 1 segundo (1000 ms)
            timer.Tick += Timer_Tick;

            comboBoxTipoAbastecimiento.SelectedIndexChanged += comboBoxTipoAbastecimiento_SelectedIndexChanged;

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

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (cantidadAConsumir > 0)
            {
                int decremento = Math.Min(cantidadReducidaPorTick, cantidadAConsumir);
                currentProgressBar.Value = Math.Max(0, currentProgressBar.Value - decremento);
                cantidadAConsumir -= decremento;

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
                }

                if (cantidadAConsumir == 0)
                {
                    List<Cliente> abastecimientos1 = LeerArchivoAbastecimientos();
                    var cliente = abastecimientos1.FirstOrDefault(c => c.BombaSeleccionada == currentProgressBar.Name);
                    if (cliente != null)
                    {
                        cliente.CantidadRestante = currentProgressBar.Value;
                        GuardarArchivoAbastecimientos(abastecimientos1);
                    }
                    timer.Stop();
                }
            }
        }





        private void button1_Click(object sender, EventArgs e)
        {

            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string tipoAbastecimiento1 = comboBoxTipoAbastecimiento.Text;
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

            if (!int.TryParse(txtCantidad.Text, out cantidadProgreso))
            {
                MessageBox.Show("Por favor, ingrese una cantidad válida.");
                return;
            }

            int cantidadDisponible = currentProgressBar.Value;
            int cantidadFaltante = cantidadProgreso - cantidadDisponible;

            if (cantidadFaltante > 0)
            {
                cantidadProgreso = cantidadDisponible;
                MessageBox.Show($"No hay suficiente combustible. Se entregaron {cantidadDisponible} lts y faltaron {cantidadFaltante} lts.");
            }
            else
            {
                cantidadFaltante = 0;
            }

            var abastecimiento = new Cliente
            {
                Nombre = nombre,
                Apellido = apellido,
                TipoAbastecimiento = tipoAbastecimiento1,
                BombaSeleccionada = nombreBomba,
                CantidadAbastecer = cantidadProgreso.ToString(),
                Fecha = DateTime.Now
            };

            List<Cliente> abastecimientos1 = LeerArchivoAbastecimientos();
            abastecimientos1.Add(abastecimiento);
            GuardarArchivoAbastecimientos(abastecimientos1);

            int cantidadCombustible = ObtenerCantidadIngresada();
            int costoPorLitro = 10; // Costo por litro en quetzales
            int cantidadAPagar = cantidadCombustible * costoPorLitro;

            // Muestra la cantidad a pagar en el label
            label19.Text = cantidadAPagar.ToString() + " Q.";

            ReducirBarraDeProgreso(cantidadProgreso);

            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            comboBoxTipoAbastecimiento.SelectedIndex = -1;
            radioButtonBombaRegular.Checked = false;
            radioButtonBombaSuper.Checked = false;
            radioButtonBombaDiesel.Checked = false;
            radioButtonBombaVPower.Checked = false;
            txtCantidad.Text = string.Empty;
        }

        private void comboBoxTipoAbastecimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoAbastecimiento.SelectedItem != null)
            {
                string selectedItem = comboBoxTipoAbastecimiento.SelectedItem.ToString();

                if (selectedItem == "Prepago")
                {
                    label15.Text = "Q.";
                }
                else if (selectedItem == "Tanque Lleno")
                {
                    label15.Text = "lts";
                }
            }
        }

        private void ReducirBarraDeProgreso(int cantidad)
        {
            if (currentProgressBar != null)
            {
                reductionAmount = cantidad;
                reductionTimer = new Timer();
                reductionTimer.Interval = 100; // Ajusta el intervalo según sea necesario (más rápido)
                reductionTimer.Tick += new EventHandler(ReductionTimer_Tick);
                reductionTimer.Start();
            }
        }
        private void ReductionTimer_Tick(object sender, EventArgs e)
        {
            if (currentProgressBar.Value > 0 && reductionAmount > 0)
            {
                currentProgressBar.Value = Math.Max(0, currentProgressBar.Value - 1);
                reductionAmount--;

                switch (currentProgressBar.Name)
                {
                    case "progressBarRegular":
                        label7.Text = $"{currentProgressBar.Value} lts";
                        break;
                    case "progressBarSuper":
                        label13.Text = $"{currentProgressBar.Value} lts";
                        break;
                    case "progressBarDiesel":
                        label12.Text = $"{currentProgressBar.Value} lts";
                        break;
                    case "progressBarVpower":
                        label14.Text = $"{currentProgressBar.Value} lts";
                        break;
                }

                if (currentProgressBar.Value == 0 || reductionAmount == 0)
                {
                    reductionTimer.Stop();
                    reductionTimer.Dispose();
                }
            }
            else
            {
                reductionTimer.Stop();
                reductionTimer.Dispose();
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
            foreach (var cliente in abastecimientos)
            {
                switch (cliente.BombaSeleccionada)
                {
                    case "Regular":
                        cliente.CantidadRestante = progressBarRegular.Value;
                        break;
                    case "Diesel":
                        cliente.CantidadRestante = progressBarDiesel.Value;
                        break;
                    case "Super":
                        cliente.CantidadRestante = progressBarSuper.Value;
                        break;
                    case "VPower":
                        cliente.CantidadRestante = progressBarVpower.Value;
                        break;
                }
            }
            GuardarArchivoAbastecimientos(abastecimientos);
        }

        private void CargarDatos()
        {
            List<Cliente> abastecimientos = LeerArchivoAbastecimientos();
            foreach (var cliente in abastecimientos)
            {
                switch (cliente.BombaSeleccionada)
                {
                    case "Regular":
                        progressBarRegular.Value = cliente.CantidadRestante;
                        label7.Text = $"{progressBarRegular.Value} lts";
                        break;
                    case "Diesel":
                        progressBarDiesel.Value = cliente.CantidadRestante;
                        label12.Text = $"{progressBarDiesel.Value} lts";
                        break;
                    case "Super":
                        progressBarSuper.Value = cliente.CantidadRestante;
                        label13.Text = $"{progressBarSuper.Value} lts";
                        break;
                    case "VPower":
                        progressBarVpower.Value = cliente.CantidadRestante;
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
