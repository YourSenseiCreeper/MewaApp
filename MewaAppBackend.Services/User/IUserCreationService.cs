using Microsoft.AspNetCore.Identity;

namespace MewaAppBackend.Services.User
{
    public interface IUserCreationService
    {
        Task<string?> HandleLogin(string email, string password);
        IdentityResult? HandleRegister(Model.Model.User user, string password);
    }
}