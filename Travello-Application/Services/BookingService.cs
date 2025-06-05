using Travello_Application;
using Travello_Application.Interfaces;
using Travello_Domain;
using Travello_Domain.Interfaces;

namespace Travello_Application.Services;

public class BookingService : IBookingService
{
    private readonly IOfferRepository _offerRepo;
    private readonly IBookingRepository _bookingRepo;
    private readonly IAccommodationRepository _accommodationRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPaymentService _paymentService;
    private readonly IRefundRepository _refundRepo;

    public BookingService(
        IBookingRepository bookingRepo,
        IAccommodationRepository accommodationRepo,
        IUnitOfWork unitOfWork,
        IOfferRepository offerRepo,
        IPaymentService paymentService,
        IRefundRepository refundRepo
    )
    {
        _bookingRepo = bookingRepo;
        _accommodationRepo = accommodationRepo;
        _offerRepo = offerRepo;
        _unitOfWork = unitOfWork;
        _paymentService = paymentService;
        _refundRepo = refundRepo;
    }

    public async Task<BookingDetailsDto> CreateBookingAsync(CreateBookingDto dto, Guid userId)
    {
        // 1. Get accommodation
        var accommodation = await _accommodationRepo.GetByIdAsync(dto.AccommodationId);
        if (accommodation == null)
            throw new KeyNotFoundException("Accommodation not found");

        // 2. Validate capacity
        if (dto.NumberOfGuests > accommodation.Capacity)
            throw new InvalidOperationException("Exceeds accommodation capacity");

        // 3. Check availability
        if (
            !await _bookingRepo.IsAccommodationAvailableAsync(
                dto.AccommodationId,
                dto.CheckInDate,
                dto.CheckOutDate
            )
        )
            throw new InvalidOperationException("Selected dates not available");

        // 4. Calculate price
        var nights = (dto.CheckOutDate - dto.CheckInDate).Days;
        decimal totalPrice = accommodation.Price * nights;

        // 5. Apply offer discount
        if (!string.IsNullOrEmpty(dto.PromoCode))
        {
            var offer = await _offerRepo.GetByCodeAsync(dto.PromoCode);
            if (offer != null && offer.ExpiryDate > DateTime.UtcNow)
            {
                totalPrice -= offer.DiscountValue;
                if (totalPrice < 0)
                    totalPrice = 0;
            }
        }

        // 6. Create payment entity
        var payment = new Payment
        {
            PaymentId = Guid.NewGuid(),
            PaymentMethod = Enum.Parse<PaymentMethod>(dto.PaymentMethod),
            Status = PaymentStatus.Pending,
        };

        // 7. Process payment
        var paymentResult = await _paymentService.ProcessPayment(
            amount: totalPrice,
            method: dto.PaymentMethod,
            token: dto.PaymentToken
        );

        if (!paymentResult.Success)
            throw new Exception($"Payment failed: {paymentResult.Message}");

        payment.TransactionID = paymentResult.TransactionId;
        payment.Status = paymentResult.Status;
        payment.PaymentDate = DateTime.UtcNow;

        // 8. Create booking
        var booking = new Booking
        {
            BookingId = Guid.NewGuid(),
            UserId = userId,
            AccommodationId = dto.AccommodationId,
            CheckInDate = dto.CheckInDate,
            CheckOutDate = dto.CheckOutDate,
            NumberOfGuests = dto.NumberOfGuests,
            TotalPrice = totalPrice,
            Payment = payment,
        };

        // 9. Save to database
        await _bookingRepo.AddAsync(booking);
        await _unitOfWork.SaveChangesAsync();

        // 10. Return DTO
        return new BookingDetailsDto
        {
            BookingId = booking.BookingId,
            CheckInDate = booking.CheckInDate,
            CheckOutDate = booking.CheckOutDate,
            NumberOfGuests = booking.NumberOfGuests,
            TotalPrice = booking.TotalPrice,
            HotelName = accommodation.Hotel.Name,
            Stars = accommodation.Hotel.Stars,
            HotelAddress =
                $"{accommodation.Hotel.Address?.Street}, {accommodation.Hotel.Address?.City}",
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
        var bookings = await _bookingRepo.GetUserBookingsAsync(
            userId,
            filter?.FromDate,
            filter?.ToDate,
            filter?.HotelName,
            filter?.HasRefund,
            filter?.MinStars,
            filter?.SortBy
        );

        return bookings
            .Select(booking => new UserBookingHistoryDto
            {
                BookingId = booking.BookingId,
                HotelName = booking.Accommodation.Hotel.Name,
                // AccommodationName = booking.Accommodation.Name,
                CheckInDate = booking.CheckInDate,
                CheckOutDate = booking.CheckOutDate,
                NumberOfGuests = booking.NumberOfGuests,
                TotalPrice = booking.TotalPrice,
                PaymentStatus = booking.Payment.Status.ToString(),
                RefundStatus = booking.Refund?.RefundStatus.ToString(),
            })
            .ToList();
    }

    public async Task CancelBookingAsync(Guid bookingId, string reason)
    {
        var booking = await _bookingRepo.GetByIdAsync(bookingId);
        if (booking == null)
            throw new KeyNotFoundException("Booking not found");

        // 1. Check cancellation policy
        var cancellationCutoff = booking.CheckInDate.AddHours(-48);
        if (DateTime.UtcNow > cancellationCutoff)
            throw new Exception("Cancellation not allowed within 48 hours of check-in");

        // 2. Calculate refund amount
        decimal refundPercentage = CalculateRefundPercentage(booking.CheckInDate);
        decimal refundAmount = booking.TotalPrice * refundPercentage;

        // 3. Process refund
        var refundResult = await _paymentService.ProcessRefund(
            provider: booking.Payment.PaymentMethod.ToString(),
            transactionId: booking.Payment.TransactionID,
            amount: refundAmount
        );

        // 4. Create refund record
        var refund = new Refund
        {
            RefundId = Guid.NewGuid(),
            BookingId = bookingId,
            RefundPercentage = refundPercentage,
            RefundDate = DateTime.UtcNow,
            RefundStatus = refundResult.Success ? RefundStatus.Approved : RefundStatus.Failed,
            Reason = reason,
        };

        // 5. Update payment status
        booking.Payment.Status =
            refundPercentage == 1m ? PaymentStatus.Refunded : PaymentStatus.PartiallyRefunded;

        // 6. Save changes
        await _refundRepo.AddAsync(refund);
        await _bookingRepo.UpdateAsync(booking);
        await _unitOfWork.SaveChangesAsync();
    }

    private decimal CalculateRefundPercentage(DateTime checkInDate)
    {
        var daysUntilCheckIn = (checkInDate - DateTime.UtcNow).Days;

        return daysUntilCheckIn switch
        {
            > 30 => 1.00m, // 100% refund
            > 14 => 0.75m, // 75% refund
            > 7 => 0.50m, // 50% refund
            > 2 => 0.25m, // 25% refund
            _ => 0.00m, // No refund
        };
    }
}
