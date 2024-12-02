using Ecommerce.Migrations.Entities;

namespace Ecommerce.Monolito.Core.Interface {
    public interface ICategoriaService {
        Task<Categoria> GetCategoriaByIdAsync(int? id);
        Task<List<Categoria>> GetAllCategoriasAsync();
        Task AddCategoriaAsync(Categoria categoria);
        Task UpdateCategoriaAsync(Categoria categoria);
        Task DeleteCategoriaByIdAsync(int id);
        Task<bool> ExisteCategoriaAsync(string nome);
    }
}
