using Microsoft.EntityFrameworkCore;
using Travello_Domain;
using Travello_Domain.Interfaces;

namespace Travello_Infrastructure.Persistence.Repository
{
    public class UserRepository : GenericRepository<User> , IUserRepository
    {

        private readonly TravelloDbContext _context;
        public UserRepository(TravelloDbContext context)
            : base(context)
            {}
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == username);
        }
        public async Task<IEnumerable<User>> GetUsersByNationalityAsync(string nationality)
        {
            return await _context.Users
                .Where(u => u.Nationality == nationality)
                .ToListAsync();
        }
        public async Task<User> GetUserWithDetailsAsync(Guid userId)
        {
            return await _context.Users
                .Include(u => u.Passport)
                .Include(u => u.ProfileImage)
                .Include(u => u.Address)
                .Include(u => u.Level)
                .Include(u => u.UserOffers)
                .ThenInclude(uo => uo.Offer)
                .Include(u => u.UserReviews)
                .Include(u => u.Bookings)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }
        public async Task<bool> ExistsAsync(Guid userId)
        {
            return await _context.Users.AnyAsync(u => u.Id == userId);
        } 
    }
}
