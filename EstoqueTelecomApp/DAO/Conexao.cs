using MySqlConnector;

namespace EstoqueTelecomApp.DAO
{
    public class Conexao
    {
    
        private readonly string stringConexao = "Server=localhost;Database=EstoqueTelecom;Uid=root;Pwd=carlosemanuel1;";

        // Método que devolve uma ligação pronta a usar
        public MySqlConnection ObterConexao()
        {
            return new MySqlConnection(stringConexao);
        }
    }
}