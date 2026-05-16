using System.Collections.Generic;
using Proyecto.Models.Conex;
using Proyecto.Models;

namespace Proyecto.Services
{
    public class CarritoService
    {
        DBCarrito dbCarrito = new DBCarrito();

        public bool SetCarrito(Carrito carrito)
        {
            return dbCarrito.SetCarrito(carrito);
        }

        public List<Carrito> GetCarrito(int idUsuario)
        {
            return dbCarrito.GetCarrito(idUsuario);
        }

        public bool UpdateCarrito(Carrito carrito)
        {
            return dbCarrito.UpdateCarrito(carrito);
        }

        public bool DeleteCarrito(int idUsuario)
        {
            return dbCarrito.DeleteCarrito(idUsuario);
        }
    }
}