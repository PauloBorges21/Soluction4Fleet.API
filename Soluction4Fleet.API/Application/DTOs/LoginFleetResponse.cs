namespace Soluction4Fleet.API.Application.DTOs
{
    public class LoginFleetResponse
    {
        public string Token { get; set; }
        //public DateTime Expiracao { get; set; }
        public string Email { get; set; }
        public string Perfil { get; set; }

        public LoginFleetResponse(string token, string userEmail, string roles)
        {
            Token = token;
            //Expiracao = expiration;
            Email = userEmail;
            Perfil = roles;
        }
    }
}
