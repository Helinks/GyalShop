using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models;
using Proyecto.Services;

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

        public bool deleteProducto(Producto producto)
        {
            return productoService.deleteProducto(producto);
        }
    }
}
