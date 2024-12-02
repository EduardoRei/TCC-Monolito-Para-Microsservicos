namespace Ecommerce.Migrations.Entities {
    public class Usuario {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Endereco { get; set; }

        // Relacionamentos
        public ICollection<Carrinho> Carrinhos { get; set; }
        public ICollection<Pagamento> Pagamentos { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
    }
}
