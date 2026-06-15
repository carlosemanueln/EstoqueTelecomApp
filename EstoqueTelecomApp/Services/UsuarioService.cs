using System;
using System.Collections.Generic;
using EstoqueTelecomApp.Models;
using EstoqueTelecomApp.Interfaces;
using EstoqueTelecomApp.DAO;

namespace EstoqueTelecomApp.Services
{
    public class UsuarioService : IService<Usuario>
    {
        private readonly IDAO<Usuario> _usuarioDAO;

        public UsuarioService()
        {
            _usuarioDAO = new UsuarioDAO();
        }

        public void Salvar(Usuario obj)
        {
            // Regra 1: Nome é obrigatório
            if (string.IsNullOrWhiteSpace(obj.Nome))
            {
                throw new Exception("O nome do técnico é obrigatório.");
            }

            // Regra 2: E-mail deve ser válido (conter @)
            if (string.IsNullOrWhiteSpace(obj.Email) || !obj.Email.Contains("@"))
            {
                throw new Exception("Por favor, insira um e-mail válido.");
            }

            // Regra 3: Senha não pode ser vazia
            if (string.IsNullOrWhiteSpace(obj.Senha))
            {
                throw new Exception("A senha de acesso é obrigatória.");
            }

            // Se passou por todas as validações, decide se vai Inserir (novo) ou Atualizar (existente)
            if (obj.IdUsuario == 0)
            {
                _usuarioDAO.Inserir(obj);
            }
            else
            {
                _usuarioDAO.Atualizar(obj);
            }
        }

        public void Excluir(int id)
        {
         
            _usuarioDAO.Excluir(id);
        }

        public List<Usuario> ObterTodos()
        {
            return _usuarioDAO.ListarTodos();
        }

        public Usuario ObterPorId(int id)
        {
            return _usuarioDAO.BuscarPorId(id);
        }
    }
}