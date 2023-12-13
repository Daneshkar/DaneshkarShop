using DaneshkarShop.Domain.Entitties.User;
namespace DaneshkarShop.Domain.IRepositories;

public interface IUserRepository
{
    #region General Methods

    bool IsExistUserByMobile(string mobile);

    void AddUser(User user);

    void SaveChange();

    User? GetUserByMobile(string mobile);

    User? GetUserById(int userId);

    #endregion

    #region Admin Side Methods 

    List<User> ListOfUsers();

    #endregion
}
