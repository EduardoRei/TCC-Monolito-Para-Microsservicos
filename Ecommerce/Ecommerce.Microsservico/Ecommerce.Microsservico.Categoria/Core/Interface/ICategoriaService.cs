using Ecommerce.Commons.Dtos;

namespace Ecommerce.Microsservico.Categoria.Api.Core.Interface
{
    public interface ICategoriaService
    {
        Task<CategoriaDto?> GetCategoriaByIdAsync(int? id);
        Task<List<CategoriaDto>> GetAllCategoriasAsync();
        Task AddCategoriaAsync(CategoriaDto categoria);
        Task UpdateCategoriaAsync(CategoriaDto categoria);
        Task DeleteCategoriaByIdAsync(int id);
        Task<bool> ExisteNomeCategoriaAsync(string nome);
        Task<bool> ExisteCategoriaAsync(int? id);
    }
}
