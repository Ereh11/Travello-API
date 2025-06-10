namespace Travello_Application.Dtos.UesrOffer;

public class UserOfferDto
{
    public Guid UserId { get; set; }
    public Guid OfferId { get; set; }
    public DateTime DateOfActivate { get; set; }
    public bool IsActive { get; set; } = true;
}
