using Ecommerce.Commons.Entities;

namespace Ecommerce.Monolito.Core.Interface
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuarioByIdAsync(int? id);
        Task<List<Usuario>> GetAllUsuariosAsync();
        Task AddUsuarioAsync(Usuario Usuario);
        Task UpdateUsuarioAsync(Usuario Usuario);
        Task DeleteUsuarioByIdAsync(int id);
        Task<(bool existe, string campoExistente)> ExisteUsuarioAsync(string email, string cpf);
    }
}