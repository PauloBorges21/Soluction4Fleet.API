namespace Soluction4Fleet.API.Application.DTOs.FrotaLocadora
{
    public class TransferirFrotaVeiculoDTO
    {
        public Guid VeiculoId { get; set; }
        public Guid LocadoraId { get; set; }
        public DateTime DataEntrada { get; set; }
    }
}
