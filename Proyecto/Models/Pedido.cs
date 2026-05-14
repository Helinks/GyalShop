using Proyecto.Services;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public Usuario IdUsuarioPedido { get; set; }
        public Estado idEstadoPedido { get; set; }

<<<<<<< HEAD
        public Pedido(int idPedido, Usuario idUsuarioPedido, Estado idEstadoPedido)
        {
            IdPedido = idPedido;
            IdUsuarioPedido = idUsuarioPedido;
            this.idEstadoPedido = idEstadoPedido;
=======
        public List<ProductoPorPedido> Productos { get; set; }

        public Pedido(
            int idPedido,
            int idUsuarioPedido,
            int idEstadoPedido)
        {
            IdPedido = idPedido;
            IdUsuarioPedido = idUsuarioPedido;
            IdEstadoPedido = idEstadoPedido;

            Productos = new List<ProductoPorPedido>();
>>>>>>> 5a903cf (Perfil y HomeView echos con el carrito)
        }

        public Pedido()
        {
            Productos = new List<ProductoPorPedido>();
        }
    }
}