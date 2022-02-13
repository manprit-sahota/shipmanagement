namespace Shipmanagement.API.Models
{
    /// <summary>
    /// Response class for generic API call
    /// </summary>
    public class ServiceReponseViewModel<T> : ServiceReponseViewModel
    {
        public T Data { get; set; }
    }

    /// <summary>
    /// Response class for every API call
    /// </summary>
    public class ServiceReponseViewModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
