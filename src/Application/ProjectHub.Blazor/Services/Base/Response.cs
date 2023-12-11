namespace ProjectHub.Blazor.Services.Base
{
    public class Response<T>
    {
        public string? Title { get; set; }
        public string? DetailMessage { get; set; }
        public string? ValidationErrors { get; set; }
        public bool Success { get; set; }
        public T? Data { get; set; }
    }
}