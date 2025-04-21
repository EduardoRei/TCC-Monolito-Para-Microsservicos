using Ecommerce.Commons.Dtos;

namespace Ecommerce.Microsservico.Pedido.Api.Core.Interface
{
    public interface IProdutoService
    {
        Task<List<ProdutoDto>> GetListaProdutosAsync(List<int> listaIds);
    }
}
