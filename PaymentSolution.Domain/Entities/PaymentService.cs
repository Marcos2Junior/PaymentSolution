using System.ComponentModel.DataAnnotations;

namespace PaymentSolution.Domain.Entities
{
    public class PaymentService : BaseEntity
    {
        public PaymentServiceType PaymentServiceType { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public string ClientID { get; set; }
        public string Secret { get; set; }
        public string ApiKey { get; set; }
        /// <summary>
        /// Nossa aplicacao sera responsavel por receber as notificacoes de pagamento e apos tratar ira disparar a notificacao ao cliente caso forneca um endpoint
        /// </summary>
        public string WebHook { get; set; }
        public bool UseCertificate { get; set; }
        public string Scope { get; set; }
    }

    public enum PaymentServiceType
    {
        GerenciaNet = 1,
        BancoBrasil = 2,
        Santander = 3
    }
}