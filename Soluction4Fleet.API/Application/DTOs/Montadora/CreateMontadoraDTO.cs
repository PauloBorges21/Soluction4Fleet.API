namespace Soluction4Fleet.API.Application.DTOs.Montadora
{
    public class CreateMontadoraDTO
    {
        public List<CreateListMontadoraDTO> Montadoras { get; set; } = new();
    }

    public class CreateListMontadoraDTO
    {
        public string Nome { get; set; }
        public string PaisOrigem { get; set; }
        public int? AnoFundacao { get; set; }
    }
}
