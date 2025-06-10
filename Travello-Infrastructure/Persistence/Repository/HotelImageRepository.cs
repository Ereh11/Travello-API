using Travello_Domain;
using Travello_Domain.Interfaces;

namespace Travello_Infrastructure.Persistence.Repository;

public class HotelImageRepository : IHotelImageRepository
{
    private readonly TravelloDbContext _context;
    public HotelImageRepository(TravelloDbContext context)
    {
        _context = context;
    }
    public async Task AddImageAsync(HotelImage image)
    {
        await _context.Set<HotelImage>()
            .AddAsync(image);
    }
}
