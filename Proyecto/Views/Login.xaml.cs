using Proyecto.Controllers;
using Proyecto.Models;
using Proyecto.Services;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto.Views
{
    public partial class Login : UserControl
    {
        AuthController authController = new AuthController();

        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string correo = txtCorreo.Text;
            string password = txtPassword.Password;

            Usuario usuario = authController.Login(correo, password);

            if (usuario == null)
            {
                MessageBox.Show("Correo o contraseña incorrectos");
                return;
            }

            MainWindow main = (MainWindow)Window.GetWindow(this);

            if (SesionService.EsAdmin)
                main.MainContent.Content = new DashboardView();
            else
                main.MainContent.Content = new HomeView();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Window.GetWindow(this);

            main.MainContent.Content = new SignUp();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Window.GetWindow(this);

            main.MainContent.Content = new HomeView();
        }
    }
}