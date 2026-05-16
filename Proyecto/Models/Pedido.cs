using Proyecto.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdUsuarioPedido { get; set; }
        public Estado IdEstadoPedido { get; set; }

        public Pedido(int idPedido, int idUsuarioPedido, Estado idEstadoPedido)
        {
            IdPedido = idPedido;
            IdUsuarioPedido = idUsuarioPedido;
            IdEstadoPedido = idEstadoPedido;
        }

        public Pedido()
        {
            
        }
    }
}
