namespace Travello_Domain.Interfaces
{
    public interface ILevelRepository : IGenericRepository<Level>
    {
        // specific queries
        Task<Level?> GetByNameAsync(string name);
        Task<IEnumerable<Level>> GetLevelsWithUsersAsync(); // Includes related Users
        Task<bool> ExistsAsync(Guid levelId);
    }
}
