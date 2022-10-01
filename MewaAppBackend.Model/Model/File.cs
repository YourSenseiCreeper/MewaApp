using MewaAppBackend.Model.Enum;

namespace MewaAppBackend.Model.Model
{

    public class File: Entity
    {
        public string ServerPath { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public FileType Type { get; set; }
        public Link Link { get; set; }
        public int? LinkId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
