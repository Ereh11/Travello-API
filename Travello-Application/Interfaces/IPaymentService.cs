using Travello_Domain;

public interface IPaymentService
{
    Task<PaymentResult> ProcessPayment(decimal amount, string method, string? token = null);
    Task<RefundResult> ProcessRefund(string provider, string transactionId, decimal amount);
}

public record PaymentResult(
    bool Success,
    string? TransactionId = null,
    PaymentStatus Status = PaymentStatus.Pending,
    string? Message = null
);

public record RefundResult(bool Success, string? Message = null);
