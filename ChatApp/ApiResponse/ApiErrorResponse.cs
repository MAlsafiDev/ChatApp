namespace ChatApp.Api.ApiResponse
{
    public class ApiErrorResponse
    {
        public bool Succeeded { get; set; } = false;

        public string Message { get; set; } = string.Empty;

        public List<string>? Errors { get; set; }

        public string? Details { get; set; }
    }
}
