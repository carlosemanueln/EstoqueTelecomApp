using System;
using System.Collections.Generic;
using EstoqueTelecomApp.Models;
using EstoqueTelecomApp.Interfaces;
using EstoqueTelecomApp.DAO;

namespace EstoqueTelecomApp.Services
{
    public class EquipamentoService : IService<Equipamento>
    {
        private readonly IDAO<Equipamento> _equipamentoDAO;
     
        private readonly LogAuditoriaDAO _logDAO;

        public EquipamentoService()
        {
            _equipamentoDAO = new EquipamentoDAO();
            _logDAO = new LogAuditoriaDAO();
        }

        public void Salvar(Equipamento obj)
        {
            // Regras de validação mantidas
            if (string.IsNullOrWhiteSpace(obj.NomeModelo))
                throw new Exception("O modelo do equipamento não pode ficar em branco.");

            if (string.IsNullOrWhiteSpace(obj.Fabricante))
                throw new Exception("O fabricante do equipamento deve ser informado.");

            if (obj.QuantidadeEstoque < 0)
                throw new Exception("A quantidade em estoque não pode ser menor que zero.");

            if (obj.IdCategoria <= 0)
                throw new Exception("Por favor, selecione uma categoria válida para o equipamento.");

            if (obj.IdEquipamento == 0)
            {
                _equipamentoDAO.Inserir(obj);
                // grava o log no MongoDB
                _logDAO.RegistrarLog("INSERIR_ATIVO", "Tecnico_Campo", $"Novo equipamento {obj.NomeModelo} ({obj.Fabricante}) adicionado à malha.");
            }
            else
            {
                _equipamentoDAO.Atualizar(obj);
                _logDAO.RegistrarLog("ATUALIZAR_ATIVO", "Tecnico_Campo", $"Estoque do equipamento ID {obj.IdEquipamento} foi alterado.");
            }
        }

        public void Excluir(int id)
        {
            _equipamentoDAO.Excluir(id);
            // Registra se alguém remover um equipamento do sistema
            _logDAO.RegistrarLog("REMOVER_ATIVO", "Tecnico_Campo", $"Equipamento ID {id} foi removido da infraestrutura.");
        }

        public List<Equipamento> ObterTodos()
        {
            return _equipamentoDAO.ListarTodos();
        }

        public Equipamento ObterPorId(int id)
        {
            return _equipamentoDAO.BuscarPorId(id);
        }
    }
}