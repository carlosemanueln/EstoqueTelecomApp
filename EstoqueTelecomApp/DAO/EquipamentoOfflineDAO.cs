using Microsoft.Data.Sqlite;
using EstoqueTelecomApp.Models;
using EstoqueTelecomApp.Interfaces;
using System.Collections.Generic;

namespace EstoqueTelecomApp.DAO
{
   
    public class EquipamentoOfflineDAO : IDAO<Equipamento>
    {
        private readonly ConexaoSqlite _conexaoSqlite;

        public EquipamentoOfflineDAO()
        {
            _conexaoSqlite = new ConexaoSqlite();
        }

        public void Inserir(Equipamento obj)
        {
            using var conn = _conexaoSqlite.ObterConexao();
            conn.Open();


            string sql = "INSERT INTO Equipamentos_Offline (nome_modelo, fabricante, quantidade, sincronizado) VALUES (@nome_modelo, @fabricante, @quantidade, 0)";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nome_modelo", obj.NomeModelo);
            cmd.Parameters.AddWithValue("@fabricante", obj.Fabricante);
            cmd.Parameters.AddWithValue("@quantidade", obj.QuantidadeEstoque);
            cmd.ExecuteNonQuery();
        }

        public List<Equipamento> ListarTodos()
        {
            var lista = new List<Equipamento>();
            using var conn = _conexaoSqlite.ObterConexao();
            conn.Open();

            // O sistema busca apenas os equipamentos que o técnico cadastrou hoje e que ainda não subiram para o servidor
            string sql = "SELECT id_equipamento, nome_modelo, fabricante, quantidade FROM Equipamentos_Offline WHERE sincronizado = 0";

            using var cmd = new SqliteCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Equipamento
                {
                    IdEquipamento = reader.GetInt32(0),
                    NomeModelo = reader.GetString(1),
                    Fabricante = reader.GetString(2),
                    QuantidadeEstoque = reader.GetInt32(3)
                });
            }
            return lista;
        }

        public void Atualizar(Equipamento obj) { }
        public void Excluir(int id) { }
        public Equipamento BuscarPorId(int id) => null;
    }
}