using Ecommerce.Commons.Dtos;
namespace Ecommerce.Monolito.Core.Interface
{
    public interface IProdutoService
    {
        Task<ProdutoDto?> GetProdutoByIdAsync(int? id);
        Task<int> GetQuantidadeProdutoByIdAsync(int? id);
        Task<List<ProdutoDto>> GetListaProdutosByIdListAsync(List<int> listaIds);
        Task<List<ProdutoDto>> GetAllProdutosAsync();
        Task AddProdutoAsync(ProdutoDto produto);
        Task UpdateProdutoAsync(ProdutoDto produto);
        Task RemoverQuantidadeProdutoAsync(int id, int quantidade);
        Task DeleteProdutoByIdAsync(int id);
        Task<bool> ExisteProdutoAsync(string nome, int? idCategoria);
    }
}
