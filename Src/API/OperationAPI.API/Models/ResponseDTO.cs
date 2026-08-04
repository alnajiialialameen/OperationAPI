namespace OperationAPI.API.Models
{
    public class ResponseDTO<T>
    {
        public string status { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public T? data { get; set; }
    }
}
