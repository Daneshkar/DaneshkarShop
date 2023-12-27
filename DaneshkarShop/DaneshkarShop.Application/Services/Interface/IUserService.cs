using DaneshkarShop.Domain.DTOs.AdminSide.User;
using DaneshkarShop.Domain.DTOs.SiteSode.Account;
using DaneshkarShop.Domain.Entitties.User;

namespace DaneshkarShop.Application.Services.Interface
{
    public interface IUserService
    {
        #region General Methods

        bool IsExistUserByMobile(string mobile);

        User FillUserEntity(UserRegisterDTO userDTO);

        void AddUser(User user);

        bool RegisterUser(UserRegisterDTO userDTO);

        User? GetUserByMobile(string mobile);

        #endregion

        #region Admin Side Methods 

        #region Async Methods

        Task<EditUserAdminSideDTO?> FillEditUserAdminSideDTOAsync(int userId, CancellationToken cancellationToken);

        #endregion

        #region Sync Methods

        List<User> ListOfUsers();

        List<ListOfUsersDTO> listOfUsersWithDTO();

        EditUserAdminSideDTO? FillEditUserAdminSideDTO(int userId);

        bool EditUserAdminSide(EditUserAdminSideDTO model, List<int> SelectedRoles);

        Task<bool> DeleteUserAsync(int userId, CancellationToken cancellation);

        #endregion

        #endregion
    }
}
