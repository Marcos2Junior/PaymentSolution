namespace PaymentSolution.Shared.Dtos.Pix
{
    public class CreatePixDto
    {
        public string Key { get; set; }
        public string Message { get; set; }
        public decimal Amount { get; set; }
        public CustomerDetailsDto CustomerDetails { get; set; }
        public int ExpirationInSeconds { get; set; }
    }
}
