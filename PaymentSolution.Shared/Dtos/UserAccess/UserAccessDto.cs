namespace PaymentSolution.Shared.Dtos.UserAccess
{
    public class UserAccessDto
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string RefreshToken { get; set; }
        public string Ip { get; set; }
        public string UserAgent { get; set; }
        public DateTime DateTime { get; set; }
    }
}
