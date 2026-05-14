using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Proyecto.Models.Conex
{
    public class DBCategoria
    {
<<<<<<< HEAD
        string stringConex = "server=localhost; user=root; database=gyalshop; password=Dilnic2909*; port=3306;";
=======
        
        private readonly string stringConex = "server=localhost; user=root; database=gyalshop; password=Dilnic2909*; port=3306;";
>>>>>>> 5a903cf (Perfil y HomeView echos con el carrito)

        private Categoria LeerCategoria(MySqlDataReader reader)
        {
            return new Categoria
            {
                IdCategoria = reader.GetInt32("idCategoria"),
                NombreCategoria = reader.GetString("nombreCategoria"),
                EstaActivo = reader.GetBoolean("estadoCategoria")
            };
        }

        public bool SetCategoria(Categoria categoria)
        {
            string queryInsert = @"INSERT INTO categorias (nombreCategoria, estadoCategoria)
                                   VALUES (@nombreCategoria, @estadoCategoria)";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            using (MySqlCommand command = new MySqlCommand(queryInsert, mySqlConnection))
            {
                command.Parameters.AddWithValue("@nombreCategoria", categoria.NombreCategoria);
                command.Parameters.AddWithValue("@estadoCategoria", true);

                mySqlConnection.Open();
                int result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public Categoria GetCategoria(Categoria categoria)
        {
            Categoria resCategoria = null;

            string query = @"SELECT idCategoria, nombreCategoria, estadoCategoria
                             FROM categorias
                             WHERE idCategoria = @idCategoria";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
            {
                command.Parameters.AddWithValue("@idCategoria", categoria.IdCategoria);

                mySqlConnection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        resCategoria = LeerCategoria(reader);
                    }
                }
            }

            return resCategoria;
        }

        public List<Categoria> GetCategorias(Categoria categoria)
        {
            List<Categoria> resCategorias = new List<Categoria>();

            string query = @"SELECT idCategoria, nombreCategoria, estadoCategoria
                             FROM categorias
                             WHERE idCategoria = @idCategoria";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
            {
                command.Parameters.AddWithValue("@idCategoria", categoria.IdCategoria);

                mySqlConnection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resCategorias.Add(LeerCategoria(reader));
                    }
                }
            }

            return resCategorias;
        }

        // SOLO ACTIVAS: para que no se rompa tu ProductoView
        public List<Categoria> GetAllCategoria()
        {
            List<Categoria> listaCategoria = new List<Categoria>();

            string query = @"SELECT idCategoria, nombreCategoria, estadoCategoria
                             FROM categorias
                             WHERE estadoCategoria = @estadoCategoria
                             ORDER BY idCategoria DESC";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
            {
                command.Parameters.AddWithValue("@estadoCategoria", true);

                mySqlConnection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaCategoria.Add(LeerCategoria(reader));
                    }
                }
            }

            return listaCategoria;
        }

        // TODAS: para la vista de categorías
        public List<Categoria> GetAllCategoriaConEstado()
        {
            List<Categoria> listaCategoria = new List<Categoria>();

            string query = @"SELECT idCategoria, nombreCategoria, estadoCategoria
                             FROM categorias
                             ORDER BY idCategoria DESC";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
            {
                mySqlConnection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaCategoria.Add(LeerCategoria(reader));
                    }
                }
            }

            return listaCategoria;
        }

        public bool UpdateCategoria(Categoria categoria)
        {
            string query = @"UPDATE categorias
                             SET nombreCategoria = @nombreCategoria,
                                 estadoCategoria = @estadoCategoria
                             WHERE idCategoria = @idCategoria";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
            {
                command.Parameters.AddWithValue("@nombreCategoria", categoria.NombreCategoria);
                command.Parameters.AddWithValue("@estadoCategoria", categoria.EstaActivo);
                command.Parameters.AddWithValue("@idCategoria", categoria.IdCategoria);

                mySqlConnection.Open();
                int result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public bool CambiarEstadoCategoria(int idCategoria, bool estado)
        {
            string query = @"UPDATE categorias
                             SET estadoCategoria = @estadoCategoria
                             WHERE idCategoria = @idCategoria";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
            {
                command.Parameters.AddWithValue("@idCategoria", idCategoria);
                command.Parameters.AddWithValue("@estadoCategoria", estado);

                mySqlConnection.Open();
                int result = command.ExecuteNonQuery();

                return result > 0;
            }
        }
    }
}