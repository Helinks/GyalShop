using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public bool EstaActivo { get; set; }

        public Usuario(int idUsuario, TipoUsuario tipoUsuario, string nombreUsuario, string correo, string passwrod, int telefono, string direccion, bool estaActivo)
        {
            IdUsuario = idUsuario;
            TipoUsuario = tipoUsuario;
            NombreUsuario = nombreUsuario;
            Correo = correo;
            Password = passwrod;
            Telefono = telefono;
            Direccion = direccion;
            EstaActivo = estaActivo;
        }
        public Usuario()
        {

        }
    }
}
