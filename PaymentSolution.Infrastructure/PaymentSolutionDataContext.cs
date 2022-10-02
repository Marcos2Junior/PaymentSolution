using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PaymentSolution.Domain.Entities;
using PaymentSolution.Infrastructure.EntitiesConfiguration;

namespace PaymentSolution.Infrastructure
{
    public class PaymentSolutionDataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public PaymentSolutionDataContext(DbContextOptions<PaymentSolutionDataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.OnConfiguring(_configuration);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentInstallmentConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentInstallment> PaymentInstallments { get; set; }
        public DbSet<PaymentService> PaymentServices { get; set; }
    }
}
