using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Proyecto.Models.Conex
{
    public class DBCategoria
    {
        string stringConex = "server=localhost; user=root; database=gyalshop; password=; port=3306;";

        public bool setCategoria(Categoria categoria) {
          
                string queryInsert = "INSERT INTO categorias (nombreCategoria, estadoCategoria) VALUES (@nombreCategoria, @estadoCategoria)";

                using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex)) {
                    using (MySqlCommand command = new MySqlCommand(queryInsert, mySqlConnection)) {
                        command.Parameters.AddWithValue("@nombreCategoria", categoria.NombreCategoria);
                        command.Parameters.AddWithValue("@estadoCategoria", true);

                        mySqlConnection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0) { 
                        return true;
                        }
                    }
                }
           
            return false;
        }

        public Categoria getCategoria(Categoria categoria) {
           
                Categoria resCategoria = new Categoria();
                string query = "select * from categorias where idCategoria = @idCategoria";

                using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
                {
                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                    command.Parameters.AddWithValue("@idCategoria",categoria.IdCategoria);
                        mySqlConnection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                        resCategoria.IdCategoria = reader.GetInt32("idCategoria");
                        resCategoria.NombreCategoria = reader.GetString("nombreCategoria");
                        resCategoria.EstaActivo = reader.GetBoolean("estadoCategoria");
                        }
                    }
                }
                return resCategoria;
        }

        
        public List<Categoria> getCategorias(Categoria categoria)
        {
           
                List<Categoria> resCategorias = new List<Categoria>();
                string query = "select * from categorias where idCategoria = @idCategorias";

                using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
                {
                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                    command.Parameters.AddWithValue("@idCategoria", categoria.IdCategoria);

                    mySqlConnection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Categoria categorias = new Categoria();
                            categorias.IdCategoria = reader.GetInt32("idCategoria");
                            categorias.NombreCategoria = reader.GetString("nombreCategoria");
                            categorias.EstaActivo = reader.GetBoolean("estadoCategoria");

                            resCategorias.Add(categorias);
                            }
                        }

                    }
                }
                return resCategorias;
   
        }

        public List<Categoria> getAllCategoria()
        {
            List<Categoria> listaCategoria = new List<Categoria>();

            string query = "select * from categorias where estadoCategoria = @estadoCategoria";

            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
            using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
            {
                command.Parameters.AddWithValue("@estadoCategoria", true);
                mySqlConnection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Categoria categoria = new Categoria();

                        categoria.IdCategoria = reader.GetInt32("idCategoria");
                        categoria.NombreCategoria = reader.GetString("nombreCategoria");
                        categoria.EstaActivo = reader.GetBoolean("estadoCategoria");


                        listaCategoria.Add(categoria);
                    }
                }
            }

            return listaCategoria;
        }

        public bool updateCategoria(Categoria categoria) {

            string query = "update categorias set nombreCategoria = @nombreCategoria, estadoCategoria = @estadoCategoria where idCategoria = @idCategoria";
            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex)) {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection)) {
                    command.Parameters.AddWithValue("@nombreCategoria",categoria.NombreCategoria);
                    command.Parameters.AddWithValue("@estadoCategoria", categoria.EstaActivo);
                    command.Parameters.AddWithValue("@idCategoria", categoria.IdCategoria);

                    mySqlConnection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result > 0) {
                        return true;
                    }
                
                }
            }
            return false;
        }

        public bool deleteCategoria(Categoria categoria) {
            string query = "Update categorias set estadoCategoria = 0 where idCategoria = @idCategoria";
            using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex)) {
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection)) {
                    command.Parameters.AddWithValue("@idCategoria", categoria.IdCategoria);

                    mySqlConnection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result > 0) {
                        return true;
                    }
                }
            }
            return false;
        }
            
    }
}

