using System.Collections.Generic;

namespace Proyecto.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }

        public Usuario IdUsuarioPedido { get; set; }

        public Estado IdEstadoPedido { get; set; }

        public List<ProductoPorPedido> Productos { get; set; }

        public Pedido(
            int idPedido,
            Usuario idUsuarioPedido,
            Estado idEstadoPedido)
        {
            IdPedido = idPedido;
            IdUsuarioPedido = idUsuarioPedido;
            this.IdEstadoPedido = idEstadoPedido;

            Productos = new List<ProductoPorPedido>();
        }

        public Pedido()
        {
            Productos = new List<ProductoPorPedido>();
        }
    }
}