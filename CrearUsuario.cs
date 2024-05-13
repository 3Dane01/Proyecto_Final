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
    public partial class CrearUsuario : Form
    {
        List<ClaseUsuario> usuarios = new List<ClaseUsuario>();
        ClaseUsuario ingreso = new ClaseUsuario();

        public CrearUsuario()
        {
            InitializeComponent();
        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {
            
            ingreso.Usuario = textBoxUsuario.Text;
            ingreso.Contraseña = textBoxContraseña.Text;
            usuarios.Add(ingreso);
            
            MessageBox.Show(ingreso.Usuario+ ingreso.Contraseña);
            
            textBoxUsuario.Text = "";
            textBoxContraseña.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Acceso regresar = new Acceso();
            regresar.Show();
            Hide();
        }
    }

}
