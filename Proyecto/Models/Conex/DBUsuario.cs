using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Proyecto.Models.Conex
{
    public class DBUsuario     
    {
        string stringConex = "server=localhost; user=Backend; database=backend; password=123456; port=3306;";

        public Usuario GetUsuario(int idUsuario)
        {
            Usuario usuario = new Usuario();
            string query = "Select * from usuarios where id = " + idUsuario;

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    mySqlConnection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuario.IdUsuario = reader.GetInt32("idUsuario");
                            usuario.TipoUsuario.IdTipo = reader.GetInt32("TipoUsuario");
                            usuario.NombreUsuario = reader.GetString("nombreUsuario");
                            usuario.Correo = reader.GetString("correo");
                            usuario.Passwrod = reader.GetString("password");
                            usuario.Telefono = reader.GetInt32("telefono");
                            usuario.Direccion = reader.GetString("direccion");
                            usuario.EstaActivo = reader.GetBoolean("estaActivo");


                        }
                    }
                }
            }
            return usuario;
        } 
    }

}
}
