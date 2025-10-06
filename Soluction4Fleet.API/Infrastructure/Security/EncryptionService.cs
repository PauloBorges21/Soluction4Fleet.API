using Microsoft.Extensions.Options;
using Soluction4Fleet.API.Application.Interfaces.Services;
using Soluction4Fleet.API.Infrastructure.Configurations;
using System.Reflection;
using System.Security.Cryptography;

namespace Soluction4Fleet.API.Infrastructure.Security
{
    public class EncryptionService : ISecurityService
    {
        private readonly byte[] _key;
        private readonly byte[] _iv;

        public EncryptionService(IOptions<CryptoSettings> cryptoOptions)
        {
            var settings = cryptoOptions.Value;
            _key = Convert.FromBase64String(settings.Key);
            _iv = Convert.FromBase64String(settings.IV);
        }

        public async Task<string> EncryptAsync(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _key;
                aesAlg.IV = _iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public async Task<string> DecryptAsync(string cipherText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _key;
                aesAlg.IV = _iv;

                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (var msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Ler o conteúdo descriptografado de forma assíncrona
                            string decryptedText = await srDecrypt.ReadToEndAsync();

                            // Garantir que o texto retornado esteja limpo
                            return decryptedText.Trim('"').Replace("\\", "");
                        }
                    }
                }
            }
        }

        public async Task<T> DecryptObjectMulti<T>(T obj)
        {
            try
            {
                if (obj == null) return default;

                foreach (var property in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {

                    // Ignora a propriedade "TokenLandPage"
                    if (property.Name == "TokenLandPage")
                        continue;

                    // Ignora DateTime com valor padrão (01/01/0001) e outros tipos que não precisam de descriptografia
                    if ((property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?)) &&
                        (DateTime?)property.GetValue(obj) == DateTime.MinValue)
                    {
                        continue;
                    }

                    // Verifica se é uma string e aplica descriptografia
                    if (property.PropertyType == typeof(string) && property.CanRead && property.CanWrite)
                    {
                        var currentValue = (string)property.GetValue(obj);
                        if (!string.IsNullOrEmpty(currentValue))
                        {
                            var decryptedValue = await DecryptAsync(currentValue);
                            property.SetValue(obj, decryptedValue);
                        }
                    }
                    // Se for um objeto complexo, chama o método recursivamente
                    else if (!property.PropertyType.IsPrimitive && property.PropertyType != typeof(string) && property.CanRead)
                    {
                        var nestedObject = property.GetValue(obj);
                        if (nestedObject != null)
                        {
                            // Chamada recursiva para descriptografar objetos internos
                            await DecryptObjectMulti(nestedObject);
                        }
                    }
                }
                return obj;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> EncryptObjectMulti<T>(T obj)
        {
            try
            {
                if (obj == null) return default;

                foreach (var property in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {

                    // Ignora DateTime com valor padrão (01/01/0001) e outros tipos que não precisam de descriptografia
                    if ((property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?)) &&
                        (DateTime?)property.GetValue(obj) == DateTime.MinValue)
                    {
                        continue;
                    }

                    // Verifica se é uma string e aplica descriptografia
                    if (property.PropertyType == typeof(string) && property.CanRead && property.CanWrite)
                    {
                        var currentValue = (string)property.GetValue(obj);
                        if (!string.IsNullOrEmpty(currentValue))
                        {
                            var decryptedValue = await EncryptAsync(currentValue);
                            property.SetValue(obj, decryptedValue);
                        }
                    }
                    // Se for um objeto complexo, chama o método recursivamente
                    else if (!property.PropertyType.IsPrimitive && property.PropertyType != typeof(string) && property.CanRead)
                    {
                        var nestedObject = property.GetValue(obj);
                        if (nestedObject != null)
                        {
                            // Chamada recursiva para descriptografar objetos internos
                            await EncryptObjectMulti(nestedObject);
                        }
                    }
                }
                return obj;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
