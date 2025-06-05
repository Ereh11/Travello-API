using Microsoft.EntityFrameworkCore;
using Travello_Domain;
using Travello_Domain.Interfaces;

namespace Travello_Infrastructure.Persistence.Repository
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(TravelloDbContext context)
            : base(context) { }

        public async Task<bool> IsAccommodationAvailableAsync(
            Guid accommodationId,
            DateTime checkIn,
            DateTime checkOut
        )
        {
            // Count bookings for this accommodation during the period
            var bookingCount = await _context.Bookings.CountAsync(b =>
                b.AccommodationId == accommodationId
                && b.CheckInDate < checkOut
                && b.CheckOutDate > checkIn
            );

            // Get accommodation capacity (how many can be booked simultaneously)
            var accommodation = await _context.Accommodations.FirstOrDefaultAsync(a =>
                a.AccommodationId == accommodationId
            );

            // If no capacity limit, just check if any booking exists
            if (accommodation?.Capacity == null || accommodation.Capacity <= 1)
                return bookingCount == 0;

            // Check if bookings exceed accommodation capacity
            return bookingCount < accommodation.Capacity;
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
                .Include(b => b.Accommodation)
                .ThenInclude(a => a.Hotel)
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
                query = query.Where(b => b.Accommodation.Hotel.Stars >= minStars.Value);

            if (!string.IsNullOrEmpty(hotelName))
                query = query.Where(b => b.Accommodation.Hotel.Name.Contains(hotelName));

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
