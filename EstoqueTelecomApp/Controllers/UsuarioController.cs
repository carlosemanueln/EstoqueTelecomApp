using System.Collections.Generic;
using EstoqueTelecomApp.Models;
using EstoqueTelecomApp.Interfaces;
using EstoqueTelecomApp.Services;

namespace EstoqueTelecomApp.Controllers
{
    public class UsuarioController : IController<Usuario>
    {
        private readonly IService<Usuario> _usuarioService;

        public UsuarioController()
        {
            _usuarioService = new UsuarioService();
        }

        public void Salvar(Usuario obj)
        {
            _usuarioService.Salvar(obj);
        }

        public void Deletar(int id)
        {
            _usuarioService.Excluir(id);
        }

        public List<Usuario> Listar()
        {
            return _usuarioService.ObterTodos();
        }
    }
}
