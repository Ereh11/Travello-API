using Travello_Domain;

public interface IOfferRepository
{
    Task<Offer?> GetByCodeAsync(string promoCode);
}
