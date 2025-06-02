using System;
using System.Threading.Tasks;

namespace Travello_Domain.Interfaces;

public interface IBookingRepository : IGenericRepository<Booking>
{
    // Task<Booking> GetByIdAsync(Guid id);
    // Task AddAsync(Booking booking);
    Task<bool> IsRoomAvailableAsync(Guid hotelId, DateTime checkIn, DateTime checkOut);
    Task<IEnumerable<Booking>> GetUserBookingsAsync(Guid userId);
}
