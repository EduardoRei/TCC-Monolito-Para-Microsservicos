namespace Ecommerce.Migrations.Entities {
    public class StatusPedido {
        public int Id { get; set; }
        public string Status { get; set; }

        // Relacionamentos
        public ICollection<Pedido> Pedidos { get; set; }

    }
}
