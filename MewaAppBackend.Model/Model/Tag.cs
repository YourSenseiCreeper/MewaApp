namespace MewaAppBackend.Model.Model
{
    public class Tag: Entity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
