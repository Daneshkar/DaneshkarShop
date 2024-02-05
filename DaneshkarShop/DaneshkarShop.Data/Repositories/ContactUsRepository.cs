using DaneshkarShop.Data.AppDbContext;
using DaneshkarShop.Domain.Entitties.ContactUs;
using DaneshkarShop.Domain.IRepositories;
namespace DaneshkarShop.Data.Repositories;

public class ContactUsRepository : IContactUsRepository
{
	#region Ctor

	private readonly DaneshkarDbContext _context;

    public ContactUsRepository(DaneshkarDbContext context)
    {
            _context = context;
    }

    #endregion

    public async Task SaveChangeAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task AddContactUsToTheDataBase(ContactUs contactUs)
    {
        await _context.ContactUs.AddAsync(contactUs);
    }
}
