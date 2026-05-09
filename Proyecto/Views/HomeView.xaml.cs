using Proyecto.Controllers;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto.Views
{
    public partial class HomeView : UserControl
    {
        private AuthController authController = new AuthController();

        public HomeView()
        {
            InitializeComponent();
            Loaded += HomeView_Loaded;
        }

        private void HomeView_Loaded(object sender, RoutedEventArgs e)
        {
            bool logueado = authController.UsuarioLogueado();

            BtnLogin.Visibility = logueado
                ? Visibility.Collapsed
                : Visibility.Visible;

            BtnPerfi.Visibility = logueado
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Window.GetWindow(this);

            main.MainContent.Content = new Login();
        }
    }
}