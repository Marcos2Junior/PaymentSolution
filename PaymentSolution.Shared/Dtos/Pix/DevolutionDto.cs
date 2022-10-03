namespace PaymentSolution.Shared.Dtos.Pix
{
    public class DevolutionDto
    {
        public string Id { get; set; }
        public string RtrID { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
    }
}
