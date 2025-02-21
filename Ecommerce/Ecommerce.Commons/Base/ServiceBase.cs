using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Commons.Core.Base
{
    public abstract class ServiceBase<TContext> where TContext : DbContext
    {
        protected readonly TContext DbContext;

        protected ServiceBase(TContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Salva as alterações no banco de dados.
        /// </summary>
        /// <returns>O número de entradas no banco de dados afetadas.</returns>
        public virtual int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        /// <summary>
        /// Salva as alterações no banco de dados de forma assíncrona.
        /// </summary>
        /// <returns>O número de entradas no banco de dados afetadas.</returns>
        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await DbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Método para liberar recursos do DbContext.
        /// </summary>
        public virtual void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
