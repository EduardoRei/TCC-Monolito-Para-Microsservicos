using Ecommerce.Commons.Entities;
using Ecommerce.DbMigrator.Context;
using Ecommerce.Monolito.Core.Base;
using Ecommerce.Monolito.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Monolito.Core.Service
{
    public class PagamentoService : ServiceBase<EcommerceDbContext>, IPagamentoService
    {
        public PagamentoService(EcommerceDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Pagamento> GetByIdAsync(int id)
        {
            var pagamento = await DbContext.Pagamento
                .Include(p => p.Pedido)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pagamento?.Id == 00 || pagamento == null || pagamento.Equals(new Pagamento()))
                return new Pagamento();

            return pagamento;
        }

        public async Task<IEnumerable<Pagamento>> GetAllAsync()
        {
            return await DbContext.Pagamento.ToListAsync();
        }

        public async Task AddAsync(Pagamento pagamento)
        {
            DbContext.Pagamento.Add(pagamento);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pagamento pagamento)
        {
            DbContext.Pagamento.Update(pagamento);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pagamento = await GetByIdAsync(id);
            if (pagamento != null)
            {
                DbContext.Pagamento.Remove(pagamento);
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
