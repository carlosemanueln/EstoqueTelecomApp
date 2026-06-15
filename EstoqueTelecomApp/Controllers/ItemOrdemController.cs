using System.Collections.Generic;
using EstoqueTelecomApp.Models;
using EstoqueTelecomApp.Interfaces;
using EstoqueTelecomApp.Services;

namespace EstoqueTelecomApp.Controllers
{
    public class ItemOrdemController : IController<ItemOrdem>
    {
        private readonly IService<ItemOrdem> _itemService;

        public ItemOrdemController()
        {
            _itemService = new ItemOrdemService();
        }

        public void Salvar(ItemOrdem obj)
        {
            _itemService.Salvar(obj);
        }

        public void Deletar(int id)
        {
            _itemService.Excluir(id);
        }

        public List<ItemOrdem> Listar()
        {
            return _itemService.ObterTodos();
        }
    }
}