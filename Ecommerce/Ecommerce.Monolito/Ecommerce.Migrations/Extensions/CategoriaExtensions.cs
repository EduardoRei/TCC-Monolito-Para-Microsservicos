using Ecommerce.Commons.Dtos;
using Ecommerce.Monolito.DbMigrator.Entities;

namespace Ecommerce.Monolito.DbMigrator.Extensions
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
