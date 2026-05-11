using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models.Conex;
using Proyecto.Models;
using Proyecto.Services;
namespace Proyecto.Controllers
{
    public class CategoriaController
    {
        CategoriaService categoriaService = new CategoriaService();
        public bool setCategoria(Categoria categoria)
        {
            return categoriaService.setCategoria(categoria);
        }
        public Categoria getCategoria(Categoria categoria) { 
        return categoriaService.getCategoria(categoria);
        }
        public List<Categoria> GetCategorias(Categoria categoria) { 
        return categoriaService.getCategorias(categoria);
        }
        public List<Categoria> getAllCategoria()
        {
            return categoriaService.getAllCategoria();
        }
        public bool updateCategoria(Categoria categoria)
        {
            return categoriaService.updateCategoria(categoria);
        }

        public bool deleteCategoria(Categoria categoria) { 
        return categoriaService.deleteCategoria(categoria);
        }
    }
}
