using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EstoqueTelecomApp.Models
{
    public class LogAuditoria
    {
        // O MongoDB não usa inteiros para ID, ele usa o formato próprio ObjectId
        [BsonId]
        public ObjectId Id { get; set; }

        public DateTime DataHora { get; set; }
        public string Acao { get; set; }
        public string Usuario { get; set; }
        public string Detalhes { get; set; }

        public LogAuditoria()
        {
            DataHora = DateTime.Now;
        }
    }
}