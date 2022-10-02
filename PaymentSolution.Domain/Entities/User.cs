using System.ComponentModel.DataAnnotations;

namespace PaymentSolution.Domain.Entities
{
    public class User : BaseEntity
    {
        [Required, MaxLength(36)]
        public string Name { get; set; }

        [Required, MaxLength(254)]
        public string Email { get; set; }
        
        [Required, MaxLength(128)]
        public string Password { get; set; }
        public DateTime DateTime { get; set; }
    }
}
