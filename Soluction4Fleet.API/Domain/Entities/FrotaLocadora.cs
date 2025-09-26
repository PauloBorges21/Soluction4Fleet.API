namespace Soluction4Fleet.API.Domain.Entities
{
    public class FrotaLocadora
    {
        public Guid Id { get; set; }
        // Relacionamentos
        public Guid LocadoraId { get; set; }
        public Locadora Locadora { get; set; }

        public Guid VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        // Controle de período
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }

        // Extras
        public int Status { get; set; } // indica se o veículo está atualmente nessa locadora
        public DateTime DataCriacao { get; set; }
    }
}
