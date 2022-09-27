namespace PaymentSolution.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int PaymentServiceID { get; set; }
        public PaymentService PaymentService { get; set; }
        public List<PaymentInstallment> PaymentInstallments { get; set; }
        public DateTime DateTime { get; set; }
    }
}
