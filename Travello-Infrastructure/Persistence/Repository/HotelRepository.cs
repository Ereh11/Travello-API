using Microsoft.EntityFrameworkCore;
using Travello_Domain;
using Travello_Domain.Interfaces;

namespace Travello_Infrastructure.Persistence.Repository;

public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
{
    public HotelRepository(TravelloDbContext context) : base(context)
    {}
    public async Task<List<Hotel>?> GetHotelsByCityAsync(string city)
    {
        return await _context.Set<Hotel>()
            .Include(h => h.Address)
            .Where(h => h.Address.City.Equals(city, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
    }

    public async Task<List<Hotel>?> GetHotelsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
    {
        return await _context.Set<Hotel>()
            .Include(h => h.Accommodations)
            .ThenInclude(a => a.Rooms)
            .Where(h => h.Accommodations.Any(a => a.Price >= minPrice && a.Price <= maxPrice))
            .Include(h => h.Address)
            .Include(h => h.Images)
            .Include(h => h.HotelFacilities)
            .ThenInclude(hf => hf.Facility)
            .ToListAsync();
    }

    public async Task<List<Hotel>?> GetHotelsByRatingAsync(decimal rating)
    {
        return await _context.Set<Hotel>()
            .Include(h => h.UserReviews)
            .ThenInclude(r => r.User)
            .Where(h => h.UserReviews.Any(r => r.Rating >= rating))
            .Include(h => h.Address)
            .Include(h => h.Images)
            .Include(h => h.HotelFacilities)
            .ThenInclude(hf => hf.Facility)
            .ToListAsync();
    }

    public Task<List<Hotel>?> GetHotelsWithReviewsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Hotel?> GetHotelWithAllDetailsAsync(Guid id)
    {
       return await _context.Set<Hotel>()
            .Include(h => h.Address)
            .Include(h => h.Images)
            .Include(h => h.HotelFacilities)
            .ThenInclude(hf => hf.Facility)
            .Include(h => h.Accommodations)
            .ThenInclude(a => a.Rooms)
            .Include(h => h.UserReviews)
            .ThenInclude(r => r.User)
            .FirstOrDefaultAsync(h => h.HotelId == id);
    }
    public async Task<List<Hotel>?> GetAllHotelsWithAllDetailsAsync()
    {
        return await _context.Set<Hotel>()
            .Include(h => h.Address)
            .Include(h => h.Images)
            .Include(h => h.HotelFacilities)
            .ThenInclude(hf => hf.Facility)
            .Include(h => h.Accommodations)
            .ThenInclude(a => a.Rooms)
            .Include(h => h.UserReviews)
            .ThenInclude(r => r.User)
            .AsNoTracking()
            .ToListAsync();
    }

}
