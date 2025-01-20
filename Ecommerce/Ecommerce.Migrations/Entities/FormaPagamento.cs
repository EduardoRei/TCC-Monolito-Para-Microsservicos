namespace Ecommerce.Migrations.Entities {
    public class FormaPagamento {
        public int Id { get; set; }
        public string Nome { get; set; }

        // Relacionamentos
        public ICollection<Pagamento> Pagamento { get; set; }
    }
}
