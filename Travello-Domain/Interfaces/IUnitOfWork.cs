namespace Travello_Domain.Interfaces
{
    public interface IUnitOfWork 
    {
        IUserRepository UserRepository { get; }
        IPassportRepository PassportRepository { get; }
        IOfferRepository OfferRepository { get; }
        IUserOfferRepository UserOfferRepository { get; }
        IUserReviewRepository UserReviewRepository { get; }
        ILevelRepository LevelRepository { get; }
        IHotelRepository HotelRepository { get; }
        IAddressRepository AddressRepository { get; }
        IHotelImageRepository HotelImageRepository { get; }
        IProfileImageRepository ProfileImageRepository { get; }
        IAttachment Attachment { get; }
        Task<int> SaveChangesAsync();
        
    }
}
