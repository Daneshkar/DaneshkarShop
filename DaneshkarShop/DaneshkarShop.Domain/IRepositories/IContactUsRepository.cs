using DaneshkarShop.Domain.Entitties.ContactUs;

namespace DaneshkarShop.Domain.IRepositories;

public interface IContactUsRepository
{
    Task SaveChangeAsync();

    Task AddContactUsToTheDataBase(ContactUs contactUs);

    Task<List<ContactUs>> GetListOfContactUs();

    Task<ContactUs?> GetContactUsById(int id);

    void DeleteContactUs(ContactUs contactUs);

    void Update(ContactUs contactUs);
}
