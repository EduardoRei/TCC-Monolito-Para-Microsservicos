using Ecommerce.Commons.Entities;
using Ecommerce.Commons.Dtos;

namespace Ecommerce.Commons.Extensions
{
    public static class ProdutoExtensions
    {
        public static ProdutoDto ToDto(this Produto produto)
            => new ProdutoDto
            {
                Id = produto.Id,
                IdCategoria = produto.IdCategoria,
                Nome = produto.Nome,
                PrecoUnitario = produto.PrecoUnitario,
                Descricao = produto.Descricao,
                QuantidadeEstoque = produto.QuantidadeEstoque
            };

        public static Produto ToEntity(this ProdutoDto produto)
            => new Produto
            {
                Id = produto.Id,
                IdCategoria = produto.IdCategoria ?? 0,
                Nome = produto.Nome,
                PrecoUnitario = produto.PrecoUnitario ?? 0,
                Descricao = produto.Descricao,
                QuantidadeEstoque = produto.QuantidadeEstoque ?? 0
            };
    }
}
