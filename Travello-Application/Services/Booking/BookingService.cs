public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepo;
    private readonly IHotelRepository _hotelRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookingService(
        IBookingRepository bookingRepo,
        IHotelRepository hotelRepo,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _bookingRepo = bookingRepo;
        _hotelRepo = hotelRepo;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BookingDetailsDto> CreateBookingAsync(CreateBookingDto dto, Guid userId)
    {
        // 1. Check availability
        if (!await _bookingRepo.IsRoomAvailableAsync(dto.HotelId, dto.CheckInDate, dto.CheckOutDate))
            throw new InvalidOperationException("Selected dates not available");

        // 2. Calculate price
        var price = await _hotelRepo.CalculatePriceAsync(
            dto.HotelId, 
            dto.CheckInDate, 
            dto.CheckOutDate, 
            dto.NumberOfGuests
        );

        // 3. Create entities
        var payment = new Payment
        {
            PaymentMethod = Enum.Parse<PaymentMethod>(dto.PaymentMethod),
            TransactionID = dto.TransactionId
        };

        var booking = new Booking
        {
            UserId = userId,
            HotelId = dto.HotelId,
            CheckInDate = dto.CheckInDate,
            CheckOutDate = dto.CheckOutDate,
            NumberOfGuests = dto.NumberOfGuests,
            TotalPrice = price,
            Payment = payment
        };

        // 4. Save to database
        await _bookingRepo.AddAsync(booking);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<BookingDetailsDto>(booking);
    }

    public async Task<IEnumerable<UserBookingHistoryDto>> GetUserHistoryAsync(Guid userId)
    {
        var bookings = await _bookingRepo.GetUserBookingsAsync(userId);
        return _mapper.Map<IEnumerable<UserBookingHistoryDto>>(bookings);
    }
    
}
