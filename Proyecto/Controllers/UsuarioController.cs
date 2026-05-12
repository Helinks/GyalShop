using Proyecto.Models;
using Proyecto.Services;
using System.Collections.Generic;

namespace Proyecto.Controllers
{
    internal class UsuarioController
    {
        private readonly UsuarioService usuarioService = new UsuarioService();

        public List<Usuario> GetAll()
        {
            return usuarioService.GetAll();
        }

        public List<TipoUsuario> GetTiposUsuario()
        {
            return usuarioService.GetTiposUsuario();
        }

        public Usuario GetById(int id)
        {
            return usuarioService.GetById(id);
        }

        public bool Create(Usuario usuario)
        {
            return usuarioService.Register(usuario);
        }

        public bool Update(Usuario usuario, bool cambiarPassword)
        {
            return usuarioService.Update(usuario, cambiarPassword);
        }

        public bool UpdateEstado(int idUsuario, bool estado)
        {
            return usuarioService.UpdateEstado(idUsuario, estado);
        }

        public bool Delete(int id)
        {
            return usuarioService.Delete(id);
        }
    }
}