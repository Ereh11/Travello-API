using Travello_Application;
using Travello_Application.Interfaces;
using Travello_Domain;
using Travello_Domain.Interfaces;

namespace Travello_Application.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepo;
    private readonly IHotelRepository _hotelRepo;
    private readonly IUnitOfWork _unitOfWork;

    public BookingService(
        IBookingRepository bookingRepo,
        IHotelRepository hotelRepo,
        IUnitOfWork unitOfWork
    )
    {
        _bookingRepo = bookingRepo;
        _hotelRepo = hotelRepo;
        _unitOfWork = unitOfWork;
    }

    public async Task<BookingDetailsDto> CreateBookingAsync(CreateBookingDto dto, Guid userId)
    {
        // check hotel exists
        var hotel = await _hotelRepo.GetByIdAsync(dto.HotelId);
        if (hotel == null)
            throw new KeyNotFoundException("Hotel not found");

        // 1. Check availability
        if (
            !await _bookingRepo.IsRoomAvailableAsync(dto.HotelId, dto.CheckInDate, dto.CheckOutDate)
        )
            throw new InvalidOperationException("Selected dates not available");

        //TODO: 2. Validate payment method
        // Placeholder price calculation
        var price = CalculatePlaceholderPrice(
            dto.CheckInDate,
            dto.CheckOutDate,
            dto.NumberOfGuests
        );

        // Create entities
        var payment = new Payment
        {
            PaymentId = Guid.NewGuid(),
            PaymentMethod = Enum.Parse<PaymentMethod>(dto.PaymentMethod),
            TransactionID = dto.TransactionId,
            PaymentDate = DateTime.UtcNow,
        };

        var booking = new Booking
        {
            BookingId = Guid.NewGuid(),
            UserId = userId,
            HotelId = dto.HotelId,
            CheckInDate = dto.CheckInDate,
            CheckOutDate = dto.CheckOutDate,
            NumberOfGuests = dto.NumberOfGuests,
            TotalPrice = price,
            Payment = payment,
            PaymentId = payment.PaymentId,
        };

        // Save to database
        await _bookingRepo.AddAsync(booking);
        await _unitOfWork.SaveChangesAsync();

        // Manual mapping to DTO
        return new BookingDetailsDto
        {
            BookingId = booking.BookingId,
            CheckInDate = booking.CheckInDate,
            CheckOutDate = booking.CheckOutDate,
            NumberOfGuests = booking.NumberOfGuests,
            TotalPrice = booking.TotalPrice,
            HotelName = hotel.Name,
            Stars = 3, //TODO: add the stars
            HotelAddress = "Address Placeholder", //TODO: add the address
            PaymentMethod = booking.Payment.PaymentMethod.ToString(),
            PaymentDate = booking.Payment.PaymentDate,
            TransactionId = booking.Payment.TransactionID,
        };
    }

    public async Task<IEnumerable<UserBookingHistoryDto>> GetUserHistoryAsync(
        Guid userId,
        BookingHistoryFilterDto? filter = null
    )
    {
        var bookings = await _bookingRepo.GetUserBookingsAsync(userId);

        return bookings
            .Select(booking => new UserBookingHistoryDto
            {
                BookingId = booking.BookingId,
                HotelName = booking.Hotel?.Name ?? "Hotel Name",
                CheckInDate = booking.CheckInDate,
                CheckOutDate = booking.CheckOutDate,
                NumberOfGuests = booking.NumberOfGuests,
                TotalPrice = booking.TotalPrice,
                PaymentStatus = "Completed", // Placeholder for now
                RefundStatus = booking.Refund?.RefundStatus.ToString(), // Fixed property name
            })
            .ToList();
    }

    //TODO: Add a good calculation for the price
    private decimal CalculatePlaceholderPrice(DateTime checkIn, DateTime checkOut, int guests)
    {
        // Simple calculation: $100 per night per guest
        var nights = (checkOut - checkIn).Days;
        return 100 * nights * guests;
    }
}
