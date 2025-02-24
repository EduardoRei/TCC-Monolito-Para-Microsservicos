namespace Ecommerce.Microsservico.Pedido.Api.Core.Interface
{
    public interface IHttpService
    {
        Task<T> GetAsync<T>(string serviceName, string uri);
    }
}
