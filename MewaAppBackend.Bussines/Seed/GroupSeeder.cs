using MewaAppBackend.Model.Model;
using Microsoft.AspNetCore.Identity;
using MewaAppBackend.WebApi;
using Microsoft.EntityFrameworkCore;

namespace MewaAppBackend.Business.Seed
{
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
    public class GroupSeeder
    {        
        public static async Task Seed(Context context)
        {
            var existingGroups= await context.Group.ToListAsync();
            if (existingGroups.Count == 0)
            {
                var newGroup = new List<Group>
                {
                    new Group {Name = GroupSeederNames.User1Folder1},
                    new Group {Name = GroupSeederNames.User1Folder2},
                    new Group {Name = GroupSeederNames.User2Folder1},
                    new Group {Name = GroupSeederNames.User2Folder2},
                    new Group {Name = GroupSeederNames.User3Folder1},
                    new Group {Name = GroupSeederNames.User3Folder2},
                    new Group {Name = GroupSeederNames.User4Folder1},
                    new Group {Name = GroupSeederNames.User4Folder2},
                    new Group {Name = GroupSeederNames.User5Folder1},
                    new Group {Name = GroupSeederNames.User5Folder2},
                    new Group {Name = GroupSeederNames.User6Folder1},
                    new Group {Name = GroupSeederNames.User6Folder2},
                    new Group {Name = GroupSeederNames.User7Folder1},
                    new Group {Name = GroupSeederNames.User7Folder2},
                    new Group {Name = GroupSeederNames.User8Folder1},
                    new Group {Name = GroupSeederNames.User8Folder2},
                    new Group {Name = GroupSeederNames.User9Folder1},
                    new Group {Name = GroupSeederNames.User9Folder2},
                    new Group {Name = GroupSeederNames.User10Folder1},
                    new Group {Name = GroupSeederNames.User10Folder2},
                    new Group {Name = GroupSeederNames.User11Folder1},
                    new Group {Name = GroupSeederNames.User11Folder2},
                    new Group {Name = GroupSeederNames.User12Folder1},
                    new Group {Name = GroupSeederNames.User12Folder2},
                    new Group {Name = GroupSeederNames.User13Folder1},
                    new Group {Name = GroupSeederNames.User13Folder2},
                    new Group {Name = GroupSeederNames.User14Folder1},
                    new Group {Name = GroupSeederNames.User14Folder2},
                    new Group {Name = GroupSeederNames.User15Folder1},
                    new Group {Name = GroupSeederNames.User15Folder2}
                };
                await context.Group.AddRangeAsync(newGroup);
            }
        }
    }
}
