using System.Collections.Generic;
using EstoqueTelecomApp.Models;
using EstoqueTelecomApp.DAO;

namespace EstoqueTelecomApp.Controllers
{
    public class EquipamentoOfflineController
    {
        private readonly EquipamentoOfflineDAO _daoOffline;

        public EquipamentoOfflineController()
        {
            _daoOffline = new EquipamentoOfflineDAO();
        }

        public void SalvarLocal(Equipamento obj)
        {
            _daoOffline.Inserir(obj);
        }

        public List<Equipamento> ListarPendentes()
        {
            return _daoOffline.ListarTodos();
        }
    }
}