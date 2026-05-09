using Proyecto.Models;
using Proyecto.Models.Conex;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;


namespace Proyecto.Services
{
    public class UsuarioService
    {
        DBUsuario dbUsuario = new DBUsuario();

        public Usuario Login(string correo, string password)
        {
            return dbUsuario.Login(correo, password);
        }

        public bool Register(Usuario usuario)
        {
            return dbUsuario.SetUsuario(usuario);
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public List<Usuario> GetAll()
        {
            return dbUsuario.GetAll();
        }

        public Usuario GetById(int id)
        {
            return dbUsuario.GetUsuario(id);
        }

        public bool Update(Usuario usuario)
        {
            return dbUsuario.UpdateUsuario(usuario);
        }

        public bool Delete(int id)
        {
            return dbUsuario.DeleteUsuario(id);
        }
    }
}
