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

        public bool SetUsuario(Usuario usuario)
        {
            try
            {
                string queryInsert = @"INSERT INTO usuarios
                (TipoUsuario, nombreUsuario, correo, password, telefono, direccion, estaActivo)
                VALUES
                (@tipoUsuario, @nombreUsuario, @correo, @password, @telefono, @direccion, @estaActivo)";

                using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
                {
                    using (MySqlCommand command = new MySqlCommand(queryInsert, mySqlConnection))
                    {
                        command.Parameters.AddWithValue("@tipoUsuario", usuario.TipoUsuario.IdTipo);
                        command.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                        command.Parameters.AddWithValue("@correo", usuario.Correo);
                        command.Parameters.AddWithValue("@password", usuario.Password);
                        command.Parameters.AddWithValue("@telefono", usuario.Telefono);
                        command.Parameters.AddWithValue("@direccion", usuario.Direccion);
                        command.Parameters.AddWithValue("@estaActivo", usuario.EstaActivo);

                        mySqlConnection.Open();

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return false;
        }

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
                            usuario.Password = reader.GetString("password");
                            usuario.Telefono = reader.GetInt32("telefono");
                            usuario.Direccion = reader.GetString("direccion");
                            usuario.EstaActivo = reader.GetBoolean("estaActivo");


                        }
                    }
                }
            }
            return usuario;
        }


        public List<Usuario> GetUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            string query = "SELECT * FROM usuarios";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    mySqlConnection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario usuario = new Usuario();

                            usuario.IdUsuario = reader.GetInt32("idUsuario");

                            usuario.TipoUsuario = new TipoUsuario();
                            usuario.TipoUsuario.IdTipo = reader.GetInt32("TipoUsuario");

                            usuario.NombreUsuario = reader.GetString("nombreUsuario");
                            usuario.Correo = reader.GetString("correo");
                            usuario.Password = reader.GetString("password");
                            usuario.Telefono = reader.GetInt32("telefono");
                            usuario.Direccion = reader.GetString("direccion");
                            usuario.EstaActivo = reader.GetBoolean("estaActivo");

                            listaUsuarios.Add(usuario);
                        }
                    }
                }
            }

            return listaUsuarios;
        }
        public bool UpdateUsuario(Usuario usuario)
        {
            try
            {
                string queryUpdate = @"UPDATE usuarios 
                SET 
                    TipoUsuario = @tipoUsuario,
                    nombreUsuario = @nombreUsuario,
                    correo = @correo,
                    password = @password,
                    telefono = @telefono,
                    direccion = @direccion,
                    estaActivo = @estaActivo
                WHERE idUsuario = @idUsuario";

                using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
                {
                    using (MySqlCommand command = new MySqlCommand(queryUpdate, mySqlConnection))
                    {
                        command.Parameters.AddWithValue("@tipoUsuario", usuario.TipoUsuario.IdTipo);
                        command.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                        command.Parameters.AddWithValue("@correo", usuario.Correo);
                        command.Parameters.AddWithValue("@password", usuario.Password);
                        command.Parameters.AddWithValue("@telefono", usuario.Telefono);
                        command.Parameters.AddWithValue("@direccion", usuario.Direccion);
                        command.Parameters.AddWithValue("@estaActivo", usuario.EstaActivo);
                        command.Parameters.AddWithValue("@idUsuario", usuario.IdUsuario);

                        mySqlConnection.Open();

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return false;
        }
        public bool CambiarEstadoUsuario(int idUsuario)
        {
            try
            {
                string queryEstado = @"UPDATE usuarios
                SET estaActivo = NOT estaActivo
                WHERE idUsuario = @idUsuario";

                using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
                {
                    using (MySqlCommand command = new MySqlCommand(queryEstado, mySqlConnection))
                    {
                        command.Parameters.AddWithValue("@idUsuario", idUsuario);

                        mySqlConnection.Open();

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return false;
        }

    }
}

