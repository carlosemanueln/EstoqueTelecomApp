using MongoDB.Driver;
using EstoqueTelecomApp.Models;
using System;

namespace EstoqueTelecomApp.DAO
{
    public class LogAuditoriaDAO
    {
        private readonly IMongoCollection<LogAuditoria> _logsCollection;

        public LogAuditoriaDAO()
        {
            try
            {
                // Conecta ao MongoDB
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("EstoqueTelecomDB_Logs");

               
                _logsCollection = database.GetCollection<LogAuditoria>("LogsAuditoria");
            }
            catch (Exception)
            {
   
            }
        }

        public void RegistrarLog(string acao, string usuario, string detalhes)
        {
            try
            {
                var log = new LogAuditoria
                {
                    Acao = acao,
                    Usuario = usuario,
                    Detalhes = detalhes
                };

                // Insere o documento JSON
                _logsCollection.InsertOne(log);
            }
            catch (Exception)
            {
                // O log não deve travar o aplicativo principal caso o Mongo esteja desligado
            }
        }
    }
}