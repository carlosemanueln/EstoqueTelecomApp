using System;
using System.Collections.Generic;
using System.Text;

using System;
using System.Collections.Generic;
using EstoqueTelecomApp.Models;
using EstoqueTelecomApp.Interfaces;
using EstoqueTelecomApp.DAO;

namespace EstoqueTelecomApp.Services
{
    
    public class CategoriaService : IService<Categoria>
    {
        // O Service precisa conversar com o DAO
        private readonly IDAO<Categoria> _categoriaDAO;

        public CategoriaService()
        {
            _categoriaDAO = new CategoriaDAO();
        }

        public void Salvar(Categoria obj)
        {
            // Regra de Negócio 1: Validação de dados em branco
            if (string.IsNullOrWhiteSpace(obj.Nome))
            {
                // Interrompe o processo e lança um erro para a tela
                throw new Exception("O nome da categoria não pode ficar em branco.");
            }

            // Regra de Negócio 2: Se o ID for 0, é um cadastro novo (Inserir). Se tiver ID, é edição (Atualizar).
            if (obj.IdCategoria == 0)
            {
                _categoriaDAO.Inserir(obj);
            }
            else
            {
                _categoriaDAO.Atualizar(obj);
            }
        }

        public void Excluir(int id)
        {
       
            _categoriaDAO.Excluir(id);
        }

        public List<Categoria> ObterTodos()
        {
            return _categoriaDAO.ListarTodos();
        }

        public Categoria ObterPorId(int id)
        {
            return _categoriaDAO.BuscarPorId(id);
        }
    }
}