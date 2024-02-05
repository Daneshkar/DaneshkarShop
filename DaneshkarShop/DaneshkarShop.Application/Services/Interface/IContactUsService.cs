using DaneshkarShop.Domain.DTOs.SiteSode.ContactUs;
using DaneshkarShop.Domain.Entitties.ContactUs;

namespace DaneshkarShop.Application.Services.Interface;

public interface IContactUsService
{
    Task AddContactUsMessage(ContactUsDTO contactUs);
}
