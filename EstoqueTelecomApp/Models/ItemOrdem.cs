namespace EstoqueTelecomApp.Models
{
    public class ItemOrdem
    {
        public int IdItemOrdem { get; set; }
        public int IdOrdem { get; set; } // Chave Estrangeira
        public int IdEquipamento { get; set; } // Chave Estrangeira
        public int QuantidadeMovimentada { get; set; }
    }
}