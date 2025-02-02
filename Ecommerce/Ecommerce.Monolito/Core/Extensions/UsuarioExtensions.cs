using Ecommerce.Commons.Entities;
using Ecommerce.Monolito.Core.Dtos;

namespace Ecommerce.Monolito.Core.Extensions
{
    public static class UsuarioExtensions
    {
        public static UsuarioDto ToDto(this Usuario usuario)
        => new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                DataNascimento = usuario.DataNascimento,
                Endereco = usuario.Endereco
            };

        public static Usuario ToEntity(this UsuarioDto usuario)
            => new Usuario
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                DataNascimento = usuario.DataNascimento,
                Endereco = usuario.Endereco
            };
    }
}
