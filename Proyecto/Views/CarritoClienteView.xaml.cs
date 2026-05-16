using Proyecto.Controllers;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto.Views
{
    /// <summary>
    /// Lógica de interacción para CarritoClienteView.xaml
    /// </summary>
    public partial class CarritoClienteView : UserControl
    {
        private readonly AuthController authController = new AuthController();
        private readonly CarritoController carritoController = new CarritoController();

        private Producto productoSeleccionado;

        public CarritoClienteView(Producto producto = null)
        {
            InitializeComponent();
            productoSeleccionado = producto;
            Loaded += ComprasView_Loaded;
        }

        private void ComprasView_Loaded(object sender, RoutedEventArgs e)
        {
            if (!authController.UsuarioLogueado())
            {
                MessageBox.Show("Debes iniciar sesión o registrarte para continuar.");

                MainWindow main = (MainWindow)Window.GetWindow(this);
                main.MainContent.Content = new Login();
                return;
            }

            CargarUsuario();
            CargarProducto();
            CargarCarrito();
        }

        private Usuario UsuarioActual => authController.DataUsuario();

        private void CargarUsuario()
        {
            txtUsuarioActual.Text = $"Usuario loggeado: {UsuarioActual.IdUsuario} - {UsuarioActual.NombreUsuario}";
        }

        private void CargarProducto()
        {
            if (productoSeleccionado == null)
            {
                bdProducto.Visibility = Visibility.Collapsed;
                return;
            }

            bdProducto.Visibility = Visibility.Visible;

            txtNombreProducto.Text = productoSeleccionado.NombreProducto;
            txtPrecioProducto.Text = $"$ {productoSeleccionado.PrecioProducto:N0}";
            numCantidad.Value = 1;
            txtTotalProducto.Text = $"$ {productoSeleccionado.PrecioProducto:N0}";
            BtnAgregarActualizar.Content = "Agregar al carrito";
        }

        private void CargarCarrito()
        {
            List<Carrito> carrito =
                carritoController.GetCarrito(UsuarioActual.IdUsuario)
                ?? new List<Carrito>();

            dgCarrito.ItemsSource = carrito;

            if (carrito.Count == 0)
            {
                txtEstadoCarrito.Text = "Tu carrito está vacío.";
                txtCantidadItems.Text = "0 productos";
                txtTotalCarrito.Text = "Total: $ 0";
                return;
            }

            double total = carrito.Sum(x => x.Subtotal);
            int cantidadItems = carrito.Sum(x => x.Cantidad);

            txtEstadoCarrito.Text = "Carrito cargado correctamente.";
            txtCantidadItems.Text = $"{cantidadItems} productos";
            txtTotalCarrito.Text = $"Total: $ {total:N0}";
        }

        private void RecalcularTotalProducto()
        {
            if (productoSeleccionado == null)
                return;

            int cantidad = numCantidad.Value ?? 1;
            double total = productoSeleccionado.PrecioProducto * cantidad;
            txtTotalProducto.Text = $"$ {total:N0}";
        }

        private void BtnAgregarActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (!authController.UsuarioLogueado())
            {
                MessageBox.Show("Debes iniciar sesión o registrarte para agregar productos al carrito.");

                MainWindow main = (MainWindow)Window.GetWindow(this);
                main.MainContent.Content = new Login();
                return;
            }

            if (productoSeleccionado == null)
            {
                MessageBox.Show("No hay ningún producto seleccionado.");
                return;
            }

            int cantidad = numCantidad.Value ?? 0;

            if (cantidad <= 0)
            {
                MessageBox.Show("Debes seleccionar una cantidad mayor a 0.");
                return;
            }

            Usuario usuario = UsuarioActual;

            List<Carrito> carritoActual =
                carritoController.GetCarrito(usuario.IdUsuario)
                ?? new List<Carrito>();

            Carrito itemExistente =
                carritoActual.FirstOrDefault(
                    x => x.IdProducto == productoSeleccionado.IdProducto
                );

            if (itemExistente != null)
            {
                itemExistente.Cantidad = cantidad;
                itemExistente.PrecioUnidad = productoSeleccionado.PrecioProducto;

                carritoController.UpdateCarrito(itemExistente);
            }
            else
            {
                Carrito nuevoItem = new Carrito(
                    0,
                    productoSeleccionado.IdProducto,
                    usuario.IdUsuario,
                    productoSeleccionado.NombreProducto,
                    productoSeleccionado.PrecioProducto,
                    cantidad
                );

                carritoController.SetCarrito(nuevoItem);
            }

            MessageBox.Show("Producto agregado al carrito.");

            CargarCarrito();
            RecalcularTotalProducto();
        }

        private void BtnVaciarCarrito_Click(object sender, RoutedEventArgs e)
        {
            List<Carrito> carrito =
                carritoController.GetCarrito(UsuarioActual.IdUsuario)
                ?? new List<Carrito>();

            if (carrito.Count == 0)
            {
                MessageBox.Show("No hay productos en tu carrito.");
                return;
            }

            MessageBoxResult result = MessageBox.Show(
                "¿Seguro que deseas vaciar todo el carrito?",
                "Confirmación",
                MessageBoxButton.YesNo
            );

            if (result == MessageBoxResult.Yes)
            {
                carritoController.DeleteCarrito(
                    UsuarioActual.IdUsuario
                );

                CargarCarrito();
            }
        }

        private void BtnHacerPedido_Click(object sender, RoutedEventArgs e)
        {
            List<Carrito> carrito = carritoController.GetCarrito(UsuarioActual.IdUsuario) ?? new List<Carrito>();

            if (carrito.Count == 0)
            {
                MessageBox.Show("No puedes hacer el pedido porque el carrito está vacío.");
                return;
            }

            MainWindow main = (MainWindow)Window.GetWindow(this);
            main.MainContent.Content = new ConfirmarPedidoView();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Window.GetWindow(this);
            main.MainContent.Content = new HomeView();
        }

        private void numCantidad_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            RecalcularTotalProducto();
        }
    }
}
