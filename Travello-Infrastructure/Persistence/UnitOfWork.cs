using Travello_Domain;
using Travello_Domain.Interfaces;

namespace Travello_Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TravelloDbContext _context;

        public IUserRepository UserRepository { get; }
        public IPassportRepository PassportRepository { get; }
        public IOfferRepository OfferRepository { get; }
        public IUserOfferRepository UserOfferRepository { get; }
        public IUserReviewRepository UserReviewRepository { get; }
        public ILevelRepository LevelRepository { get; }
        public UnitOfWork(TravelloDbContext context,
            IUserRepository userRepository,
            IPassportRepository passportRepository,
            IOfferRepository offerRepository,
            IUserOfferRepository userOfferRepository,
            IUserReviewRepository userReviewRepository,
            ILevelRepository levelRepository)
        {
            _context = context;
            UserRepository = userRepository;
            PassportRepository = passportRepository;
            OfferRepository = offerRepository;
            UserOfferRepository = userOfferRepository;
            UserReviewRepository = userReviewRepository;
            LevelRepository = levelRepository;

        }

        

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
