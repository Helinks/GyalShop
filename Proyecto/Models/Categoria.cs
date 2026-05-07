using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public bool EstaActivo { get; set; }

        public Categoria(int idCategoria, string nombreCategoria, bool estaActivo)
        {
            IdCategoria = idCategoria;
            NombreCategoria = nombreCategoria;
            EstaActivo = estaActivo;
        }

        public Categoria()
        {
            
        }


    }
}
