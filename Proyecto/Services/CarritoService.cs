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
        public List<Carrito> GetCarrito(Usuario usuario)
        {
            return dbCarrito.GetCarrito(usuario);
        }
        public bool UpdateCarrito(Carrito carrito)
        {
            return dbCarrito.UpdateCarrito(carrito);
        }
        public bool DeleteCarrito(Usuario usuario)
        {
            return dbCarrito.DeleteCarrito(usuario);
        }
        public bool DeleteCarritoProducto(Carrito carrito)
        {
            return dbCarrito.DeleteCarritoProducto(carrito);
        }
    }
}
