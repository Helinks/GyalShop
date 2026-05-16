using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Services;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class PedidoController
    {
        PedidoService pedidoService = new PedidoService();
        public bool SetPedido(Pedido pedido)
        {
            return pedidoService.SetPedido(pedido);
        }
        public Pedido GetPedido(Pedido pedido)
        {
            return pedidoService.GetPedido(pedido);
        }
        public List<Pedido> GetAllPedido()
        {
            return pedidoService.GetAllPedido();
        }
        public bool UpdatePedido(Pedido pedido)
        {
            return pedidoService.UpdatePedido(pedido);
        }
        public bool CambiarEstadoPedido(Pedido pedido)
        {
            return pedidoService.CambiarEstadoPedido(pedido);
        }
    }
}