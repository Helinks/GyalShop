using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Proyecto.Models.Conex
{
    public class DBCarrito
    {
        string stringConex =
            "server=localhost; user=root; database=gyalshop; password=Dilnic2909*; port=3306;";

        public bool SetCarrito(Carrito carrito)
        {
            string queryInsert = @"
                INSERT INTO carrito
                (
                    idProducto,
                    idCliente,
                    nombreProducto,
                    precioUnidad,
                    cantidadProducto
                )
                VALUES
                (
                    @idProducto,
                    @idCliente,
                    @nombreProducto,
                    @precioUnidad,
                    @cantidadProducto
                )";

            using (MySqlConnection mySqlConnection =
                new MySqlConnection(stringConex))
            {
                using (MySqlCommand command =
                    new MySqlCommand(queryInsert, mySqlConnection))
                {
                    command.Parameters.AddWithValue(
                        "@idProducto",
                        carrito.IdProducto
                    );

                    command.Parameters.AddWithValue(
                        "@idCliente",
                        carrito.IdCliente
                    );

                    command.Parameters.AddWithValue(
                        "@nombreProducto",
                        carrito.NombreProducto
                    );

                    command.Parameters.AddWithValue(
                        "@precioUnidad",
                        carrito.PrecioUnidad
                    );

                    command.Parameters.AddWithValue(
                        "@cantidadProducto",
                        carrito.Cantidad
                    );

                    mySqlConnection.Open();

                    int result = command.ExecuteNonQuery();

                    return result > 0;
                }
            }
        }

        public List<Carrito> GetCarrito(int idCliente)
        {
            List<Carrito> listaCarrito =
                new List<Carrito>();

            string query = @"
                SELECT *
                FROM carrito
                WHERE idCliente = @idCliente";

            using (MySqlConnection mySqlConnection =
                new MySqlConnection(stringConex))
            {
                using (MySqlCommand command =
                    new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue(
                        "@idCliente",
                        idCliente
                    );

                    mySqlConnection.Open();

                    using (MySqlDataReader reader =
                        command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Carrito item = new Carrito
                            {
                                IdCarrito =
                                    reader.GetInt32("idCarrito"),

                                IdProducto =
                                    reader.GetInt32("idProducto"),

                                IdCliente =
                                    reader.GetInt32("idCliente"),

                                NombreProducto =
                                    reader.GetString("nombreProducto"),

                                PrecioUnidad =
                                    reader.GetDouble("precioUnidad"),

                                Cantidad =
                                    reader.GetInt32("cantidadProducto")
                            };

                            listaCarrito.Add(item);
                        }
                    }
                }
            }

            return listaCarrito;
        }

        public bool UpdateCarrito(Carrito carrito)
        {
            string query = @"
                UPDATE carrito
                SET
                    cantidadProducto = @cantidadProducto,
                    precioUnidad = @precioUnidad
                WHERE idCarrito = @idCarrito";

            using (MySqlConnection mySqlConnection =
                new MySqlConnection(stringConex))
            {
                using (MySqlCommand command =
                    new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue(
                        "@cantidadProducto",
                        carrito.Cantidad
                    );

                    command.Parameters.AddWithValue(
                        "@precioUnidad",
                        carrito.PrecioUnidad
                    );

                    command.Parameters.AddWithValue(
                        "@idCarrito",
                        carrito.IdCarrito
                    );

                    mySqlConnection.Open();

                    int result = command.ExecuteNonQuery();

                    return result > 0;
                }
            }
        }

        public bool DeleteCarrito(int idCliente)
        {
            string query = @"
                DELETE FROM carrito
                WHERE idCliente = @idCliente";

            using (MySqlConnection mySqlConnection =
                new MySqlConnection(stringConex))
            {
                using (MySqlCommand command =
                    new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue(
                        "@idCliente",
                        idCliente
                    );

                    mySqlConnection.Open();

                    int result = command.ExecuteNonQuery();

                    return result > 0;
                }
            }
        }
    }
}