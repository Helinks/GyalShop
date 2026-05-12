using Microsoft.Win32;
using Proyecto.Controllers;
using Proyecto.Models;
using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Proyecto.Views
{
    public partial class ProductoView : UserControl
    {
        CategoriaController categoriaController = new CategoriaController();
        ProductoController productoController = new ProductoController();
        Producto selectedProducto;

        private string rutaImagenSeleccionada = null;
        private readonly string carpetaImagenes = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Img", "Productos");

        public ProductoView()
        {
            InitializeComponent();
            Loaded += UserControl_Loaded;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatos();
            limpiarCampos();
        }

        private void CargarDatos()
        {
            CBCategoria.ItemsSource = categoriaController.GetAllCategoria();
            dgProductos.ItemsSource = null;
            dgProductos.ItemsSource = productoController.getAllProductos();
        }

        private void limpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtDescuento.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            CBCategoria.SelectedIndex = -1;
            txtRutaImagen.Text = string.Empty;
            imgPreview.Source = null;
            rutaImagenSeleccionada = null;
            selectedProducto = null;

            BtnActualizar.Visibility = Visibility.Collapsed;
            BtnInhabilitar.Visibility = Visibility.Collapsed;
            BtnCancelar.Visibility = Visibility.Collapsed;
            BtnGuardar.Visibility = Visibility.Visible;
            BtnInhabilitar.Content = "Inhabilitar";
        }

        private void BtnSwitch()
        {
            if (BtnCancelar.Visibility == Visibility.Visible)
            {
                BtnActualizar.Visibility = Visibility.Collapsed;
                BtnInhabilitar.Visibility = Visibility.Collapsed;
                BtnCancelar.Visibility = Visibility.Collapsed;
                BtnGuardar.Visibility = Visibility.Visible;
                return;
            }

            BtnActualizar.Visibility = Visibility.Visible;
            BtnInhabilitar.Visibility = Visibility.Visible;
            BtnCancelar.Visibility = Visibility.Visible;
            BtnGuardar.Visibility = Visibility.Collapsed;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCantidad.Text) ||
                string.IsNullOrWhiteSpace(txtDescuento.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                CBCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor complete todos los campos");
                return false;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad < 0)
            {
                MessageBox.Show("La cantidad debe ser un número válido");
                return false;
            }

            if (!int.TryParse(txtDescuento.Text, out int descuento) || descuento < 0 || descuento > 100)
            {
                MessageBox.Show("El descuento debe estar entre 0 y 100");
                return false;
            }

            if (!double.TryParse(txtPrecio.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double precio) &&
                !double.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("El precio debe ser un número válido");
                return false;
            }

            return true;
        }

        private string GuardarImagenEnCarpeta(string rutaOrigen)
        {
            if (string.IsNullOrWhiteSpace(rutaOrigen))
                return null;

            if (!Directory.Exists(carpetaImagenes))
                Directory.CreateDirectory(carpetaImagenes);

            string extension = Path.GetExtension(rutaOrigen);
            string nombreArchivo = $"producto_{Guid.NewGuid():N}{extension}";
            string rutaDestino = Path.Combine(carpetaImagenes, nombreArchivo);

            File.Copy(rutaOrigen, rutaDestino, true);

            return Path.Combine("Assets", "Img", "Productos", nombreArchivo).Replace("\\", "/");
        }

        private void MostrarPreview(string rutaImagen)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(rutaImagen))
                {
                    imgPreview.Source = null;
                    txtRutaImagen.Text = string.Empty;
                    return;
                }

                string rutaAbsoluta = rutaImagen;

                if (!Path.IsPathRooted(rutaAbsoluta))
                {
                    rutaAbsoluta = Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        rutaImagen.Replace("/", Path.DirectorySeparatorChar.ToString())
                    );
                }

                if (!File.Exists(rutaAbsoluta))
                {
                    imgPreview.Source = null;
                    txtRutaImagen.Text = rutaImagen;
                    return;
                }

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.UriSource = new Uri(rutaAbsoluta, UriKind.Absolute);
                bitmap.EndInit();

                imgPreview.Source = bitmap;
                txtRutaImagen.Text = rutaImagen;
            }
            catch
            {
                imgPreview.Source = null;
            }
        }

        private void BtnSeleccionarImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Imagenes|*.jpg;*.jpeg;*.png;*.bmp;*.webp",
                Title = "Seleccionar imagen del producto"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                rutaImagenSeleccionada = openFileDialog.FileName;
                MostrarPreview(rutaImagenSeleccionada);
            }
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarCampos())
                return;

            Categoria categoria = new Categoria((int)CBCategoria.SelectedValue, "", false);

            string rutaGuardada = null;
            if (!string.IsNullOrWhiteSpace(rutaImagenSeleccionada))
                rutaGuardada = GuardarImagenEnCarpeta(rutaImagenSeleccionada);

            Producto producto = new Producto
            {
                NombreProducto = txtNombre.Text,
                CantidadProducto = int.Parse(txtCantidad.Text),
                DescuentoProducto = int.Parse(txtDescuento.Text),
                PrecioProducto = double.Parse(txtPrecio.Text),
                IdCategoriaProducto = categoria,
                ImagenProducto = rutaGuardada,
                EstaActivo = true
            };

            bool guardado = productoController.setProducto(producto);

            if (guardado)
            {
                MessageBox.Show("Producto guardado con éxito");
                limpiarCampos();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("No se pudo guardar el producto");
            }
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (selectedProducto == null)
                return;

            if (!ValidarCampos())
                return;

            Categoria categoria = new Categoria((int)CBCategoria.SelectedValue, "", false);

            selectedProducto.NombreProducto = txtNombre.Text;
            selectedProducto.CantidadProducto = int.Parse(txtCantidad.Text);
            selectedProducto.DescuentoProducto = int.Parse(txtDescuento.Text);
            selectedProducto.PrecioProducto = double.Parse(txtPrecio.Text);
            selectedProducto.IdCategoriaProducto = categoria;

            if (!string.IsNullOrWhiteSpace(rutaImagenSeleccionada))
            {
                selectedProducto.ImagenProducto = GuardarImagenEnCarpeta(rutaImagenSeleccionada);
            }

            bool actualizado = productoController.updateProducto(selectedProducto);

            if (actualizado)
            {
                MessageBox.Show("Se ha actualizado con éxito");
                CargarDatos();
                limpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el producto");
            }
        }

        private void BtnInhabilitar_Click(object sender, RoutedEventArgs e)
        {
            if (selectedProducto == null)
                return;

            bool nuevoEstado = !selectedProducto.EstaActivo;
            string accion = nuevoEstado ? "habilitar" : "inhabilitar";

            MessageBoxResult result = MessageBox.Show(
                $"¿Está seguro que desea {accion} este producto?",
                "Confirmación",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                bool actualizado = productoController.cambiarEstadoProducto(selectedProducto.IdProducto, nuevoEstado);

                if (actualizado)
                {
                    MessageBox.Show(nuevoEstado ? "Producto habilitado correctamente" : "Producto inhabilitado correctamente");
                    limpiarCampos();
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("No se pudo cambiar el estado del producto");
                }
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            limpiarCampos();
            BtnSwitch();
            CargarDatos();
        }

        private void dgProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedProducto = dgProductos.SelectedItem as Producto;

            if (selectedProducto != null)
            {
                txtNombre.Text = selectedProducto.NombreProducto;
                txtCantidad.Text = selectedProducto.CantidadProducto.ToString();
                txtDescuento.Text = selectedProducto.DescuentoProducto.ToString();
                txtPrecio.Text = selectedProducto.PrecioProducto.ToString();
                CBCategoria.SelectedValue = selectedProducto.IdCategoriaProducto.IdCategoria;

                rutaImagenSeleccionada = null;
                MostrarPreview(selectedProducto.ImagenProducto);

                BtnActualizar.Visibility = Visibility.Visible;
                BtnInhabilitar.Visibility = Visibility.Visible;
                BtnCancelar.Visibility = Visibility.Visible;
                BtnGuardar.Visibility = Visibility.Collapsed;

                BtnInhabilitar.Content = selectedProducto.EstaActivo ? "Inhabilitar" : "Habilitar";
            }
        }
    }
}