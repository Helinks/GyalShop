using System.Windows;
using System.Windows.Controls;
using Proyecto.Controllers;
using Proyecto.Models;

namespace Proyecto.Views
{
    public partial class SignUp : UserControl
    {
        AuthController authController = new AuthController();

        public SignUp()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario
            {
                NombreUsuario = txtNombre.Text,
                Correo = txtCorreo.Text,
                Password = txtPassword.Password,
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text,
                EstaActivo = true,
                TipoUsuario = new TipoUsuario
                {
                    IdTipo = 2
                }
            };

            bool result = authController.Register(usuario);

            if (result)
            {
                MessageBox.Show("Usuario registrado correctamente");

                MainWindow main = (MainWindow)Window.GetWindow(this);
                main.MainContent.Content = new Login();
            }
            else
            {
                MessageBox.Show("Error al registrar usuario");
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Window.GetWindow(this);
            main.MainContent.Content = new Login();
        }
<<<<<<< HEAD

=======
>>>>>>> 5a903cf (Perfil y HomeView echos con el carrito)
        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Window.GetWindow(this);
            main.MainContent.Content = new HomeView();
        }
    }
}