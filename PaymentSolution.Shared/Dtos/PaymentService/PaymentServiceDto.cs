using PaymentSolution.Shared.Enums;

namespace PaymentSolution.Shared.Dtos.PaymentService
{
    public class PaymentServiceDto : CreatePaymentServiceDto
    {
        public int ID { get; set; }
        public int UserID { get; set; }
    }
}
