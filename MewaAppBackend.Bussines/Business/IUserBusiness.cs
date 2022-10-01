namespace MewaAppBackend.Business.Business
{
    public interface IUserBusiness
    {
        bool IsEmailUsed(string email);
        bool IsUserNameUsed(string userName);
    }
}