using Proyecto.Models;
using Proyecto.Services;
using System.Collections.Generic;

namespace Proyecto.Controllers
{
    public class HomeController
    {
        private readonly HomeService homeService = new HomeService();

        public List<Categoria> GetCategorias()
        {
            return homeService.GetCategorias();
        }

        public List<Producto> GetProductos()
        {
            return homeService.GetProductos();
        }

        public List<Producto> GetProductosPorCategoria(int idCategoria)
        {
            return homeService.GetProductosPorCategoria(idCategoria);
        }
    }
}
