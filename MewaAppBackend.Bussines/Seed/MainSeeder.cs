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

            var userSeeder = new UserSeeder(userManager);
            await userSeeder.Seed();

            // TAGS
            await TagsSeeder.Seed(context);

            var linkSeeder = new LinkSeeder(context);
            await linkSeeder.Seed();

            //await SeedGroupsAsync(context);
            await context.SaveChangesAsync();

        }

        private static async Task SeedGroupsAsync(Context context)
        {
            var groups = await context.Group.ToListAsync();
        }
    }
}
