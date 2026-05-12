using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public int IdCategoriaProducto { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadProducto { get; set; }
        public double PrecioProducto { get; set; }
        public int DescuentoProducto { get; set; }
        public bool EstaActivo { get; set; }

        public Producto(int idProducto, int idCategoriaProducto, string nombreProducto, int cantidadProducto, double precioProducto, int descuentoProducto, bool estaActivo)
        {
            IdProducto = idProducto;
            IdCategoriaProducto = idCategoriaProducto;
            NombreProducto = nombreProducto;
            CantidadProducto = cantidadProducto;
            PrecioProducto = precioProducto;
            DescuentoProducto = descuentoProducto;
            EstaActivo = estaActivo;
        }

        public Producto()
        {
            
        }
    }
}
