using Ecommerce.Commons.Core.Base;
using Ecommerce.Commons.Dtos;
using Ecommerce.Commons.Extensions;
using Ecommerce.Microservico.Usuario.Api.Core.Interface;
using Ecommerce.Microsservico.Usuario.DbMigrator.Context;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Ecommerce.Microservico.Usuario.Api.Core.Service
{
    public class UsuarioService : ServiceBase<UsuarioDbContext>, IUsuarioService
    {
        public UsuarioService(UsuarioDbContext dbContext) : base(dbContext)
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
            var listaUsuarios = await DbContext.Usuario
                .Where(x => x.Email.ToLower() == email.ToLower() || x.CPF.ToLower() == cpf.ToLower())
                .ToListAsync();

            if (listaUsuarios.Count == 0)
                return (false, string.Empty);

            var sb = new StringBuilder();
            bool cpfCadastrado = listaUsuarios.Any(x => x.CPF == cpf);
            bool emailCadastrado = listaUsuarios.Any(x => x.Email == email);

            if (cpfCadastrado)
                sb.Append($"Já existe um usuário com o CPF {cpf} cadastrado");

            if (emailCadastrado)
            {
                if (cpfCadastrado)
                    sb.Append(" e ");
                sb.Append($"já existe um usuário com o email {email} cadastrado.");
            }

            return (true, sb.ToString());
        }

        public async Task<List<UsuarioDto>> GetAllUsuariosAsync() =>
            await DbContext.Usuario.Select(p => p.ToDto()).ToListAsync();

        public async Task<UsuarioDto?> GetUsuarioByIdAsync(int? id) =>
            await DbContext.Usuario
            .Where(x => x.Id == id)
            .Select(p => p.ToDto())
            .FirstOrDefaultAsync();

        public async Task UpdateUsuarioAsync(UsuarioDto usuario)
        {
            var existingEntity = await DbContext.Usuario.FindAsync(usuario.Id);
            if (existingEntity != null)
            {
                DbContext.Entry(existingEntity).CurrentValues.SetValues(usuario.ToEntity());
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
