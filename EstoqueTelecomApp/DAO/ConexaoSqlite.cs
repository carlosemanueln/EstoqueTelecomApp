using Microsoft.Data.Sqlite;
using System.IO;

namespace EstoqueTelecomApp.DAO
{
    public class ConexaoSqlite
    {
        // O caminho físico onde o arquivo será criado no dispositivo
        private readonly string _caminhoBanco;

        public ConexaoSqlite()
        {
            
            _caminhoBanco = Path.Combine(FileSystem.AppDataDirectory, "EstoqueOffline.db");
            InicializarBanco();
        }

        public SqliteConnection ObterConexao()
        {
            return new SqliteConnection($"Data Source={_caminhoBanco}");
        }

        private void InicializarBanco()
        {
            using var conn = ObterConexao();
            conn.Open();

            // Cria a tabela local apenas se ela ainda não existir no aparelho
            // A coluna 'sincronizado' é a inteligência que define se o dado já foi pro MySQL ou não (0 = Não, 1 = Sim)
            string sql = @"
                CREATE TABLE IF NOT EXISTS Equipamentos_Offline (
                    id_equipamento INTEGER PRIMARY KEY AUTOINCREMENT,
                    nome_modelo TEXT NOT NULL,
                    fabricante TEXT NOT NULL,
                    quantidade INTEGER NOT NULL,
                    sincronizado INTEGER DEFAULT 0
                );";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
    }
}