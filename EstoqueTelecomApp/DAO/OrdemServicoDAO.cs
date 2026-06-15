using MySqlConnector;
using EstoqueTelecomApp.Models;
using EstoqueTelecomApp.Interfaces;

namespace EstoqueTelecomApp.DAO
{
    public class OrdemServicoDAO : IDAO<OrdemServico>
    {
        private readonly Conexao _conexao;

        public OrdemServicoDAO()
        {
            _conexao = new Conexao();
        }

        public void Inserir(OrdemServico obj)
        {
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "INSERT INTO Ordens_Servico (data_ordem, tipo, id_usuario) VALUES (@data, @tipo, @id_usuario)";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@data", obj.DataOrdem);
            cmd.Parameters.AddWithValue("@tipo", obj.Tipo);
            cmd.Parameters.AddWithValue("@id_usuario", obj.IdUsuario);
            cmd.ExecuteNonQuery();
        }

        public void Atualizar(OrdemServico obj)
        {
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "UPDATE Ordens_Servico SET data_ordem = @data, tipo = @tipo, id_usuario = @id_usuario WHERE id_ordem = @id";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@data", obj.DataOrdem);
            cmd.Parameters.AddWithValue("@tipo", obj.Tipo);
            cmd.Parameters.AddWithValue("@id_usuario", obj.IdUsuario);
            cmd.Parameters.AddWithValue("@id", obj.IdOrdem);
            cmd.ExecuteNonQuery();
        }

        public void Excluir(int id)
        {
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "DELETE FROM Ordens_Servico WHERE id_ordem = @id";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public List<OrdemServico> ListarTodos()
        {
            var lista = new List<OrdemServico>();
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "SELECT * FROM Ordens_Servico";

            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new OrdemServico
                {
                    IdOrdem = reader.GetInt32("id_ordem"),
                    DataOrdem = reader.GetDateTime("data_ordem"),
                    Tipo = reader.GetString("tipo"),
                    IdUsuario = reader.GetInt32("id_usuario")
                });
            }
            return lista;
        }

        public OrdemServico BuscarPorId(int id)
        {
            OrdemServico ordem = null;
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "SELECT * FROM Ordens_Servico WHERE id_ordem = @id";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                ordem = new OrdemServico
                {
                    IdOrdem = reader.GetInt32("id_ordem"),
                    DataOrdem = reader.GetDateTime("data_ordem"),
                    Tipo = reader.GetString("tipo"),
                    IdUsuario = reader.GetInt32("id_usuario")
                };
            }
            return ordem;
        }
    }
}