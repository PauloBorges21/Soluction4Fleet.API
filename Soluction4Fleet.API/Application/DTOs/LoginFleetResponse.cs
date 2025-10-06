namespace Soluction4Fleet.API.Application.DTOs
{
    public class LoginFleetResponse
    {
        public string Token { get; set; }
        public Guid IdUsuario { get; set; }
        public string Email { get; set; }
        public string Perfil { get; set; }

        public LoginFleetResponse(string token, Guid idUsuario ,string userEmail, string roles)
        {
            Token = token;
            IdUsuario = idUsuario;
            Email = userEmail;
            Perfil = roles;
        }
    }
}
