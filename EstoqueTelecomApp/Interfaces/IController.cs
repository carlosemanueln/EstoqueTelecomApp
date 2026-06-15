namespace EstoqueTelecomApp.Interfaces
{
    public interface IController<T>
    {
        void Salvar(T obj);
        void Deletar(int id);
        List<T> Listar();
    }
}