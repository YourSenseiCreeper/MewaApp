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
        public const string User11 = "user11";
        public const string User12 = "user12";
        public const string User13 = "user13";
        public const string Teriyaki = "TeriyakiGod";
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
                CreateSingleUser(UserSeederNames.User10, "user10@gmail.com"),
                CreateSingleUser(UserSeederNames.Teriyaki,"teriyaki@mewaapp.pl")
            );

            var newGroup = new List<Group>
            {
                new Group {RedirectURL = GroupSeederNames.User1Folder1},
                new Group {RedirectURL = GroupSeederNames.User1Folder2},
                new Group {RedirectURL = GroupSeederNames.User2Folder1},
                new Group {RedirectURL = GroupSeederNames.User2Folder2},
                new Group {RedirectURL = GroupSeederNames.User3Folder1},
                new Group {RedirectURL = GroupSeederNames.User3Folder2},
                new Group {RedirectURL = GroupSeederNames.User4Folder1},
                new Group {RedirectURL = GroupSeederNames.User4Folder2},
                new Group {RedirectURL = GroupSeederNames.User5Folder1},
                new Group {RedirectURL = GroupSeederNames.User5Folder2},
                new Group {RedirectURL = GroupSeederNames.User6Folder1},
                new Group {RedirectURL = GroupSeederNames.User6Folder2},
                new Group {RedirectURL = GroupSeederNames.User7Folder1},
                new Group {RedirectURL = GroupSeederNames.User7Folder2},
                new Group {RedirectURL = GroupSeederNames.User8Folder1},
                new Group {RedirectURL = GroupSeederNames.User8Folder2},
                new Group {RedirectURL = GroupSeederNames.User9Folder1},
                new Group {RedirectURL = GroupSeederNames.User9Folder2},
                new Group {RedirectURL = GroupSeederNames.User10Folder1},
                new Group {RedirectURL = GroupSeederNames.User10Folder2},
                new Group {RedirectURL = GroupSeederNames.User11Folder1},
                new Group {RedirectURL = GroupSeederNames.User11Folder2},
                new Group {RedirectURL = GroupSeederNames.User12Folder1},
                new Group {RedirectURL = GroupSeederNames.User12Folder2},
                new Group {RedirectURL = GroupSeederNames.User13Folder1},
                new Group {RedirectURL = GroupSeederNames.User13Folder2},
                new Group {RedirectURL = GroupSeederNames.User14Folder1},
                new Group {RedirectURL = GroupSeederNames.User14Folder2},
                new Group {RedirectURL = GroupSeederNames.User15Folder1},
                new Group {RedirectURL = GroupSeederNames.User15Folder2}
            };
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

    public class GroupSeederNames
        {
            public const string User1Folder1 = "grupa 1, folder 1";
            public const string User1Folder2 = "grupa 1, folder 2";
            public const string User2Folder1 = "grupa 2, folder 1";
            public const string User2Folder2 = "grupa 2, folder 2";
            public const string User3Folder1 = "grupa 3, folder 1";
            public const string User3Folder2 = "grupa 3, folder 2";
            public const string User4Folder1 = "grupa 4, folder 1";
            public const string User4Folder2 = "grupa 4, folder 2";
            public const string User5Folder1 = "grupa 5, folder 1";
            public const string User5Folder2 = "grupa 5, folder 2";
            public const string User6Folder1 = "grupa 6, folder 1";
            public const string User6Folder2 = "grupa 6, folder 2";
            public const string User7Folder1 = "grupa 7, folder 1";
            public const string User7Folder2 = "grupa 7, folder 2";
            public const string User8Folder1 = "grupa 8, folder 1";
            public const string User8Folder2 = "grupa 8, folder 2";
            public const string User9Folder1 = "grupa 9, folder 1";
            public const string User9Folder2 = "grupa 9, folder 2";
            public const string User10Folder1 = "grupa 10, folder 1";
            public const string User10Folder2 = "grupa 10, folder 2";
            public const string User11Folder1 = "grupa 11, folder 1";
            public const string User11Folder2 = "grupa 11, folder 2";
            public const string User12Folder1 = "grupa 12, folder 1";
            public const string User12Folder2 = "grupa 12, folder 2";
            public const string User13Folder1 = "grupa 13, folder 1";
            public const string User13Folder2 = "grupa 13, folder 2";
            public const string User14Folder1 = "grupa 14, folder 1";
            public const string User14Folder2 = "grupa 14, folder 2";
            public const string User15Folder1 = "grupa 15, folder 1";
            public const string User15Folder2 = "grupa 15, folder 2";

        }
}
