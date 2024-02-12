using DaneshkarShop.Data.AppDbContext;
using DaneshkarShop.Domain.Entitties.ContactUs;
using DaneshkarShop.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
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

    public async Task<List<ContactUs>> GetListOfContactUs()
    {
        return await _context.ContactUs.ToListAsync();
    }

    public async Task<ContactUs?> GetContactUsById(int id)
    {
        return await _context.ContactUs.FirstOrDefaultAsync(p=> p.Id == id);
    }

    public void DeleteContactUs(ContactUs contactUs)
    {
        _context.ContactUs.Remove(contactUs);
    }
}
