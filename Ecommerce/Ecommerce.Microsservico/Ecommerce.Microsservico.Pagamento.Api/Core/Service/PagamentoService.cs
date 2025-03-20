using Ecommerce.Commons.Core.Base;
using Ecommerce.Commons.Dtos;
using Ecommerce.Microsservico.Pagamento.Api.Core.Interface;
using Ecommerce.Commons.Extensions;
using Ecommerce.Microsservico.Pagamento.DbMigrator.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Microsservico.Pagamento.Api.Core.Service
{
    public class PagamentoService : ServiceBase<PagamentoDbContext>, IPagamentoService
    {
        public PagamentoService(PagamentoDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<PagamentoDto?> GetByIdAsync(int id)
            => await DbContext.Pagamento
                .Where(p => p.Id == id)
                .Select(p => p.ToDto())
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<PagamentoDto>> GetAllAsync()
            => await DbContext.Pagamento
                .Select(p => p.ToDto())
                .ToListAsync();

        public async Task AddAsync(PagamentoDto pagamento)
        {
            var entity = pagamento.ToEntity();
            DbContext.Pagamento.Add(entity);
            await DbContext.SaveChangesAsync();
            pagamento.Id = entity.Id;
        }

        public async Task UpdateAsync(PagamentoDto pagamento)
        {
            var existingEntity = await DbContext.Pagamento.FindAsync(pagamento.Id);
            if (existingEntity != null)
            {
                DbContext.Entry(existingEntity).CurrentValues.SetValues(pagamento.ToEntity());
                await DbContext.SaveChangesAsync();
            }
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
