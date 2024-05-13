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
    public partial class Acceso : Form
    {
        List<ClaseUsuario> permitirAcceso = new List<ClaseUsuario>();
        ClaseUsuario datos = new ClaseUsuario();
        public Acceso()
        {
            InitializeComponent();
        }

        private void Acceso_Load(object sender, EventArgs e)
        {
            textBoxContraseña.PasswordChar = '*';
            
        }

        private void buttonAcceso_Click(object sender, EventArgs e)
        {
            string nombreUsuario = textBoxUsuario.Text;
            string contraseña = textBoxContraseña.Text;

            MessageBox.Show(datos.Usuario);
            // Verificar si el usuario y la contraseña son válidos
            if (permitirAcceso.Any(u => u.Usuario == nombreUsuario && u.Contraseña == contraseña))
            {
                Inicio inicio = new Inicio();
                inicio.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearUsuario Crear = new CrearUsuario();
            Crear.Show();
            Hide();
        }
    }
}
