using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PaymentSolution.Application.Interfaces.Services;
using PaymentSolution.Infrastructure.Interfaces.Repositories;
using PaymentSolution.Shared.Dtos.User;
using PaymentSolution.Shared.Dtos.UserAccess;

namespace PaymentSolution.Application.Services
{
    public class UserAccessService : IUserAccessService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserAccessRepository _userAccessRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserAccessService> _logger;

        public UserAccessService(IUserAccessRepository userAccessRepository, IMapper mapper, ILogger<UserAccessService> logger, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _userAccessRepository = userAccessRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserAccessDto> NewAccessAsync(UserDto userDto)
        {
            try
            {
                var userAccess = await _userAccessRepository.AddAsync(new Domain.Entities.UserAccess
                {
                    DateTime = DateTime.UtcNow,
                    UserAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"].ToString(),
                    Ip = _httpContextAccessor.HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                    RefreshToken = Guid.NewGuid().ToString(),
                    UserID = userDto.Id
                });

                return _mapper.Map<UserAccessDto>(userAccess);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<UserAccessDto> UpdateAccessAsync(int userAccessId, string refreshToken)
        {
            var userAccess = await _userAccessRepository.GetByIdAsync(userAccessId);
            if (userAccess != null && userAccess.RefreshToken == refreshToken)
            {
                userAccess.RefreshToken = Guid.NewGuid().ToString();
                if (await _userAccessRepository.UpdateAsync(userAccess) > 0)
                {
                    return _mapper.Map<UserAccessDto>(userAccess);
                }
            }

            return null;
        }
    }
}
