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
        {/*
            string Nombre = txtNombre.Text;
            string Apellido = txtApellido.Text;
            string tipoAbastecimiento = comboBoxTipoAbastecimiento.Text;
            string cantidad = txtCantidad.Text ;
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Apellido) || string.IsNullOrWhiteSpace(cantidad))
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
             */   
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCantidad.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormIngreso Regresar = new FormIngreso();
            Regresar.Show();
            this.Hide();
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
    }
}
