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
        public bool setCategoria(Categoria categoria) {
            return dbCategoria.setCategoria(categoria);
        }

        public Categoria getCategoria(Categoria categoria)
        {
            return dbCategoria.getCategoria(categoria);
        }
        public List<Categoria> getCategorias(Categoria categoria)
        {
            return dbCategoria.getCategorias(categoria);
        }
        public List<Categoria> getAllCategoria()
        {
            return dbCategoria.getAllCategoria();
        }
        public bool updateCategoria(Categoria categoria) { 
        return dbCategoria.updateCategoria(categoria);
        }

        public bool deleteCategoria(Categoria categoria) {
            return dbCategoria.deleteCategoria(categoria);
        }

    }
}
