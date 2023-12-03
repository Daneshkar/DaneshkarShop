using DaneshkarShop.Domain.DTOs.SiteSode.Account;
using DaneshkarShop.Domain.Entitties.User;

namespace DaneshkarShop.Application.Services.Interface
{
    public interface IUserService
    {
        bool IsExistUserByMobile(string mobile);

        User FillUserEntity(UserRegisterDTO userDTO);

        void AddUser(User user);

        bool RegisterUser(UserRegisterDTO userDTO);

        User? GetUserByMobile(string mobile);
    }
}
