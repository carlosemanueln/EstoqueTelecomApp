using System;
using System.Collections.Generic;
using EstoqueTelecomApp.Models;
using EstoqueTelecomApp.Interfaces;
using EstoqueTelecomApp.DAO;

namespace EstoqueTelecomApp.Services
{
    public class ItemOrdemService : IService<ItemOrdem>
    {
        private readonly IDAO<ItemOrdem> _itemOrdemDAO;

        public ItemOrdemService()
        {
            _itemOrdemDAO = new ItemOrdemDAO();
        }

        public void Salvar(ItemOrdem obj)
        {
            // Regra 1: A quantidade movimentada (seja entrada ou saída) tem que ser pelo menos 1
            if (obj.QuantidadeMovimentada <= 0)
            {
                throw new Exception("A quantidade movimentada do equipamento deve ser maior que zero.");
            }

            // Regra 2: O item precisa estar obrigatoriamente ligado a uma Ordem de Serviço
            if (obj.IdOrdem <= 0)
            {
                throw new Exception("Ocorreu um erro: A ordem de serviço não foi identificada.");
            }

            // Regra 3: O item precisa ser um Equipamento real do sistema
            if (obj.IdEquipamento <= 0)
            {
                throw new Exception("Selecione um equipamento válido para adicionar à ordem.");
            }

            if (obj.IdItemOrdem == 0)
            {
                _itemOrdemDAO.Inserir(obj);
            }
            else
            {
                _itemOrdemDAO.Atualizar(obj);
            }
        }

        public void Excluir(int id)
        {
            _itemOrdemDAO.Excluir(id);
        }

        public List<ItemOrdem> ObterTodos()
        {
            return _itemOrdemDAO.ListarTodos();
        }

        public ItemOrdem ObterPorId(int id)
        {
            return _itemOrdemDAO.BuscarPorId(id);
        }
    }
}