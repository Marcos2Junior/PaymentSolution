using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentSolution.Domain.Entities;

namespace PaymentSolution.Infrastructure.EntitiesConfiguration
{
    public class PaymentInstallmentConfiguration : IEntityTypeConfiguration<PaymentInstallment>
    {
        public void Configure(EntityTypeBuilder<PaymentInstallment> builder)
        {
            builder.Property(x => x.Amount).HasPrecision(19, 4);
        }
    }
}
