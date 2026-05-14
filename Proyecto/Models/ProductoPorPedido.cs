using System;

namespace Proyecto.Models
{
    public class ProductoPorPedido
    {
        public int IdProductoXPedido { get; set; }
<<<<<<< HEAD
        public Pedido IdPedidoProducto { get; set; }
        public Producto IdProductoPedido { get; set; }
=======
        public int IdPedidoProducto { get; set; }
        public int IdProductoPedido { get; set; }
        public string NombreProducto { get; set; }
        public double PrecioProducto { get; set; }
        public int CantidadProducto { get; set; }
        public double Subtotal { get; set; }

        public ProductoPorPedido(int idProductoXPedido, int idPedidoProducto, int idProductoPedido, string nombreProducto, double precioProducto, int cantidadProducto, double subtotal)
        {
            IdProductoXPedido = idProductoXPedido;
            IdPedidoProducto = idPedidoProducto;
            IdProductoPedido = idProductoPedido;
            NombreProducto = nombreProducto;
            PrecioProducto = precioProducto;
            CantidadProducto = cantidadProducto;
            Subtotal = subtotal;
        }

        public ProductoPorPedido()
        {
        }
>>>>>>> 5a903cf (Perfil y HomeView echos con el carrito)
    }
}