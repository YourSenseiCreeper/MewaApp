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
        public const string politechnikaLink = "Link do Politechniki";
        public const string weiipkLink = "Link do WEII PK";
        public const string wnepkLink = "Link do WNE PK";
        public const string allegroLink = "Link do Allegro";
        public const string wykopLink = "Link do Wykopu";
        public const string tiktokLink = "Link do Tik Tok'a";
        public const string makowiecLink = "Link do przepisu na makowca";
        public const string spaghettiLink = "Link do przepisu na spaghetti";
        public const string netflixLink = "Link do Netflix'a";
        public const string mediaexpertLink = "Link do MediaExpert";
        public const string dotnetLink = "Link do strony koła .NET";
        public const string pocztaLink = "Link do poczty";
        public const string usosLink = "Link do Usos";
        public const string amazonLink = "Link do Amazon'u";
        public const string Bigos = "Przepis na bigos";
        public const string Akwarium = "Sklep akwarystyczny";
        public const string Ryz = "Przepis na ryż z jabłkami";
        public const string Pomidorowa = "Przepis na pomidorową";
        public const string Parowki = "Jak ugotować parówki";
        public const string Bomberman = "Gra bomberman";
        public const string Szachy = "Szachy";
        public const string Warcaby = "Warcaby";
        public const string Empik = "Empik";

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
                    CreateSingleLink(LinkSeederNames.youtubeLink, "https://youtube.com", UserSeederNames.User1, new[]{TagsSeederNames.Youtube}),
                    CreateSingleLink(LinkSeederNames.fbLink, "https://www.facebook.com/", UserSeederNames.User2, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink(LinkSeederNames.politechnikaLink, "https://tu.koszalin.pl/" , UserSeederNames.User3, new[]{TagsSeederNames.Politechnika}),
                    CreateSingleLink(LinkSeederNames.weiipkLink, "https://weii.tu.koszalin.pl/" , UserSeederNames.User4, new[]{TagsSeederNames.Politechnika}),
                    CreateSingleLink(LinkSeederNames.wnepkLink, "https://tu.koszalin.pl/wne" , UserSeederNames.User1, new[]{TagsSeederNames.Politechnika}),
                    CreateSingleLink(LinkSeederNames.allegroLink, "https://allegro.pl" , UserSeederNames.User2, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink(LinkSeederNames.wykopLink, "https://www.wykop.pl" , UserSeederNames.User3, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink(LinkSeederNames.tiktokLink, "https://www.tiktok.com" , UserSeederNames.User4, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink(LinkSeederNames.makowiecLink, "https://www.domowe-wypieki.pl/przepisy/ciasta/109-makowiec-zawijany" , UserSeederNames.User2, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink(LinkSeederNames.spaghettiLink, "https://www.kuchnia-domowa.pl/przepisy/dania-glowne/202-spaghetti-bolognese" , UserSeederNames.User1, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink(LinkSeederNames.Bigos, "https://aniagotuje.pl/przepis/bigos", UserSeederNames.User3, new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink(LinkSeederNames.Akwarium, "https://www.akwarystyczny24.pl/" , UserSeederNames.User3, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink(LinkSeederNames.Ryz, "https://www.kwestiasmaku.com/przepis/ryz-zapiekany-z-jablkami" , UserSeederNames.User1, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink(LinkSeederNames.Pomidorowa, "https://aniagotuje.pl/przepis/zupa-pomidorowa" , UserSeederNames.User1, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink(LinkSeederNames.Parowki, "https://www.youtube.com/watch?v=n4j-ztIeB5w&ab_channel=PrymitywnaKuchnia.pl", UserSeederNames.User1, new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink(LinkSeederNames.Bomberman, "https://www.wyspagier.pl/bomb-it-4.htm" , UserSeederNames.User4, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink(LinkSeederNames.Szachy, "https://chess.com/" , UserSeederNames.User1, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink(LinkSeederNames.Warcaby, "https://www.kurnik.pl/warcaby/", UserSeederNames.User3, new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink(LinkSeederNames.Empik, "https://empik.com/", UserSeederNames.User2, new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink(LinkSeederNames.netflixLink, "https://netflix.com", UserSeederNames.User1, new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink(LinkSeederNames.mediaexpertLink, "https://www.mediaexpert.pl/" , UserSeederNames.User2, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink(LinkSeederNames.dotnetLink, "https://www.facebook.com/grupadotnetpk/" , UserSeederNames.User4, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink(LinkSeederNames.pocztaLink, "https://gmail.com", UserSeederNames.User3, new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink(LinkSeederNames.usosLink, "https://usosweb.tu.koszalin.pl", UserSeederNames.User2, new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink(LinkSeederNames.amazonLink, "https://amazon.com", UserSeederNames.User4, new[]{TagsSeederNames.Przepisy} )

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
