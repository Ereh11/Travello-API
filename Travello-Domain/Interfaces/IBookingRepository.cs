using System;
using System.Threading.Tasks;

namespace Travello_Domain.Interfaces;

public interface IBookingRepository : IGenericRepository<Booking>
{
    Task<bool> IsAccommodationAvailableAsync(
        Guid accommodationId,
        DateTime checkIn,
        DateTime checkOut
    );
    Task<IEnumerable<Booking>> GetUserBookingsAsync(
        Guid userId,
        DateTime? fromDate = null,
        DateTime? toDate = null,
        string? hotelName = null,
        bool? hasRefund = null,
        int? minStars = null,
        string? sortBy = null
    );
}
