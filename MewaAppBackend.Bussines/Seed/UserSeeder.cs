using MewaAppBackend.Model.Model;
using Microsoft.AspNetCore.Identity;

namespace MewaAppBackend.Business.Seed
{
    public class UserSeederNames
    {
        public const string AdminUser = "admin";
        public const string User1 = "user1";
        public const string User2 = "user2";
        public const string User3 = "user3";
        public const string User4 = "user4";
        public const string User5 = "user5";
        public const string User6 = "user6";
        public const string User7 = "user7";
        public const string User8 = "user8";
        public const string User9 = "user9";
        public const string User10 = "user10";
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
                CreateSingleUser(UserSeederNames.User1, "user1@gmail.com"),
                CreateSingleUser(UserSeederNames.User2, "user2@gmail.com"),
                CreateSingleUser(UserSeederNames.User3, "user3@gmail.com"),
                CreateSingleUser(UserSeederNames.User4, "user4@gmail.com"),
                CreateSingleUser(UserSeederNames.User5, "user5@gmail.com"),
                CreateSingleUser(UserSeederNames.User6, "user6@gmail.com"),
                CreateSingleUser(UserSeederNames.User7, "user7@gmail.com"),
                CreateSingleUser(UserSeederNames.User8, "user8@gmail.com"),
                CreateSingleUser(UserSeederNames.User9, "user9@gmail.com"),
                CreateSingleUser(UserSeederNames.User10, "user10@gmail.com")
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
