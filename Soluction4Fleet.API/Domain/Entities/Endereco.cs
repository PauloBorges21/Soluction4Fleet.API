namespace Soluction4Fleet.API.Domain.Entities
{
    public class Endereco
    {
        public Guid Id { get; set; }
        public string Cep { get; set; } = string.Empty;
        public string Rua { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
        public Locadora? Locadora { get; set; }
    }
}
