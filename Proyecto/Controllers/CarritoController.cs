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
        public List<Carrito> GetCarrito(Usuario cliente)
        {
            return carritoService.GetCarrito(cliente);
        }
        public bool UpdateCarrito(Carrito carrito)
        {
            return carritoService.UpdateCarrito(carrito);
        }
        public bool DeleteCarrito(Usuario usuario)
        {
            return carritoService.DeleteCarrito(usuario);
        }
        public bool DeleteCarritoProducto(Carrito carrito)
        {
            return carritoService.DeleteCarritoProducto(carrito);
        }
    }
}
