using Ecommerce.Migrations.Entities;

namespace Ecommerce.Monolito.Core.Interface {
    public interface IProdutoCarrinhoService
    {
        Task<ProdutoPedido> GetByIdAsync(int idCarrinho, int idProduto);
        Task<IEnumerable<ProdutoPedido>> GetAllAsync();
        Task AddAsync(ProdutoPedido produtoCarrinho);
        Task UpdateAsync(ProdutoPedido produtoCarrinho);
        Task DeleteAsync(int idCarrinho, int idProduto);
    }
}
