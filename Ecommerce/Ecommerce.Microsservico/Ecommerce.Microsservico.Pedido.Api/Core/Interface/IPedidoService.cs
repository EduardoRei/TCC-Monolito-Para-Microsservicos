﻿using Ecommerce.Commons.Dtos;

namespace Ecommerce.Microsservico.Pedido.Api.Core.Interface
{
    public interface IPedidoService
    {
        Task<PedidoDto?> GetByIdAsync(int id);
        Task<IEnumerable<PedidoDto>> GetAllAsync();
        Task AddAsync(PedidoDto pedido);
        Task UpdateAsync(PedidoDto pedido);
        Task DeleteAsync(int id);
    }
}
