using Ecommerce.Commons.Enums;

namespace Ecommerce.Microsservico.Pedido.Api.Core.Entities
{
    public record MensagemPedidoCriadoPagamento(int IdPedido, FormaPagamentoEnum FormaPagamento, OperacaoPedidoEnum OperacaoPedido);
    public record MensagemPedidoCriadoProduto(int IdProduto, int QuantidadeVendida);

}
