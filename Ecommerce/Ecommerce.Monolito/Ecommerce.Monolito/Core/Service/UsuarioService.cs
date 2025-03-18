using Ecommerce.Commons.Dtos;
using Ecommerce.Monolito.DbMigrator.Extensions;
using Ecommerce.Monolito.DbMigrator.Context;
using Ecommerce.Commons.Core.Base;
using Ecommerce.Monolito.Core.Interface;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Ecommerce.Monolito.Core.Service
{
    public class UsuarioService : ServiceBase<EcommerceDbContext>, IUsuarioService
    {
        public UsuarioService(EcommerceDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddUsuarioAsync(UsuarioDto usuario)
        {
            var entity = usuario.ToEntity();
            await DbContext.Usuario.AddAsync(usuario.ToEntity());
            await DbContext.SaveChangesAsync();
            usuario.Id = entity.Id;
        }

        public async Task DeleteUsuarioByIdAsync(int id)
        {
            var usuarioDto = await GetUsuarioByIdAsync(id);
            if (usuarioDto != null)
            {
                var usuario = usuarioDto.ToEntity();
                DbContext.Usuario.Remove(usuario);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<(bool existe, string campoExistente)> ExisteUsuarioAsync(string email, string cpf)
        {
            var listaUsuarios = await DbContext.Usuario.Where(x => x.Email == email || x.CPF == cpf).ToListAsync();

            if (listaUsuarios.Count > 0)
                return (false, " ");

            var sb = new StringBuilder();
            bool cpfCadastrado = false;

            if (listaUsuarios.Any(x => x.CPF == cpf))
            {
                cpfCadastrado = true;
                sb.Append($"Ja existe um usario com o Cpf {cpf} cadastrado");
            }

            if (listaUsuarios.Any(x => x.Email == email))
                if (cpfCadastrado)
                    sb.Append($" e ja existe um usuario com o email {email} esta cadastrado.");
                else
                    sb.Append($"Ja existe um usario cadastarado com o email {email}.");

            return (true, sb.ToString());
        }

        public async Task<List<UsuarioDto>> GetAllUsuariosAsync() =>
            await DbContext.Usuario.Select(p => p.ToDto()).ToListAsync();

        public async Task<UsuarioDto?> GetUsuarioByIdAsync(int? id) =>
            await DbContext.Usuario.Where(x => x.Id == id).Select(p => p.ToDto()).FirstOrDefaultAsync();

        public async Task UpdateUsuarioAsync(UsuarioDto usuario)
        {
            DbContext.Usuario.Update(usuario.ToEntity());
            await DbContext.SaveChangesAsync();
        }
    }
}
