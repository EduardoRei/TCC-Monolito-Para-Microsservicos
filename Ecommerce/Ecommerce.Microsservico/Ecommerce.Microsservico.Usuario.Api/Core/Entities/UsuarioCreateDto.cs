namespace Ecommerce.Microsservico.Usuario.Api.Core.Entities
{
    public class UsuarioCreateDto
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Endereco { get; set; }
        public required string CPF { get; set; }
        public required string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCriacaoUsuario { get; set; }
    }
}
