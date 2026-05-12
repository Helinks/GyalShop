using Proyecto.Controllers;
using Proyecto.Models;
using Proyecto.Models.Conex;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto.Views
{
    public partial class ComprasView : UserControl
    {
        private CategoriaController controller = new CategoriaController();
        private ProductoController productoController = new ProductoController();
        private Categoria selectedCategoria;
        private Producto selectedProducto;
        public ObservableCollection<Carrito> carrito;

        public ComprasView()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            dgProductos.ItemsSource = productoController.getAllProductos();
            carrito = new ObservableCollection<Carrito>();
            dgCarrito.ItemsSource = carrito;


        }
        private void limpiarCampos()
        {
            txtNombre.Text = string.Empty;
        }
        private void BtnSwitch()
        {

            if (BtnCancelar.Visibility == Visibility.Visible)
            {
                BtnActualizar.Visibility = Visibility.Collapsed;
                BtnEliminar.Visibility = Visibility.Collapsed;
                BtnCancelar.Visibility = Visibility.Collapsed;
                BtnAgregar.Visibility = Visibility.Visible;
                return;
            }
            BtnActualizar.Visibility = Visibility.Visible;
            BtnEliminar.Visibility = Visibility.Visible;
            BtnCancelar.Visibility = Visibility.Visible;
            BtnAgregar.Visibility = Visibility.Collapsed;
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == string.Empty)
            {
                MessageBoxResult result = MessageBox.Show(
                "Por favor complete todos los campos");
                return;

            }
            Categoria categoria = new Categoria
            {
                NombreCategoria = txtNombre.Text,
            };

            controller.SetCategoria(categoria);
            limpiarCampos();
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

            

            controller.UpdateCategoria(selectedCategoria);
            limpiarCampos();
            CargarDatos();
            MessageBoxResult update = MessageBox.Show(
                "Se ha actualizado con exito");
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCategoria == null) return;

            MessageBoxResult result = MessageBox.Show(
                "¿Esta seguro que desea eliminar este producto?",
                "Confirmación",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                controller.DeleteCategoria(selectedCategoria);
                limpiarCampos();
                CargarDatos();
            }
        }
        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            limpiarCampos();
            BtnSwitch();
            CargarDatos();
        }

        private void dgProductos_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedProducto = dgProductos.SelectedItem as Producto;

            if (selectedProducto != null)
            {
                nombreProductoLabel.Visibility = Visibility.Visible;
                cantidadProductoLabel.Visibility = Visibility.Visible;
                nombreProducto.Visibility = Visibility.Visible;
                numCantidad.Visibility = Visibility.Visible;
                nombreProducto.Text = selectedProducto.NombreProducto;
                BtnAgregar.Visibility = Visibility.Visible;
            }
        }
        private void dgProductoCarrito_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedCategoria = dgProductos.SelectedItem as Categoria;

            if (selectedCategoria != null)
            {
                
                BtnActualizar.Visibility = Visibility.Visible;
                BtnEliminar.Visibility = Visibility.Visible;
                BtnCancelar.Visibility = Visibility.Visible;
                
            }
        }


        private void AgregarCarrito(object sender, RoutedEventArgs e)
        {
            int cantidad = numCantidad.Value ?? 0 ;
            Producto producto = dgProductos.SelectedItem as Producto;
            Carrito itemExistente = carrito.FirstOrDefault(x => x.IdProducto == producto.IdProducto);

            if (itemExistente != null)
            {
                itemExistente.Cantidad += cantidad;
            }
            else
            {
                carrito.Add(new Carrito
                {
                    IdProducto = producto.IdProducto,
                    NombreProducto = producto.NombreProducto,
                    PrecioUnidad = producto.PrecioProducto,
                    Cantidad = cantidad
                });
            }
            numCantidad.Value = 0;
        }
    }
}