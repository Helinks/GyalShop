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
        string stringConex = "server=localhost; user=root; database=gyalshop; password=; port=3306;";

        public bool SetPedido(Pedido pedido)
        {

            string queryInsert = "insert into pedidos (idUsuarioPedido, idEstadoPedido) values (@idUsuarioPedido, @idEstadoPedido)";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(queryInsert, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idUsuarioPedido", pedido.IdUsuarioPedido);
                    command.Parameters.AddWithValue("@idEstadoPedido", 1);

                    mySqlConnection.Open();

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        pedido.IdPedido = Convert.ToInt32(command.LastInsertedId);
                        return true;
                    }
                }
            }

            return false;
        }

        public Pedido GetPedido(Pedido pedido)
        {

            Pedido resPedido = new Pedido();

            string query = "select * from pedidos where idPedido = @idPedido";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idPedido", pedido.IdPedido);
                    mySqlConnection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Estado estado = new Estado(reader.GetInt32("idEstadoPedido"), "");
                            resPedido.IdPedido = reader.GetInt32("idPedido");
                            resPedido.IdUsuarioPedido = reader.GetInt32("idUsuarioPedido");
                            resPedido.IdEstadoPedido= estado;
                        }
                    }
                }
            }

            return resPedido;
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
                            Estado estado = new Estado(reader.GetInt32("idEstadoPedido"), reader.GetString("descEstado"));
                            pedido.IdPedido = reader.GetInt32("idPedido");
                            pedido.IdUsuarioPedido = reader.GetInt32("idUsuarioPedido");
                            pedido.IdEstadoPedido = estado;

                            pedidos.Add(pedido);
                        }
                    }

                }
            }

            return pedidos;
        }

        public bool UpdatePedido(Pedido pedido)
        {

            string query = "update pedidos Set idUsuarioPedido = @idUsuarioPedido, idEstadoPedido = @idEstadoPedido where idPedido = @idPedido";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idUsuarioPedido", pedido.IdUsuarioPedido);
                    command.Parameters.AddWithValue("@idEstadoPedido", pedido.IdEstadoPedido);
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

            string query = "update pedidos Set idEstadoPedido = @idEstadoPedido where idPedido = @idPedido";

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
    }
}