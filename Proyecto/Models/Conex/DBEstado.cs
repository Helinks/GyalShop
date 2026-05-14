using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Proyecto.Models.Conex
{
    public class DBEstado
    {
        string stringConex = "server=localhost; user=root; database=gyalshop; password=Dilnic2909*; port=3306";
        public bool SetEstado(Estado estado)
        {
            string query = "insert into estado (descEStado) values (@descEstado)";
            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection)) {
                    command.Parameters.AddWithValue("@descEstado", estado.DescEstado);
                    mySqlConnection.Open();

                    int result = command.ExecuteNonQuery();
                    if (result > 0) { 
                    return true;
                    }

                }
            }
            return false;
        }
        public Estado GetEstado(Estado estado) {
            Estado resEstado = new Estado();
            string query = "select * from estado where idEstado = @idEstado";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using(MySqlCommand command = new MySqlCommand(query,mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idEstado", estado.IdEstado);
                    mySqlConnection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader()) { 
                        resEstado.IdEstado=reader.GetInt32("idEstado");
                        resEstado.DescEstado = reader.GetString("descEstado");
                    }
                }
            }
            return resEstado;
        }
        public List<Estado> GetAllEstado(Estado estado)
        {
            List<Estado> estados = new List<Estado>();
            string query = "select * from estado where idEstado = @idEstado";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idEstado", estado.IdEstado);
                    mySqlConnection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader()) { 
                    while (reader.Read())
                        {
                            Estado resEstado =new Estado();
                            resEstado.IdEstado = reader.GetInt32("idEstado");
                            resEstado.DescEstado = reader.GetString("descEstado");
                            estados.Add(resEstado);
                        }
                    }
                    
                }
            }
            return estados;
        }

        public bool UpdateEstado(Estado estado) {
            string query = "update estado set descEstado = @descEstado";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex)) {
                using (MySqlCommand command = new MySqlCommand(query,mySqlConnection)) {
                    command.Parameters.AddWithValue("@descEstado", estado.DescEstado);

                    mySqlConnection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result > 0) {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool DeleteEstado(Estado estado)
        {
            string query = "delete from estado where idEstado = @idEstado";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@idEstado", estado.IdEstado);

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
