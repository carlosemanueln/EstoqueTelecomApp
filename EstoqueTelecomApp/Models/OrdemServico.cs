namespace EstoqueTelecomApp.Models
{
    public class OrdemServico
    {
        public int IdOrdem { get; set; }
        public DateTime DataOrdem { get; set; } = DateTime.Now;
        public string Tipo { get; set; } = string.Empty; 
        public int IdUsuario { get; set; } // Chave Estrangeira
    }
}