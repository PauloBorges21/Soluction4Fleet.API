using Soluction4Fleet.API.Application.DTOs;
using Soluction4Fleet.API.Application.Responses;

namespace Soluction4Fleet.API.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<ApiResponse<LoginFleetResponse>> Authenticate(LoginFleetRequest request);
    }
}
