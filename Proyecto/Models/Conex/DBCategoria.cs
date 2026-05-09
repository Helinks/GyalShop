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
        string stringConex = "server=localhost; user=Backend; database=backend; password=123456; port=3306;";

        public bool setCategoria(Categoria categoria) {
          
                string queryInsert = "INSERT INTO categorias (nombreCategoria, estadoCategoria) VALUES (@nombreCategoria, @estadoCategoria)";

                using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex)) {
                    using (MySqlCommand command = new MySqlCommand(queryInsert, mySqlConnection)) {
                        command.Parameters.AddWithValue("@nombreCategoria", categoria.NombreCategoria);
                        command.Parameters.AddWithValue("@estadoCategoria", categoria.EstaActivo);

                        mySqlConnection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0) { 
                        return true;
                        }
                    }
                }
           
            return false;
        }

        public Categoria getCategoria(int idCategoria) {
           
                Categoria categoria = new Categoria();
                string query = "select * from categorias where idCategoria = " + idCategoria;

                using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
                {
                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        mySqlConnection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            categoria.IdCategoria = reader.GetInt32("idCategoria");
                            categoria.NombreCategoria = reader.GetString("nombreCategoria");
                            categoria.EstaActivo = reader.GetBoolean("estado");
                        }
                    }
                }
                return categoria;
        }

        
        public List<Categoria> getCategorias(int idCategoria)
        {
           
                List<Categoria> categorias = new List<Categoria>();
                string query = "select * from categorias where idCategoria = " + idCategoria;

                using (MySqlConnection mySqlConnection = new MySqlConnection(stringConex))
                {
                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        mySqlConnection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Categoria categoria = new Categoria();
                                categoria.IdCategoria = reader.GetInt32("idCategoria");
                                categoria.NombreCategoria = reader.GetString("nombreCategoria");
                                categoria.EstaActivo = reader.GetBoolean("estado");

                                categorias.Add(categoria);
                            }
                        }

                    }
                }
                return categorias;

           
            
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

        public bool cambiarEstadoCategoria(Categoria categoria) {
            string query = "Update categorias set estadoCategoria = NOT estadoCategoria where idCategoria = @idCategoria";
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

