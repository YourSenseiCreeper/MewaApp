namespace MewaAppBackend.Business.Business
{
    public interface IBusinessFactory
    {
        IGroupBusiness GroupBusiness { get; }
        ILinkBusiness LinkBusiness { get; }
        IUserBusiness UserBusiness { get; }

        void SaveChanges();
    }
}