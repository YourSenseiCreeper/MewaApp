using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MewaAppBackend.Business.Seed
{
    public class LinkSeederNames
    {
        public const string youtubeLink = "Link do YouTube";
        public const string fbLink = "Link do Facebooka";


    }
    public class LinkSeeder
    {
        private readonly Context _context;

        public LinkSeeder(Context context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            var existingLinks = await _context.Link.ToListAsync();
            if (existingLinks.Count == 0)
            {
                var newLinks = new List<Link>
                {
                    CreateSingleLink("Link do YouTube", "https://youtube.com", UserSeederNames.User1, new[]{TagsSeederNames.Youtube}),
                    CreateSingleLink("Link do Facebooka", "https://www.facebook.com/", UserSeederNames.User2, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Link do Politechniki", "https://tu.koszalin.pl/" , UserSeederNames.User3, new[]{TagsSeederNames.Politechnika}),
                    CreateSingleLink("Link do WEII PK", "https://weii.tu.koszalin.pl/" , UserSeederNames.User4, new[]{TagsSeederNames.Politechnika}),
                    CreateSingleLink("Link do WNE PK", "https://tu.koszalin.pl/wne" , UserSeederNames.User1, new[]{TagsSeederNames.Politechnika}),
                    CreateSingleLink("Allegro", "https://allegro.pl" , UserSeederNames.User2, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Wykop", "https://www.wykop.pl" , UserSeederNames.User3, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("TikTok", "https://www.tiktok.com" , UserSeederNames.User4, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Przepis na maowiec", "https://www.domowe-wypieki.pl/przepisy/ciasta/109-makowiec-zawijany" , UserSeederNames.User2, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Przepis na spaghetti", "https://www.kuchnia-domowa.pl/przepisy/dania-glowne/202-spaghetti-bolognese" , UserSeederNames.User1, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Przepis na bigos", "https://aniagotuje.pl/przepis/bigos", UserSeederNames.User3, new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink("Sklep akwarystyczny", "https://www.akwarystyczny24.pl/" , UserSeederNames.User3, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Przepis na ryż z jabłkami", "https://www.kwestiasmaku.com/przepis/ryz-zapiekany-z-jablkami" , UserSeederNames.User1, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Przepis na pomidorową", "https://aniagotuje.pl/przepis/zupa-pomidorowa" , UserSeederNames.User1, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Jak ugotować parówki", "https://www.youtube.com/watch?v=n4j-ztIeB5w&ab_channel=PrymitywnaKuchnia.pl", UserSeederNames.User1, new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink("Gra bomberman", "https://www.wyspagier.pl/bomb-it-4.htm" , UserSeederNames.User4, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Szachy", "https://chess.com" , UserSeederNames.User1, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Warcaby", "https://www.kurnik.pl/warcaby/", UserSeederNames.User3, new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink("Empik", "https://empik.com", UserSeederNames.User2, new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink("Netflix", "https://netflix.com", UserSeederNames.User1, new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink("MediaExpert", "https://www.mediaexpert.pl/" , UserSeederNames.User2, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Strona koła .NET", "https://www.facebook.com/grupadotnetpk/" , UserSeederNames.User4, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Poczta", "https://gmail.com", UserSeederNames.User3, new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink("Usos", "https://usosweb.tu.koszalin.pl", UserSeederNames.User2, new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink("Amazon", "https://amazon.com", UserSeederNames.User4, new[]{TagsSeederNames.Przepisy} )

                };
                await _context.Link.AddRangeAsync(newLinks);
            }

        }
        private Link CreateSingleLink(string name, string url, string userName, string[] tagName)
        {
            //var tag = (Tag)(from item in _context.Tag where item.Name.Equals(tagName) select item);
            var user = _context.Users.First(u => u.UserName == userName);
            var tags = _context.Tag.Where(t => tagName.Contains(t.Name)).ToList();
            var link = new Link { Name = name, Url = url, Tags = tags, Owner = user};
            return link;
        }
    }
}
