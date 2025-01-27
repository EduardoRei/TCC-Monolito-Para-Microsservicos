﻿using Ecommerce.Commons.Enums;

namespace Ecommerce.Monolito.Core.Dtos
{
    public class PedidoDto
    {
        public int IdUsuario { get; set; }
        public int? IdPagamento { get; set; }
        public StatusPedidoEnum StatusPedido { get; set; }
        public FormaPagamentoEnum FormaPagamento { get; set; }
        public long PrecoTotal { get; set; }

        public List<ProdutoPedidoDto> ProdutoPedido { get; set; }
    }
}
