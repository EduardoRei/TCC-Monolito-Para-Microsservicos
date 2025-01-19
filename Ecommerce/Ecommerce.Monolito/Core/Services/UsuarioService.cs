using Ecommerce.Migrations.Context;
using Ecommerce.Migrations.Entities;
using Ecommerce.Monolito.Core.Base;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Ecommerce.Monolito.Core.Services {
    public class UsuarioService : ServiceBase<EcommerceDbContext>, IUsuarioService
    {
        public UsuarioService(EcommerceDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddUsuarioAsync(Usuario usuario)
        {
            await DbContext.AddAsync(usuario);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteUsuarioByIdAsync(int id)
        {
            var usuario = await GetUsuarioByIdAsync(id);
            if (usuario != null)
            {
                DbContext.Usuarios.Remove(usuario);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<(bool existe, string campoExistente)> ExisteUsuarioAsync(string email, string cpf)
        {
            var listaUsuarios = await DbContext.Usuarios.Where(x => x.Email == email || x.CPF == cpf).ToListAsync();

            if(listaUsuarios.Count > 0)
                return (false, " ");

            var sb = new StringBuilder();
            bool cpfCadastrado = false;

            if (listaUsuarios.Any(x => x.CPF == cpf))
            {
                cpfCadastrado = true;
                sb.Append($"Ja existe um usario com o Cpf {cpf} cadastrado");
            }

            if (listaUsuarios.Any(x => x.Email == email))
                if(cpfCadastrado)
                    sb.Append($" e ja existe um usuario com o email {email} esta cadastrado.");
                else
                    sb.Append($"Ja existe um usario cadastarado com o email {email}.");
                

            return (true, sb.ToString()) ;
        }

        public async Task<List<Usuario>> GetAllUsuariosAsync() =>
            await DbContext.Usuarios.ToListAsync();

        public async Task<Usuario> GetUsuarioByIdAsync(int? id)
        {
            var usuario = await DbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (usuario == null)
                return new Usuario();

            return usuario;
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            DbContext.Update(usuario);
            await DbContext.SaveChangesAsync();
        }
    }
}
