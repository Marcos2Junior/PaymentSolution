using System.ComponentModel.DataAnnotations;

namespace PaymentSolution.Shared.Dtos.Authentication
{
    public class CreateAuthenticationDto
    {
        [Required]
        public string Scope { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
