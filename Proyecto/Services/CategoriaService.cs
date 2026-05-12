using Proyecto.Models.Conex;
using Proyecto.Models;
using System.Collections.Generic;

namespace Proyecto.Services
{
    public class CategoriaService
    {
        private readonly DBCategoria dbCategoria = new DBCategoria();

        public bool SetCategoria(Categoria categoria)
        {
            return dbCategoria.SetCategoria(categoria);
        }

        public Categoria GetCategoria(Categoria categoria)
        {
            return dbCategoria.GetCategoria(categoria);
        }

        public List<Categoria> GetCategorias(Categoria categoria)
        {
            return dbCategoria.GetCategorias(categoria);
        }

        public List<Categoria> GetAllCategoria()
        {
            return dbCategoria.GetAllCategoria();
        }

        public List<Categoria> GetAllCategoriaConEstado()
        {
            return dbCategoria.GetAllCategoriaConEstado();
        }

        public bool UpdateCategoria(Categoria categoria)
        {
            return dbCategoria.UpdateCategoria(categoria);
        }

        public bool CambiarEstadoCategoria(int idCategoria, bool estado)
        {
            return dbCategoria.CambiarEstadoCategoria(idCategoria, estado);
        }
    }
}