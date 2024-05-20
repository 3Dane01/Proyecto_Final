using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Resources.ResXFileRef;
namespace Proyecto_Final
{
    public partial class FormCrear : Form
    {
        private List<claseUsuario> usuarios = new List<claseUsuario>();
        private string rutaArchivo = "usuarios.json";
        public FormCrear()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            CargarUsuariosDesdeArchivo();
        }

        private void CargarUsuariosDesdeArchivo()
        {
            if (File.Exists(rutaArchivo))
            {
                string json = File.ReadAllText(rutaArchivo);
                usuarios = JsonConvert.DeserializeObject<List<claseUsuario>>(json);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;
            
            // Verificar si los campos están vacíos
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Verificar si ya existe un usuario con el mismo nombre
                bool usuarioExistente = usuarios.Exists(u => u.NombreUsuario == nombreUsuario);
                foreach (var usuario in usuarios)
                {
                    if (usuario.NombreUsuario == nombreUsuario)
                    {
                        usuarioExistente = true;
                        break;
                    }
                }

                if (usuarioExistente)
                {
                    MessageBox.Show("El nombre de usuario ya está en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Clear();
                    txtContraseña.Clear();
                }
                else
                {
                    // Agregar nuevo usuario a la lista
                    claseUsuario nuevoUsuario = new claseUsuario();
                    nuevoUsuario.NombreUsuario = nombreUsuario;
                    nuevoUsuario.Contraseña = contraseña;
                    usuarios.Add(nuevoUsuario);
                    MessageBox.Show("Usuario registrado exitosamente.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //guardar los datos en el archivo
                    string json = JsonConvert.SerializeObject(usuarios, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(rutaArchivo, json);

                    // Limpiar campos
                    txtUsuario.Clear();
                    txtContraseña.Clear();
                }

            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FormIngreso Regresar = new FormIngreso();
            Regresar.Show();
            this.Hide();
        }
    }
}
