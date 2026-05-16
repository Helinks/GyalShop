using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Proyecto.Models.Conex
{
    public class DBProductoPorPedido
    {
        string stringConex = "server=localhost; user=root; database=gyalshop; password=Dilnic2909*; port=3306;";

        public bool SetProductoPorPedido(Pedido pedido, List<Carrito> carrito)
        {
            string query = "insert into productoporpedido (idPedidoProducto, idProductoPedido, precioProducto, cantidadProducto, subTotal) values (@idPedidoProducto, @idProductoPedido, @precioProducto, @cantidadProducto, @subTotal)";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                mySqlConnection.Open();
                using (MySqlTransaction mySqlTransaction = mySqlConnection.BeginTransaction())
                {
                    try
                    {
                        foreach (Carrito c in carrito)
                        {
                            using (MySqlCommand command = new MySqlCommand(query, mySqlConnection, mySqlTransaction))
                            {

                                command.Parameters.AddWithValue("@idPedidoProducto", pedido.IdPedido);
                                command.Parameters.AddWithValue("@idProductoPedido", c.IdProducto);
                                command.Parameters.AddWithValue("@precioProducto", c.PrecioUnidad);
                                command.Parameters.AddWithValue("@cantidadProducto", c.Cantidad);
                                command.Parameters.AddWithValue("@subTotal", c.Subtotal);

                                command.ExecuteNonQuery();
                            }
                        }
                        mySqlTransaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error en la transacción: " + ex.Message);
                        mySqlTransaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public List<ProductoPorPedido> GetProductoPorPedido(Pedido pedido)
        {
            List<ProductoPorPedido> productosXPedidos =
                new List<ProductoPorPedido>();

            string query = @"
        SELECT *
        FROM productoporpedido pp
        INNER JOIN productos p
            ON pp.idProductoPedido = p.idProducto
        WHERE idPedidoProducto = @idPedidoProducto";

            using (MySqlConnection mySqlConnection =
                new MySqlConnection(stringConex))
            {
                using (MySqlCommand command =
                    new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue(
                        "@idPedidoProducto",
                        pedido.IdPedido
                    );

                    mySqlConnection.Open();

                    using (MySqlDataReader reader =
                        command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductoPorPedido productoPorPedido1 =
                                new ProductoPorPedido();

                            productoPorPedido1.IdProductoXPedido =
                                reader.GetInt32("idProductoXPedido");

                            productoPorPedido1.IdPedidoProducto =
                                reader.GetInt32("idPedidoProducto");

                            productoPorPedido1.IdProductoPedido =
                                reader.GetInt32("idProductoPedido");

                            productoPorPedido1.NombreProducto =
                                reader.GetString("nombreProducto");

                            productoPorPedido1.PrecioProducto =
                                reader.GetDouble("precioProducto");

                            productoPorPedido1.CantidadProducto =
                                reader.GetInt32("cantidadProducto");

                            productoPorPedido1.Subtotal =
                                reader.GetDouble("subtotal");

                            productosXPedidos.Add(productoPorPedido1);
                        }
                    }
                }
            }

            return productosXPedidos;
        }
    }
}