using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models.Conex;
using Proyecto.Models;
using Proyecto.Services;
namespace Proyecto.Services
{
    public class PedidoService
    {
        DBPedido dbPedido = new DBPedido();
        public bool SetPedido(Pedido pedido)
        {
            return dbPedido.SetPedido(pedido);
        }
        public Pedido GetPedido(Pedido pedido)
        {
            return dbPedido.GetPedido(pedido.IdPedido);
        }
        public List<Pedido> GetAllPedido()
        {

            return dbPedido.GetAllPedido();
        }
        public bool UpdatePedido(Pedido pedido)
        {
            return dbPedido.UpdatePedido(pedido);
        }
        public bool CambiarEstadoPedido(Pedido pedido)
        {
            return dbPedido.CambiarEstadoPedido(pedido);
        }
    }
}