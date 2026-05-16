namespace Proyecto.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public TipoUsuario TipoUsuario { get; set; } = new TipoUsuario();

        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool EstaActivo { get; set; }

        public Usuario()
        {
            TipoUsuario = new TipoUsuario();
        }

        public Usuario(int idUsuario, TipoUsuario tipoUsuario, string nombreUsuario, string correo,
                       string password, string telefono, string direccion, bool estaActivo)
        {
            IdUsuario = idUsuario;
            TipoUsuario = tipoUsuario;
            NombreUsuario = nombreUsuario;
            Correo = correo;
            Password = password;
            Telefono = telefono;
            Direccion = direccion;
            EstaActivo = estaActivo;
        }
    }
}