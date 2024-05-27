using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace Proyecto_Final
{
    public partial class FormIngreso : Form
    {
        private List<claseUsuario> usuarios = new List<claseUsuario>();
        private string rutaArchivo = "usuarios.json";
        public FormIngreso()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            if (File.Exists(rutaArchivo))
            {
                string json = File.ReadAllText(rutaArchivo);
                usuarios = JsonConvert.DeserializeObject<List<claseUsuario>>(json);
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool usuarioValido = usuarios.Exists(u => u.NombreUsuario == nombreUsuario && u.Contraseña == contraseña);

                if (usuarioValido)
                {
                    FormInicio forminicio = new FormInicio();
                    forminicio.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña incorrectos.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Clear();
                    txtContraseña.Clear();
                }
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
          
            FormCrear formcrear = new FormCrear();
            formcrear.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormIngreso_Load(object sender, EventArgs e)
        {

        }
    }
}
