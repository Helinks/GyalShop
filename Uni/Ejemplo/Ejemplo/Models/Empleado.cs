using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string name;
        public bool activo;

        public Empleado() { }

        public Empleado( int Id, string name, bool activo)
        {
            this.Id = Id;
            this.name = name;
            this.activo = activo;
        }

        public bool getActivo() {
            return this.activo;
        }

        public void setActivo(bool activo ) {
            this.activo = activo;
        }


    }
}
