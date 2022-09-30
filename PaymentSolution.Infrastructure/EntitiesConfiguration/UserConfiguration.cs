using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentSolution.Domain.Entities;

namespace PaymentSolution.Infrastructure.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(builder => builder.Id);
            builder.HasIndex(builder => builder.Email).IsUnique(true);
        }
    }
}
