using Proyecto.Models;
using Proyecto.Services;
using System.Collections.Generic;

namespace Proyecto.Controllers
{
    public class ProductoController
    {
        ProductoService productoService = new ProductoService();

        public bool setProducto(Producto producto)
        {
            return productoService.setProducto(producto);
        }

        public Producto getProducto(Producto producto)
        {
            return productoService.getProducto(producto);
        }

        public List<Producto> getProductos(Producto producto)
        {
            return productoService.getProductos(producto);
        }

        public List<Producto> getAllProductos()
        {
            return productoService.getAllProductos();
        }

        public bool updateProducto(Producto producto)
        {
            return productoService.updateProducto(producto);
        }

        public bool cambiarEstadoProducto(int idProducto, bool estado)
        {
            return productoService.cambiarEstadoProducto(idProducto, estado);
        }
    }
}