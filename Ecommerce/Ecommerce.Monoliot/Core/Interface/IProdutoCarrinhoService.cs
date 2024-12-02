using Ecommerce.Migrations.Entities;

namespace Ecommerce.Monolito.Core.Interface {
    public interface IProdutoCarrinhoService
    {
        Task<ProdutoCarrinho> GetByIdAsync(int idCarrinho, int idProduto);
        Task<IEnumerable<ProdutoCarrinho>> GetAllAsync();
        Task AddAsync(ProdutoCarrinho produtoCarrinho);
        Task UpdateAsync(ProdutoCarrinho produtoCarrinho);
        Task DeleteAsync(int idCarrinho, int idProduto);
    }
}
