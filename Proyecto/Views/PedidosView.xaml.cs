using Proyecto.Controllers;
using Proyecto.Models;
using Proyecto.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace Proyecto.Views
{
    public partial class PedidosView: UserControl
    {
        private CategoriaController controller = new CategoriaController();
        private ProductoController productoController = new ProductoController();
        private CarritoController carritoController = new CarritoController();
        private PedidoController pedidoController = new PedidoController();
        private ProductoPorPedidoController productoPorPedidoController = new ProductoPorPedidoController();
        private Producto selectedProducto;
        private Carrito selectedCarrito;
        private Pedido selectedPedido;

        public PedidosView()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {

            dgPedidos.ItemsSource = pedidoController.GetAllPedido();
        }
        private void LimpiarCampos()
        {
            nombreProducto.Text = "";
            numCantidad.Value = 0;
            selectedProducto = null;
            selectedCarrito = null;
        }

        private void BtnsOff()
        {
            BtnActualizar.Visibility = Visibility.Collapsed;
            BtnEliminar.Visibility = Visibility.Collapsed;
            BtnCancelar.Visibility = Visibility.Collapsed;
            BtnAgregar.Visibility = Visibility.Collapsed;
            BtnEliminarCarrito.Visibility = Visibility.Visible;
            BtnFinalizarCompra.Visibility = Visibility.Visible;
        }
        private void LimpiarVista()
        {
            nombreProductoLabel.Visibility = Visibility.Collapsed;
            cantidadProductoLabel.Visibility = Visibility.Collapsed;
            nombreProducto.Visibility = Visibility.Collapsed;
            numCantidad.Visibility = Visibility.Collapsed;
            nombreProducto.Text = "";
        }
        private void ProductoSelected()
        {
            nombreProductoLabel.Visibility = Visibility.Visible;
            cantidadProductoLabel.Visibility = Visibility.Visible;
            nombreProducto.Visibility = Visibility.Visible;
            numCantidad.Visibility = Visibility.Visible;
            nombreProducto.Text = selectedProducto.NombreProducto;

            BtnAgregar.Visibility = Visibility.Visible;
            BtnCancelar.Visibility = Visibility.Visible;
            BtnEliminarCarrito.Visibility = Visibility.Collapsed;
            BtnFinalizarCompra.Visibility = Visibility.Collapsed;
        }
        private void CarritoProductoSelected()
        {
            nombreProductoLabel.Visibility = Visibility.Visible;
            cantidadProductoLabel.Visibility = Visibility.Visible;
            nombreProducto.Visibility = Visibility.Visible;
            numCantidad.Visibility = Visibility.Visible;
            nombreProducto.Text = selectedCarrito.NombreProducto;
            numCantidad.Value = selectedCarrito.Cantidad;
            BtnAgregar.Visibility = Visibility.Collapsed;

            BtnActualizar.Visibility = Visibility.Visible;
            BtnEliminar.Visibility = Visibility.Visible;
            BtnCancelar.Visibility = Visibility.Visible;
            BtnEliminarCarrito.Visibility = Visibility.Collapsed;
            BtnFinalizarCompra.Visibility = Visibility.Collapsed;
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == string.Empty)
            {
                MessageBoxResult result = MessageBox.Show(
                "Por favor complete todos los campos");
                return;

            }
            Categoria categoria = new Categoria
            {
                NombreCategoria = txtNombre.Text,
            };

            controller.SetCategoria(categoria);
            LimpiarCampos();
            CargarDatos();
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (numCantidad.Value == 0)
            {
                MessageBoxResult result = MessageBox.Show(
                "El campo de cantidad no puede estar vacio");
                return;

            }
            if (selectedCarrito == null) return;

            selectedCarrito.Cantidad = numCantidad.Value ?? 0;

            carritoController.UpdateCarrito(selectedCarrito);
            CargarDatos();
            MessageBoxResult update = MessageBox.Show(
                "Se ha actualizado con exito");
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCarrito == null) return;

            MessageBoxResult result = MessageBox.Show(
                "¿Esta seguro que desea eliminar este producto del carrito?",
                "Confirmación",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                carritoController.DeleteCarritoProducto(selectedCarrito);
                LimpiarVista();
                LimpiarCampos();
                BtnsOff();
                CargarDatos();
            }
        }
        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
            LimpiarVista();
            BtnsOff();
            BtnEliminarCarrito.Visibility = Visibility.Visible;
            CargarDatos();
        }

        private void dgPedido_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedProducto = dgPedidos.SelectedItem as Producto;

            if (selectedProducto != null)
            {
                ProductoSelected();
                dgProductosPedido.ItemsSource = productoPorPedidoController.GetProductoPorPedido(selectedPedido);
            }
        }
        private void dgProductoPedido_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedCarrito = dgProductosPedido.SelectedItem as Carrito;


            if (selectedCarrito != null)
            {
                CarritoProductoSelected();
            }
        }


        private void AgregarCarrito(object sender, RoutedEventArgs e)
        {
            if (numCantidad.Value == 0)
            {
                MessageBoxResult result = MessageBox.Show(
                "Por favor escoja la cantidad del producto");
                return;
            }
            if (selectedProducto == null)
            {
                MessageBoxResult result = MessageBox.Show(
                "No se ha escogido ningun producto");
                return;
            }
            int cantidad = numCantidad.Value ?? 0;
            Producto producto = dgProductosPedido.SelectedItem as Producto;
            Carrito itemExistente = carritoController.GetCarrito(SesionService.UsuarioActual).FirstOrDefault(x => x.IdProducto == producto.IdProducto);

            Carrito carritoCliente;

            if (itemExistente != null)
            {
                itemExistente.Cantidad += cantidad;
                carritoController.UpdateCarrito(itemExistente);
            }
            else
            {
                carritoCliente = new Carrito(0, producto.IdProducto, SesionService.UsuarioActual.IdUsuario, producto.NombreProducto, producto.PrecioProducto, cantidad);
                carritoController.SetCarrito(carritoCliente);
            }
            LimpiarCampos();
            LimpiarVista();
            BtnsOff();
            CargarDatos();
        }

        private void BtnEliminarCarrito_Click(object sender, RoutedEventArgs e)
        {
            var listaCarrito = carritoController.GetCarrito(SesionService.UsuarioActual);
            if (listaCarrito == null || listaCarrito.Count == 0)
            {
                MessageBoxResult message = MessageBox.Show(
               "No hay productos en tu carrito");
                dgProductosPedido.ItemsSource = null;
                return;
            }

            MessageBoxResult result = MessageBox.Show(
            "¿Esta seguro que desea eliminar todos los productos del carrito?",
            "Confirmación",
            MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                carritoController.DeleteCarrito(SesionService.UsuarioActual);
                LimpiarVista();
                LimpiarCampos();
                BtnsOff();
                CargarDatos();
            }
        }
        private void BtnFinalizarCompra_Click(object sender, RoutedEventArgs e)
        {
            var listaCarrito = carritoController.GetCarrito(SesionService.UsuarioActual);
            if (listaCarrito == null || listaCarrito.Count == 0)
            {
                MessageBoxResult message = MessageBox.Show(
               "No hay productos en tu carrito");
                dgProductosPedido.ItemsSource = null;
                return;
            }

            MessageBoxResult result = MessageBox.Show(
            "¿Esta seguro que desea finalizar la compra?",
            "Confirmación",
            MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                Pedido pedido = new Pedido(0, SesionService.UsuarioActual.IdUsuario, 0);
                List<Carrito> carrtioList = carritoController.GetCarrito(SesionService.UsuarioActual);

                pedidoController.SetPedido(pedido);
                productoPorPedidoController.SetProductoPorPedido(pedido, carrtioList);
                carritoController.DeleteCarrito(SesionService.UsuarioActual);
                LimpiarVista();
                LimpiarCampos();
                BtnsOff();
                CargarDatos();
            }
        }
    }
}