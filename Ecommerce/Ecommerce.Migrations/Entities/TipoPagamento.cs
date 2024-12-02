namespace Ecommerce.Migrations.Entities {
    public class TipoPagamento {
        public int Id { get; set; }
        public string Tipo { get; set; }

        // Relacionamentos
        public ICollection<Pagamento> Pagamentos { get; set; }
    }
}
