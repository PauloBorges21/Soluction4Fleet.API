using Soluction4Fleet.API.Domain.Enum;

namespace Soluction4Fleet.API.Application.DTOs.Veiculo
{
    public class VeiculoDTO
    {
        public Guid Id { get; set; }
        public Guid LocadoraId { get; set; }
        public string NomeLocadoura { get; set; }
        public StatusCarro Status { get; set; }
        public string NomeMontadora { get; set; }
        public string NomeModelo { get; set; }
        public int NumeroPortas { get; set; }
        public string Cor { get; set; }
        public string Fabricante { get; set; }
        public int AnoModelo { get; set; }
        public int AnoFabricacao { get; set; }
        public string Placa { get; set; }
        public string Chassi { get; set; }

    }
}
