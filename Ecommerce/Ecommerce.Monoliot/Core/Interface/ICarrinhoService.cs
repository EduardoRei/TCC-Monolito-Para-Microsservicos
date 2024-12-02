using Ecommerce.Migrations.Entities;

namespace Ecommerce.Monolito.Core.Services
{
    public interface ICarrinhoService
    {
        Task<Carrinho> GetByIdAsync(int id);
        Task<IEnumerable<Carrinho>> GetAllAsync();
        Task AddAsync(Carrinho carrinho);
        Task UpdateAsync(Carrinho carrinho);
        Task DeleteAsync(int id);
    }
}
