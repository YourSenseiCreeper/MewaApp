using MewaAppBackend.Model.Dtos.Tag;

namespace MewaAppBackend.Model.Dtos.Link
{
    public class AddLinkToGroupDto
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int GroupId { get; set; }
    }
}
