using MewaAppBackend.Business.Seed;

namespace MewaAppBackend.WebApi
{
    public static class AnotherSeedExtension
    {
        public static async Task RunSeeder(this WebApplication app, string[] args)
        {
            using (var scope = app.Services.CreateScope())
            {
                var seedArg = args.FirstOrDefault(a => a.Contains("seed"));
                var seed = seedArg != null ? bool.Parse(seedArg.Replace("--seed=", "")) : false;
                if (seed)
                {
                    var context = scope.ServiceProvider.GetRequiredService<Context>();
                    Console.WriteLine("Start seeding");
                    await MainSeeder.Seed(scope.ServiceProvider);
                }
            }
        }
    }
}
