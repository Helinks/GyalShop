using MySql.Data.MySqlClient;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Proyecto.Models.Conex
{
    public class DBUsuario
    {
        private readonly string stringConex = "server=localhost; user=root; database=gyalshop; password=Dilnic2909*; port=3306;";

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

        private string GetStringSafe(MySqlDataReader reader, string column)
        {
            int ordinal = reader.GetOrdinal(column);
            return reader.IsDBNull(ordinal) ? string.Empty : reader.GetString(ordinal);
        }

        public List<TipoUsuario> GetTiposUsuario()
        {
            List<TipoUsuario> lista = new List<TipoUsuario>();

            string query = @"SELECT idTipo, tipo
                             FROM tipousuario
                             ORDER BY tipo;";

            using (MySqlConnection conn = new MySqlConnection(stringConex))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TipoUsuario tipo = new TipoUsuario
                        {
                            IdTipo = reader.GetInt32("idTipo"),
                            Tipo = reader.GetString("tipo")
                        };

                        lista.Add(tipo);
                    }
                }
            }

            return lista;
        }

        public Usuario GetUsuario(int idUsuario)
        {
            Usuario usuario = null;

            string query = @"SELECT u.idUsuario,
                                    u.idTipoUsuario,
                                    t.tipo,
                                    u.nombreUsuario,
                                    u.correo,
                                    u.password,
                                    u.telefono,
                                    u.direccion,
                                    u.estadoUsuario
                             FROM usuarios u
                             INNER JOIN tipousuario t ON u.idTipoUsuario = t.idTipo
                             WHERE u.idUsuario = @idUsuario;";

            using (MySqlConnection conn = new MySqlConnection(stringConex))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        usuario = new Usuario
                        {
                            IdUsuario = reader.GetInt32("idUsuario"),
                            TipoUsuario = new TipoUsuario
                            {
                                IdTipo = reader.GetInt32("idTipoUsuario"),
                                Tipo = reader.GetString("tipo")
                            },
                            NombreUsuario = GetStringSafe(reader, "nombreUsuario"),
                            Correo = GetStringSafe(reader, "correo"),
                            Password = GetStringSafe(reader, "password"),
                            Telefono = GetStringSafe(reader, "telefono"),
                            Direccion = GetStringSafe(reader, "direccion"),
                            EstaActivo = reader.GetBoolean("estadoUsuario")
                        };
                    }
                }
            }

            return usuario;
        }

        public List<Usuario> GetAll()
        {
            List<Usuario> lista = new List<Usuario>();

            string query = @"SELECT u.idUsuario,
                                    u.idTipoUsuario,
                                    t.tipo,
                                    u.nombreUsuario,
                                    u.correo,
                                    u.telefono,
                                    u.direccion,
                                    u.estadoUsuario
                             FROM usuarios u
                             INNER JOIN tipousuario t ON u.idTipoUsuario = t.idTipo
                             ORDER BY u.idUsuario DESC;";

            using (MySqlConnection conn = new MySqlConnection(stringConex))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuario u = new Usuario
                        {
                            IdUsuario = reader.GetInt32("idUsuario"),
                            TipoUsuario = new TipoUsuario
                            {
                                IdTipo = reader.GetInt32("idTipoUsuario"),
                               Tipo = reader.GetString("tipo")
                            },
                            NombreUsuario = GetStringSafe(reader, "nombreUsuario"),
                            Correo = GetStringSafe(reader, "correo"),
                            Telefono = GetStringSafe(reader, "telefono"),
                            Direccion = GetStringSafe(reader, "direccion"),
                            EstaActivo = reader.GetBoolean("estadoUsuario")
                        };

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
                             VALUES
                             (@tipoUsuario, @nombreUsuario, @correo, @password, @telefono, @direccion, @estadoUsuario);";

            using (MySqlConnection conn = new MySqlConnection(stringConex))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@tipoUsuario", usuario.TipoUsuario.IdTipo);
                cmd.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@password", HashPassword(usuario.Password));
                cmd.Parameters.AddWithValue("@telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@direccion", usuario.Direccion);
                cmd.Parameters.AddWithValue("@estadoUsuario", usuario.EstaActivo);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateUsuario(Usuario usuario, bool cambiarPassword)
        {
            string query;

            if (cambiarPassword)
            {
                query = @"UPDATE usuarios SET
                          idTipoUsuario = @tipoUsuario,
                          nombreUsuario = @nombreUsuario,
                          correo = @correo,
                          password = @password,
                          telefono = @telefono,
                          direccion = @direccion,
                          estadoUsuario = @estadoUsuario
                          WHERE idUsuario = @idUsuario;";
            }
            else
            {
                query = @"UPDATE usuarios SET
                          idTipoUsuario = @tipoUsuario,
                          nombreUsuario = @nombreUsuario,
                          correo = @correo,
                          telefono = @telefono,
                          direccion = @direccion,
                          estadoUsuario = @estadoUsuario
                          WHERE idUsuario = @idUsuario;";
            }

            using (MySqlConnection conn = new MySqlConnection(stringConex))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@tipoUsuario", usuario.TipoUsuario.IdTipo);
                cmd.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@direccion", usuario.Direccion);
                cmd.Parameters.AddWithValue("@estadoUsuario", usuario.EstaActivo);
                cmd.Parameters.AddWithValue("@idUsuario", usuario.IdUsuario);

                if (cambiarPassword)
                    cmd.Parameters.AddWithValue("@password", HashPassword(usuario.Password));

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateEstadoUsuario(int idUsuario, bool estado)
        {
            string query = @"UPDATE usuarios
                             SET estadoUsuario = @estado
                             WHERE idUsuario = @idUsuario;";

            using (MySqlConnection conn = new MySqlConnection(stringConex))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteUsuario(int idUsuario)
        {
            return UpdateEstadoUsuario(idUsuario, false);
        }

        public Usuario Login(string correo, string password)
        {
            string query = @"SELECT u.idUsuario,
                                    u.idTipoUsuario,
                                    t.tipo,
                                    u.nombreUsuario,
                                    u.correo,
                                    u.password,
                                    u.telefono,
                                    u.direccion,
                                    u.estadoUsuario
                             FROM usuarios u
                             INNER JOIN tipousuario t ON u.idTipoUsuario = t.idTipo
                             WHERE u.correo = @correo
                               AND u.password = @password
                               AND u.estadoUsuario = 1;";

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
                        return new Usuario
                        {
                            IdUsuario = reader.GetInt32("idUsuario"),
                            TipoUsuario = new TipoUsuario
                            {
                                IdTipo = reader.GetInt32("idTipoUsuario"),
                                Tipo = reader.GetString("tipo")
                            },
                            NombreUsuario = GetStringSafe(reader, "nombreUsuario"),
                            Correo = GetStringSafe(reader, "correo"),
                            Password = GetStringSafe(reader, "password"),
                            Telefono = GetStringSafe(reader, "telefono"),
                            Direccion = GetStringSafe(reader, "direccion"),
                            EstaActivo = reader.GetBoolean("estadoUsuario")
                        };
                    }
                }
            }

            return null;
        }
    }
}