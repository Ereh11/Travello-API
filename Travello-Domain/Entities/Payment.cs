using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travello_Domain;

public class Payment
{
    public Guid PaymentId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public DateTime? PaymentDate { get; set; }
    public string TransactionID { get; set; } = string.Empty;
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
}
