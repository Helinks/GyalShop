using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class Estado
    {
        public int IdEstado { get; set; }
        public string DescEstado { get; set; }

        public Estado(int idEstado, string descEstado)
        {
            IdEstado = idEstado;
            DescEstado = descEstado;
        }

        public Estado()
        {
        }
    }
}
