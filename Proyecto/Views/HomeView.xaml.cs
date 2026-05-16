using Proyecto.Controllers;
using Proyecto.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto.Views
{
    public partial class HomeView : UserControl
    {
        private readonly AuthController authController = new AuthController();
        private readonly HomeController homeController = new HomeController();

        public HomeView()
        {
            InitializeComponent();
            Loaded += HomeView_Loaded;
        }

        private void HomeView_Loaded(object sender, RoutedEventArgs e)
        {
            CargarCategorias();
            CargarProductos();

            bool logueado = authController.UsuarioLogueado();

            BtnLogin.Visibility = logueado ? Visibility.Collapsed : Visibility.Visible;
            BtnPerfi.Visibility = logueado ? Visibility.Visible : Visibility.Collapsed;
        }

        private void CargarCategorias()
        {
            List<Categoria> categorias = homeController.GetCategorias();

            categorias.Insert(0, new Categoria
            {
                IdCategoria = 0,
                NombreCategoria = "Todas",
                EstaActivo = true
            });

            icCategorias.ItemsSource = categorias;
        }

        private void CargarProductos()
        {
            icProductos.ItemsSource = homeController.GetProductos();
        }

        private void CargarProductosPorCategoria(int idCategoria)
        {
            if (idCategoria == 0)
            {
                CargarProductos();
                return;
            }

            icProductos.ItemsSource = homeController.GetProductosPorCategoria(idCategoria);
        }

        private void BtnCategoria_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag != null && int.TryParse(button.Tag.ToString(), out int idCategoria))
            {
                CargarProductosPorCategoria(idCategoria);
            }
        }

        private void BtnAgregarCarrito_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button == null)
                return;

            Producto producto = button.Tag as Producto;

            if (producto == null)
                return;

            if (!authController.UsuarioLogueado())
            {
                MessageBox.Show("Debes iniciar sesión o registrarte para agregar productos al carrito.");

                MainWindow main = (MainWindow)Window.GetWindow(this);
                main.MainContent.Content = new Login();
                return;
            }

            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.MainContent.Content = new CarritoClienteView(producto);
        }

        private void BtnComprarAhora_Click(object sender, RoutedEventArgs e)
        {
            if (!authController.UsuarioLogueado())
            {
                MessageBox.Show("Debes iniciar sesión o registrarte para continuar.");

                MainWindow main = (MainWindow)Window.GetWindow(this);
                main.MainContent.Content = new Login();
                return;
            }

            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.MainContent.Content = new ComprasView();
        }

        private void BtnExplorar_Click(object sender, RoutedEventArgs e)
        {
            CargarProductos();
        }

        private void BtnProductos_Click(object sender, RoutedEventArgs e)
        {
            CargarProductos();
        }

        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
            CargarProductos();
        }

        private void BtnCarrito_Click(object sender, RoutedEventArgs e)
        {
            if (!authController.UsuarioLogueado())
            {
                MessageBox.Show("Debes iniciar sesión o registrarte para ver tu carrito.");

                MainWindow main = (MainWindow)Window.GetWindow(this);
                main.MainContent.Content = new Login();
                return;
            }

            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.MainContent.Content = new ComprasView();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.MainContent.Content = new Login();
        }

        private void BtnPerfil_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Window.GetWindow(this);
            main.MainContent.Content = new PerfilView();
        }
    }
}