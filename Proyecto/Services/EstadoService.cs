using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models.Conex;
using Proyecto.Models;

namespace Proyecto.Services
{
    public class EstadoService
    {
        DBEstado dbEstado = new DBEstado();

        public bool SetEstado(Estado estado) { 
            return dbEstado.SetEstado(estado);
        }
        public Estado GetEstado(Estado estado)
        {
            return dbEstado.GetEstado(estado);
        }
        public List<Estado> GetAllEstado() { 
        return dbEstado.GetAllEstado();
        }
        public bool UpdateEstado(Estado estado) { 
        return dbEstado.UpdateEstado(estado);
        }
        public bool DeleteEstado(Estado estado) { 
        return dbEstado.DeleteEstado(estado);
        }
    }
}
