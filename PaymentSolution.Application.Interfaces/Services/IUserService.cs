using PaymentSolution.Shared.Dtos.Default;
using PaymentSolution.Shared.Dtos.User;

namespace PaymentSolution.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<PaymentSolutionResponse<UserDto>> GetUserByEmailAsync(string email);
        Task<PaymentSolutionResponse<UserWithPasswordDto>> GetUserWithPasswordByEmailAsync(string email);
    }
}
