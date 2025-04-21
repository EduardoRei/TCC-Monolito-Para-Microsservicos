using Ecommerce.Commons.Core.Base;
using Ecommerce.Commons.Dtos;
using Ecommerce.Commons.Enums;
using Ecommerce.Commons.Extensions;
using Ecommerce.Commons.RabbitMq.Producer;
using Ecommerce.Microsservico.Pedido.Api.Core.Entities;
using Ecommerce.Microsservico.Pedido.Api.Core.Interface;
using Ecommerce.Microsservico.Pedido.DbMigrator.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Microsservico.Pedido.Api.Core.Service
{
    public class PedidoService : ServiceBase<PedidoDbContext>, IPedidoService
    {
        private readonly IMessageProducer _producer;

        public PedidoService(
            PedidoDbContext dbContext,
            IMessageProducer producer) : base(dbContext)
        {
            _producer = producer;
        }

        public async Task<PedidoDto?> GetByIdAsync(int id)
        {
            return await DbContext.Pedido
                .Include(p => p.ProdutoPedido)
                .Where(p => p.Id == id)
                .Select(p => p.ToDto())
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PedidoDto>> GetAllAsync()
            => await DbContext.Pedido
                .Include(p => p.ProdutoPedido)
                .Select(p => p.ToDto())
                .ToListAsync();

        public async Task AddAsync(PedidoDto pedido, List<MensagemPedidoCriadoProduto> mensagens)
        {
            await using var transaction = await DbContext.Database.BeginTransactionAsync();
            try
            {
                var entity = pedido.ToEntity();

                foreach (var produtoPedido in entity.ProdutoPedido)
                {
                    produtoPedido.Pedido = entity;
                }

                DbContext.Pedido.Add(entity);
                await DbContext.SaveChangesAsync();

                pedido.Id = entity.Id;

                var tasks = mensagens.Select(mensagem =>
                    _producer.SendMessage(mensagem, RabbitMqQueueEnum.PedidoQueue, RabbitMqRoutingKeyEnum.PedidoProduto)).ToList();

                await Task.WhenAll(tasks);

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateAsync(PedidoDto pedido)
        {
            var existingEntity = await DbContext.Pedido.FindAsync(pedido.Id);
            if (existingEntity != null)
            {
                DbContext.Entry(existingEntity).CurrentValues.SetValues(pedido.ToEntity());
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var pedidoDto = await GetByIdAsync(id);
            if (pedidoDto != null)
            {
                var pedido = pedidoDto.ToEntity();
                DbContext.Pedido.Remove(pedido);
            }
        }
    }
}
