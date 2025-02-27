﻿using Ecommerce.Monolito.DbMigrator.Entities;
using Ecommerce.Commons.Dtos;

namespace Ecommerce.Monolito.DbMigrator.Extensions
{
    public static class ProdutoPedidoExtensions
    {
        public static ProdutoPedidoDto ToDto(this ProdutoPedido produtoPedido)
            => new ProdutoPedidoDto
            {
                
                Id = produtoPedido.Id,
                IdPedido = produtoPedido.IdPedido,
                IdProduto = produtoPedido.IdProduto,
                Quantidade_Produto = produtoPedido.Quantidade_Produto
            };

        public static ProdutoPedido ToEntity(this ProdutoPedidoDto produtoPedido)
            => new ProdutoPedido
            {

                Id = produtoPedido.Id,
                IdPedido = produtoPedido.IdPedido,
                IdProduto = produtoPedido.IdProduto,
                Quantidade_Produto = produtoPedido.Quantidade_Produto
            };
    }
}
