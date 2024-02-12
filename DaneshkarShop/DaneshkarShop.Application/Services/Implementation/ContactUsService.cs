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

    public async Task<List<ContactUs>> GetListOfContactUs()
    {
        return await _contactUsRepository.GetListOfContactUs();
    }

    public async Task<ContactUs?> GetContactUsById(int id)
    {
        return await _contactUsRepository.GetContactUsById(id);
    }

    public async Task<bool> DeleteContactUs(int id)
    {
        //Get Contact Us By Id 
        var contactUs = await GetContactUsById(id);
        if (contactUs == null) return false;

        //Remove Contact Us 
        _contactUsRepository.DeleteContactUs(contactUs);

        //Save Change Method 
        await _contactUsRepository.SaveChangeAsync();

        return true;
    }
}
