using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Proyecto.Models.Conex
{
    public class DBPedido
    {
        private readonly string stringConex = "server=localhost; user=root; database=gyalshop; password=Dilnic2909*; port=3306;";

        public bool SetPedido(Pedido pedido)
        {
            string query = @"
            INSERT INTO pedidos (idUsuarioPedido, idEstadoPedido)
            VALUES (@idUsuarioPedido, @idEstadoPedido);
            SELECT LAST_INSERT_ID();";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idUsuarioPedido", pedido.IdUsuarioPedido.IdUsuario);
                    command.Parameters.AddWithValue("@idEstadoPedido", pedido.IdEstadoPedido.IdEstado);

                    mySqlConnection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        pedido.IdPedido = Convert.ToInt32(result);
                        return true;
                    }
                }
            }

            return false;
        }

        public Pedido GetPedido(int idPedido)
        {
            Pedido pedido = new Pedido();

            string query = "select * from pedidos where idPedido = " + idPedido;

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    mySqlConnection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pedido.IdPedido = reader.GetInt32("idPedido");

                            pedido.IdUsuarioPedido = new Usuario();
                            pedido.IdUsuarioPedido.IdUsuario = reader.GetInt32("idUsuarioPedido");

                            pedido.IdEstadoPedido = new Estado();
                            pedido.IdEstadoPedido.IdEstado = reader.GetInt32("idEstadoPedido");
                        }
                    }
                }
            }

            return pedido;
        }

        public List<Pedido> GetPedidos()
        {
            List<Pedido> pedidos = new List<Pedido>();

            string query = "select * from pedidos";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    mySqlConnection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pedido pedido = new Pedido();

                            pedido.IdPedido = reader.GetInt32("idPedido");

                            pedido.IdUsuarioPedido = new Usuario();
                            pedido.IdUsuarioPedido.IdUsuario = reader.GetInt32("idUsuarioPedido");

                            pedido.IdEstadoPedido = new Estado();
                            pedido.IdEstadoPedido.IdEstado = reader.GetInt32("idEstadoPedido");

                            pedidos.Add(pedido);
                        }
                    }
                }
            }

            return pedidos;
        }

        public bool UpdatePedido(Pedido pedido)
        {
            string query = "update pedidos set idUsuarioPedido = @idUsuarioPedido, idEstadoPedido = @idEstadoPedido where idPedido = @idPedido";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idUsuarioPedido", pedido.IdUsuarioPedido.IdUsuario);
                    command.Parameters.AddWithValue("@idEstadoPedido", pedido.IdEstadoPedido.IdEstado);
                    command.Parameters.AddWithValue("@idPedido", pedido.IdPedido);

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

        public bool CambiarEstadoPedido(Pedido pedido)
        {
            string query = "update pedidos set idEstadoPedido = @idEstadoPedido where idPedido = @idPedido";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idEstadoPedido", pedido.IdEstadoPedido.IdEstado);
                    command.Parameters.AddWithValue("@idPedido", pedido.IdPedido);

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

        public List<Pedido> GetPedidosUsuario(int idUsuario)
        {
            List<Pedido> pedidos = new List<Pedido>();

            string query = @"
                SELECT 
                    p.idPedido,
                    p.idUsuarioPedido,
                    p.idEstadoPedido,

                    pp.idProductoXPedido,
                    pp.idPedidoProducto,
                    pp.idProductoPedido,
                    pp.precioProducto,
                    pp.cantidadProducto,
                    pp.subtotal,

                    pr.nombreProducto

                FROM pedidos p
                INNER JOIN productoporpedido pp
                    ON p.idPedido = pp.idPedidoProducto
                INNER JOIN productos pr
                    ON pp.idProductoPedido = pr.idProducto

                WHERE p.idUsuarioPedido = @idUsuario
                ORDER BY p.idPedido";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);

                    mySqlConnection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idPedido = reader.GetInt32("idPedido");

                            Pedido pedidoExistente =
                                pedidos.FirstOrDefault(p => p.IdPedido == idPedido);

                            if (pedidoExistente == null)
                            {
                                pedidoExistente = new Pedido
                                {
                                    IdPedido = reader.GetInt32("idPedido"),
                                    IdUsuarioPedido = new Usuario
                                    {
                                        IdUsuario = reader.GetInt32("idUsuarioPedido")
                                    },
                                    IdEstadoPedido = new Estado
                                    {
                                        IdEstado = reader.GetInt32("idEstadoPedido")
                                    },
                                    Productos = new List<ProductoPorPedido>()
                                };

                                pedidos.Add(pedidoExistente);
                            }

                            ProductoPorPedido producto = new ProductoPorPedido
                            {
                                IdProductoXPedido = reader.GetInt32("idProductoXPedido"),
                                IdPedidoProducto = reader.GetInt32("idPedidoProducto"),
                                IdProductoPedido = reader.GetInt32("idProductoPedido"),
                                NombreProducto = reader.GetString("nombreProducto"),
                                PrecioProducto = reader.GetDouble("precioProducto"),
                                CantidadProducto = reader.GetInt32("cantidadProducto"),
                                Subtotal = reader.GetDouble("subtotal")
                            };

                            pedidoExistente.Productos.Add(producto);
                        }
                    }
                }
            }

            return pedidos;
        }

        public List<Pedido> GetAllPedido()
        {

            List<Pedido> pedidos = new List<Pedido>();

            string query = "select * from pedidos p inner join estado e on p.idEstadoPedido = e.idEstado";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    mySqlConnection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Pedido pedido = new Pedido();
                            Estado estado = new Estado
                            {
                                IdEstado = reader.GetInt32("idEstadoPedido"),
                                DescEstado = reader.GetString("descEstado")
                            };
                            pedido.IdPedido = reader.GetInt32("idPedido");
                            pedido.IdUsuarioPedido = new Usuario
                            {
                                IdUsuario = reader.GetInt32("idUsuarioPedido")
                            };
                            pedido.IdEstadoPedido = estado;

                            pedidos.Add(pedido);
                        }
                    }

                }
            }

            return pedidos;
        }
    }
}