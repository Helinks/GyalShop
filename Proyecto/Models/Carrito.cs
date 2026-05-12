using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class Carrito
    {
        public int IdCarrito { get; set; }
        public int IdProducto { get; set; }
        public int IdCliente { get; set; }
        public string NombreProducto { get; set; }
        public double PrecioUnidad { get; set; }
        public int Cantidad {  get; set; }
        public double subtotal => PrecioUnidad * Cantidad;

    }
}
