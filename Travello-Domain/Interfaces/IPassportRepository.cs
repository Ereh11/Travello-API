namespace Travello_Domain.Interfaces
{
    public interface IPassportRepository: IGenericRepository<Passport>
    {
        // Specific Queries
        Task<Passport> GetByUserIdAsync(Guid userId);
        Task<Passport> GetByPassportNumberAsync(string passportNumber);
        Task<IEnumerable<Passport>> GetPassportsByCountryAsync(string country);
        Task<bool> ExistsAsync(Guid passportId);

    }
}
