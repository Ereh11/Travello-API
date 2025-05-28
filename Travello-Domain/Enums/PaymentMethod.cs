using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travello_Domain;

public enum PaymentMethod
{
    None,
    CreditCard,
    DebitCard,
    PayPal,
    BankTransfer,
    Cash,
    Cryptocurrency
}
