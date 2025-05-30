using Microsoft.EntityFrameworkCore;
using Travello_Domain;
using Travello_Domain.Interfaces;

namespace Travello_Infrastructure.Persistence.Repository
{
    public class LevelRepository : GenericRepository<Level>, ILevelRepository
    {
        private readonly TravelloDbContext _context;
        public LevelRepository(TravelloDbContext context)
            : base(context)
        { }

        

        public async Task<Level?> GetByNameAsync(string name)
        {
            return await _context.Levels
                .FirstOrDefaultAsync(l => l.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<IEnumerable<Level>> GetLevelsWithUsersAsync()
        {
           return await _context.Levels
                .Include(l => l.Users) // Assuming Level has a navigation property Users
                .ToListAsync();
        }

        public async Task<bool> ExistsAsync(Guid levelId)
        {
            return await _context.Levels.AnyAsync(u => u.LevelId == levelId);
        }
    }
}
