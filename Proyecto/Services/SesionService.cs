using Proyecto.Models;

namespace Proyecto.Services
{
    public static class SesionService
    {
        public static Usuario UsuarioActual { get; set; }

        public static bool EstaLogueado => UsuarioActual != null;

        public static bool EsAdmin => UsuarioActual?.TipoUsuario?.IdTipo == 1;

        public static bool EsCliente => UsuarioActual?.TipoUsuario?.IdTipo == 2;

        public static void CerrarSesion()
        {
            UsuarioActual = null;
        }
    }
}