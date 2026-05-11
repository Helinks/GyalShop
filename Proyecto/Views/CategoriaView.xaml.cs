using Proyecto.Controllers;
using Proyecto.Models;
using Proyecto.Models.Conex;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto.Views
{
    public partial class CategoriaView : UserControl
    {
        private CategoriaController controller = new CategoriaController();
        private Categoria selectedCategoria;

        public CategoriaView()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            dgCategorias.ItemsSource = controller.getAllCategoria();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if(txtNombre.Text == string.Empty)
            {
                MessageBoxResult result = MessageBox.Show(
                "Por favor complete todos los campos");
                return;

            }
            Categoria categoria = new Categoria
            {
                NombreCategoria = txtNombre.Text,
            };

            controller.setCategoria(categoria);
            txtNombre.Text = string.Empty;
            CargarDatos();
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == string.Empty)
            {
                MessageBoxResult result = MessageBox.Show(
                "Por favor complete todos los campos");
                return;

            }
            if (selectedCategoria == null) return;

            selectedCategoria.NombreCategoria = txtNombre.Text;
           
            controller.updateCategoria(selectedCategoria);
            CargarDatos();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCategoria == null) return;

            MessageBoxResult result = MessageBox.Show(
                "¿Inhabilitar categoria?",
                "Confirmación",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                controller.deleteCategoria(selectedCategoria);
                CargarDatos();
            }
        }
        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            
            txtNombre.Text = string.Empty;
                BtnActualizar.Visibility = Visibility.Collapsed;
                BtnEliminar.Visibility = Visibility.Collapsed;
                BtnCancelar.Visibility = Visibility.Collapsed;
                BtnGuardar.Visibility = Visibility.Visible;
            

        }

        private void dgCategorias_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedCategoria = dgCategorias.SelectedItem as Categoria;

            if (selectedCategoria != null)
            {
                txtNombre.Text = selectedCategoria.NombreCategoria;
                BtnActualizar.Visibility = Visibility.Visible;
                BtnEliminar.Visibility = Visibility.Visible;
                BtnCancelar.Visibility = Visibility.Visible;
                BtnGuardar.Visibility = Visibility.Collapsed;
            }
        }
    }
}