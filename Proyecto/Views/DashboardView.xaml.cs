using Proyecto.Services;
using Proyecto.Views;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto.Views
{
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
            //MainContent.Content = new DashboardHome();
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            //MainContent.Content = new DashboardHome();
        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new UsuarioView();
        }

        private void BtnProducts_Click(object sender, RoutedEventArgs e)
        {
            //MainContent.Content = new ProductsView();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            SesionService.CerrarSesion();

            MainWindow main = (MainWindow)Window.GetWindow(this);
            main.MainContent.Content = new HomeView();
        }
    }
}