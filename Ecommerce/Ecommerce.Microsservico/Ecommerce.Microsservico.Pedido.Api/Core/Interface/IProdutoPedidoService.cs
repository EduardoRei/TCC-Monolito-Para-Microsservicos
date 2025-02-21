using Ecommerce.Commons.Dtos;

namespace Ecommerce.Microsservico.Pedido.Api.Core.Interface
{
    public interface IProdutoPedidoService
    {
        Task<ProdutoPedidoDto?> GetByIdAsync(int idPedido, int idProduto);
        Task<IEnumerable<ProdutoPedidoDto>> GetAllAsync();
        Task AddAsync(ProdutoPedidoDto produtoPedido);
        Task UpdateAsync(ProdutoPedidoDto produtoPedido);
        Task DeleteAsync(int idPedido, int idProduto);
    }
}
