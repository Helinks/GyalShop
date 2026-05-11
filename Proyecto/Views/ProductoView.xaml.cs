using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Proyecto.Models;
using Proyecto.Models.Conex;
using Proyecto.Controllers;

namespace Proyecto.Views
{
    /// <summary>
    /// Interaction logic for ProductoView.xaml
    /// </summary>
    public partial class ProductoView : UserControl
    {
        CategoriaController categoriaController = new CategoriaController();
        ProductoController productoController = new ProductoController();
        Producto selectedProducto;
        public ProductoView()
        {
            InitializeComponent();
            CargarDatos();
        }
        private void CargarDatos()
        {
            CBCategoria.ItemsSource = categoriaController.getAllCategoria();
            dgProductos.ItemsSource = productoController.getAllProductos();
        }
        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == string.Empty || txtCantidad.Text==string.Empty || txtDescuento.Text == string.Empty || txtPrecio.Text == string.Empty || CBCategoria.SelectedIndex == -1)
            {
                MessageBoxResult result = MessageBox.Show(
                "Por favor complete todos los campos");
                return;

            }
            Categoria categoria = new Categoria((int)CBCategoria.SelectedValue,"",false);
            Producto producto = new Producto
            {
                NombreProducto = txtNombre.Text,
                CantidadProducto = int.Parse(txtCantidad.Text),
                DescuentoProducto = int.Parse(txtDescuento.Text),
                PrecioProducto = double.Parse(txtPrecio.Text),
                IdCategoriaProducto =categoria,
            };

            productoController.setProducto(producto);
            txtNombre.Text = string.Empty;
            CargarDatos();
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == string.Empty || txtCantidad.Text == string.Empty || txtDescuento.Text == string.Empty || txtPrecio.Text == string.Empty || CBCategoria.SelectedIndex == -1)
            {
                MessageBoxResult result = MessageBox.Show(
                "Por favor complete todos los campos");
                return;

            }
            if (selectedProducto == null) return;

            Categoria categoria = new Categoria((int)CBCategoria.SelectedValue, "", false);
            selectedProducto.NombreProducto = txtNombre.Text;
            selectedProducto.CantidadProducto = int.Parse(txtCantidad.Text);
            selectedProducto.DescuentoProducto = int.Parse(txtDescuento.Text);
            selectedProducto.PrecioProducto = int.Parse(txtPrecio.Text);
            selectedProducto.IdCategoriaProducto = categoria;

            productoController.updateProducto(selectedProducto);
            txtNombre.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtDescuento.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            CBCategoria.SelectedIndex = -1;
            BtnActualizar.Visibility = Visibility.Collapsed;
            BtnEliminar.Visibility = Visibility.Collapsed;
            BtnCancelar.Visibility = Visibility.Collapsed;
            BtnGuardar.Visibility = Visibility.Visible;
            CargarDatos();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (selectedProducto == null) return;

            MessageBoxResult result = MessageBox.Show(
                "¿Inhabilitar categoria?",
                "Confirmación",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                productoController.deleteProducto(selectedProducto);
                CargarDatos();
            }
        }
        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            
            txtNombre.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtDescuento.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            CBCategoria.SelectedIndex = -1;
            BtnActualizar.Visibility = Visibility.Collapsed;
            BtnEliminar.Visibility = Visibility.Collapsed;
            BtnCancelar.Visibility = Visibility.Collapsed;
            BtnGuardar.Visibility = Visibility.Visible;
            CargarDatos();


        }

        private void dgProducts_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedProducto = dgProductos.SelectedItem as Producto;

            if (selectedProducto != null)
            {
                txtNombre.Text = selectedProducto.NombreProducto;
                txtCantidad.Text = selectedProducto.CantidadProducto.ToString();
                txtDescuento.Text = selectedProducto.DescuentoProducto.ToString();
                txtPrecio.Text = selectedProducto.PrecioProducto.ToString();
                CBCategoria.SelectedValue = selectedProducto.IdCategoriaProducto.IdCategoria;

                BtnActualizar.Visibility = Visibility.Visible;
                BtnEliminar.Visibility = Visibility.Visible;
                BtnCancelar.Visibility = Visibility.Visible;
                BtnGuardar.Visibility = Visibility.Collapsed;
            }

        }
    }
}
