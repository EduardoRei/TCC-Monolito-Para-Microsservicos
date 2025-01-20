namespace Ecommerce.Migrations.Entities {
    public class Pedido {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdPagamento { get; set; }
        public int IdStatusPedido { get; set; }
        public long PrecoTotal {  get; set; }
        public DateTime? DataPagamento { get; set; }

        // Relacionamentos
        public Usuario Usuario { get; set; }
        public Pagamento Pagamento { get; set; }
        public StatusPedido StatusPedido { get; set; }
        public ICollection<ProdutoPedido> ProdutoPedido { get; set; }
    }
}
