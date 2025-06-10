namespace Travello_Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        // Specific Queries
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByUsernameAsync(string username);
        Task<IEnumerable<User>> GetUsersByNationalityAsync(string nationality);
        Task<User> GetUserWithDetailsAsync(Guid userId); // Includes Passport, ProfileImage, Address, Level, UserOffers, UserReviews, Bookings
        Task<bool> ExistsAsync(Guid userId);
    }
}
