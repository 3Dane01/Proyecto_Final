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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Proyecto_Final
{
    public partial class FormInformes : Form
    {
        public FormInformes()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            comboBoxInfo.Items.Add("");
            comboBoxInfo.Items.Add("Cierre de caja");
            comboBoxInfo.Items.Add("Informes de prepago");
            comboBoxInfo.Items.Add("Informes de tanque lleno");
            comboBoxInfo.Items.Add("Informes de tanques");
            comboBoxInfo.SelectedIndex = 0;


        }

        private void FormInformes_Load(object sender, EventArgs e)
        {

        }

        private void CargarDatos(string opcion)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormInicio Inicio = new FormInicio();
            Inicio.Show();
            this.Hide();
        }

        private void comboBoxInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxInfo.SelectedItem.ToString())
            {
                case "Cierre de caja":
                    MostrarCierreCaja();
                    break;
                case "Informes de prepago":
                    MostrarInformePrepago();
                    break;
                case "Informes de tanque lleno":
                    MostrarInformeTanqueLleno();
                    break;
                case "Informes de tanques":
                    MostrarInformedeCadaTanque();
                    break;
            }
        }

        private void MostrarCierreCaja()
        {
            List<Cliente> abastecimientos = LeerArchivoAbastecimientos();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = abastecimientos;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }
        private void MostrarInformePrepago()
        {
            List<Cliente> abastecimientos = LeerArchivoAbastecimientos();

            var abastecimientosPrepago = abastecimientos.Where(a => a.TipoAbastecimiento == "Prepago").ToList();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = abastecimientosPrepago;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void MostrarInformeTanqueLleno()
        {
            List<Cliente> abastecimientos = LeerArchivoAbastecimientos();

            var abastecimientosTanqueLleno = abastecimientos.Where(a => a.TipoAbastecimiento == "Tanque Lleno").ToList();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = abastecimientosTanqueLleno;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void MostrarInformedeCadaTanque()
        {
            List<Cliente> abastecimientos = LeerArchivoAbastecimientos();

            // Contadores para cada bomba
            int contadorRegular = 0;
            int contadorSuper = 0;
            int contadorDiesel = 0;
            int contadorVPower = 0;

            // Contar el uso de cada bomba
            foreach (var abastecimiento in abastecimientos)
            {
                switch (abastecimiento.BombaSeleccionada)
                {
                    case "Regular":
                        contadorRegular++;
                        break;
                    case "Super":
                        contadorSuper++;
                        break;
                    case "Diesel":
                        contadorDiesel++;
                        break;
                    case "VPower":
                        contadorVPower++;
                        break;
                }
            }

            // Encontrar la bomba más utilizada
            int maxUsos = contadorRegular;
            string bombaMasUtilizada = "Regular";

            if (contadorSuper > maxUsos)
            {
                maxUsos = contadorSuper;
                bombaMasUtilizada = "Super";
            }
            if (contadorDiesel > maxUsos)
            {
                maxUsos = contadorDiesel;
                bombaMasUtilizada = "Diesel";
            }
            if (contadorVPower > maxUsos)
            {
                maxUsos = contadorVPower;
                bombaMasUtilizada = "VPower";
            }

            // Encontrar la bomba menos utilizada
            int minUsos = contadorRegular;
            string bombaMenosUtilizada = "Regular";

            if (contadorSuper < minUsos)
            {
                minUsos = contadorSuper;
                bombaMenosUtilizada = "Super";
            }
            if (contadorDiesel < minUsos)
            {
                minUsos = contadorDiesel;
                bombaMenosUtilizada = "Diesel";
            }
            if (contadorVPower < minUsos)
            {
                minUsos = contadorVPower;
                bombaMenosUtilizada = "VPower";
            }

            // Crear una lista para mostrar en el DataGridView
            var resultados = new List<BombaResultado>
            {
                new BombaResultado { Bomba = "Bomba más utilizada", Cantidad = bombaMasUtilizada },
                new BombaResultado { Bomba = "Bomba menos utilizada", Cantidad = bombaMenosUtilizada }
            };

            // Mostrar los datos en el DataGridView
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = resultados;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
    }
}
