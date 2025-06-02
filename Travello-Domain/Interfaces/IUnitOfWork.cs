namespace Travello_Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IUserRepository UserRepository { get; }
        IPassportRepository PassportRepository { get; }
        IOfferRepository OfferRepository { get; }
        IUserOfferRepository UserOfferRepository { get; }
        IUserReviewRepository UserReviewRepository { get; }
        ILevelRepository LevelRepository { get; }
        IHotelRepository HotelRepository { get; }
        Task<int> SaveChangesAsync();
        void Dispose();


    }
}
