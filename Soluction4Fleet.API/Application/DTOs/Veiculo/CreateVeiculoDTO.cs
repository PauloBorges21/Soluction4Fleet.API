namespace Soluction4Fleet.API.Application.DTOs.Veiculo
{
    public class CreateVeiculoDTO
    {
        public int NumeroPortas { get; set; }
        public string Cor { get; set; }
        public string Fabricante { get; set; }
        public int AnoModelo { get; set; }
        public int AnoFabricacao { get; set; }
        public string Placa { get; set; }
        public string Chassi { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ModeloId { get; set; }
    }
}
