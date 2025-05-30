using Microsoft.EntityFrameworkCore;
using Travello_Domain;
using Travello_Domain.Interfaces;

namespace Travello_Infrastructure.Persistence.Repository
{
    public class PassportRepository : GenericRepository<Passport>, IPassportRepository
    {
        private readonly TravelloDbContext _context;
        public PassportRepository(TravelloDbContext context)
            : base(context)
        { }

        public async Task<bool> ExistsAsync(Guid passportId)
        {
            return await _context.Passports.AnyAsync(u => u.PassportId == passportId);
        }

        public async Task<Passport> GetByPassportNumberAsync(string passportNumber)
        {
            return await _context.Passports
                .FirstOrDefaultAsync(p => p.PassportNumber == passportNumber);
        }

        public async Task<Passport> GetByUserIdAsync(Guid userId)
        {
            return await _context.Passports.FindAsync(userId);
        }

        public async Task<IEnumerable<Passport>> GetPassportsByCountryAsync(string country)
        {
            return await _context.Passports
                .Where(p => p.CountryOfProduction == country)
                .ToListAsync();

        }
    }
}
