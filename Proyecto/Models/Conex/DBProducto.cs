using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Proyecto.Models.Conex
{
    public class DBProducto
    {
        string stringConex = "server=localhost; user=root; database=gyalshop; password=; port=3306;";

        public bool setProducto(Producto producto)
        {

            string queryInsert = "insert into productos (idCategoriaProducto, nombreProducto, cantidadProducto, precioProducto, descuentoProducto, estadoProducto) values (@idCategoriaProducto, @nombreProducto, @cantidadProducto, @precioProducto, @descuentoProducto, @estadoProducto)";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(queryInsert, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idCategoriaProducto", producto.IdCategoriaProducto);
                    command.Parameters.AddWithValue("@nombreProducto", producto.NombreProducto);
                    command.Parameters.AddWithValue("@cantidadProducto", producto.CantidadProducto);
                    command.Parameters.AddWithValue("@precioProducto", producto.PrecioProducto);
                    command.Parameters.AddWithValue("@descuentoProducto", producto.DescuentoProducto);
                    command.Parameters.AddWithValue("@estadoProducto", true);

                    mySqlConnection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public Producto getProducto(Producto producto)
        {

            Producto resProducto = new Producto();

            string query = "select * from productos where idProducto = @idProducto";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idProducto", producto.IdProducto);

                    mySqlConnection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            resProducto.IdProducto = reader.GetInt32("idProducto");

                            resProducto.IdCategoriaProducto = reader.GetInt32("idCategoriaProducto");

                            resProducto.NombreProducto = reader.GetString("nombreProducto");
                            resProducto.CantidadProducto = reader.GetInt32("cantidadProducto");
                            resProducto.PrecioProducto = reader.GetDouble("precioProducto");
                            resProducto.DescuentoProducto = reader.GetInt32("descuentoProducto");
                            resProducto.EstaActivo = reader.GetBoolean("estadoProducto");
                        }
                    }
                }
            }

            return resProducto;
        }

        public List<Producto> getProductos(Producto producto)
        {

            List<Producto> resProductos = new List<Producto>();

            string query = "select * from productos where idProducto = @idProdcuto";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
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

                            productos.IdCategoriaProducto = reader.GetInt32("idCategoriaProducto");

                            productos.NombreProducto = reader.GetString("nombreProducto");
                            productos.CantidadProducto = reader.GetInt32("cantidadProducto");
                            productos.PrecioProducto = reader.GetDouble("precioProducto");
                            productos.DescuentoProducto = reader.GetInt32("descuentoProducto");
                            productos.EstaActivo = reader.GetBoolean("estadoProducto");

                            resProductos.Add(productos);
                        }
                    }

                }
            }

            return resProductos;
        }
        public List<Producto> getAllProductos()
        {

            List<Producto> resProductos = new List<Producto>();

            string query = "select * from productos where estadoProducto= @estadoProducto";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@estadoProducto", true);

                    mySqlConnection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Producto productos = new Producto();

                            productos.IdProducto = reader.GetInt32("idProducto");

                            productos.IdCategoriaProducto = reader.GetInt32("idCategoriaProducto");

                            productos.NombreProducto = reader.GetString("nombreProducto");
                            productos.CantidadProducto = reader.GetInt32("cantidadProducto");
                            productos.PrecioProducto = reader.GetDouble("precioProducto");
                            productos.DescuentoProducto = reader.GetInt32("descuentoProducto");
                            productos.EstaActivo = reader.GetBoolean("estadoProducto");

                            resProductos.Add(productos);
                        }
                    }

                }
            }

            return resProductos;
        }

        public bool updateProducto(Producto producto)
        {

            string query = "update productos set idCategoriaProducto = @idCategoriaProducto, nombreProducto = @nombreProducto, cantidadProducto = @cantidadProducto, precioProducto = @precioProducto, descuentoProducto = @descuentoProducto, estadoProducto = @estadoProducto where idProducto = @idProducto";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idCategoriaProducto", producto.IdCategoriaProducto);
                    command.Parameters.AddWithValue("@nombreProducto", producto.NombreProducto);
                    command.Parameters.AddWithValue("@cantidadProducto", producto.CantidadProducto);
                    command.Parameters.AddWithValue("@precioProducto", producto.PrecioProducto);
                    command.Parameters.AddWithValue("@descuentoProducto", producto.DescuentoProducto);
                    command.Parameters.AddWithValue("@estadoProducto", producto.EstaActivo);
                    command.Parameters.AddWithValue("@idProducto", producto.IdProducto);

                    mySqlConnection.Open();

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        return true;
                    }

                }
            }

            return false;
        }

        public bool deleteProducto(Producto producto)
        {

            string query = "Update productos set estadoProducto = @estadoProducto where idProducto = @idProducto";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idProducto", producto.IdProducto);
                    command.Parameters.AddWithValue("@estadoProducto", false);

                    mySqlConnection.Open();

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}