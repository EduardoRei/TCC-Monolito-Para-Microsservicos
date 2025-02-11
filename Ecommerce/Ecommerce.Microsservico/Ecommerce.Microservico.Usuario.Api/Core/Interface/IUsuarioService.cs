using Ecommerce.Commons.Dtos;

namespace Ecommerce.Microservico.Usuario.Api.Core.Interface
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
