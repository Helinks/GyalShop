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
        string stringConex = "server=localhost; user=root; database=gyalshop; password=Dilnic2909*; port=3306;";

        public bool SetCarrito(Carrito carrito)
        {
            string queryInsert = "inser into carrito (idProducto, nombreProducto, precioUnidad, cantidadProducto) values (@idProducto, @nombreProducto, @precioUnidad, @cantidadProducto)";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(queryInsert, mySqlConnection))
                {
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
        public List<Carrito> GetCarrito(Carrito carrito)
        {
            List<Carrito> listaCarrito = new List<Carrito>();
            string query = "select * from carrito where idCliente = @idCliente";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idCliente", carrito.IdCliente);

                    mySqlConnection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Carrito item = new Carrito
                            {
                                IdCarrito = reader.GetInt32("idCarrito"),
                                IdProducto = reader.GetInt32("idProducto"),
                                NombreProducto = reader.GetString("nombreProducto"),
                                PrecioUnidad = reader.GetDouble("precioUnidad"),
                                Cantidad = reader.GetInt32("cantidadProducto")
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
            string query = "update carrito set cantidadProducto = @cantidadProducto, precioUnidad = @precioUnidad where idCliente = @idCliente";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@cantidadProducto", carrito.Cantidad);
                    command.Parameters.AddWithValue("@precioUnidad", carrito.PrecioUnidad);
                    command.Parameters.AddWithValue("@idCliente", carrito.IdCliente);

                    mySqlConnection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result > 0) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool DeleteCarrito(Carrito carrito)
        {
            string query = "delete from carrito where idCliente = @idCliente";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idCliente", carrito.IdCliente);
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
