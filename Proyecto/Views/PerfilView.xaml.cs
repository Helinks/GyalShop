<<<<<<< HEAD
﻿// ============================
// PerfilView.xaml.cs
// ============================

using Proyecto.Controllers;
using Proyecto.Models;
using Proyecto.Services;
using System.Collections.Generic;
=======
﻿using Proyecto.Controllers;
using Proyecto.Models;
using Proyecto.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
>>>>>>> 5a903cf (Perfil y HomeView echos con el carrito)
using System.Windows;
using System.Windows.Controls;

namespace Proyecto.Views
{
    public partial class PerfilView : UserControl
    {
<<<<<<< HEAD
        PerfilController perfilController = new PerfilController();
=======
        private readonly PerfilController perfilController = new PerfilController();

        private ObservableCollection<PedidoDetalleVista> pedidosDetalle =
            new ObservableCollection<PedidoDetalleVista>();
>>>>>>> 5a903cf (Perfil y HomeView echos con el carrito)

        public PerfilView()
        {
            InitializeComponent();

            CargarUsuario();
            CargarPedidos();
        }

        private void CargarUsuario()
        {
<<<<<<< HEAD
            Usuario usuario = perfilController.GetUsuario(SesionService.UsuarioActual.IdUsuario);
=======
            if (SesionService.UsuarioActual == null)
                return;

            Usuario usuario =
                perfilController.GetUsuario(SesionService.UsuarioActual.IdUsuario);

            if (usuario == null)
                return;
>>>>>>> 5a903cf (Perfil y HomeView echos con el carrito)

            txtNombre.Text = usuario.NombreUsuario;
            txtCorreo.Text = usuario.Correo;
            txtTelefono.Text = usuario.Telefono;
            txtDireccion.Text = usuario.Direccion;
        }

        private void CargarPedidos()
        {
<<<<<<< HEAD
            List<Pedido> pedidos = perfilController.GetPedidosUsuario(SesionService.UsuarioActual.IdUsuario);

            dgPedidos.ItemsSource = pedidos;
=======
            if (SesionService.UsuarioActual == null)
                return;

            List<Pedido> pedidos =
                perfilController.GetPedidosUsuario(
                    SesionService.UsuarioActual.IdUsuario
                );

            pedidosDetalle.Clear();

            foreach (Pedido pedido in pedidos)
            {
                if (pedido.Productos == null)
                    continue;

                foreach (ProductoPorPedido producto in pedido.Productos)
                {
                    pedidosDetalle.Add(new PedidoDetalleVista
                    {
                        IdPedido = pedido.IdPedido,

                        Estado = pedido.IdEstadoPedido.ToString(),

                        NombreProducto = producto.NombreProducto,

                        PrecioProducto = producto.PrecioProducto,

                        CantidadProducto = producto.CantidadProducto,

                        Subtotal = producto.Subtotal
                    });
                }
            }

            dgPedidosDetalle.ItemsSource = pedidosDetalle;
>>>>>>> 5a903cf (Perfil y HomeView echos con el carrito)
        }

        private void BtnGuardarDireccion_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
=======
            if (SesionService.UsuarioActual == null)
                return;

>>>>>>> 5a903cf (Perfil y HomeView echos con el carrito)
            bool result = perfilController.ActualizarDireccion(
                SesionService.UsuarioActual.IdUsuario,
                txtDireccion.Text
            );

            if (result)
            {
                MessageBox.Show("Dirección actualizada");

<<<<<<< HEAD
                SesionService.UsuarioActual.Direccion = txtDireccion.Text;
=======
                SesionService.UsuarioActual.Direccion =
                    txtDireccion.Text;
>>>>>>> 5a903cf (Perfil y HomeView echos con el carrito)
            }
            else
            {
                MessageBox.Show("Error al actualizar dirección");
            }
        }

        private void BtnVolverInicio_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            MainWindow main = (MainWindow)Window.GetWindow(this);
            main.MainContent.Content = new HomeView();
        }
=======
            MainWindow main =
                (MainWindow)Window.GetWindow(this);

            main.MainContent.Content = new HomeView();
        }

        private class PedidoDetalleVista
        {
            public int IdPedido { get; set; }

            public string Estado { get; set; }

            public string NombreProducto { get; set; }

            public double PrecioProducto { get; set; }

            public int CantidadProducto { get; set; }

            public double Subtotal { get; set; }
        }
>>>>>>> 5a903cf (Perfil y HomeView echos con el carrito)
    }
}