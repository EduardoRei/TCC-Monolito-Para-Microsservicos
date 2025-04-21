using Ecommerce.Microsservico.Pedido.Api.Core.Interface;

namespace Ecommerce.Microsservico.Pedido.Api.Core.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HttpClient _httpClient;

        public UsuarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> UsuarioExistsAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
