using System.Text.Json.Serialization;

namespace PaymentSolution.Shared.Dtos.Default
{
    public class PaymentSolutionResponse<Tmodel> : PaymentSolutionVoidResponse
    {
        /// <summary>
        /// Modelo de retorno
        /// </summary>
        public Tmodel Model { get; private set; }

        /// <summary>
        /// Indica que a requisicao teve sucesso
        /// </summary>
        public PaymentSolutionResponse(Tmodel model, string message = null) : base(true, message)
        {
            Model = model;
        }

        /// <summary>
        /// Indica que a requisicao falhou/inconsistente
        /// </summary>
        public PaymentSolutionResponse(string message = null) : base(false, message)
        {
        }

        [JsonConstructor]
        public PaymentSolutionResponse(Tmodel model, string message, bool success) : base(success, message)
        {
            Model = model;
        }
    }
}
