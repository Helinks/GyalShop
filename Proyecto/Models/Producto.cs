using System;

namespace Proyecto.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public Categoria IdCategoriaProducto { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadProducto { get; set; }
        public double PrecioProducto { get; set; }
        public int DescuentoProducto { get; set; }
        public string ImagenProducto { get; set; }
        public bool EstaActivo { get; set; }

        public List<ProductoPorPedido> Productos { get; set; }

        public Producto(int idProducto, Categoria idCategoriaProducto, string nombreProducto, int cantidadProducto, double precioProducto, int descuentoProducto, bool estaActivo, string imagenProducto = null)
        {
            IdProducto = idProducto;
            IdCategoriaProducto = idCategoriaProducto;
            NombreProducto = nombreProducto;
            CantidadProducto = cantidadProducto;
            PrecioProducto = precioProducto;
            DescuentoProducto = descuentoProducto;
            EstaActivo = estaActivo;
            ImagenProducto = imagenProducto;
        }

        public Producto()
        {
        }
    }
}