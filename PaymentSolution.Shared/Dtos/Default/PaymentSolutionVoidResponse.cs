using System.Text.Json.Serialization;

namespace PaymentSolution.Shared.Dtos.Default
{
    public class PaymentSolutionVoidResponse
    {
        /// <summary>
        /// Indica se a requisicao ocorreu como o esperado
        /// </summary>
        public bool Success { get; private set; }
        /// <summary>
        /// Detalhes sobre a requisicao
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// </summary>
        /// <param name="success">Indica se a requisicao ocorreu como o esperado</param>
        /// <param name="message">Detalhes sobre a requisicao</param>
        [JsonConstructor]
        public PaymentSolutionVoidResponse(bool success, string message = null)
        {
            Initialize(success, message);
        }

        /// <summary>
        /// Define resposta como falha
        /// </summary>
        /// <param name="message">Detalhes sobre a requisicao</param>
        public PaymentSolutionVoidResponse(string message = null)
        {
            Initialize(false, message);
        }

        private void Initialize(bool success, string message = null)
        {
            if (string.IsNullOrEmpty(message))
            {
                message = success ? "Operação realizada com sucesso" : "Operação não obteve sucesso";
            }
            Message = message;
            Success = success;
        }
    }
}
