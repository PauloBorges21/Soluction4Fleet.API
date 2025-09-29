namespace Soluction4Fleet.API.Application.Responses
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
     

        public ApiResponse(T data, string message = "", bool success = true)
        {            
            Data = data;
            Success = success;
            Message = message;
        }
    }
}
