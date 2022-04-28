using MewaAppBackend.Model.Model;
using Microsoft.AspNetCore.Identity;

namespace MewaAppBackend.Business.Seed
{
    public class UserSeederNames
    {
        public const string AdminUser = "admin";
    }

    public class UserSeeder
    {
        private readonly UserManager<User> _userManager;
        public UserSeeder(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task Seed()
        {
            await Task.WhenAll(
                CreateSingleUser(UserSeederNames.AdminUser, "admin@mewaapp.pl"),
                CreateSingleUser("asdf", "asdf@test.pl") // do zmiany
            );
        }

        private async Task CreateSingleUser(string username, string mail)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                user = new User { UserName = username, Email = mail, EmailConfirmed = true };
                await _userManager.CreateAsync(user, "123qwe");

                if (user == null)
                {
                    throw new Exception("The password is probably not strong enough!");
                }
            }
        }
    }
}
