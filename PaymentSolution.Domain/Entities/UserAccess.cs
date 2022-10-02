namespace PaymentSolution.Domain.Entities
{
    public class UserAccess : BaseEntity
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public string RefreshToken { get; set; }
        public string Ip { get; set; }
        public string UserAgent { get; set; }
        public DateTime DateTime { get; set; }
    }
}
