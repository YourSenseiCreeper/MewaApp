namespace MewaAppBackend.Business.Business
{
    public interface IBusinessFactory
    {
        GroupBusiness GroupBusiness { get; }

        void SaveChanges();
    }
}