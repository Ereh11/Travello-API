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
        public IBookingRepository BookingRepository {get;}
        public ILevelRepository LevelRepository { get; }
        public IHotelRepository HotelRepository { get; }
        public IAddressRepository AddressRepository { get; }

        public IAttachment Attachment { get; }
        public IProfileImageRepository ProfileImageRepository { get; }
        public IHotelImageRepository HotelImageRepository { get; }

        public UnitOfWork(TravelloDbContext context,
            IUserRepository userRepository,
            IPassportRepository passportRepository,
            IOfferRepository offerRepository,
            IUserOfferRepository userOfferRepository,
            IUserReviewRepository userReviewRepository,
            ILevelRepository levelRepository,
            IHotelRepository hotelRepository,
            IBookingRepository bookingRepository,
            IAddressRepository addressRepository,
            IHotelImageRepository hotelImageRepository,
            IProfileImageRepository profileImageRepository,
            IAttachment attachment

            )

        {
            _context = context;
            UserRepository = userRepository;
            PassportRepository = passportRepository;
            OfferRepository = offerRepository;
            UserOfferRepository = userOfferRepository;
            UserReviewRepository = userReviewRepository;
            LevelRepository = levelRepository;
            HotelRepository = hotelRepository;
            BookingRepository = bookingRepository;
            AddressRepository = addressRepository;
            HotelImageRepository = hotelImageRepository;
            ProfileImageRepository = profileImageRepository;
            Attachment = attachment;
        }

        

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
