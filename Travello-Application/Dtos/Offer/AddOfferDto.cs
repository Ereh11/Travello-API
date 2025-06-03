namespace Travello_Application.Dtos.Offer
{
    public class OfferDto
    {
        public string Title { get; set; } = string.Empty;
        public decimal DiscountValue { get; set; }
        public string PromoCode { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public DateTime StartDate { get; set; }
        public string ImageURL { get; set; } = string.Empty;
        public DateTime DateOfActivate { get; set; }

    }

}
