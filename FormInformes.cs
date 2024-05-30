using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_Final
{
    public partial class FormInformes : Form
    {
        private BindingList<Cliente> abastecimientos;

        public FormInformes()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            comboBoxInfo.Items.Add("");
            comboBoxInfo.Items.Add("Cierre de caja");
            comboBoxInfo.Items.Add("Informes de prepago");
            comboBoxInfo.Items.Add("Informes de tanque lleno");
            comboBoxInfo.SelectedIndex = 0;

            // Agregar el manejador del evento Click para el botón Eliminar
            buttonEliminar.Click += new EventHandler(this.buttonEliminar_Click);
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
            abastecimientos = new BindingList<Cliente>(LeerArchivoAbastecimientos());
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = abastecimientos;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void MostrarInformePrepago()
        {
            abastecimientos = new BindingList<Cliente>(LeerArchivoAbastecimientos().Where(a => a.TipoAbastecimiento == "Prepago").ToList());
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = abastecimientos;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void MostrarInformeTanqueLleno()
        {
            abastecimientos = new BindingList<Cliente>(LeerArchivoAbastecimientos().Where(a => a.TipoAbastecimiento == "Tanque Lleno").ToList());
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = abastecimientos;
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

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el índice de la fila seleccionada
                int rowIndex = dataGridView1.SelectedRows[0].Index;

                // Eliminar la fila del BindingList
                abastecimientos.RemoveAt(rowIndex);

                // Guardar los cambios en el archivo JSON
                GuardarArchivoAbastecimientos(abastecimientos.ToList());
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GuardarArchivoAbastecimientos(List<Cliente> abastecimientos)
        {
            string json = JsonConvert.SerializeObject(abastecimientos, Formatting.Indented);
            File.WriteAllText("abastecimientos1.json", json);
        }
    }
    }
   