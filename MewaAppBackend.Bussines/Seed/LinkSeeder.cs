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
                    CreateSingleLink("Link do youtube", "https://youtube.com", UserSeederNames.User1,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Youtube}),
                    CreateSingleLink("Link do Facebook'a", "https://www.facebook.com/", UserSeederNames.User2,new[] {GroupSeederNames.User2Folder1}, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Link do Politechniki", "https://tu.koszalin.pl/" , UserSeederNames.User3,new[] {GroupSeederNames.User3Folder1}, new[]{TagsSeederNames.Politechnika}),
                    CreateSingleLink("Link do WEII PK", "https://weii.tu.koszalin.pl/" , UserSeederNames.User4,new[] {GroupSeederNames.User4Folder1}, new[]{TagsSeederNames.Politechnika}),
                    CreateSingleLink("Link do WNE PK", "https://tu.koszalin.pl/wne" , UserSeederNames.User1,new[] {GroupSeederNames.User1Folder2}, new[]{TagsSeederNames.Politechnika}),
                    CreateSingleLink("Link do Allegro", "https://allegro.pl" , UserSeederNames.User2, new[] {GroupSeederNames.User2Folder2},new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Link do Wykopu", "https://www.wykop.pl" , UserSeederNames.User3,new[] {GroupSeederNames.User3Folder2}, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Link do Tik Tok'a", "https://www.tiktok.com" , UserSeederNames.User4, new[] {GroupSeederNames.User4Folder2},new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Link do przepisu na makowca", "https://www.domowe-wypieki.pl/przepisy/ciasta/109-makowiec-zawijany" , UserSeederNames.User11, new[] {GroupSeederNames.User11Folder1},new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Link do przepisu na spaghetti", "https://www.kuchnia-domowa.pl/przepisy/dania-glowne/202-spaghetti-bolognese" , UserSeederNames.User11, new[] {GroupSeederNames.User11Folder2},new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Przepis na bigos", "https://aniagotuje.pl/przepis/bigos", UserSeederNames.User12,new[] {GroupSeederNames.User12Folder1}, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Sklep akwarystyczny", "https://www.akwarystyczny24.pl/" , UserSeederNames.User12,new[] {GroupSeederNames.User12Folder2}, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Przepis na ryż z jabłkami", "https://www.kwestiasmaku.com/przepis/ryz-zapiekany-z-jablkami" , UserSeederNames.User13, new[] {GroupSeederNames.User13Folder1},new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Przepis na pomidorową", "https://aniagotuje.pl/przepis/zupa-pomidorowa" , UserSeederNames.User13,new[] {GroupSeederNames.User13Folder2}, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Jak ugotować parówki", "https://www.youtube.com/watch?v=n4j-ztIeB5w&ab_channel=PrymitywnaKuchnia.pl", UserSeederNames.User10, new[] {GroupSeederNames.User10Folder2},new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink("Gra bomberman", "https://www.wyspagier.pl/bomb-it-4.htm" , UserSeederNames.User10, new[] {GroupSeederNames.User10Folder1},new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Szachy", "https://chess.com/" , UserSeederNames.User9, new[] {GroupSeederNames.User9Folder1},new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Warcaby", "https://www.kurnik.pl/warcaby/", UserSeederNames.User8, new[] {GroupSeederNames.User8Folder2},new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink("Empik", "https://empik.com/", UserSeederNames.User8,new[] {GroupSeederNames.User8Folder1}, new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink("Link do Netflix'a", "https://netflix.com", UserSeederNames.User7, new[] {GroupSeederNames.User7Folder2},new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink("Link do MediaExpert", "https://www.mediaexpert.pl/" , UserSeederNames.User7,new[] {GroupSeederNames.User7Folder1}, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Link do strony koła .NET", "https://www.facebook.com/grupadotnetpk/" , UserSeederNames.User6,new[] {GroupSeederNames.User6Folder2}, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Link do poczty gmail", "https://gmail.com", UserSeederNames.User6, new[] {GroupSeederNames.User6Folder1},new[] {TagsSeederNames.Przepisy}),
                    CreateSingleLink("Link do Usos", "https://usosweb.tu.koszalin.pl", UserSeederNames.User5, new[] {GroupSeederNames.User5Folder2},new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink("Link do Amazon'u", "https://amazon.com", UserSeederNames.User5, new[] {GroupSeederNames.User5Folder1},new[]{TagsSeederNames.Przepisy} )
                };
                await _context.Link.AddRangeAsync(newLinks);
            }

        }
        private Link CreateSingleLink(string name, string url, string userName, string[] groupFolder, string[] tagName)
        {
            //var tag = (Tag)(from item in _context.Tag where item.Name.Equals(tagName) select item);
            var user = _context.Users.First(u => u.UserName == userName);
            var tags = _context.Tag.Where(t => tagName.Contains(t.Name)).ToList();
            var link = new Link { Name = name, Url = url, Tags = tags, Owner = user};
            return link;
        }
    }
}
