﻿namespace Ecommerce.Commons.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCriacaoUsuario { get; set; }
    }
}
