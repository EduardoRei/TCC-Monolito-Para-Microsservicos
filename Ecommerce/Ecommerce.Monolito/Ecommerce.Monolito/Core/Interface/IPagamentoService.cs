using Ecommerce.Commons.Dtos;
namespace Ecommerce.Monolito.Core.Interface
{
    public interface IPagamentoService
    {
        Task<PagamentoDto?> GetByIdAsync(int id);
        Task<IEnumerable<PagamentoDto>> GetAllAsync();
        Task<bool> PagamentoExistsByIdPedido(int idPedido);
        Task AddAsync(PagamentoDto pagamento);
        Task UpdateAsync(PagamentoDto pagamento);
        Task DeleteAsync(int id); 
    }
}
