using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Application.Interfaces.Services
{
    public interface ITokenService
    {
        string GerarToken(Usuario usuario);
    }
}
