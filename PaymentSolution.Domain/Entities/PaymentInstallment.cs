using PaymentSolution.Shared.Enums;

namespace PaymentSolution.Domain.Entities
{
    public class PaymentInstallment : BaseEntity
    {
        public string Key { get; set; }
        public StatusPayment Status { get; set; }
        public int PaymentID { get; set; }
        public Payment Payment { get; set; }
        public decimal Amount { get; set; }
        public DateTime Scheduled { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime? Processed { get; set; }
        public DateTime DateTime { get; set; }
    }
}