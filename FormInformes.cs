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
