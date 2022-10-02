using AutoMapper;
using Microsoft.Extensions.Logging;
using PaymentSolution.Application.Interfaces.Services;
using PaymentSolution.Domain.Entities;
using PaymentSolution.Infrastructure.Interfaces.Repositories;
using PaymentSolution.Shared.Dtos.Default;
using PaymentSolution.Shared.Dtos.User;
using System.ComponentModel.DataAnnotations;

namespace PaymentSolution.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<PaymentSolutionResponse<UserDto>> GetUserByEmailAsync(string email)
        {
            var userResponse = await GerUserEntitieByEmailAsync(email);
            if (userResponse.Success)
            {
                return new PaymentSolutionResponse<UserDto>(_mapper.Map<UserDto>(userResponse.Model));
            }
            return new PaymentSolutionResponse<UserDto>(userResponse.Message);
        }

        public async Task<PaymentSolutionResponse<UserWithPasswordDto>> GetUserWithPasswordByEmailAsync(string email)
        {
            var userResponse = await GerUserEntitieByEmailAsync(email);
            if (userResponse.Success)
            {
                return new PaymentSolutionResponse<UserWithPasswordDto>(_mapper.Map<UserWithPasswordDto>(userResponse.Model));
            }
            return new PaymentSolutionResponse<UserWithPasswordDto>(userResponse.Message);
        }

        private async Task<PaymentSolutionResponse<User>> GerUserEntitieByEmailAsync(string email)
        {
            try
            {
                if (!new EmailAddressAttribute().IsValid(email))
                {
                    return new PaymentSolutionResponse<User>("email inválido");
                }

                var user = await _userRepository.GetByEmailAsync(email);
                if (user == null)
                {
                    return new PaymentSolutionResponse<User>("usuario não identificado");
                }

                return new PaymentSolutionResponse<User>(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
