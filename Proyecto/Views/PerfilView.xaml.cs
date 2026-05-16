using Proyecto.Controllers;
using Proyecto.Models;
using Proyecto.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto.Views
{
    public partial class PerfilView : UserControl
    {
        private readonly PerfilController perfilController = new PerfilController();

        private ObservableCollection<PedidoDetalleVista> pedidosDetalle =
            new ObservableCollection<PedidoDetalleVista>();

        public PerfilView()
        {
            InitializeComponent();

            CargarUsuario();
            CargarPedidos();
        }

        private void CargarUsuario()
        {
            if (SesionService.UsuarioActual == null)
                return;

            Usuario usuario =
                perfilController.GetUsuario(SesionService.UsuarioActual.IdUsuario);

            if (usuario == null)
                return;

            txtNombre.Text = usuario.NombreUsuario;
            txtCorreo.Text = usuario.Correo;
            txtTelefono.Text = usuario.Telefono;
            txtDireccion.Text = usuario.Direccion;
        }

        private void CargarPedidos()
        {
            if (SesionService.UsuarioActual == null)
                return;

            List<Pedido> pedidos =
                perfilController.GetPedidosUsuario(
                    SesionService.UsuarioActual.IdUsuario
                );

            pedidosDetalle.Clear();

            foreach (Pedido pedido in pedidos)
            {
                if (pedido.Productos == null)
                    continue;

                foreach (ProductoPorPedido producto in pedido.Productos)
                {
                    pedidosDetalle.Add(new PedidoDetalleVista
                    {
                        IdPedido = pedido.IdPedido,

                        Estado = pedido.IdEstadoPedido.DescEstado,

                        NombreProducto = producto.NombreProducto,

                        PrecioProducto = producto.PrecioProducto,

                        CantidadProducto = producto.CantidadProducto,

                        Subtotal = producto.Subtotal
                    });
                }
            }

            dgPedidosDetalle.ItemsSource = pedidosDetalle;
        }

        private void BtnGuardarDireccion_Click(object sender, RoutedEventArgs e)
        {
            if (SesionService.UsuarioActual == null)
                return;

            bool result = perfilController.ActualizarDireccion(
                SesionService.UsuarioActual.IdUsuario,
                txtDireccion.Text
            );

            if (result)
            {
                MessageBox.Show("Dirección actualizada");

                SesionService.UsuarioActual.Direccion =
                    txtDireccion.Text;
            }
            else
            {
                MessageBox.Show("Error al actualizar dirección");
            }
        }

        private void BtnVolverInicio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main =
                (MainWindow)Window.GetWindow(this);

            main.MainContent.Content = new HomeView();
        }

        private class PedidoDetalleVista
        {
            public int IdPedido { get; set; }

            public string Estado { get; set; }

            public string NombreProducto { get; set; }

            public double PrecioProducto { get; set; }

            public int CantidadProducto { get; set; }

            public double Subtotal { get; set; }
        }
    }
}