namespace Soluction4Fleet.API.Application.DTOs
{
    public class LoginFleetRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
