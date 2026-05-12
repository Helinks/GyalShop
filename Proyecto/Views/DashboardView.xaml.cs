using Proyecto.Services;
using Proyecto.Views;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto.Views
{
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
            
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new HomeView();
        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new UsuarioView();
        }

        private void BtnCategorias_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CategoriaView();

        }

        private void BtnProducts_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ProductoView();
        }
        private void BtnCompras_Click(object sender, RoutedEventArgs e)
        {

            MainContent.Content = new ComprasView();
       
        }
        private void BtnPedidos_Click(object sender, RoutedEventArgs e)
        {

            MainContent.Content = new PedidosView();

        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            SesionService.CerrarSesion();

            MainWindow main = (MainWindow)Window.GetWindow(this);
            main.MainContent.Content = new HomeView();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}