using Soluction4Fleet.API.Application.Responses;

namespace Soluction4Fleet.API.Application.DTOs
{
    public static class ApiResponseFactory
    {
        public static ApiResponse<T> Success<T>(T data, string message = "")
        {
            return new ApiResponse<T>(data, message, true);
        }

        public static ApiResponse<T> Fail<T>(string message)
        {
            return new ApiResponse<T>(default(T), message, false);
        }
    }
}
