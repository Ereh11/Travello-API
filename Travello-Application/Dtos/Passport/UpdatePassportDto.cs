using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travello_Application.Dtos.Passport
{
    public class UpdatePassportDto
    {
        public Guid PassportId { get; set; }
        public string PassportNumber { get; set; } = string.Empty;
        public string PassportName { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public string CountryOfProduction { get; set; } = string.Empty;
    }
}
