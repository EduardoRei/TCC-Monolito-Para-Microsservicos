using Ecommerce.Migrations.Context;
using Ecommerce.Migrations.Entities;
using Ecommerce.Monolito.Core.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Monolito.Core.Services
{
    public class CarrinhoService : ServiceBase<EcommerceDbContext>, ICarrinhoService
    {
        public CarrinhoService(EcommerceDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Carrinho> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O ID deve ser maior que zero.", nameof(id));

            var carrinho = await DbContext.Carrinhos
                .Include(c => c.Usuario)
                .Include(c => c.ProdutoCarrinhos)
                .ThenInclude(pc => pc.Produto) // Inclui detalhes de Produto se necessário
                .Include(c => c.Pedidos)
                .Include(c => c.Pagamento)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (carrinho == null || !CarrinhoValido(carrinho))
                return new Carrinho(); // Retorna um carrinho vazio se for inválido.

            return carrinho;
        }

        // Método auxiliar para validar propriedades do Carrinho.
        private bool CarrinhoValido(Carrinho carrinho)
        {
            return carrinho.Id > 0 &&
                   carrinho.Usuario != null &&
                   carrinho.ProdutoCarrinhos.Any(); // Garante pelo menos um produto no carrinho
        }

        public async Task<IEnumerable<Carrinho>> GetAllAsync()
        {
            return await DbContext.Carrinhos.ToListAsync();
        }

        public async Task AddAsync(Carrinho carrinho)
        {
            DbContext.Carrinhos.Add(carrinho);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Carrinho carrinho)
        {
            DbContext.Carrinhos.Update(carrinho);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var carrinho = await GetByIdAsync(id);
            if (carrinho != null)
            {
                DbContext.Carrinhos.Remove(carrinho);
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
