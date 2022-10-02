using System.Security.Cryptography;
using System.Text;

namespace PaymentSolution.Application.Helpers
{
    public static class Criptography
    {
        public static string ToSHA512(this string value)
        {
            using var hashAlgorithm = SHA512.Create();
            var byteHash = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(value));
            return Convert.ToBase64String(byteHash);
        }
    }
}
