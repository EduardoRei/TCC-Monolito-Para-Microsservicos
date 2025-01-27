using Ecommerce.Commons.Entities;

namespace Ecommerce.Monolito.Core.Interface
{
    public interface IPagamentoService
    {
        Task<Pagamento> GetByIdAsync(int id);
        Task<IEnumerable<Pagamento>> GetAllAsync();
        Task<bool> PagamentoExistsByIdPedido(int idPedido);
        Task AddAsync(Pagamento pagamento);
        Task UpdateAsync(Pagamento pagamento);
        Task DeleteAsync(int id); 
    }
}
