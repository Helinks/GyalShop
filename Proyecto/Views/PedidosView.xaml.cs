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
        private EstadoController estadoController = new EstadoController();
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
            cmEstado.ItemsSource = estadoController.GetAllEstado();
        }
        private void LimpiarCampos()
        {
            selectedProducto = null;
            selectedProducto = null;
            selectedCarrito = null;
            dgProductosPedido.ItemsSource = null;
        }

        private void BtnsOff()
        {
            BtnCancelar.Visibility = Visibility.Collapsed;
            BtnEstado.Visibility = Visibility.Collapsed;
        }
        private void LimpiarVista()
        {
            
            cmEstado.Visibility = Visibility.Collapsed;
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
            CargarDatos();
        }

        private void dgPedido_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedPedido = dgPedidos.SelectedItem as Pedido;

            if (selectedPedido != null)
            {
                dgProductosPedido.ItemsSource = productoPorPedidoController.GetProductoPorPedido(selectedPedido);
                cmEstado.SelectedValue = selectedPedido.IdEstadoPedido.IdEstado;
                BtnEstado.Visibility = Visibility.Visible;
                BtnCancelar.Visibility = Visibility.Visible;
                cmEstado.Visibility = Visibility.Visible;
            }
        }



        private void CambiarEstadoPedido(object sender, RoutedEventArgs e)
        {
            if (selectedPedido == null && cmEstado.SelectedValue == null) {
                MessageBox.Show(
                "Porfavor seleccione un estado para el producto");
                return;
            }
            selectedPedido.IdEstadoPedido= new Estado { IdEstado= (int)cmEstado.SelectedValue };
            LimpiarCampos();
            BtnsOff();
            CargarDatos();
        }

        
        
    }
}