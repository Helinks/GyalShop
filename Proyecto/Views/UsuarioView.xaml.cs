using Proyecto.Controllers;
using Proyecto.Models;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto.Views
{
    public partial class UsuarioView : UserControl
    {
        private UsuarioController controller = new UsuarioController();
        private Usuario selectedUser;

        public UsuarioView()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            dgUsuarios.ItemsSource = controller.GetAll();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Usuario u = new Usuario
            {
                NombreUsuario = txtNombre.Text,
                Correo = txtCorreo.Text,
                Password = txtPassword.Password,
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text,
                EstaActivo = true,
                TipoUsuario = new TipoUsuario { IdTipo = int.Parse(txtTipo.Text) }
            };

            controller.Create(u);
            CargarDatos();
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (selectedUser == null) return;

            selectedUser.NombreUsuario = txtNombre.Text;
            selectedUser.Correo = txtCorreo.Text;
            selectedUser.Telefono = txtTelefono.Text;
            selectedUser.Direccion = txtDireccion.Text;
            selectedUser.TipoUsuario.IdTipo = int.Parse(txtTipo.Text);

            controller.Update(selectedUser);
            CargarDatos();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (selectedUser == null) return;

            MessageBoxResult result = MessageBox.Show(
                "¿Inhabilitar usuario?",
                "Confirmación",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                controller.Delete(selectedUser.IdUsuario);
                CargarDatos();
            }
        }

        private void dgUsuarios_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedUser = dgUsuarios.SelectedItem as Usuario;

            if (selectedUser != null)
            {
                txtNombre.Text = selectedUser.NombreUsuario;
                txtCorreo.Text = selectedUser.Correo;
                txtTelefono.Text = selectedUser.Telefono;
                txtDireccion.Text = selectedUser.Direccion;
                txtTipo.Text = selectedUser.TipoUsuario.IdTipo.ToString();
            }
        }
    }
}