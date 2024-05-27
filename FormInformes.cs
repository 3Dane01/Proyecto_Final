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
        }

        private void FormInformes_Load(object sender, EventArgs e)
        {
            comboBoxInfo.Items.Add("Cierre de Caja");
            comboBoxInfo.Items.Add("Abastecimientos Prepago");
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void CargarDatos(string opcion)
        {
            List<Abastecimiento> abastecimientos = new List<Abastecimiento>();
            if (File.Exists("abastecimientos1.json"))
            {
                string json = File.ReadAllText("abastecimientos1.json");
                abastecimientos = JsonConvert.DeserializeObject<List<Abastecimiento>>(json) ?? new List<Abastecimiento>();
            }
            List<Abastecimiento> filteredAbastecimientos = new List<Abastecimiento>();
            if (opcion == "Cierre de Caja")
            {
                //filteredAbastecimientos = abastecimientos.Where(a => a.Fecha.Contains(DateTime.Now.ToString("dd/MM/yyyy"))).ToList();
            }
            else if (opcion == "Abastecimientos Prepago")
            {
                filteredAbastecimientos = abastecimientos.Where(a => a.AbastecimientoTipo == "Prepago").ToList();
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filteredAbastecimientos;

        }
    }
}
