using MySqlConnector;
using EstoqueTelecomApp.Models;
using EstoqueTelecomApp.Interfaces;

namespace EstoqueTelecomApp.DAO
{
    public class UsuarioDAO : IDAO<Usuario>
    {
        private readonly Conexao _conexao;

        public UsuarioDAO()
        {
            _conexao = new Conexao();
        }

        public void Inserir(Usuario obj)
        {
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "INSERT INTO Usuarios (nome, email, senha) VALUES (@nome, @email, @senha)";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nome", obj.Nome);
            cmd.Parameters.AddWithValue("@email", obj.Email);
            cmd.Parameters.AddWithValue("@senha", obj.Senha);
            cmd.ExecuteNonQuery();
        }

        public void Atualizar(Usuario obj)
        {
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "UPDATE Usuarios SET nome = @nome, email = @email, senha = @senha WHERE id_usuario = @id";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nome", obj.Nome);
            cmd.Parameters.AddWithValue("@email", obj.Email);
            cmd.Parameters.AddWithValue("@senha", obj.Senha);
            cmd.Parameters.AddWithValue("@id", obj.IdUsuario);
            cmd.ExecuteNonQuery();
        }

        public void Excluir(int id)
        {
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "DELETE FROM Usuarios WHERE id_usuario = @id";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public List<Usuario> ListarTodos()
        {
            var lista = new List<Usuario>();
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "SELECT * FROM Usuarios";

            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Usuario
                {
                    IdUsuario = reader.GetInt32("id_usuario"),
                    Nome = reader.GetString("nome"),
                    Email = reader.GetString("email"),
                    Senha = reader.GetString("senha")
                });
            }
            return lista;
        }

        public Usuario BuscarPorId(int id)
        {
            Usuario usuario = null;
            using var conn = _conexao.ObterConexao();
            conn.Open();
            string sql = "SELECT * FROM Usuarios WHERE id_usuario = @id";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                usuario = new Usuario
                {
                    IdUsuario = reader.GetInt32("id_usuario"),
                    Nome = reader.GetString("nome"),
                    Email = reader.GetString("email"),
                    Senha = reader.GetString("senha")
                };
            }
            return usuario;
        }
    }
}