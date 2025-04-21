using Ecommerce.Commons.Enums;

namespace Ecommerce.Microsservico.Produto.Api.Core.Entities
{
    public record MensagemProdutoAlterado(int IdProduto, AlteracaoProdutoEnum AlteracaoProduto);
}
