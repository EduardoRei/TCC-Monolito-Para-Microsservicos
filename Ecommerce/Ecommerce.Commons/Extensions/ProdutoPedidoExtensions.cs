﻿using Ecommerce.Commons.Entities;
using Ecommerce.Commons.Dtos;

namespace Ecommerce.Commons.Extensions
{
    public static class ProdutoPedidoExtensions
    {
        public static ProdutoPedidoDto ToDto(this ProdutoPedido produtoPedido)
            => new ProdutoPedidoDto
            {
                
                IdPedido = produtoPedido.IdPedido,
                IdProduto = produtoPedido.IdProduto,
                QuantidadeProduto = produtoPedido.Quantidade_Produto
            };

        public static ProdutoPedido ToEntity(this ProdutoPedidoDto produtoPedido)
            => new ProdutoPedido
            {

                IdPedido = produtoPedido.IdPedido,
                IdProduto = produtoPedido.IdProduto,
                Quantidade_Produto = produtoPedido.QuantidadeProduto
            };
    }
}
