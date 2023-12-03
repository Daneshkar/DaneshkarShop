using DaneshkarShop.Domain.Entitties.User;

namespace DaneshkarShop.Domain.IRepositories
{
    public interface IUserRepository
    {
        bool IsExistUserByMobile(string mobile);

        void AddUser(User user);

        void SaveChange();

        User? GetUserByMobile(string mobile);
    }
}
