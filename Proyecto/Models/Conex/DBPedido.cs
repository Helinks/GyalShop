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
        string stringConex = "server=localhost; user=root; database=gyalshop; password=Dilnic2909*; port=3306;";

        public bool setPedido(Pedido pedido)
        {

            string queryInsert = "insert into pedidos (idUsuarioPedido, idEstadoPedido) values (@idUsuarioPedido, @idEstadoPedido)";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(queryInsert, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idUsuarioPedido", pedido.IdUsuarioPedido.IdUsuario);
                    command.Parameters.AddWithValue("@idEstadoPedido", pedido.idEstadoPedido.IdEstado);

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

        public Pedido getPedido(int idPedido)
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

                            pedido.idEstadoPedido = new Estado();
                            pedido.idEstadoPedido.IdEstado= reader.GetInt32("idEstadoPedido");
                        }
                    }
                }
            }

            return pedido;
        }

        public List<Pedido> getPedidos()
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

                            pedido.idEstadoPedido = new Estado();
                            pedido.idEstadoPedido.IdEstado = reader.GetInt32("idEstadoPedido");

                            pedidos.Add(pedido);
                        }
                    }

                }
            }

            return pedidos;
        }

        public bool updatePedido(Pedido pedido)
        {

            string query = "update pedidos set idUsuarioPedido = @idUsuarioPedido, idEstadoPedido = @idEstadoPedido where idPedido = @idPedido";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idUsuarioPedido", pedido.IdUsuarioPedido.IdUsuario);
                    command.Parameters.AddWithValue("@idEstadoPedido", pedido.idEstadoPedido.IdEstado);
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

        public bool cambiarEstadoPedido(Pedido pedido)
        {

            string query = "update pedidos set idEstadoPedido = @idEstadoPedido where idPedido = @idPedido";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idEstadoPedido", pedido.idEstadoPedido.IdEstado);
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

            string query = @"SELECT p.idPedido,
                            p.idUsuarioPedido,
                            p.idEstadoPedido
                     FROM pedidos p
                     WHERE p.idUsuarioPedido = @idUsuario";

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
                            Pedido pedido = new Pedido();

                            pedido.IdPedido = reader.GetInt32("idPedido");

                            pedido.IdUsuarioPedido = new Usuario();
                            pedido.IdUsuarioPedido.IdUsuario = reader.GetInt32("idUsuarioPedido");

                            pedido.idEstadoPedido = new Estado();
                            pedido.idEstadoPedido.IdEstado = reader.GetInt32("idEstadoPedido");

                            pedidos.Add(pedido);
                        }
                    }
                }
            }

            return pedidos;
        }
    }


}