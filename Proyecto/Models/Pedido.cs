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
        public Usuario IdUsuarioPedido { get; set; }
        public Estado idEstadoPedido { get; set; }

        public Pedido(int idPedido, Usuario idUsuarioPedido, Estado idEstadoPedido)
        {
            IdPedido = idPedido;
            IdUsuarioPedido = idUsuarioPedido;
            this.idEstadoPedido = idEstadoPedido;
        }

        public Pedido()
        {
            
        }
    }
}
