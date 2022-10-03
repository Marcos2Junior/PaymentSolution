using PaymentSolution.Shared.Enums;

namespace PaymentSolution.Shared.Dtos.PaymentService
{
    public class CreatePaymentServiceDto
    {
        public PaymentServiceType PaymentServiceType { get; set; }
        public string Name { get; set; }
        public string? ClientID { get; set; }
        public string? Secret { get; set; }
        public string? ApiKey { get; set; }
        public string? WebHook { get; set; }
        public bool UseCertificate { get; set; }
        public string? Scope { get; set; }
    }
}
