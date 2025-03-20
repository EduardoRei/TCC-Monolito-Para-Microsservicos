using Ecommerce.Commons.Dtos;
using Ecommerce.Commons.Enums;
namespace Ecommerce.Monolito.Core.Interface
{
    public interface IPedidoService
    {
        Task<PedidoDto?> GetByIdAsync(int id);
        Task<IEnumerable<PedidoDto>> GetAllAsync();
        Task AddAsync(PedidoDto pedido);
        Task UpdateAsync(PedidoDto pedido);
        Task UpdatePedidoStatusAsync(int idPedido, StatusPedidoEnum statusPedido);
        Task DeleteAsync(int id);
    }
}
