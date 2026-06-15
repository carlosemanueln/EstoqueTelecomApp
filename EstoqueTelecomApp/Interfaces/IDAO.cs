namespace EstoqueTelecomApp.Interfaces
{
    public interface IDAO<T>
    {
        void Inserir(T obj);
        void Atualizar(T obj);
        void Excluir(int id);
        List<T> ListarTodos();
        T BuscarPorId(int id);
    }
}