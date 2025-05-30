namespace Travello_Application.Dtos.Passport
{
    public class AddPassportDto
    {
        public string PassportNumber { get; set; } = string.Empty;
        public string PassportName { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public string CountryOfProduction { get; set; } = string.Empty;

    }
}
