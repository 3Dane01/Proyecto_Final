using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    internal class ClaseUsuario
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }

        public static bool verificar(string verUsuario, string verContraseña, List<ClaseUsuario> usuarios)
        {
            var usuario = usuarios.Find(u => u.Usuario == verUsuario);
            if (usuario == null)
            {
                return false;
            }
            return usuario.Contraseña == verContraseña;
        }
    }
}
