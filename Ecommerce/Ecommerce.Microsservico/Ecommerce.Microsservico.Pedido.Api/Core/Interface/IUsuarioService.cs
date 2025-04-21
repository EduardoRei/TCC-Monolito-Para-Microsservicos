namespace Ecommerce.Microsservico.Pedido.Api.Core.Interface
{
    public interface IUsuarioService
    {
        Task<bool> UsuarioExistsAsync(int id);
    }
}
