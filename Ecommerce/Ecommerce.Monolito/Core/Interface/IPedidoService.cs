using Ecommerce.Commons.Entities;

namespace Ecommerce.Monolito.Core.Interface
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
