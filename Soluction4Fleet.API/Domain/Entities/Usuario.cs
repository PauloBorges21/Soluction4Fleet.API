namespace Soluction4Fleet.API.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public required string Perfil { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
