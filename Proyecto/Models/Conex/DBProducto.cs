using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Proyecto.Models.Conex
{
    public class DBProducto
    {
        string stringConex = "server=localhost; user=root; database=gyalshop; password=; port=3306;";

        public bool setProducto(Producto producto)
        {
            string queryInsert = @"INSERT INTO productos 
                                   (idCategoriaProducto, nombreProducto, cantidadProducto, precioProducto, descuentoProducto, imagenProducto, estadoProducto) 
                                   VALUES 
                                   (@idCategoriaProducto, @nombreProducto, @cantidadProducto, @precioProducto, @descuentoProducto, @imagenProducto, @estadoProducto)";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            using (MySqlCommand command = new MySqlCommand(queryInsert, mySqlConnection))
            {
                command.Parameters.AddWithValue("@idCategoriaProducto", producto.IdCategoriaProducto.IdCategoria);
                command.Parameters.AddWithValue("@nombreProducto", producto.NombreProducto);
                command.Parameters.AddWithValue("@cantidadProducto", producto.CantidadProducto);
                command.Parameters.AddWithValue("@precioProducto", producto.PrecioProducto);
                command.Parameters.AddWithValue("@descuentoProducto", producto.DescuentoProducto);
                command.Parameters.AddWithValue("@imagenProducto", string.IsNullOrWhiteSpace(producto.ImagenProducto) ? (object)DBNull.Value : producto.ImagenProducto);
                command.Parameters.AddWithValue("@estadoProducto", true);

                mySqlConnection.Open();
                int result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public Producto getProducto(Producto producto)
        {
            if (producto == null) return null;
            return getProducto(producto.IdProducto);
        }

        public Producto getProducto(int idProducto)
        {
            Producto resProducto = new Producto();

            string query = @"SELECT idProducto, idCategoriaProducto, nombreProducto, cantidadProducto, precioProducto, descuentoProducto, imagenProducto, estadoProducto
                             FROM productos
                             WHERE idProducto = @idProducto";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
            {
                command.Parameters.AddWithValue("@idProducto", idProducto);

                mySqlConnection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resProducto.IdProducto = reader.GetInt32("idProducto");

                        resProducto.IdCategoriaProducto = new Categoria();
                        resProducto.IdCategoriaProducto.IdCategoria = reader.GetInt32("idCategoriaProducto");

                        resProducto.NombreProducto = reader.GetString("nombreProducto");
                        resProducto.CantidadProducto = reader.GetInt32("cantidadProducto");
                        resProducto.PrecioProducto = reader.GetDouble("precioProducto");
                        resProducto.DescuentoProducto = reader.GetInt32("descuentoProducto");
                        resProducto.ImagenProducto = reader.IsDBNull(reader.GetOrdinal("imagenProducto")) ? null : reader.GetString("imagenProducto");
                        resProducto.EstaActivo = reader.GetBoolean("estadoProducto");
                    }
                }
            }

            return resProducto;
        }

        public List<Producto> getProductos(Producto producto)
        {
            List<Producto> resProductos = new List<Producto>();

            string query = @"SELECT p.idProducto,
                                    p.idCategoriaProducto,
                                    c.nombreCategoria,
                                    p.nombreProducto,
                                    p.cantidadProducto,
                                    p.precioProducto,
                                    p.descuentoProducto,
                                    p.imagenProducto,
                                    p.estadoProducto
                             FROM productos p
                             INNER JOIN categorias c ON p.idCategoriaProducto = c.idCategoria
                             WHERE p.idProducto = @idProducto";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
            {
                command.Parameters.AddWithValue("@idProducto", producto.IdProducto);

                mySqlConnection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Producto productos = new Producto();

                        productos.IdProducto = reader.GetInt32("idProducto");

                        productos.IdCategoriaProducto = new Categoria();
                        productos.IdCategoriaProducto.IdCategoria = reader.GetInt32("idCategoriaProducto");
                        productos.IdCategoriaProducto.NombreCategoria = reader.GetString("nombreCategoria");

                        productos.NombreProducto = reader.GetString("nombreProducto");
                        productos.CantidadProducto = reader.GetInt32("cantidadProducto");
                        productos.PrecioProducto = reader.GetDouble("precioProducto");
                        productos.DescuentoProducto = reader.GetInt32("descuentoProducto");
                        productos.ImagenProducto = reader.IsDBNull(reader.GetOrdinal("imagenProducto")) ? null : reader.GetString("imagenProducto");
                        productos.EstaActivo = reader.GetBoolean("estadoProducto");

                        resProductos.Add(productos);
                    }
                }
            }

            return resProductos;
        }

        public List<Producto> getAllProductos()
        {
            List<Producto> resProductos = new List<Producto>();

            string query = @"SELECT p.idProducto,
                            p.idCategoriaProducto,
                            c.nombreCategoria,
                            p.nombreProducto,
                            p.cantidadProducto,
                            p.precioProducto,
                            p.descuentoProducto,
                            p.imagenProducto,
                            p.estadoProducto
                     FROM productos p
                     LEFT JOIN categorias c 
                        ON p.idCategoriaProducto = c.idCategoria
                     ORDER BY p.idProducto DESC";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
            {
                mySqlConnection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Producto productos = new Producto();

                        productos.IdProducto = Convert.ToInt32(reader["idProducto"]);

                        productos.IdCategoriaProducto = new Categoria();

                        productos.IdCategoriaProducto.IdCategoria =
                            reader["idCategoriaProducto"] == DBNull.Value
                            ? 0
                            : Convert.ToInt32(reader["idCategoriaProducto"]);

                        productos.IdCategoriaProducto.NombreCategoria =
                            reader["nombreCategoria"] == DBNull.Value
                            ? "Sin categoría"
                            : reader["nombreCategoria"].ToString();

                        productos.NombreProducto = reader["nombreProducto"].ToString();

                        productos.CantidadProducto =
                            Convert.ToInt32(reader["cantidadProducto"]);

                        productos.PrecioProducto =
                            Convert.ToDouble(reader["precioProducto"]);

                        productos.DescuentoProducto =
                            Convert.ToInt32(reader["descuentoProducto"]);

                        productos.ImagenProducto =
                            reader["imagenProducto"] == DBNull.Value
                            ? null
                            : reader["imagenProducto"].ToString();

                        productos.EstaActivo =
                            Convert.ToBoolean(reader["estadoProducto"]);

                        resProductos.Add(productos);
                    }
                }
            }

            return resProductos;
        }

        public bool updateProducto(Producto producto)
        {
            string query = @"UPDATE productos 
                             SET idCategoriaProducto = @idCategoriaProducto, 
                                 nombreProducto = @nombreProducto, 
                                 cantidadProducto = @cantidadProducto, 
                                 precioProducto = @precioProducto, 
                                 descuentoProducto = @descuentoProducto, 
                                 imagenProducto = @imagenProducto,
                                 estadoProducto = @estadoProducto 
                             WHERE idProducto = @idProducto";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
            {
                command.Parameters.AddWithValue("@idCategoriaProducto", producto.IdCategoriaProducto.IdCategoria);
                command.Parameters.AddWithValue("@nombreProducto", producto.NombreProducto);
                command.Parameters.AddWithValue("@cantidadProducto", producto.CantidadProducto);
                command.Parameters.AddWithValue("@precioProducto", producto.PrecioProducto);
                command.Parameters.AddWithValue("@descuentoProducto", producto.DescuentoProducto);
                command.Parameters.AddWithValue("@imagenProducto", string.IsNullOrWhiteSpace(producto.ImagenProducto) ? (object)DBNull.Value : producto.ImagenProducto);
                command.Parameters.AddWithValue("@estadoProducto", producto.EstaActivo);
                command.Parameters.AddWithValue("@idProducto", producto.IdProducto);

                mySqlConnection.Open();

                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool cambiarEstadoProducto(int idProducto, bool estado)
        {
            string query = "UPDATE productos SET estadoProducto = @estadoProducto WHERE idProducto = @idProducto";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
            {
                command.Parameters.AddWithValue("@idProducto", idProducto);
                command.Parameters.AddWithValue("@estadoProducto", estado);

                mySqlConnection.Open();

                int result = command.ExecuteNonQuery();

                return result > 0;
            }
        }
    }
}