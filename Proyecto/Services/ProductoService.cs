using Proyecto.Models.Conex;
using Proyecto.Models;
using System.Collections.Generic;

namespace Proyecto.Services
{
    internal class ProductoService
    {
        DBProducto dbProducto = new DBProducto();

        public bool setProducto(Producto producto)
        {
            return dbProducto.setProducto(producto);
        }

        public Producto getProducto(Producto producto)
        {
            return dbProducto.getProducto(producto);
        }

        public List<Producto> getProductos(Producto producto)
        {
            return dbProducto.getProductos(producto);
        }

        public List<Producto> getAllProductos()
        {
            return dbProducto.getAllProductos();
        }

        public bool updateProducto(Producto producto)
        {
            return dbProducto.updateProducto(producto);
        }

        public bool cambiarEstadoProducto(int idProducto, bool estado)
        {
            return dbProducto.cambiarEstadoProducto(idProducto, estado);
        }
    }
}