using Microsoft.EntityFrameworkCore;
using Travello_Domain;
using Travello_Domain.Interfaces;

namespace Travello_Infrastructure.Persistence.Repository
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(TravelloDbContext context)
            : base(context) { }

        public async Task<bool> IsRoomAvailableAsync(
            Guid hotelId,
            DateTime checkIn,
            DateTime checkOut
        )
        {
            return !await _context.Bookings.AnyAsync(b =>
                b.HotelId == hotelId && b.CheckInDate < checkOut && b.CheckOutDate > checkIn
            );
        }

        public async Task<IEnumerable<Booking>> GetUserBookingsAsync(
            Guid userId,
            DateTime? fromDate = null,
            DateTime? toDate = null,
            string? hotelName = null,
            bool? hasRefund = null,
            int? minStars = null,
            string? sortBy = null
        )
        {
            var query = _context
                .Bookings.Where(b => b.UserId == userId)
                .Include(b => b.Hotel)
                .Include(b => b.Payment)
                .Include(b => b.Refund)
                .AsQueryable();

            if (fromDate.HasValue)
                query = query.Where(b => b.CheckInDate >= fromDate.Value);

            if (toDate.HasValue)
                query = query.Where(b => b.CheckOutDate <= toDate.Value);

            if (hasRefund.HasValue)
                query = hasRefund.Value
                    ? query.Where(b => b.Refund != null)
                    : query.Where(b => b.Refund == null);

            if (minStars.HasValue)
                query = query.Where(b => b.Hotel.Stars >= minStars.Value);

            if (!string.IsNullOrEmpty(hotelName))
                query = query.Where(b => b.Hotel.Name.Contains(hotelName));

            query = (sortBy?.ToLower()) switch
            {
                "date_asc" => query.OrderBy(b => b.CheckInDate),
                "date_desc" => query.OrderByDescending(b => b.CheckInDate),
                "price_asc" => query.OrderBy(b => b.TotalPrice),
                "price_desc" => query.OrderByDescending(b => b.TotalPrice),
                _ => query.OrderByDescending(b => b.CheckInDate),
            };
            return await query.ToListAsync();
        }
    }
}
