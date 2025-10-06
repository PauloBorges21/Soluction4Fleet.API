namespace Soluction4Fleet.API.Application.Interfaces.Services
{
    public interface ISecurityService
    {
        Task<string> EncryptAsync(string plainText);
        Task<string> DecryptAsync(string cipherText);
        Task<T> DecryptObjectMulti<T>(T obj);
        Task<T> EncryptObjectMulti<T>(T obj);
    }
}
