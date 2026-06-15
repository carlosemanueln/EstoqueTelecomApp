using System.Collections.Generic;
using EstoqueTelecomApp.Models;
using EstoqueTelecomApp.Interfaces;
using EstoqueTelecomApp.Services;

namespace EstoqueTelecomApp.Controllers
{
    public class EquipamentoController : IController<Equipamento>
    {
        private readonly IService<Equipamento> _equipamentoService;

        public EquipamentoController()
        {
            _equipamentoService = new EquipamentoService();
        }

        public void Salvar(Equipamento obj)
        {
            _equipamentoService.Salvar(obj);
        }

        public void Deletar(int id)
        {
            _equipamentoService.Excluir(id);
        }

        public List<Equipamento> Listar()
        {
            return _equipamentoService.ObterTodos();
        }
    }
}
