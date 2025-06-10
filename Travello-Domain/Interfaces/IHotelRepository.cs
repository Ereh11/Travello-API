namespace Travello_Domain.Interfaces;
public interface IHotelRepository : IGenericRepository<Hotel>
{
    Task<List<Hotel>?> GetHotelsByCityAsync(string city);
    Task<List<Hotel>?> GetHotelsByRatingAsync(decimal rating);
    Task<List<Hotel>?> GetHotelsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
    Task<List<Hotel>?> GetHotelsWithReviewsAsync();
    Task<Hotel?> GetHotelWithAllDetailsAsync(Guid id);
    Task<List<Hotel>?> GetAllHotelsWithAllDetailsAsync();
}   