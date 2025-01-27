using Ecommerce.Commons.Entities;

namespace Ecommerce.Monolito.Core.Interface
{
    public interface ICategoriaService
    {
        Task<Categoria> GetCategoriaByIdAsync(int? id);
        Task<List<Categoria>> GetAllCategoriasAsync();
        Task AddCategoriaAsync(Categoria categoria);
        Task UpdateCategoriaAsync(Categoria categoria);
        Task DeleteCategoriaByIdAsync(int id);
        Task<bool> ExisteNomeCategoriaAsync(string nome);
        Task<bool> ExisteCategoriaAsync(int? id);
    }
}
