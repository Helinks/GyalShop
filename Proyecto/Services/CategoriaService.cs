using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models.Conex;
using Proyecto.Models;

namespace Proyecto.Services
{
    public class CategoriaService
    {

        private  DBCategoria dbCategoria = new DBCategoria();

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

        public bool DeleteCategoria(Categoria categoria)
        {
            
            return dbCategoria.CambiarEstadoCategoria(categoria.IdCategoria, false);
        }

        public bool CambiarEstadoCategoria(int idCategoria, bool estado)
        {
            return dbCategoria.CambiarEstadoCategoria(idCategoria, estado);
        }
    }
}