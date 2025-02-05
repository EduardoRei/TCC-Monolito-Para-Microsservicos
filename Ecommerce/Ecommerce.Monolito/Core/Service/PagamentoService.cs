using Ecommerce.Commons.Dtos;
using Ecommerce.Commons.Extensions;
using Ecommerce.Monolito.DbMigrator.Context;
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

        public async Task<PagamentoDto?> GetByIdAsync(int id)
            => await DbContext.Pagamento
                .Include(p => p.Pedido)
                .Select(p => p.ToDto())
                .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<PagamentoDto>> GetAllAsync()
            => await DbContext.Pagamento
                .Include(p => p.Pedido)
                .Select(p => p.ToDto())
                .ToListAsync();

        public async Task AddAsync(PagamentoDto pagamento)
        {
            DbContext.Pagamento.Add(pagamento.ToEntity());
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PagamentoDto pagamento)
        {
            DbContext.Pagamento.Update(pagamento.ToEntity());
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pagamentoDto = await GetByIdAsync(id);
            if (pagamentoDto != null)
            {
                var pagamento = pagamentoDto.ToEntity();
                DbContext.Pagamento.Remove(pagamento);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> PagamentoExistsByIdPedido(int idPedido)
        {
            var pagamento = await DbContext.Pagamento.FirstOrDefaultAsync(x => x.IdPedido == idPedido);

            return pagamento?.Id != 0;
        }
    }
}
