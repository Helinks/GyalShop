using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Services;
using Proyecto.Models;
namespace Proyecto.Controllers
{
    public class CarritoController
    {
        CarritoService carritoService = new CarritoService();

        public bool SetCarrito(Carrito carrito) { 
        return carritoService.SetCarrito(carrito);
        }
        public List<Carrito> GetCarrito(Carrito carrito)
        {
            return carritoService.GetCarrito(carrito);
        }
        public bool UpdateCarrito(Carrito carrito)
        {
            return carritoService.UpdateCarrito(carrito);
        }
        public bool DeleteCarrito(Carrito carrito)
        {
            return carritoService.DeleteCarrito(carrito);
        }
    }
}
