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
        public Pedido IdPedidoProducto { get; set; }
        public Producto IdProductoPedido { get; set; }
    }
}
