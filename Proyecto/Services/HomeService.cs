using Proyecto.Models;
using Proyecto.Models.Conex;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto.Services
{
    public class HomeService
    {
        private readonly DBCategoria dbCategoria = new DBCategoria();
        private readonly DBProducto dbProducto = new DBProducto();

        public List<Categoria> GetCategorias()
        {
            return dbCategoria.GetAllCategoria();
        }

        public List<Producto> GetProductos()
        {
            return dbProducto.getAllProductos();
        }

        public List<Producto> GetProductosPorCategoria(int idCategoria)
        {
            return dbProducto.getAllProductos()
                             .Where(p =>
                                 p.EstaActivo &&
                                 p.IdCategoriaProducto != null &&
                                 p.IdCategoriaProducto.IdCategoria == idCategoria)
                             .ToList();
        }
    }
}