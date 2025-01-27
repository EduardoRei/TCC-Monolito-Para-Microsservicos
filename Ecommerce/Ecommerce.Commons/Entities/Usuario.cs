namespace Ecommerce.Commons.Entities {
    public class Usuario {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCriacaoUsuario { get; set; }


        // Relacionamentos
        public ICollection<Pedido> Pedido { get; set; }
    }
}
