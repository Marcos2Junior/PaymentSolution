using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentSolution.Domain.Entities;

namespace PaymentSolution.Infrastructure.EntitiesConfiguration
{
    public class PaymentServiceConfiguration : IEntityTypeConfiguration<PaymentService>
    {
        public void Configure(EntityTypeBuilder<PaymentService> builder)
        {
            builder.HasData(new PaymentService
            {
                Id = 1,
                Name = "GerenciaNet",
                ClientID = "Client_Id_bf67d22a0bf523ec6415a3145e918190df3bcb83",
                Secret = "Client_Secret_78d738db37d9968b6497df342559180bbbf7f715",
                UseCertificate = true,
            });
        }
    }
}
