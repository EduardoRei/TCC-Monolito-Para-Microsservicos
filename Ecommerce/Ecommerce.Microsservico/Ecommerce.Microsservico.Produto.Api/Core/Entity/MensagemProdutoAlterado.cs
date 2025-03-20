using Ecommerce.Commons.Enums;

namespace Ecommerce.Microsservico.Produto.Api.Core.Entity
{
    public record MensagemProdutoAlterado(int IdProduto, AlteracaoProdutoEnum AlteracaoProduto);
}
