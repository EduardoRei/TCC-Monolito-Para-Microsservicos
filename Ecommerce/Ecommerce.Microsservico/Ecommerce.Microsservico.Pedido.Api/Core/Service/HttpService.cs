using Ecommerce.Microsservico.Pedido.Api.Core.Interface;
using System.Text;

namespace Ecommerce.Microsservico.Pedido.Api.Core.Service
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T?> GetAsync<T>(string serviceName, string uri)
        {
            var client = _httpClientFactory.CreateClient(serviceName);
            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T?>(); // Use ReadFromJsonAsync instead of ReadAsAsync
        }
    }
}
