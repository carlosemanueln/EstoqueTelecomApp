namespace EstoqueTelecomApp.Interfaces
{
    public interface IService<T>
    {
        void Salvar(T obj);
        void Excluir(int id);
        List<T> ObterTodos();
        T ObterPorId(int id);
    }
}