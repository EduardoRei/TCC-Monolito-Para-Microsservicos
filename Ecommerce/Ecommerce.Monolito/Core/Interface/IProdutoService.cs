using Ecommerce.Commons.Entities;

namespace Ecommerce.Monolito.Core.Interface
{
    public interface IProdutoService
    {
        Task<Produto> GetProdutoByIdAsync(int? id);
        Task<int> GetQuantidadeProdutoByIdAsync(int? id);
        Task<List<Produto>> GetListaProdutosByIdListAsync(List<int> listaIds);
        Task<List<Produto>> GetAllProdutosAsync();
        Task AddProdutoAsync(Produto produto);
        Task UpdateProdutoAsync(Produto produto);
        Task DeleteProdutoByIdAsync(int id);
        Task<bool> ExisteProdutoAsync(string nome, int? idCategoria);
    }
}
