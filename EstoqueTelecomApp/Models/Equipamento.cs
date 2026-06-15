namespace EstoqueTelecomApp.Models
{
    public class Equipamento
    {
        public int IdEquipamento { get; set; }
        public string NomeModelo { get; set; } = string.Empty;
        public string Fabricante { get; set; } = string.Empty;
        public int QuantidadeEstoque { get; set; }
        public int IdCategoria { get; set; } 
    }
}