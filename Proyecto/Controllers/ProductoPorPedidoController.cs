using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models.Conex;
using Proyecto.Models;
using Proyecto.Services;

namespace Proyecto.Controllers
{
    public class ProductoPorPedidoController
    {
        ProductoPorPedidoService service = new ProductoPorPedidoService();
        public bool SetProductoPorPedido(Pedido pedido, List<Carrito> carrito)
        {
            return service.SetProductoPorPedido(pedido, carrito);
        }
        public List<ProductoPorPedido> GetProductoPorPedido(Pedido pedido)
        {
            return service.GetProductoPorPedido(pedido);
        }
    }
}