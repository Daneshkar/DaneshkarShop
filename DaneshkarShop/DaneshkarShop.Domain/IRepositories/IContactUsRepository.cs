using DaneshkarShop.Domain.Entitties.ContactUs;

namespace DaneshkarShop.Domain.IRepositories;

public interface IContactUsRepository
{
    Task SaveChangeAsync();

    Task AddContactUsToTheDataBase(ContactUs contactUs);
}
