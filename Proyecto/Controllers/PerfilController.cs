using Proyecto.Models;
using Proyecto.Models.Conex;
using System.Collections.Generic;

namespace Proyecto.Controllers
{
    public class PerfilController
    {
        DBUsuario dbUsuario = new DBUsuario();
        DBPedido dbPedido = new DBPedido();

        public Usuario GetUsuario(int idUsuario)
        {
            return dbUsuario.GetUsuario(idUsuario);
        }

        public bool ActualizarDireccion(int idUsuario, string direccion)
        {
            Usuario usuario = dbUsuario.GetUsuario(idUsuario);

            if (usuario == null)
                return false;

            usuario.Direccion = direccion;

            return dbUsuario.UpdateUsuario(usuario, false);
        }

        public List<Pedido> GetPedidosUsuario(int idUsuario)
        {
            return dbPedido.GetPedidosUsuario(idUsuario);
        }
    }
}