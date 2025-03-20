using System.Text;

namespace RabbitMqConsumer
{
    public interface IHttpClientService
    {
        Task PostCriarPagamentoAsync(string message);
        Task PutQuantidadeProdutoAsync(string message);
        Task PutStatusPagamentoAsync(string message);
        Task PutPedidoIdPagamentoAsync(string message);
    }

    public class HttpClientService : IHttpClientService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private const string PagamentoApiUrl = "http://pagamento-api:8080/api/Pagamento/";
        private const string ProdutoApiUrl = "http://produto-api:8080/api/Produto/";
        private const string PedidoApiUrl = "http://pedido-api:8080/api/Pedido/";

        public async Task PostCriarPagamentoAsync(string message)
        {
            Console.WriteLine(message);
            await PostAsync(PagamentoApiUrl, message);
        }

        public async Task PutQuantidadeProdutoAsync(string message)
        {
            Console.WriteLine(message);
            await PutAsync($"{ProdutoApiUrl}UpdateQuantidadeEstoqueProduto", message);
        }

        public async Task PutStatusPagamentoAsync(string message)
        {
            Console.WriteLine(message);
            await PutAsync($"{PagamentoApiUrl}AlterarStatusPagamento", message);
        }

        public async Task PutPedidoIdPagamentoAsync(string message)
        {
            Console.WriteLine(message);
            await PutAsync($"{PedidoApiUrl}AtualizarIdPagamento", message);
        }

        private async Task PostAsync(string url, string message)
        {
            var jsonContent = new StringContent(message, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, jsonContent);
            response.EnsureSuccessStatusCode();
        }

        private async Task PutAsync(string url, string message)
        {
            var jsonContent = new StringContent(message, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, jsonContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
