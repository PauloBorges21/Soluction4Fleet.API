using Soluction4Fleet.API.Application.DTOs;

namespace Soluction4Fleet.API.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginFleetResponse> Authenticate(LoginFleetRequest request);
    }
}
