namespace Travello_Application;

public class BookingHistoryFilterDto
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public string? HotelName { get; set; }
    public string? SortBy { get; set; }
    public bool? HasRefund { get; set; }
    public int? MinStars { get; set; }
}
