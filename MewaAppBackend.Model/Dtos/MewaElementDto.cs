namespace MewaAppBackend.Model.Dtos
{
    public class MewaElementDto
    {
        public int Id { get; set; }
        public bool IsFolder { get; set; }
        public string Name { get; set; }
        public string? Url { get; set; }
    }
}
