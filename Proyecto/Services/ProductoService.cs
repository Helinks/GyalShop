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
        private readonly DBProducto dbProducto = new DBProducto();

        // Registrar un nuevo producto
        public bool setProducto(Producto producto)
        {
            return dbProducto.setProducto(producto);
        }

        // Obtener un solo producto por ID (usando el objeto como filtro)
        public Producto getProducto(Producto producto)
        {

            return dbProducto.getProducto(producto);
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