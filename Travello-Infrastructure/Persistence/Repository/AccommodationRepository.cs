using Microsoft.EntityFrameworkCore;
using Travello_Domain;
using Travello_Domain.Interfaces;

namespace Travello_Infrastructure.Persistence.Repository
{
    public class AccommodationRepository
        : GenericRepository<Accommodation>,
            IAccommodationRepository
    {
        public AccommodationRepository(TravelloDbContext context)
            : base(context) { }
    }
}
