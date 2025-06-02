using Microsoft.EntityFrameworkCore;
using Travello_Domain;
using Travello_Domain.Interfaces;

namespace Travello_Infrastructure.Persistence.Repository
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(TravelloDbContext context) : base(context) { }

        public async Task<bool> IsRoomAvailableAsync(Guid hotelId, DateTime checkIn, DateTime checkOut)
        {
            return !await _context.Bookings.AnyAsync(b =>
                b.HotelId == hotelId &&
                b.CheckInDate < checkOut && 
                b.CheckOutDate > checkIn);
        }

        public async Task<IEnumerable<Booking>> GetUserBookingsAsync(Guid userId)
        {
            return await _context.Bookings
                .Where(b => b.UserId == userId)
                .Include(b => b.Hotel)
                .Include(b => b.Payment)
                .ToListAsync();
        }
    }
}
