using Ecommerce.Commons.Entities;
using Ecommerce.Monolito.Core.Dtos;

namespace Ecommerce.Monolito.Core.Extensions
{
    public static class CategoriaExtensions
    {
        public static CategoriaDto ToDto(this Categoria categoria)
            => new CategoriaDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            };

        public static Categoria ToEntity(this CategoriaDto categoria)
            => new Categoria
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            };
    }
}
