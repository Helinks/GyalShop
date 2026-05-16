using Proyecto.Models;
using Proyecto.Services;
using System.Collections.Generic;

namespace Proyecto.Controllers
{
    public class PerfilController
    {
        PerfilService perfilService = new PerfilService();

        public Usuario GetUsuario(int idUsuario)
        {
            return perfilService.GetUsuario(idUsuario);
        }

        public bool ActualizarDireccion(int idUsuario, string direccion)
        {
            return perfilService.ActualizarDireccion(idUsuario, direccion);
        }

        public List<Pedido> GetPedidosUsuario(int idUsuario)
        {
            return perfilService.GetPedidosUsuario(idUsuario);
        }
    }
}