using Ecommerce.Migrations.Context;
using Ecommerce.Migrations.Entities;
using Ecommerce.Monolito.Core.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Monolito.Core.Services {
    public class PagamentoService : ServiceBase<EcommerceDbContext>, IPagamentoService
    {
        public PagamentoService(EcommerceDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Pagamento> GetByIdAsync(int id)
        {
            var pagamento = await DbContext.Pagamentos
                .Include(p => p.Usuario)
                .Include(p => p.Carrinho)
                .Include(p => p.TipoPagamento)
                .Include(p => p.StatusPagamento)
                .FirstOrDefaultAsync(p => p.Id == id);

            if(pagamento.Id == 00 || pagamento == null || pagamento.Equals(new Pagamento()))
                return new Pagamento();

            return pagamento;
        }

        public async Task<IEnumerable<Pagamento>> GetAllAsync()
        {
            return await DbContext.Pagamentos.ToListAsync();
        }

        public async Task AddAsync(Pagamento pagamento)
        {
            DbContext.Pagamentos.Add(pagamento);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pagamento pagamento)
        {
            DbContext.Pagamentos.Update(pagamento);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pagamento = await GetByIdAsync(id);
            if (pagamento != null)
            {
                DbContext.Pagamentos.Remove(pagamento);
                await DbContext.SaveChangesAsync();
            }
        }
    }

}
