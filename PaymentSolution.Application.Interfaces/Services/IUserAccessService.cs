using PaymentSolution.Shared.Dtos.User;
using PaymentSolution.Shared.Dtos.UserAccess;

namespace PaymentSolution.Application.Interfaces.Services
{
    public interface IUserAccessService
    {
        Task<UserAccessDto> NewAccessAsync(UserDto userDto);
        Task<UserAccessDto> UpdateAccessAsync(int userAccessId, string refreshToken);
    }
}
