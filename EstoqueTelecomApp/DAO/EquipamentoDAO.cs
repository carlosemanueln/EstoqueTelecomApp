using MySqlConnector;
using EstoqueTelecomApp.Models;
using EstoqueTelecomApp.Interfaces;

namespace EstoqueTelecomApp.DAO
{
    public class EquipamentoDAO : IDAO<Equipamento>
    {
        private readonly Conexao _conexao;

        public EquipamentoDAO()
        {
            _conexao = new Conexao();
        }

        public void Inserir(Equipamento obj)
        {
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "INSERT INTO Equipamentos (nome_modelo, fabricante, quantidade_estoque, id_categoria) VALUES (@nome_modelo, @fabricante, @quantidade_estoque, @id_categoria)";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nome_modelo", obj.NomeModelo);
            cmd.Parameters.AddWithValue("@fabricante", obj.Fabricante);
            cmd.Parameters.AddWithValue("@quantidade_estoque", obj.QuantidadeEstoque);
            cmd.Parameters.AddWithValue("@id_categoria", obj.IdCategoria);
            cmd.ExecuteNonQuery();
        }

        public void Atualizar(Equipamento obj)
        {
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "UPDATE Equipamentos SET nome_modelo = @nome_modelo, fabricante = @fabricante, quantidade_estoque = @quantidade_estoque, id_categoria = @id_categoria WHERE id_equipamento = @id";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nome_modelo", obj.NomeModelo);
            cmd.Parameters.AddWithValue("@fabricante", obj.Fabricante);
            cmd.Parameters.AddWithValue("@quantidade_estoque", obj.QuantidadeEstoque);
            cmd.Parameters.AddWithValue("@id_categoria", obj.IdCategoria);
            cmd.Parameters.AddWithValue("@id", obj.IdEquipamento);
            cmd.ExecuteNonQuery();
        }

        public void Excluir(int id)
        {
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "DELETE FROM Equipamentos WHERE id_equipamento = @id";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public List<Equipamento> ListarTodos()
        {
            var lista = new List<Equipamento>();
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "SELECT * FROM Equipamentos";

            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Equipamento
                {
                    IdEquipamento = reader.GetInt32("id_equipamento"),
                    NomeModelo = reader.GetString("nome_modelo"),
                    Fabricante = reader.GetString("fabricante"),
                    QuantidadeEstoque = reader.GetInt32("quantidade_estoque"),
                    // Verifica se a categoria não é nula no banco para evitar travamentos
                    IdCategoria = reader.IsDBNull(reader.GetOrdinal("id_categoria")) ? 0 : reader.GetInt32("id_categoria")
                });
            }
            return lista;
        }

        public Equipamento BuscarPorId(int id)
        {
            Equipamento equipamento = null;
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "SELECT * FROM Equipamentos WHERE id_equipamento = @id";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                equipamento = new Equipamento
                {
                    IdEquipamento = reader.GetInt32("id_equipamento"),
                    NomeModelo = reader.GetString("nome_modelo"),
                    Fabricante = reader.GetString("fabricante"),
                    QuantidadeEstoque = reader.GetInt32("quantidade_estoque"),
                    IdCategoria = reader.IsDBNull(reader.GetOrdinal("id_categoria")) ? 0 : reader.GetInt32("id_categoria")
                };
            }
            return equipamento;
        }
    }
}