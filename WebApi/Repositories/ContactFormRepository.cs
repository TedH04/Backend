using WebApi.Contexts;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;

namespace WebApi.Repositories
{
    public class ContactFormRepository
    {
        private readonly DataContext _context;

        public ContactFormRepository(DataContext context)
        {
            _context = context;
        }

        // Sparar meddelandet som kund vill skicka i databasen
        public async Task<ContactHttpResponse> SaveContactMessage(ContactFormEntity entity)
        {
            _context.Message.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
