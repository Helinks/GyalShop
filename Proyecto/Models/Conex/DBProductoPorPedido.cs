using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Proyecto.Models;
using System.Windows;

namespace Proyecto.Models.Conex
{
    public class DBProductoPorPedido
    {
        string stringConex = "server=localhost; user=root; database=gyalshop; password=Dilnic2909*; port=3306;";

        public bool SetProductoPorPedido(Pedido pedido, List<Carrito> carrito)
        {
            if (pedido == null || pedido.IdPedido <= 0 || carrito == null || carrito.Count == 0)
                return false;

            string query = @"
                INSERT INTO productoporpedido
                (idPedidoProducto, idProductoPedido, precioProducto, cantidadProducto, subtotal)
                VALUES
                (@idPedidoProducto, @idProductoPedido, @precioProducto, @cantidadProducto, @subtotal)";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                mySqlConnection.Open();

                using (MySqlTransaction transaction = mySqlConnection.BeginTransaction())
                {
                    try
                    {
                        foreach (Carrito item in carrito)
                        {
                            using (MySqlCommand command = new MySqlCommand(query, mySqlConnection, transaction))
                            {
                                command.Parameters.AddWithValue("@idPedidoProducto", pedido.IdPedido);
                                command.Parameters.AddWithValue("@idProductoPedido", item.IdProducto);
                                command.Parameters.AddWithValue("@precioProducto", item.PrecioUnidad);
                                command.Parameters.AddWithValue("@cantidadProducto", item.Cantidad);
                                command.Parameters.AddWithValue("@subtotal", item.Subtotal);

                                int result = command.ExecuteNonQuery();

                                if (result <= 0)
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error guardando detalle: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public List<ProductoPorPedido> GetProductoPorPedido(Pedido pedido)
        {
            List<ProductoPorPedido> productosXPedidos = new List<ProductoPorPedido>();

            string query = "SELECT * FROM productoporpedido WHERE idPedidoProducto = @idPedidoProducto";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idPedidoProducto", pedido.IdPedido);
                    mySqlConnection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductoPorPedido productoPorPedido1 = new ProductoPorPedido();
                            productoPorPedido1.IdProductoXPedido = reader.GetInt32("idProductoXPedido");
                            productoPorPedido1.IdPedidoProducto = reader.GetInt32("idPedidoProducto");
                            productoPorPedido1.IdProductoPedido = reader.GetInt32("idProductoPedido");
                            productoPorPedido1.PrecioProducto = reader.GetDouble("precioProducto");
                            productoPorPedido1.CantidadProducto = reader.GetInt32("cantidadProducto");
                            productoPorPedido1.Subtotal = reader.GetDouble("subtotal");

                            productosXPedidos.Add(productoPorPedido1);
                        }
                    }
                }
            }

            return productosXPedidos;
        }
    }
}