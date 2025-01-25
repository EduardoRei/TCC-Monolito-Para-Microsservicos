using Ecommerce.Commons.Entities;

namespace Ecommerce.Monolito.Core.Interface
{
    public interface IProdutoPedidoService
    {
        Task<ProdutoPedido> GetByIdAsync(int idPedido, int idProduto);
        Task<IEnumerable<ProdutoPedido>> GetAllAsync();
        Task AddAsync(ProdutoPedido produtoPedido);
        Task UpdateAsync(ProdutoPedido produtoPedido);
        Task DeleteAsync(int idPedido, int idProduto);
    }
}
