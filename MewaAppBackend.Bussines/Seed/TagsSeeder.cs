using MewaAppBackend.Model.Model;
using Microsoft.AspNetCore.Identity;
using MewaAppBackend.WebApi;
using Microsoft.EntityFrameworkCore;


namespace MewaAppBackend.Business.Seed;

    
    public class TagsSeeder
    {
         public static async Task Seed(Context context, User user)
        {
            var existingTags = await context.Tag.ToListAsync();
            if (existingTags.Count == 0)
            {
                var newTags = new List<Tag>
                {
                    new Tag { Name = "Youtube" , Description = "Związane z YouTube", UserId = user.Id },
                    new Tag { Name = "Twitter", Description = "Związane z Twitterem", UserId = user.Id},
                    new Tag { Name = "Politechnika", Description = "Związane z politechniką", UserId = user.Id},
                    new Tag { Name = "Reddit", Description = "Związane z redditem", UserId = user.Id },
                    new Tag { Name = "Przepisy", Description = "Związane z przepisami", UserId = user.Id },
                    new Tag { Name = "Gotujmy", Description = "Związane z gotowaniem", UserId = user.Id },
                    new Tag { Name = "Allegro", Description = "Związane z zakupami", UserId = user.Id },
                    new Tag { Name = "Strims", Description = "Związane z oglądaniem meczy", UserId = user.Id },
                    new Tag { Name = "Instagram", Description = "Związane z instagramem", UserId = user.Id },
                    new Tag { Name = "Wykop", Description = "Związane z wykopem", UserId = user.Id },
                    new Tag { Name = "GoogleMaps", Description = "Związane z lokalizacją", UserId = user.Id },
                    new Tag { Name = "Tiktok", Description = "Związane z tik tokiem", UserId = user.Id },
                    new Tag { Name = "Przepisy", Description = "Związane z przepisami", UserId = user.Id },
                    new Tag { Name = "Twitch", Description = "Związane z Twitch'em", UserId = user.Id },
                    new Tag { Name = "Amazon", Description = "Związane z Amazon'em", UserId = user.Id },
                    new Tag { Name = "Wyspagier", Description = "Związane z Wyspagier", UserId = user.Id },
                    new Tag { Name = "Chomikuj", Description = "Związane z Chomikuj", UserId = user.Id },
                    new Tag { Name = "Przepisy", Description = "Związane z przepisami", UserId = user.Id },
                    new Tag { Name = "Spotify", Description = "Związane z Spotify", UserId = user.Id },
                    new Tag { Name = "Soundcloud", Description = "Związane z Soundcloud", UserId = user.Id },
                    new Tag { Name = "Plantpur", Description = "Związane z kalkulator snu", UserId = user.Id },
                    new Tag { Name = "Soundcloud", Description = "Związane z Soundcloud", UserId = user.Id },
                    new Tag { Name = "Withgoogle", Description = "Związane z kursami z Google'a", UserId = user.Id },
                    new Tag { Name = "Soundcloud", Description = "Związane z Soundcloud", UserId = user.Id },
                    new Tag { Name = "Linkedin", Description = "Związane z Linkedin'em", UserId = user.Id },
                    new Tag { Name = "Booking", Description = "Związane z Bookingiem", UserId = user.Id },
                    new Tag { Name = "Pinterest", Description = "Związane z Pinterestem", UserId = user.Id },
                    new Tag { Name = "Intercity", Description = "Związane z Intercity", UserId = user.Id },
                    new Tag { Name = "MediaExpert", Description = "Związane z MediaExpert", UserId = user.Id },
                    new Tag { Name = "MediaMarkt", Description = "Związane z MediaMarkt", UserId = user.Id },
                    new Tag { Name = "Libgen", Description = "Związane z e-book'ami", UserId = user.Id },
                    new Tag { Name = "Zooplus", Description = "Związane z rzeczami dla zwierząt", UserId = user.Id },
                    new Tag { Name = "Fabrykasily", Description = "Związane z treningiem", UserId = user.Id },
                    new Tag { Name = "Polki", Description = "Związane z plotkami", UserId = user.Id },
                    new Tag { Name = "Gazeta", Description = "Związane z gazetą", UserId = user.Id },

                };
                await context.Tag.AddRangeAsync(newTags);
            }
        }
    }

