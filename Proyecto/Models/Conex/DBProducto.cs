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
        string stringConex = "server=localhost; user=Backend; database=backend; password=123456; port=3306;";

        public bool setProducto(Producto producto)
        {

            string queryInsert = "insert into productos (idCategoriaProducto, nombreProducto, cantidadProducto, precioProducto, descuentoProducto, estadoProducto) values (@idCategoriaProducto, @nombreProducto, @cantidadProducto, @precioProducto, @descuentoProducto, @estadoProducto)";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(queryInsert, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idCategoriaProducto", producto.IdCategoriaProducto.IdCategoria);
                    command.Parameters.AddWithValue("@nombreProducto", producto.NombreProducto);
                    command.Parameters.AddWithValue("@cantidadProducto", producto.CantidadProducto);
                    command.Parameters.AddWithValue("@precioProducto", producto.PrecioProducto);
                    command.Parameters.AddWithValue("@descuentoProducto", producto.DescuentoProducto);
                    command.Parameters.AddWithValue("@estadoProducto", producto.EstaActivo);

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

        public Producto getProducto(int idProducto)
        {

            Producto producto = new Producto();

            string query = "select * from productos where idProducto = " + idProducto;

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    mySqlConnection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            producto.IdProducto = reader.GetInt32("idProducto");

                            producto.IdCategoriaProducto = new Categoria();
                            producto.IdCategoriaProducto.IdCategoria = reader.GetInt32("idCategoriaProducto");

                            producto.NombreProducto = reader.GetString("nombreProducto");
                            producto.CantidadProducto = reader.GetInt32("cantidadProducto");
                            producto.PrecioProducto = reader.GetDouble("precioProducto");
                            producto.DescuentoProducto = reader.GetInt32("descuentoProducto");
                            producto.EstaActivo = reader.GetBoolean("estadoProducto");
                        }
                    }
                }
            }

            return producto;
        }

        public List<Producto> getProductos()
        {

            List<Producto> productos = new List<Producto>();

            string query = "select * from productos";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    mySqlConnection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Producto producto = new Producto();

                            producto.IdProducto = reader.GetInt32("idProducto");

                            producto.IdCategoriaProducto = new Categoria();
                            producto.IdCategoriaProducto.IdCategoria = reader.GetInt32("idCategoriaProducto");

                            producto.NombreProducto = reader.GetString("nombreProducto");
                            producto.CantidadProducto = reader.GetInt32("cantidadProducto");
                            producto.PrecioProducto = reader.GetDouble("precioProducto");
                            producto.DescuentoProducto = reader.GetInt32("descuentoProducto");
                            producto.EstaActivo = reader.GetBoolean("estadoProducto");

                            productos.Add(producto);
                        }
                    }

                }
            }

            return productos;
        }

        public bool updateProducto(Producto producto)
        {

            string query = "update productos set idCategoriaProducto = @idCategoriaProducto, nombreProducto = @nombreProducto, cantidadProducto = @cantidadProducto, precioProducto = @precioProducto, descuentoProducto = @descuentoProducto, estadoProducto = @estadoProducto where idProducto = @idProducto";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idCategoriaProducto", producto.IdCategoriaProducto.IdCategoria);
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

        public bool cambiarEstadoProducto(Producto producto)
        {

            string query = "Update productos set estadoProducto = NOT estadoProducto where idProducto = @idProducto";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
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
    }
}