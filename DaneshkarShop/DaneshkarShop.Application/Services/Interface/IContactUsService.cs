using DaneshkarShop.Domain.DTOs.SiteSode.ContactUs;
using DaneshkarShop.Domain.Entitties.ContactUs;

namespace DaneshkarShop.Application.Services.Interface;

public interface IContactUsService
{
    Task AddContactUsMessage(ContactUsDTO contactUs);

    Task<List<ContactUs>> GetListOfContactUs();

    Task<ContactUs?> GetContactUsById(int id);

    Task<bool> DeleteContactUs(int id);
}
