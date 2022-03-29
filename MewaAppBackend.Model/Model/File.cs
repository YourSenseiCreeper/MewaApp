namespace MewaAppBackend.Model.Model
{
    public enum Type
    {
        A,
        B,
        C
    }

    public class File
    {
        public int Id { get; set; }
        public int LinkId { get; set; }
        public Guid UserId { get; set; }
        public string ServerPath { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public Type Type { get; set; }

        public Link Link { get; set; }
        public User User { get; set; }
    }
}
