using MewaAppBackend.Business.EntityFramework;
using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi;
using Microsoft.EntityFrameworkCore;


namespace MewaAppBackend.Business.Seed
{
    public class TagsSeederNames
    {
        public const string Youtube = "Youtube";
        public const string Twitter = "Twitter";
        public const string Politechnika = "Politechnika";
        public const string Reddit = "Reddit";
        public const string Gotujemy = "Gotujemy";
        public const string Allegro = "Allegro";
        public const string Strims = "Strims";
        public const string Instagram = "Instagram";
        public const string Wykop = "Wykop";
        public const string GoogleMaps = "GoogleMaps";
        public const string Tiktok = "Tiktok";
        public const string Przepisy = "Przepisy";
        public const string Twitch = "Twitch";
        public const string Amazon = "Amazon";
        public const string Wyspagier = "Wyspagier";
        public const string Chomikuj = "Chomikuj";
        public const string Spotify = "Spotify";
        public const string Soundcloud = "Soundcloud";
        public const string Plantpur = "Plantpur";
        public const string Withgoogle = "Withgoogle";
        public const string Booking = "Booking";
        public const string LinkedIn = "LinkedIn";
        public const string Pinterest = "Pinterest";
        public const string Intercity = "Intercity";
        public const string MediaExpert = "MediaExpert";
        public const string MediaMarkt = "MediaMarkt";
        public const string Libgen = "Libgen";
        public const string Zooplus = "Zooplus";
        public const string Fabrykasily = "Fabrykasily";
        public const string Polki = "Polki";
        public const string Gazeta = "Gazeta";
        public const string Skate = "Skate";
        public const string Funny = "Funny";
        public const string Lego = "Lego";
        public const string Programowanie = "Programowanie";
    }

    public class TagsSeeder
    {
        public static async Task Seed(Context context)
        {
            var user = context.Users.First(u => u.UserName == UserSeederNames.User1);
            var existingTags = await context.Tag.ToListAsync();
            if (existingTags.Count == 0)
            {
                var newTags = new List<Tag>
                {
                    new Tag { Name = TagsSeederNames.Youtube , Description = "Związane z YouTube", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Twitter, Description = "Związane z Twitterem", UserId = user.Id},
                    new Tag { Name = TagsSeederNames.Politechnika, Description = "Związane z politechniką", UserId = user.Id},
                    new Tag { Name = TagsSeederNames.Reddit, Description = "Związane z redditem", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Przepisy, Description = "Związane z przepisami", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Gotujemy, Description = "Związane z gotowaniem", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Allegro, Description = "Związane z zakupami", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Strims, Description = "Związane z oglądaniem meczy", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Instagram, Description = "Związane z instagramem", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Wykop, Description = "Związane z wykopem", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.GoogleMaps, Description = "Związane z lokalizacją", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Tiktok, Description = "Związane z tik tokiem", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Twitch, Description = "Związane z Twitch'em", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Amazon, Description = "Związane z Amazon'em", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Wyspagier, Description = "Związane z Wyspagier", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Chomikuj, Description = "Związane z Chomikuj", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Spotify, Description = "Związane z Spotify", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Soundcloud, Description = "Związane z Soundcloud", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Plantpur, Description = "Związane z kalkulator snu", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Withgoogle, Description = "Związane z kursami z Google'a", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.LinkedIn, Description = "Związane z Linkedin'em", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Booking, Description = "Związane z Bookingiem", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Pinterest, Description = "Związane z Pinterestem", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Intercity, Description = "Związane z Intercity", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.MediaExpert, Description = "Związane z MediaExpert", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.MediaMarkt, Description = "Związane z MediaMarkt", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Libgen, Description = "Związane z e-book'ami", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Zooplus, Description = "Związane z rzeczami dla zwierząt", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Fabrykasily, Description = "Związane z treningiem", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Polki, Description = "Związane z plotkami", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Gazeta, Description = "Związane z gazetą", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Skate, Description = "Związane z skate", UserId = user.Id },
                    new Tag { Name = TagsSeederNames.Funny, Description = "Śmieszne", UserId = user.Id},
                    new Tag { Name = TagsSeederNames.Lego, Description = "Lego", UserId = user.Id},
                    new Tag { Name = TagsSeederNames.Programowanie, Description = "Programowanie", UserId = user.Id},
                };
                await context.Tag.AddRangeAsync(newTags);
            }
        }
    }
}

