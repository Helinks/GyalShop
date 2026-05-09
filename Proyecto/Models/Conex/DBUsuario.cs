using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Proyecto.Models.Conex
{
    public class DBUsuario
    {
        string stringConex = "server=localhost; user=root; database=gyalshop; password=Dilnic2909*; port=3306;";

        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder sb = new StringBuilder();

                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }

        public Usuario GetUsuario(int idUsuario)
        {
            Usuario usuario = new Usuario();
            usuario.TipoUsuario = new TipoUsuario();

            string query = "SELECT * FROM usuarios WHERE idUsuario = @idUsuario";

            using (MySqlConnection conn = new MySqlConnection(stringConex))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        usuario.IdUsuario = reader.GetInt32("idUsuario");
                        usuario.TipoUsuario.IdTipo = reader.GetInt32("idTipoUsuario");
                        usuario.NombreUsuario = reader.GetString("nombreUsuario");
                        usuario.Correo = reader.GetString("correo");
                        usuario.Password = reader.GetString("password");
                        usuario.Telefono = reader.GetString("telefono");
                        usuario.Direccion = reader.GetString("direccion");
                        usuario.EstaActivo = reader.GetBoolean("estadoUsuario");
                    }
                }
            }

            return usuario;
        }

        public List<Usuario> GetAll()
        {
            List<Usuario> lista = new List<Usuario>();

            string query = "SELECT * FROM usuarios";

            using (MySqlConnection conn = new MySqlConnection(stringConex))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuario u = new Usuario();
                        u.TipoUsuario = new TipoUsuario();

                        u.IdUsuario = reader.GetInt32("idUsuario");
                        u.NombreUsuario = reader.GetString("nombreUsuario");
                        u.Correo = reader.GetString("correo");
                        u.Telefono = reader.GetString("telefono");
                        u.Direccion = reader.GetString("direccion");
                        u.EstaActivo = reader.GetBoolean("estadoUsuario");
                        u.TipoUsuario.IdTipo = reader.GetInt32("idTipoUsuario");

                        lista.Add(u);
                    }
                }
            }

            return lista;
        }


        public bool SetUsuario(Usuario usuario)
        {
            string query = @"INSERT INTO usuarios 
            (idTipoUsuario, nombreUsuario, correo, password, telefono, direccion, estadoUsuario)
            VALUES (@tipoUsuario, @nombreUsuario, @correo, @password, @telefono, @direccion, @estaActivo)";

            using (MySqlConnection conn = new MySqlConnection(stringConex))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@tipoUsuario", usuario.TipoUsuario.IdTipo);
                cmd.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);

                // 🔥 HASH AQUÍ
                cmd.Parameters.AddWithValue("@password", HashPassword(usuario.Password));

                cmd.Parameters.AddWithValue("@telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@direccion", usuario.Direccion);
                cmd.Parameters.AddWithValue("@estaActivo", usuario.EstaActivo);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public bool UpdateUsuario(Usuario usuario)
        {
            string query = @"UPDATE usuarios SET 
                idTipoUsuario = @tipoUsuario,
                nombreUsuario = @nombreUsuario,
                correo = @correo,
                password = @password,
                telefono = @telefono,
                direccion = @direccion,
                estadoUsuario = @estaActivo
                WHERE idUsuario = @idUsuario";

            using (MySqlConnection conn = new MySqlConnection(stringConex))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@tipoUsuario", usuario.TipoUsuario.IdTipo);
                cmd.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);

                // 🔥 HASH AQUÍ TAMBIÉN
                cmd.Parameters.AddWithValue("@password", HashPassword(usuario.Password));

                cmd.Parameters.AddWithValue("@telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@direccion", usuario.Direccion);
                cmd.Parameters.AddWithValue("@estaActivo", usuario.EstaActivo);
                cmd.Parameters.AddWithValue("@idUsuario", usuario.IdUsuario);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public bool DeleteUsuario(int idUsuario)
        {
            string query = "UPDATE usuarios SET estadoUsuario = 0 WHERE idUsuario = @idUsuario";

            using (MySqlConnection conn = new MySqlConnection(stringConex))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public Usuario Login(string correo, string password)
        {
            string query = @"SELECT * FROM usuarios 
                             WHERE correo = @correo 
                             AND password = @password 
                             AND estadoUsuario = 1";

            using (MySqlConnection conn = new MySqlConnection(stringConex))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@correo", correo);

                cmd.Parameters.AddWithValue("@password", HashPassword(password));

                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.TipoUsuario = new TipoUsuario();

                        usuario.IdUsuario = reader.GetInt32("idUsuario");
                        usuario.NombreUsuario = reader.GetString("nombreUsuario");
                        usuario.Correo = reader.GetString("correo");
                        usuario.Password = reader.GetString("password");
                        usuario.Telefono = reader.GetString("telefono");
                        usuario.Direccion = reader.GetString("direccion");
                        usuario.EstaActivo = reader.GetBoolean("estadoUsuario");
                        usuario.TipoUsuario.IdTipo = reader.GetInt32("idTipoUsuario");

                        return usuario;
                    }
                }
            }

            return null;
        }
    }
}