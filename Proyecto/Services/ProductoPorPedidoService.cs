using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models.Conex;
using Proyecto.Models;

namespace Proyecto.Services
{
    public class ProductoPorPedidoService
    {
        DBProductoPorPedido dBProductoPorPedido = new DBProductoPorPedido();
        public bool SetProductoPorPedido(Pedido pedido, List<Carrito> carrito)
        {
            return dBProductoPorPedido.SetProductoPorPedido(pedido, carrito);
        }
        public List<ProductoPorPedido> GetProductoPorPedido(Pedido pedido)
        {
            return dBProductoPorPedido.GetProductoPorPedido(pedido);
        }
    }
}