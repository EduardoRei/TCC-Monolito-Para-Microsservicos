using Ecommerce.Monolito.Core.Dtos;

namespace Ecommerce.Monolito.Core.Interface
{
    public interface IUsuarioService
    {
        Task<UsuarioDto?> GetUsuarioByIdAsync(int? id);
        Task<List<UsuarioDto>> GetAllUsuariosAsync();
        Task AddUsuarioAsync(UsuarioDto Usuario);
        Task UpdateUsuarioAsync(UsuarioDto Usuario);
        Task DeleteUsuarioByIdAsync(int id);
        Task<(bool existe, string campoExistente)> ExisteUsuarioAsync(string email, string cpf);
    }
}