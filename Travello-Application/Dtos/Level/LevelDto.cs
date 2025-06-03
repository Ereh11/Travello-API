namespace Travello_Application.Dtos.Level
{
    public class LevelDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal DiscountPercentage { get; set; }
        public bool IsFreeTransportation { get; set; }
    }
}