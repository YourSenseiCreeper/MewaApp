using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi;
using Microsoft.EntityFrameworkCore;

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
                    CreateSingleLink("Link do Amazon'u", "https://amazon.com", UserSeederNames.User5, new[] {GroupSeederNames.User5Folder1},new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink("Visual studio 2022 pobieranie", "https://visualstudio.microsoft.com/pl/vs/community/", UserSeederNames.User1,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Programowanie}),
                    CreateSingleLink("VS Code pobieranie", "https://code.visualstudio.com/download", UserSeederNames.User2,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Programowanie}),
                    CreateSingleLink("Java pobieranie", "https://java.com/pl/download/manual.jsp" , UserSeederNames.User3,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Programowanie}),
                    CreateSingleLink("Eclipse pobieranie", "https://www.eclipse.org/downloads/" , UserSeederNames.User4,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Programowanie}),
                    CreateSingleLink("Debian 10 pobieranie", "https://www.debian.org/CD/http-ftp/" , UserSeederNames.User1,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Programowanie}),
                    CreateSingleLink("Arduino IDE download", "https://www.arduino.cc/en/software" , UserSeederNames.User2,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Programowanie}),
                    CreateSingleLink("Sklep z elektroniką", "https://botland.com.pl/" , UserSeederNames.User3,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Strona MSI", "https://pl.msi.com/" , UserSeederNames.User4,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("intel", "https://www.intel.com/content/www/us/en/homepage.html" , UserSeederNames.User2,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Programowanie}),
                    CreateSingleLink("Wikipedia SaMBy", "https://wiki.samba.org/index.php/Main_Page" , UserSeederNames.User1,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Programowanie}),
                    CreateSingleLink("Unity do pobrania", "https://unity3d.com/get-unity/download", UserSeederNames.User3,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink("nauka unity", "https://learn.unity.com/" , UserSeederNames.User3,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("C# .NET tutorials", "https://www.youtube.com/watch?v=gfkTfcpWqAY&list=PLTjRvDozrdlz3_FPXwb6lX_HoGXa09Yef&ab_channel=ProgrammingwithMosh" , UserSeederNames.User1,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink(".NET 6.0 download", "https://dotnet.microsoft.com/en-us/download/dotnet/6.0" , UserSeederNames.User1,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("MCDonald", "https://mcdonalds.pl/", UserSeederNames.User1,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink("KFC", "https://kfc.pl/" , UserSeederNames.User4,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Termometr Arduino", "https://botland.com.pl/czujniki-temperatury/376-czujnik-temperatury-lm35dz-ns-analogowy-tht-5904422362508.html" , UserSeederNames.User1,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Programowanie}),
                    CreateSingleLink("Czujnik ruchu arduino", "https://botland.com.pl/czujniki-ruchu/1655-czujnik-ruchu-pir-hc-sr501-zielony-5903351241359.html", UserSeederNames.User3,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink("Arduino StarterKit", "https://botland.com.pl/zestawy-startowe-dla-arduino/3798-starterkit-rozszerzony-z-modulem-arduino-uno-box-5903351240192.html", UserSeederNames.User2,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink("Płytka z modułem WiFi", "https://botland.com.pl/moduly-wifi-esp8266/8241-modul-wifi-esp8266-nodemcu-v3-5904422300630.html", UserSeederNames.User1,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink("Zajęcia z Javy", "https://cloud.weii.tu.koszalin.pl/s/j5TJaQ7D67caRBN?path=%2F" , UserSeederNames.User2,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Discord download", "https://discord.com/download" , UserSeederNames.User4,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Przepisy}),
                    CreateSingleLink("Steam", "https://store.steampowered.com/", UserSeederNames.User3,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink("Onet wiadomosci", "https://wiadomosci.onet.pl/", UserSeederNames.User2,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Przepisy} ),
                    CreateSingleLink("Pogoda", "https://pogoda.interia.pl/", UserSeederNames.User4,new[] {GroupSeederNames.User1Folder1}, new[]{TagsSeederNames.Przepisy} )
                };
                await _context.Link.AddRangeAsync(newLinks);
            }

        }
        private Link CreateSingleLink(string name, string url, string userName, string[] groupFolder, string[] tagName)
        {
            // Tutaj trzeba wyciągnąć te grupy i tak samo je odfiltrować i przypisać. Bez tego nasze dodawanie nie zadziała.
            var user = _context.Users.First(u => u.UserName == userName);
            var tags = _context.Tag.Where(t => tagName.Contains(t.Name)).ToList();
            var groups = _context.Group.Where(z => groupFolder.Contains(z.Name)).ToList();
            var link = new Link { Name = name, Url = url, Tags = tags, Owner = user, Groups = groups};
            return link;
        }
    }
}
// context to bazy danych
// Dbset odpowiednik tabeli w bazie dancyh
//  => dziala jak foreach
// encja jest reprezentacja obiektowa tego co jest w bazie danych