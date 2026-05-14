using Proyecto.Controllers;
using Proyecto.Models;
using Proyecto.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto.Views
{
    public partial class ConfirmarPedidoView : UserControl
    {
        private readonly AuthController authController = new AuthController();
        private readonly CarritoController carritoController = new CarritoController();
        private readonly PedidoController pedidoController = new PedidoController();
        private readonly ProductoPorPedidoController productoPorPedidoController = new ProductoPorPedidoController();

        public ConfirmarPedidoView()
        {
            InitializeComponent();
            Loaded += ConfirmarPedidoView_Loaded;
        }

        private void ConfirmarPedidoView_Loaded(object sender, RoutedEventArgs e)
        {
            if (!authController.UsuarioLogueado())
            {
                MessageBox.Show("Debes iniciar sesión para confirmar el pedido.");

                MainWindow main = (MainWindow)Window.GetWindow(this);
                main.MainContent.Content = new Login();
                return;
            }

            CargarResumen();
        }

        private Usuario UsuarioActual => authController.DataUsuario();

        private void CargarResumen()
        {
            List<Carrito> carrito = carritoController.GetCarrito(UsuarioActual) ?? new List<Carrito>();

            dgResumenPedido.ItemsSource = carrito;

            txtUsuarioPedido.Text = $"Usuario loggeado: {UsuarioActual.IdUsuario} - {UsuarioActual.NombreUsuario}";

            double total = carrito.Sum(x => x.Subtotal);
            txtTotalPedido.Text = $"Total del pedido: $ {total:N0}";
        }

        private void BtnVolverCarrito_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Window.GetWindow(this);
            main.MainContent.Content = new ComprasView();
        }

        private void BtnHacerPedido_Click(object sender, RoutedEventArgs e)
        {
            List<Carrito> carrito = carritoController.GetCarrito(UsuarioActual) ?? new List<Carrito>();

            if (carrito.Count == 0)
            {
                MessageBox.Show("No hay productos para confirmar.");
                return;
            }

            Pedido pedido = new Pedido(0, UsuarioActual.IdUsuario, 1);

            bool pedidoCreado = pedidoController.SetPedido(pedido);

            if (!pedidoCreado || pedido.IdPedido <= 0)
            {
                MessageBox.Show("No fue posible crear el pedido.");
                return;
            }

            bool detalleCreado = productoPorPedidoController.SetProductoPorPedido(pedido, carrito);

            if (!detalleCreado)
            {
                MessageBox.Show("El pedido se creó, pero no se pudo guardar el detalle.");
                return;
            }

            carritoController.DeleteCarrito(UsuarioActual);

            MessageBox.Show("Pedido realizado con éxito.");

            MainWindow main = (MainWindow)Window.GetWindow(this);
            main.MainContent.Content = new HomeView();
        }
    }
}