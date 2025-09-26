namespace Soluction4Fleet.API.Application.DTOs.Relatorio
{
    public class LogVeiculoRelatorioDTO
    {
        public string NomeLocadora { get; set; }
        public string Modelo { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
    }
}
