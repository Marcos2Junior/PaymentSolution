using PaymentSolution.Domain.Entities;
using System.Reflection;
using System.Text.Json;

namespace PaymentSolution.Infrastructure.Seeding
{
    public class SeedingService
    {
        private static bool saveChanges = false;
        public static void Seed(PaymentSolutionDataContext paymentSolutionDataContext)
        {
            ArgumentNullException.ThrowIfNull(paymentSolutionDataContext, nameof(paymentSolutionDataContext));

            paymentSolutionDataContext.Database.EnsureCreated();

            if (!paymentSolutionDataContext.Users.Any()) Add<User>("Users", paymentSolutionDataContext);
            if (!paymentSolutionDataContext.PaymentServices.Any()) Add<PaymentService>("PaymentService", paymentSolutionDataContext);

            if (saveChanges)
            {
                paymentSolutionDataContext.SaveChanges();
            }
        }

        private static void Add<Tentity>(string name, PaymentSolutionDataContext context)
        {
            string fileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"Seeding/Data/{name}.json");
            if (!File.Exists(fileName)) return;
            List<Tentity> entities = JsonSerializer.Deserialize<List<Tentity>>(File.ReadAllText(fileName));
            if (entities?.Any() == true)
            {
                foreach (var entitie in entities)
                {
                    context.Add(entitie);
                }
                saveChanges = true;
            }
        }
    }
}
