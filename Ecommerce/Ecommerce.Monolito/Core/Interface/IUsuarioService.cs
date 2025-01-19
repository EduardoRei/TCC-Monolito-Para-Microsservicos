using Ecommerce.Migrations.Entities;

namespace Ecommerce.Monolito.Core.Services {
    public interface IUsuarioService {
        Task<Usuario> GetUsuarioByIdAsync(int? id);
        Task<List<Usuario>> GetAllUsuariosAsync();
        Task AddUsuarioAsync(Usuario Usuario);
        Task UpdateUsuarioAsync(Usuario Usuario);
        Task DeleteUsuarioByIdAsync(int id);
        Task<(bool existe, string campoExistente)> ExisteUsuarioAsync(string email, string cpf);
    }
}
