using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travello_Domain
{
    public class Offer
    {
        public Guid OfferId { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal DiscountValue { get; set; }
        public string PromoCode { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public DateTime StartDate { get; set; }

        public Guid? ImageId { get; set; }
        public Image? Image { get; set; } = null!;
        public ICollection<UserOffer> UserOffers { get; set; } = new HashSet<UserOffer>();
    }
}
