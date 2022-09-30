using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PaymentSolution.Infrastructure
{
    public static class PaymentSolutionDataContextExtension
    {
        public static DbContextOptionsBuilder OnConfiguring(this DbContextOptionsBuilder modelBuilder, IConfiguration configuration)
        {
            if (!modelBuilder.IsConfigured)
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                modelBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
            return modelBuilder;
        }
    }
}
