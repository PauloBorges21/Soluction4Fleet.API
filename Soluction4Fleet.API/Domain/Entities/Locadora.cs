namespace Soluction4Fleet.API.Domain.Entities
{
    public class Locadora
    {
        public Guid Id { get; set; }        
        public string NomeFantasia { get; set; } = string.Empty;
        public string RazaoSocial { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
        public Endereco Endereco { get; set; } = null!;
    }
}
