namespace Soluction4Fleet.API.Domain.Entities
{
    public class Veiculo
    {
        public Guid Id { get; set; }
        public int NumeroPortas { get; set; }
        public string Cor { get; set; } = string.Empty;
        public string Fabricante { get; set; } = string.Empty;
        public int AnoModelo { get; set; }
        public int AnoFabricacao { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string Chassi { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public bool Ativo { get; set; } = true;
        public Guid ModeloId { get; set; }
        public Modelo Modelo { get; set; } = null!;
    }
}
