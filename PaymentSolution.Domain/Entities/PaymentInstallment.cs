namespace PaymentSolution.Domain.Entities
{
    public class PaymentInstallment
    {
        public int PaymentID { get; set; }
        public Payment Payment { get; set; }
        public decimal Amount { get; set; }
        public DateTime? Processed { get; set; }
        public DateTime DateTime { get; set; }
    }
}