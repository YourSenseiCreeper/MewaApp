namespace MewaAppBackend.Model.Dtos.Group
{
    public class CreateGroupDto
    {
        public string Name { get; set; }
        public int ParentGroupId { get; set; }
    }
}
