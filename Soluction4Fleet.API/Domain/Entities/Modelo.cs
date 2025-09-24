namespace Soluction4Fleet.API.Domain.Entities
{
    public class Modelo
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
        public Guid MontadoraId { get; set; }
        public Montadora Montadora { get; set; } = null!;


        // Relacionamento com Veículo
        public ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
    }
}
