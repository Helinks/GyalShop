using Proyecto.Models;
using Proyecto.Services;
using System.Collections.Generic;

namespace Proyecto.Controllers
{
    internal class UsuarioController
    {
        private UsuarioService usuarioService = new UsuarioService();

        public List<Usuario> GetAll()
        {
            return usuarioService.GetAll();
        }

        public Usuario GetById(int id)
        {
            return usuarioService.GetById(id);
        }

        public bool Create(Usuario usuario)
        {
            return usuarioService.Register(usuario);
        }

        public bool Update(Usuario usuario)
        {
            return usuarioService.Update(usuario);
        }

        public bool Delete(int id)
        {
            return usuarioService.Delete(id);
        }
    }
}