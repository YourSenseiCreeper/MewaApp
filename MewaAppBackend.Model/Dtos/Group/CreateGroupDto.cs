namespace MewaAppBackend.Model.Dtos.Group
{
    public class CreateGroupDto
    {
        public string RedirectURL { get; set; }
        public string Name { get; set; }
        public bool IsFolder { get; set; }
        public bool IsPersonal { get; set; }
    }
}
