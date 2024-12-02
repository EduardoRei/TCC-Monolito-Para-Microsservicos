namespace Ecommerce.Migrations.Entities {
    public class StatusPagamento {
        public int Id { get; set; }
        public string Status { get; set; }

        public ICollection<Pagamento> Pagamentos { get; set; }
    }
}
