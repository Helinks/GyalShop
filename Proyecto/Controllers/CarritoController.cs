using Proyecto.Services;
using Proyecto.Models;
using System.Collections.Generic;

namespace Proyecto.Controllers
{
    public class CarritoController
    {
        CarritoService carritoService = new CarritoService();

        public bool SetCarrito(Carrito carrito)
        {
            return carritoService.SetCarrito(carrito);
        }

        public List<Carrito> GetCarrito(int idUsuario)
        {
            return carritoService.GetCarrito(idUsuario);
        }

        public bool UpdateCarrito(Carrito carrito)
        {
            return carritoService.UpdateCarrito(carrito);
        }

        public bool DeleteCarrito(int idUsuario)
        {
            return carritoService.DeleteCarrito(idUsuario);
        }
    }
}