using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models.Conex;

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
        public double Subtotal => PrecioUnidad * Cantidad;

        public Carrito(int idCarrito,int idProducto, int idCliente, string nombreProducto, double precioUnidad, int cantidad) { 
            
            IdCarrito= idCarrito;
            IdProducto = idProducto;
            IdCliente = idCliente;
            NombreProducto = nombreProducto;
            PrecioUnidad = precioUnidad;
            Cantidad = cantidad;
        }
        public Carrito() { }
    }
}
