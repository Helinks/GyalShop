using Proyecto.Controllers;
using Proyecto.Models;
using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto.Views
{
    public partial class UsuarioView : UserControl
    {
        private readonly UsuarioController controller = new UsuarioController();
        private Usuario selectedUser;

        public UsuarioView()
        {
            InitializeComponent();

            Loaded += UsuarioView_Loaded;
        }

        private void UsuarioView_Loaded(object sender, RoutedEventArgs e)
        {
            CargarTiposUsuario();
            CargarDatos();
            LimpiarCampos();
        }

        private void CargarDatos()
        {
            dgUsuarios.ItemsSource = null;
            dgUsuarios.ItemsSource = controller.GetAll();
        }

        private void CargarTiposUsuario()
        {
            cmbTipo.ItemsSource = controller.GetTiposUsuario();

            cmbTipo.DisplayMemberPath = "NombreTipo";
            cmbTipo.SelectedValuePath = "IdTipo";
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCorreo.Clear();
            txtPassword.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();

            cmbTipo.SelectedIndex = -1;

            chkEstado.IsChecked = true;

            selectedUser = null;

            dgUsuarios.SelectedItem = null;
        }

        private bool ValidarCorreo(string correo)
        {
            try
            {
                MailAddress mail = new MailAddress(correo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool ValidarTelefono(string telefono)
        {
            return Regex.IsMatch(telefono, @"^[0-9+\-\s]{7,20}$");
        }

        private bool ValidarCampos(bool esActualizacion)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("El correo es obligatorio.");
                return false;
            }

            if (!ValidarCorreo(txtCorreo.Text.Trim()))
            {
                MessageBox.Show("Correo inválido.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("El teléfono es obligatorio.");
                return false;
            }

            if (!ValidarTelefono(txtTelefono.Text.Trim()))
            {
                MessageBox.Show("Teléfono inválido.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("La dirección es obligatoria.");
                return false;
            }

            if (cmbTipo.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un tipo de usuario.");
                return false;
            }

            if (!esActualizacion)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Password))
                {
                    MessageBox.Show("La contraseña es obligatoria.");
                    return false;
                }

                if (txtPassword.Password.Length < 6)
                {
                    MessageBox.Show("La contraseña debe tener mínimo 6 caracteres.");
                    return false;
                }
            }

            return true;
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarCampos(false))
                return;

            Usuario u = new Usuario
            {
                NombreUsuario = txtNombre.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Password = txtPassword.Password,
                Telefono = txtTelefono.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                EstaActivo = chkEstado.IsChecked == true,

                TipoUsuario = new TipoUsuario
                {
                    IdTipo = Convert.ToInt32(cmbTipo.SelectedValue)
                }
            };

            bool resultado = controller.Create(u);

            if (resultado)
            {
                MessageBox.Show("Usuario creado correctamente.");

                CargarDatos();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo crear el usuario.");
            }
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (selectedUser == null)
            {
                MessageBox.Show("Selecciona un usuario.");
                return;
            }

            if (!ValidarCampos(true))
                return;

            selectedUser.NombreUsuario = txtNombre.Text.Trim();
            selectedUser.Correo = txtCorreo.Text.Trim();
            selectedUser.Telefono = txtTelefono.Text.Trim();
            selectedUser.Direccion = txtDireccion.Text.Trim();

            selectedUser.EstaActivo = chkEstado.IsChecked == true;

            selectedUser.TipoUsuario.IdTipo =
                Convert.ToInt32(cmbTipo.SelectedValue);

            bool cambiarPassword =
                !string.IsNullOrWhiteSpace(txtPassword.Password);

            if (cambiarPassword)
            {
                if (txtPassword.Password.Length < 6)
                {
                    MessageBox.Show("La contraseña debe tener mínimo 6 caracteres.");
                    return;
                }

                selectedUser.Password = txtPassword.Password;
            }

            bool resultado = controller.Update(selectedUser, cambiarPassword);

            if (resultado)
            {
                MessageBox.Show("Usuario actualizado correctamente.");

                CargarDatos();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el usuario.");
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (selectedUser == null)
            {
                MessageBox.Show("Selecciona un usuario.");
                return;
            }

            MessageBoxResult result = MessageBox.Show(
                "¿Deseas inhabilitar este usuario?",
                "Confirmación",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                bool resultado =
                    controller.UpdateEstado(selectedUser.IdUsuario, false);

                if (resultado)
                {
                    MessageBox.Show("Usuario inhabilitado.");

                    CargarDatos();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo inhabilitar el usuario.");
                }
            }
        }

        private void dgUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedUser = dgUsuarios.SelectedItem as Usuario;

            if (selectedUser != null)
            {
                txtNombre.Text = selectedUser.NombreUsuario;
                txtCorreo.Text = selectedUser.Correo;
                txtTelefono.Text = selectedUser.Telefono;
                txtDireccion.Text = selectedUser.Direccion;

                chkEstado.IsChecked = selectedUser.EstaActivo;

                if (selectedUser.TipoUsuario != null)
                {
                    cmbTipo.SelectedValue =
                        selectedUser.TipoUsuario.IdTipo;
                }

                txtPassword.Clear();
            }
        }
    }
}