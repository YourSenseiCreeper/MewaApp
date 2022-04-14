using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MewaAppBackend.Business.Seed
{
    public class MainSeeder
    {
        public static async Task Seed(IServiceProvider service)
        {
            var context = service.GetRequiredService<Context>();
            var userManager = service.GetRequiredService<UserManager<User>>();

            var adminUser = await SeedUsersAsync(userManager);
            await context.SaveChangesAsync();

            //await SeedImagesAsync(context);
            await SeedTagsAsync(context, adminUser);
            await context.SaveChangesAsync();

            await SeedLinksAsync(context, adminUser);
            //await SeedGroupsAsync(context);
            await context.SaveChangesAsync();
        }

        private static async Task<User> SeedUsersAsync(UserManager<User> userManager)
        {
            var adminUser = await userManager.FindByNameAsync("admin");
            if (adminUser == null)
            {
                adminUser = new User { UserName = "admin", Email = "admin@mewaapp.pl", EmailConfirmed = true };
                await userManager.CreateAsync(adminUser, "123qwe");

                if (adminUser == null)
                {
                    throw new Exception("The password is probably not strong enough!");
                }
            }

            return adminUser;
        }

        private static async Task SeedImagesAsync(Context context)
        {
            var images = await context.File.ToListAsync();
        }

        private static async Task SeedLinksAsync(Context context, User user)
        {
            var existingLinks = await context.Link.ToListAsync();
            if (existingLinks.Count == 0)
            {
                var tags = await context.Tag.ToListAsync();
                var youTubeTag = tags.First(t => t.Name == "YouTube");
                var twitterTag = tags.First(t => t.Name == "Twitter");
                var politechnikaTag = tags.First(t => t.Name == "Politechnika");

                var newLinks = new List<Link>
                {
                    new Link { Name = "Link do YouTube", Url = "https://youtube.com", OwnerId = user.Id, Tags = new List<Tag> { youTubeTag } },
                    new Link { Name = "Link do Twittera", Url = "https://twitter.com", OwnerId = user.Id, Tags = new List<Tag> { twitterTag } },
                    new Link { Name = "Link do materiałów ze studiów", Url = "https://dropbox.com", OwnerId = user.Id, Tags = new List<Tag> { politechnikaTag } }
                };
                await context.Link.AddRangeAsync(newLinks);
            }
        }

        private static async Task SeedTagsAsync(Context context, User user)
        {
            var existingTags = await context.Tag.ToListAsync();
            if (existingTags.Count == 0)
            {
                var newTags = new List<Tag>
                {
                    new Tag { Name = "YouTube", Description = "Związane z YouTube", UserId = user.Id },
                    new Tag { Name = "Twitter", Description = "Związane z Twitterem", UserId = user.Id},
                    new Tag { Name = "Politechnika", Description = "Związane z politechniką", UserId = user.Id}
                };
                await context.Tag.AddRangeAsync(newTags);
            }
        }

        private static async Task SeedGroupsAsync(Context context)
        {
            var groups = await context.Group.ToListAsync();
        }
    }
}
