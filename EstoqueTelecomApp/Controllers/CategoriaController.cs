using System.Collections.Generic;
using EstoqueTelecomApp.Models;
using EstoqueTelecomApp.Interfaces;
using EstoqueTelecomApp.Services;

namespace EstoqueTelecomApp.Controllers
{

    public class CategoriaController : IController<Categoria>
    {
        // Ele conhece apenas o Service (a camada de baixo), isolando o Banco de Dados da Tela
        private readonly IService<Categoria> _categoriaService;

        public CategoriaController()
        {
            _categoriaService = new CategoriaService();
        }

        public void Salvar(Categoria obj)
        {
            // Apenas repassa o objeto para o Service aplicar as regras e salvar
            _categoriaService.Salvar(obj);
        }

        public void Deletar(int id)
        {
            _categoriaService.Excluir(id);
        }

        public List<Categoria> Listar()
        {
            return _categoriaService.ObterTodos();
        }
    }
}