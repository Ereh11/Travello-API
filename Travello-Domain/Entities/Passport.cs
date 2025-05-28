using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travello_Domain
{
    public class Passport
    {
        public Guid PassportId { get; set; }
        public string PassportNumber { get; set; } = string.Empty;
        public string PassportName { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public string CountryOfProduction { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
