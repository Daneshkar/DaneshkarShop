using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.DTOs.SiteSode.ContactUs;
using DaneshkarShop.Domain.Entitties.ContactUs;
using DaneshkarShop.Domain.IRepositories;

namespace DaneshkarShop.Application.Services.Implementation;

public class ContactUsService : IContactUsService
{
	#region Ctor

	private readonly IContactUsRepository _contactUsRepository;

    public ContactUsService(IContactUsRepository contactUsRepository)
    {
        _contactUsRepository = contactUsRepository;
    }

    #endregion

    public async Task AddContactUsMessage(ContactUsDTO contactUs)
    {
        //Object Mapping
        ContactUs model = new ContactUs()
        {
            Message = contactUs.Message,
            Mobile = contactUs.Mobile,
            Username = contactUs.Username
        };

        await _contactUsRepository.AddContactUsToTheDataBase(model);
        await _contactUsRepository.SaveChangeAsync();
    }

}
