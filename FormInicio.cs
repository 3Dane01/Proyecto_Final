using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Cliente listadoClientes = new Cliente();
            listadoClientes.Nombre = txtNombre.Text;
            listadoClientes.Apellido = txtApellido.Text;
            listadoClientes.CantidadAbastecer = int.Parse(txtCantidad.Text);
            
                
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
