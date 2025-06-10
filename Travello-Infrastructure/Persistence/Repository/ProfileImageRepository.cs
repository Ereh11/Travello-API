
using Travello_Domain;
using Travello_Domain.Interfaces;

namespace Travello_Infrastructure.Persistence.Repository;

public class ProfileImageRepository : IProfileImageRepository
{
    private readonly TravelloDbContext _context;
    public ProfileImageRepository(TravelloDbContext context)
    {
        _context = context;
    }

    public async Task AddImageAsync(ProfileImage image)
    {
        await _context.Set<ProfileImage>()
            .AddAsync(image);
    }
}
