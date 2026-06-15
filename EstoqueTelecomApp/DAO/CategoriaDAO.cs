using MySqlConnector;
using EstoqueTelecomApp.Models;
using EstoqueTelecomApp.Interfaces;

namespace EstoqueTelecomApp.DAO
{
    
    public class CategoriaDAO : IDAO<Categoria>
    {
        private readonly Conexao _conexao;

        public CategoriaDAO()
        {
            _conexao = new Conexao();
        }

        public void Inserir(Categoria obj)
        {
         
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "INSERT INTO Categorias (nome, descricao) VALUES (@nome, @descricao)";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nome", obj.Nome);
            cmd.Parameters.AddWithValue("@descricao", obj.Descricao);
            cmd.ExecuteNonQuery();
        }

        public void Atualizar(Categoria obj)
        {
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "UPDATE Categorias SET nome = @nome, descricao = @descricao WHERE id_categoria = @id";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nome", obj.Nome);
            cmd.Parameters.AddWithValue("@descricao", obj.Descricao);
            cmd.Parameters.AddWithValue("@id", obj.IdCategoria);
            cmd.ExecuteNonQuery();
        }

        public void Excluir(int id)
        {
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "DELETE FROM Categorias WHERE id_categoria = @id";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public List<Categoria> ListarTodos()
        {
            var lista = new List<Categoria>();
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "SELECT * FROM Categorias";

            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            // O While lê linha por linha do banco e transforma em objetos C#
            while (reader.Read())
            {
                lista.Add(new Categoria
                {
                    IdCategoria = reader.GetInt32("id_categoria"),
                    Nome = reader.GetString("nome"),
                    Descricao = reader.GetString("descricao")
                });
            }
            return lista;
        }

        public Categoria BuscarPorId(int id)
        {
            Categoria categoria = null;
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "SELECT * FROM Categorias WHERE id_categoria = @id";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                categoria = new Categoria
                {
                    IdCategoria = reader.GetInt32("id_categoria"),
                    Nome = reader.GetString("nome"),
                    Descricao = reader.GetString("descricao")
                };
            }
            return categoria;
        }
    }
}