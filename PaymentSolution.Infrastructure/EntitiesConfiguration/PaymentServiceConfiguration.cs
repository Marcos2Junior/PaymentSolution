using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentSolution.Domain.Entities;

namespace PaymentSolution.Infrastructure.EntitiesConfiguration
{
    public class PaymentServiceConfiguration : IEntityTypeConfiguration<PaymentService>
    {
        public void Configure(EntityTypeBuilder<PaymentService> builder)
        {
        }
    }
}
