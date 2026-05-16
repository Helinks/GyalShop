using Proyecto.Models;
using Proyecto.Services;

namespace Proyecto.Controllers
{
    internal class AuthController
    {
        private UsuarioService usuarioService = new UsuarioService();

        public Usuario Login(string correo, string password)
        {
            Usuario usuario = usuarioService.Login(correo, password);

            if (usuario == null)
                return null;

            SesionService.UsuarioActual = usuario;

            return usuario;
        }

        public bool UsuarioLogueado()
        {
            return SesionService.UsuarioActual != null;
        }
        public Usuario DataUsuario()
        {
            return SesionService.UsuarioActual;
        }

        public bool Register(Usuario usuario)
        {
            return usuarioService.Register(usuario);
        }

    }
}