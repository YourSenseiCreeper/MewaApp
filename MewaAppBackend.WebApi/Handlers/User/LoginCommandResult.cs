namespace MewaAppBackend.WebApi.Handlers.User
{
    public class LoginCommandResult : SuccessResult
    {
        public string Token { get; set; }
    }
}
