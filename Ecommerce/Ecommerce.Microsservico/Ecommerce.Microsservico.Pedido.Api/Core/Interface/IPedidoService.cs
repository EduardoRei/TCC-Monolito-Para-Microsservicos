using Ecommerce.Commons.Dtos;
using Ecommerce.Microsservico.Pedido.Api.Core.Entities;

namespace Ecommerce.Microsservico.Pedido.Api.Core.Interface
{
    public interface IPedidoService
    {
        Task<PedidoDto?> GetByIdAsync(int id);
        Task<IEnumerable<PedidoDto>> GetAllAsync();
        Task AddAsync(PedidoDto pedido, List<MensagemPedidoCriadoProduto> mensagens);
        Task UpdateAsync(PedidoDto pedido);
        Task DeleteAsync(int id);
    }
}
