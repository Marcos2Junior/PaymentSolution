using PaymentSolution.Shared.Enums;

namespace PaymentSolution.Shared.Dtos.Pix
{
    public class PIxDetailsDto : CreatePixDto
    {
        public string ID { get; set; }
        public StatusPayment Status { get; set; }
        public string QrCode { get; set; }
        public string Base64QrCode { get; set; }
        public string LinkPayment { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expiration => Created.AddSeconds(ExpirationInSeconds);
    }
}
