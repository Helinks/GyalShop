using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models.Conex;
using Proyecto.Models;

namespace Proyecto.Services
{
    internal class ProductoService
    {
        DBProducto dbProducto= new DBProducto();

        public bool setProducto(Producto producto) {
            return dbProducto.setProducto(producto);
        }
        public Producto getProducto(Producto producto) {
            
            return dbProducto.getProducto(producto);
        }
        public List<Producto> getProductos(Producto producto) {

            return dbProducto.getProductos(producto);
        }
        public List<Producto> getAllProductos()
        {

            return dbProducto.getAllProductos();
        }

        public bool updateProducto(Producto producto) { 
        return dbProducto.updateProducto(producto);
        }
        public bool deleteProducto(Producto producto) {
            return dbProducto.deleteProducto(producto);
        }
    }
}
