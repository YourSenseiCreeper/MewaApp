namespace MewaAppBackend.Model.Model
{
    public class DbImage : Entity
    {
        public Link Link { get; set; }
        public int LinkId { get; set; }
        public string Content { get; set; }
    }
}
