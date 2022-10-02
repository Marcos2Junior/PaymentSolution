using AutoMapper;
using PaymentSolution.Domain.Entities;
using PaymentSolution.Shared.Dtos.User;

namespace PaymentSolution.Application.Helpers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
