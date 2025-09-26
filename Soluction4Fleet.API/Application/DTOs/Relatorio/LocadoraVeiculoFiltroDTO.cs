
namespace Soluction4Fleet.API.Application.DTOs.Relatorio
{
    public class LocadoraVeiculoFiltroDTO
    {
        public Guid? LocadoraId { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public Guid? ModeloId { get; set; }
    }
}
