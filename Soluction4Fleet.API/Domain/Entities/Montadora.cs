namespace Soluction4Fleet.API.Domain.Entities
{
    public class Montadora
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public string PaisOrigem { get; set; } = string.Empty;
        public int? AnoFundacao { get; set; }
        public bool Ativo { get; set; } = true;
        public ICollection<Modelo> Modelos { get; set; } = new List<Modelo>(); // Navegação para Modelos
    }
}
