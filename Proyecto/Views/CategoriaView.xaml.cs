using Proyecto.Controllers;
using Proyecto.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto.Views
{
    public partial class CategoriaView : UserControl
    {
        private readonly CategoriaController controller = new CategoriaController();
        private Categoria selectedCategoria;

        public CategoriaView()
        {
            InitializeComponent();
            Loaded += CategoriaView_Loaded;
        }

        private void CategoriaView_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatos();
            limpiarCampos();
        }

        private void CargarDatos()
        {
            dgCategorias.ItemsSource = null;
            dgCategorias.ItemsSource = controller.GetAllCategoriaConEstado();
        }

        private void limpiarCampos()
        {
            txtNombre.Text = string.Empty;
            if (chkEstado != null)
                chkEstado.IsChecked = true;

            selectedCategoria = null;
            dgCategorias.SelectedItem = null;

            BtnActualizar.Visibility = Visibility.Collapsed;
            BtnEliminar.Visibility = Visibility.Collapsed;
            BtnCancelar.Visibility = Visibility.Collapsed;
            BtnGuardar.Visibility = Visibility.Visible;

            BtnEliminar.Content = "Inhabilitar";
        }

        private void BtnSwitch()
        {
            if (BtnCancelar.Visibility == Visibility.Visible)
            {
                BtnActualizar.Visibility = Visibility.Collapsed;
                BtnEliminar.Visibility = Visibility.Collapsed;
                BtnCancelar.Visibility = Visibility.Collapsed;
                BtnGuardar.Visibility = Visibility.Visible;
                return;
            }

            BtnActualizar.Visibility = Visibility.Visible;
            BtnEliminar.Visibility = Visibility.Visible;
            BtnCancelar.Visibility = Visibility.Visible;
            BtnGuardar.Visibility = Visibility.Collapsed;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor complete todos los campos");
                return false;
            }

            return true;
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarCampos())
                return;

            Categoria categoria = new Categoria
            {
                NombreCategoria = txtNombre.Text.Trim(),
                EstaActivo = chkEstado.IsChecked == true
            };

            bool guardado = controller.SetCategoria(categoria);

            if (guardado)
            {
                MessageBox.Show("Categoría guardada con éxito");
                limpiarCampos();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("No se pudo guardar la categoría");
            }
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCategoria == null)
                return;

            if (!ValidarCampos())
                return;

            selectedCategoria.NombreCategoria = txtNombre.Text.Trim();
            selectedCategoria.EstaActivo = chkEstado.IsChecked == true;

            bool actualizado = controller.UpdateCategoria(selectedCategoria);

            if (actualizado)
            {
                MessageBox.Show("Se ha actualizado con éxito");
                limpiarCampos();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la categoría");
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCategoria == null)
                return;

            bool nuevoEstado = !selectedCategoria.EstaActivo;
            string accion = nuevoEstado ? "habilitar" : "inhabilitar";

            MessageBoxResult result = MessageBox.Show(
                $"¿Está seguro que desea {accion} esta categoría?",
                "Confirmación",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                bool cambiado = controller.CambiarEstadoCategoria(selectedCategoria.IdCategoria, nuevoEstado);

                if (cambiado)
                {
                    MessageBox.Show(nuevoEstado
                        ? "Categoría habilitada correctamente"
                        : "Categoría inhabilitada correctamente");

                    limpiarCampos();
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("No se pudo cambiar el estado de la categoría");
                }
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            limpiarCampos();
            BtnSwitch();
            CargarDatos();
        }

        private void dgCategorias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCategoria = dgCategorias.SelectedItem as Categoria;

            if (selectedCategoria != null)
            {
                txtNombre.Text = selectedCategoria.NombreCategoria;
                chkEstado.IsChecked = selectedCategoria.EstaActivo;

                BtnActualizar.Visibility = Visibility.Visible;
                BtnEliminar.Visibility = Visibility.Visible;
                BtnCancelar.Visibility = Visibility.Visible;
                BtnGuardar.Visibility = Visibility.Collapsed;

                BtnEliminar.Content = selectedCategoria.EstaActivo ? "Inhabilitar" : "Habilitar";
            }
        }
    }
}