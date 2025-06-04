using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Travello; // Add this line
using Travello_Application;
using Travello_Application.Common.Result;
using Travello_Domain;

namespace Travello.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBooking(CreateBookingDto request)
    {
        var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userid, out var userIdGuid))
        {
            return Unauthorized("Invalid user ID.");
        }
        try
        {
            var result = await _bookingService.CreateBookingAsync(request, userIdGuid);
            return Ok(
                GeneralResult<BookingDetailsDto>.MappingSuccessResult(result, "Booking Created")
            );
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpGet("history")]
    public async Task<IActionResult> GetBookingHistory()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userId, out var userIdGuid))
            return Unauthorized();

        var history = await _bookingService.GetUserHistoryAsync(userIdGuid);
        return Ok(
            GeneralResult<IEnumerable<UserBookingHistoryDto>>.MappingSuccessResult(
                // history,
                "History retrieved"
            )
        );
    }
}
