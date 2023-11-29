namespace DaneshkarShop.Domain.IRepositories
{
    public interface IUserRepository
    {
        bool IsExistUserByMobile(string mobile);
    }
}
