using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Services;
using Proyecto.Models;
namespace Proyecto.Controllers
{
    public class EstadoController
    {
        EstadoService service = new EstadoService();

        public bool SetEstado(Estado estado) { 
            return service.SetEstado(estado);
        }
        public Estado GetEstado(Estado estado) { 
        return service.GetEstado(estado);
        }
        public List<Estado> GetAllEstado(Estado estado)
        {
            return service.GetAllEstado(estado);
        }
        public bool UpdateEstado(Estado estado) { 
        return service.UpdateEstado(estado);
        }
        public bool DeleteEstado(Estado estado) { 
        return service.DeleteEstado(estado);
        }
    }
}
