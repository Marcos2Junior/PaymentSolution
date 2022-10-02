using AutoMapper;
using PaymentSolution.Domain.Entities;
using PaymentSolution.Shared.Dtos.User;
using PaymentSolution.Shared.Dtos.UserAccess;

namespace PaymentSolution.Application.Helpers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserWithPasswordDto>().ReverseMap();
            CreateMap<UserAccess, UserAccessDto>().ReverseMap();
        }
    }
}
