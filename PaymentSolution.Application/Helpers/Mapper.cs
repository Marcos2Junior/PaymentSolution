using AutoMapper;
using PaymentSolution.Domain.Entities;
using PaymentSolution.Shared.Dtos.PaymentService;
using PaymentSolution.Shared.Dtos.User;
using PaymentSolution.Shared.Dtos.UserAccess;

namespace PaymentSolution.Application.Helpers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            /*
             * User
             */
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserWithPasswordDto>().ReverseMap();
            /*
            * UserAccess
            */
            CreateMap<UserAccess, UserAccessDto>().ReverseMap();
            /*
           * PaymentService
           */
            CreateMap<PaymentService, PaymentServiceDto>().ReverseMap();
            CreateMap<PaymentService, CreatePaymentServiceDto>().ReverseMap();
        }
    }
}
