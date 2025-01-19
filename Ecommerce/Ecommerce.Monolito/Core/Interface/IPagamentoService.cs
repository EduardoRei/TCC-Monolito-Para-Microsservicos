using Ecommerce.Migrations.Entities;

namespace Ecommerce.Monolito.Core.Services {
    public interface IPagamentoService
    {
        Task<Pagamento> GetByIdAsync(int id);
        Task<IEnumerable<Pagamento>> GetAllAsync();
        Task AddAsync(Pagamento pagamento);
        Task UpdateAsync(Pagamento pagamento);
        Task DeleteAsync(int id);
    }
}
