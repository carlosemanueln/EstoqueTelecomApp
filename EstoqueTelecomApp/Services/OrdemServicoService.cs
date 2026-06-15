using System;
using System.Collections.Generic;
using EstoqueTelecomApp.Models;
using EstoqueTelecomApp.Interfaces;
using EstoqueTelecomApp.DAO;

namespace EstoqueTelecomApp.Services
{
    public class OrdemServicoService : IService<OrdemServico>
    {
        private readonly IDAO<OrdemServico> _ordemDAO;

        public OrdemServicoService()
        {
            _ordemDAO = new OrdemServicoDAO();
        }

        public void Salvar(OrdemServico obj)
        {
            // Regra 1: O tipo da ordem deve ser estritamente "Entrada" ou "Saida"
            if (obj.Tipo != "Entrada" && obj.Tipo != "Saida")
            {
                throw new Exception("O tipo de movimentação deve ser obrigatoriamente 'Entrada' ou 'Saida'.");
            }

            // Regra 2: É obrigatório ter um técnico responsável pela operação
            if (obj.IdUsuario <= 0)
            {
                throw new Exception("É obrigatório informar o técnico responsável pela ordem de serviço.");
            }

            if (obj.IdOrdem == 0)
            {
                // Regra 3: Garante que a data da ordem é o momento exato da criação no sistema
                obj.DataOrdem = DateTime.Now;
                _ordemDAO.Inserir(obj);
            }
            else
            {
                _ordemDAO.Atualizar(obj);
            }
        }

        public void Excluir(int id)
        {
            _ordemDAO.Excluir(id);
        }

        public List<OrdemServico> ObterTodos()
        {
            return _ordemDAO.ListarTodos();
        }

        public OrdemServico ObterPorId(int id)
        {
            return _ordemDAO.BuscarPorId(id);
        }
    }
}