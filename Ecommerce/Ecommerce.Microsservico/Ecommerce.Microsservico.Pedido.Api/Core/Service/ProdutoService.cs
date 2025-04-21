using Ecommerce.Commons.Dtos;
using Ecommerce.Microsservico.Pedido.Api.Core.Interface;
using System.Text;
using System.Text.Json;

namespace Ecommerce.Microsservico.Pedido.Api.Core.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly HttpClient _httpClient;

        public ProdutoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProdutoDto>> GetListaProdutosAsync(List<int> listaIds)
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(listaIds), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("getListProdutosByListIds", jsonContent);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<ProdutoDto>>() ?? new List<ProdutoDto>();

            return new List<ProdutoDto>();
        }
    }
}
