using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models.Conex;
using Proyecto.Models;
namespace Proyecto.Services
{
    public class CarritoService
    {
        DBCarrito dbCarrito= new DBCarrito();
        public bool SetCarrito(Carrito carrito) { 
            return dbCarrito.SetCarrito(carrito);
        }
        public List<Carrito> GetCarrito(Carrito carrito)
        {
            return dbCarrito.GetCarrito(carrito);
        }
        public bool UpdateCarrito(Carrito carrito)
        {
            return dbCarrito.UpdateCarrito(carrito);
        }
        public bool DeleteCarrito(Carrito carrito)
        {
            return dbCarrito.DeleteCarrito(carrito);
        }
    }
}
