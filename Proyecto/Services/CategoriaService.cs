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
        DBCategoria dbCategoria = new DBCategoria();
        public bool SetCategoria(Categoria categoria) {
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
        public bool UpdateCategoria(Categoria categoria) { 
        return dbCategoria.UpdateCategoria(categoria);
        }

        public bool DeleteCategoria(Categoria categoria) {
            return dbCategoria.DeleteCategoria(categoria);
        }

    }
}
