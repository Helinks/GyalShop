using Proyecto.Controllers;
using Proyecto.Models;
using Proyecto.Services;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto.Views
{
    public partial class PerfilView : UserControl
    {
        PerfilController perfilController = new PerfilController();

        public PerfilView()
        {
            InitializeComponent();

            CargarUsuario();
            CargarPedidos();
        }

        private void CargarUsuario()
        {
            Usuario usuario = perfilController.GetUsuario(SesionService.UsuarioActual.IdUsuario);

            txtNombre.Text = usuario.NombreUsuario;
            txtCorreo.Text = usuario.Correo;
            txtTelefono.Text = usuario.Telefono;
            txtDireccion.Text = usuario.Direccion;
        }

        private void CargarPedidos()
        {
            List<Pedido> pedidos = perfilController.GetPedidosUsuario(SesionService.UsuarioActual.IdUsuario);

            dgPedidos.ItemsSource = pedidos;
        }

        private void BtnGuardarDireccion_Click(object sender, RoutedEventArgs e)
        {
            bool result = perfilController.ActualizarDireccion(
                SesionService.UsuarioActual.IdUsuario,
                txtDireccion.Text
            );

            if (result)
            {
                MessageBox.Show("Dirección actualizada");

                SesionService.UsuarioActual.Direccion = txtDireccion.Text;
            }
            else
            {
                MessageBox.Show("Error al actualizar dirección");
            }
        }

        private void BtnVolverInicio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Window.GetWindow(this);
            main.MainContent.Content = new HomeView();
        }
    }
}