using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class ProductoPorPedido
    {
        public int IdProductoXPedido { get; set; }
        public int IdPedidoProducto { get; set; }
        public Producto Producto { get; set; }
        public double PrecioProducto { get; set; }
        public int CantidadProducto { get; set; }
        public double Subtotal { get; set; }

        public ProductoPorPedido(int idProductoXPedido, int idPedidoProducto, Producto producto, double precioProducto, int cantidadProducto, double subtotal)
        {
            IdProductoXPedido = idProductoXPedido;
            IdPedidoProducto = idPedidoProducto;
            Producto = producto;
            PrecioProducto = precioProducto;
            CantidadProducto = cantidadProducto;
            Subtotal = subtotal;
        }

        public ProductoPorPedido()
        {
        }
    }
}
