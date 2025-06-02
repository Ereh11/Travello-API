using Microsoft.EntityFrameworkCore;
using Travello_Domain;
using Travello_Domain.Interfaces;

namespace Travello_Infrastructure.Persistence.Repository;

public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
{
    private readonly TravelloDbContext _context;
    public HotelRepository(TravelloDbContext context) : base(context)
    {
        _context = context;
    }
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
            .Include(h => h.Image)
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
            .Include(h => h.Image)
            .Include(h => h.HotelFacilities)
            .ThenInclude(hf => hf.Facility)
            .ToListAsync();
    }

    public Task<List<Hotel>?> GetHotelsWithReviewsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Hotel?> GetHotelWithAllDetailsAsync(Guid id)
    {
        throw new NotImplementedException();
    }

}
