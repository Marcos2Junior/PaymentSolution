namespace PaymentSolution.Shared.Dtos.Pix
{
    public class PixFullDto
    {
        public string EndToEndId { get; set; }
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
        public CustomerDetailsDto CustomerDetails { get; set; }
        public string InfoPayment { get; set; }
        public List<DevolutionDto> Devolutions { get; set; }
    }
}
