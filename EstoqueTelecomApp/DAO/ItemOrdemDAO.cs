using MySqlConnector;
using EstoqueTelecomApp.Models;
using EstoqueTelecomApp.Interfaces;

namespace EstoqueTelecomApp.DAO
{
    public class ItemOrdemDAO : IDAO<ItemOrdem>
    {
        private readonly Conexao _conexao;

        public ItemOrdemDAO()
        {
            _conexao = new Conexao();
        }

        public void Inserir(ItemOrdem obj)
        {
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "INSERT INTO Itens_Ordem (id_ordem, id_equipamento, quantidade_movimentada) VALUES (@id_ordem, @id_equipamento, @quantidade)";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id_ordem", obj.IdOrdem);
            cmd.Parameters.AddWithValue("@id_equipamento", obj.IdEquipamento);
            cmd.Parameters.AddWithValue("@quantidade", obj.QuantidadeMovimentada);
            cmd.ExecuteNonQuery();
        }

        public void Atualizar(ItemOrdem obj)
        {
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "UPDATE Itens_Ordem SET id_ordem = @id_ordem, id_equipamento = @id_equipamento, quantidade_movimentada = @quantidade WHERE id_item_ordem = @id";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id_ordem", obj.IdOrdem);
            cmd.Parameters.AddWithValue("@id_equipamento", obj.IdEquipamento);
            cmd.Parameters.AddWithValue("@quantidade", obj.QuantidadeMovimentada);
            cmd.Parameters.AddWithValue("@id", obj.IdItemOrdem);
            cmd.ExecuteNonQuery();
        }

        public void Excluir(int id)
        {
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "DELETE FROM Itens_Ordem WHERE id_item_ordem = @id";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public List<ItemOrdem> ListarTodos()
        {
            var lista = new List<ItemOrdem>();
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "SELECT * FROM Itens_Ordem";

            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new ItemOrdem
                {
                    IdItemOrdem = reader.GetInt32("id_item_ordem"),
                    IdOrdem = reader.GetInt32("id_ordem"),
                    IdEquipamento = reader.GetInt32("id_equipamento"),
                    QuantidadeMovimentada = reader.GetInt32("quantidade_movimentada")
                });
            }
            return lista;
        }

        public ItemOrdem BuscarPorId(int id)
        {
            ItemOrdem item = null;
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "SELECT * FROM Itens_Ordem WHERE id_item_ordem = @id";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                item = new ItemOrdem
                {
                    IdItemOrdem = reader.GetInt32("id_item_ordem"),
                    IdOrdem = reader.GetInt32("id_ordem"),
                    IdEquipamento = reader.GetInt32("id_equipamento"),
                    QuantidadeMovimentada = reader.GetInt32("quantidade_movimentada")
                };
            }
            return item;
        }
    }
}