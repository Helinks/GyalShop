using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models;
using Proyecto.Services;

namespace Proyecto.Controllers
{
    public class CategoriaController
    {
        private readonly CategoriaService categoriaService = new CategoriaService();

        public bool SetCategoria(Categoria categoria)
        {
            return categoriaService.SetCategoria(categoria);
        }

        public Categoria GetCategoria(Categoria categoria)
        {
            return categoriaService.GetCategoria(categoria);
        }

        public List<Categoria> GetCategorias(Categoria categoria)
        {
            return categoriaService.GetCategorias(categoria);
        }

        public List<Categoria> GetAllCategoria()
        {
            return categoriaService.GetAllCategoria();
        }


        public List<Categoria> GetAllCategoriaConEstado()
        {
            return categoriaService.GetAllCategoriaConEstado();
        }

        public bool UpdateCategoria(Categoria categoria)
        {
            return categoriaService.UpdateCategoria(categoria);
        }


        public bool CambiarEstadoCategoria(int idCategoria, bool estado)
        {
            return categoriaService.CambiarEstadoCategoria(idCategoria, estado);
        }


        public bool DeleteCategoria(Categoria categoria)
        {
            return categoriaService.DeleteCategoria(categoria);
        }
    }
}