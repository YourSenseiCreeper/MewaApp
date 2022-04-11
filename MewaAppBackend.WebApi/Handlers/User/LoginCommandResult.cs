namespace MewaAppBackend.WebApi.Handlers.User
{
    public class LoginCommandResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public string Token { get; set; }
    }
}
