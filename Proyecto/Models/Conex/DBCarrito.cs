using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Proyecto.Models.Conex
{
    public class DBCarrito
    {
        string stringConex = "server=localhost; user=root; database=gyalshop; password=; port=3306;";

        public bool SetCarrito(Carrito carrito)
        {
            string queryInsert = "insert into carrito (idCliente,idProducto, nombreProducto, precioUnidad, cantidadProducto) values (@idCliente, @idProducto, @nombreProducto, @precioUnidad, @cantidadProducto)";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(queryInsert, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idCliente", carrito.IdCliente);
                    command.Parameters.AddWithValue("@idProducto", carrito.IdProducto);
                    command.Parameters.AddWithValue("@nombreProducto", carrito.NombreProducto);
                    command.Parameters.AddWithValue("@precioUnidad", carrito.PrecioUnidad);
                    command.Parameters.AddWithValue("@cantidadProducto", carrito.Cantidad);

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
        public List<Carrito> GetCarrito(Usuario usuario)
        {
            List<Carrito> listaCarrito = new List<Carrito>();
            string query = "select * from carrito where idCliente = @idCliente";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idCliente", usuario.IdUsuario);

                    mySqlConnection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Carrito item = new Carrito();

                            item.IdCarrito = reader.GetInt32("idCarrito");
                            item.IdProducto = reader.GetInt32("idProducto");
                            item.IdCliente = reader.GetInt32("idCliente");
                            item.NombreProducto = reader.GetString("nombreProducto");
                            item.PrecioUnidad = reader.GetDouble("precioUnidad");
                            item.Cantidad = reader.GetInt32("cantidadProducto");
                            
                            listaCarrito.Add(item);
                        }
                    }
                }
            }
            return listaCarrito;
        }
        public bool UpdateCarrito(Carrito carrito)
        {
            string query = "update carrito set cantidadProducto = @cantidadProducto, precioUnidad = @precioUnidad where idCliente = @idCliente AND idProducto = @idProducto";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@cantidadProducto", carrito.Cantidad);
                    command.Parameters.AddWithValue("@precioUnidad", carrito.PrecioUnidad);
                    command.Parameters.AddWithValue("@idCliente", carrito.IdCliente);
                    command.Parameters.AddWithValue("@idProducto", carrito.IdProducto);

                    mySqlConnection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result > 0) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool DeleteCarrito(Usuario usuario)
        {
            string query = "delete from carrito where idCliente = @idCliente";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idCliente", usuario.IdUsuario);
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
        public bool DeleteCarritoProducto(Carrito carrito)
        {
            string query = "delete from carrito where idCliente = @idCliente AND idProducto = @idProducto";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idCliente", carrito.IdCliente);
                    command.Parameters.AddWithValue("@idProducto", carrito.IdProducto);
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
