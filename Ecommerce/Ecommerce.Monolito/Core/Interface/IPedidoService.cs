using Ecommerce.Migrations.Entities;

namespace Ecommerce.Monolito.Core.Services
{
    public interface IPedidoService
    {
        Task<Pedido> GetByIdAsync(int id);
        Task<IEnumerable<Pedido>> GetAllAsync();
        Task AddAsync(Pedido pedido);
        Task UpdateAsync(Pedido pedido);
        Task DeleteAsync(int id);
    }
}
