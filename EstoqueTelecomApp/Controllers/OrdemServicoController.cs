using System.Collections.Generic;
using EstoqueTelecomApp.Models;
using EstoqueTelecomApp.Interfaces;
using EstoqueTelecomApp.Services;

namespace EstoqueTelecomApp.Controllers
{
    public class OrdemServicoController : IController<OrdemServico>
    {
        private readonly IService<OrdemServico> _ordemService;

        public OrdemServicoController()
        {
            _ordemService = new OrdemServicoService();
        }

        public void Salvar(OrdemServico obj)
        {
            _ordemService.Salvar(obj);
        }

        public void Deletar(int id)
        {
            _ordemService.Excluir(id);
        }

        public List<OrdemServico> Listar()
        {
            return _ordemService.ObterTodos();
        }
    }
}