using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class TipoUsuario
    {
        public int IdTipo { get; set; }
        public string Tipo { get; set; }

        public TipoUsuario(int idTipo, string tipo)
        {
            IdTipo = idTipo;
            Tipo = tipo;
        }

        public TipoUsuario()
        {
        }
    }
}
