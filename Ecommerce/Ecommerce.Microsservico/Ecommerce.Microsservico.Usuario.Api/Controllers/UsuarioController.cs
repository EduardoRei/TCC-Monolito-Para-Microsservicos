using Ecommerce.Commons.Dtos;
using Ecommerce.Commons.Util;
using Ecommerce.Microservico.Usuario.Api.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Microservico.Usuario.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase

    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("{id}", Name = "GetUsuarioById")]
        public async Task<ActionResult<UsuarioDto>> GetUsuarioById(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }


        [HttpGet(Name = "GetAllUsuarios")]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetAllUsuarios()
        {
            var usuarios = await _usuarioService.GetAllUsuariosAsync();

            return Ok(usuarios);
        }


        [HttpDelete("{id}", Name = "DeleteUsuario")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            await _usuarioService.DeleteUsuarioByIdAsync(id);
            return NoContent();
        }



        [HttpPost(Name = "AddUsuario")]
        public async Task<ActionResult> AddUsuario(UsuarioDto usuarioDto)
        {
            if (string.IsNullOrWhiteSpace(usuarioDto.Nome) || NomeContemPalavraProibidaUtil.NomeContemPalavraProibida(usuarioDto.Nome))
                return BadRequest("Nome é obrigatório");

            if (string.IsNullOrWhiteSpace(usuarioDto.Email) || NomeContemPalavraProibidaUtil.NomeContemPalavraProibida(usuarioDto.Email))
                return BadRequest("Email é obrigatório");

            if (ValidarEmail(usuarioDto.Email))
                return BadRequest("Email é invalido");

            if (string.IsNullOrWhiteSpace(usuarioDto.Senha) || NomeContemPalavraProibidaUtil.NomeContemPalavraProibida(usuarioDto.Senha))
                return BadRequest("Senha é obrigatório");

            if (string.IsNullOrWhiteSpace(usuarioDto.Endereco) || NomeContemPalavraProibidaUtil.NomeContemPalavraProibida(usuarioDto.Endereco))
                return BadRequest("Endereco é obrigatório");

            if (string.IsNullOrWhiteSpace(usuarioDto.CPF) || NomeContemPalavraProibidaUtil.NomeContemPalavraProibida(usuarioDto.CPF))
                return BadRequest("CPF é obrigatório");

            usuarioDto.CPF = TratarCpf(usuarioDto.CPF);
            if (usuarioDto.CPF.Length != 11)
                return BadRequest("CPF invalido.");

            var (existe, mensagem) = await _usuarioService.ExisteUsuarioAsync(usuarioDto.Email, usuarioDto.CPF);

            if (existe)
                return BadRequest("Ja existe este usuario");

            await _usuarioService.AddUsuarioAsync(usuarioDto);

            return CreatedAtAction(nameof(GetUsuarioById), new { id = usuarioDto.Id }, usuarioDto);
        }


        [HttpPut("{id}", Name = "UpdateUsuario")]
        public async Task<IActionResult> UpdateUsuario(UsuarioDto usuarioDto)
        {
            if (usuarioDto.Id <= 0)
            {
                return BadRequest();
            }

            var usuario = await _usuarioService.GetUsuarioByIdAsync(usuarioDto.Id);
            if (usuario == null)
            {
                return NotFound($"Nenhum usuario foi encontrado com o id: {usuarioDto.Id}");
            }

            if (!string.IsNullOrWhiteSpace(usuarioDto.Nome) || !NomeContemPalavraProibidaUtil.NomeContemPalavraProibida(usuarioDto.Nome))
                usuario.Nome = usuarioDto.Nome;

            if (!string.IsNullOrWhiteSpace(usuarioDto.Email) || !NomeContemPalavraProibidaUtil.NomeContemPalavraProibida(usuarioDto.Email))
            {
                if (ValidarEmail(usuarioDto.Email))
                    return BadRequest("Email é invalido");
                usuario.Email = usuarioDto.Email;
            }

            if (!string.IsNullOrWhiteSpace(usuarioDto.Senha) || !NomeContemPalavraProibidaUtil.NomeContemPalavraProibida(usuarioDto.Senha))
                usuario.Senha = usuarioDto.Senha;

            if (!string.IsNullOrWhiteSpace(usuarioDto.Endereco) || !NomeContemPalavraProibidaUtil.NomeContemPalavraProibida(usuarioDto.Endereco))
                usuario.Endereco = usuarioDto.Endereco;

            if (!string.IsNullOrWhiteSpace(usuarioDto.CPF) || !NomeContemPalavraProibidaUtil.NomeContemPalavraProibida(usuarioDto.CPF))
            {
                usuarioDto.CPF = TratarCpf(usuarioDto.CPF);
                if (usuarioDto.CPF.Length != 11)
                    return BadRequest("CPF invalido.");
                usuario.CPF = usuarioDto.CPF;
            }

            await _usuarioService.UpdateUsuarioAsync(usuario);

            return NoContent();
        }

        private string TratarCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return string.Empty;

            return new string(cpf.Where(char.IsDigit).ToArray());
        }

        private bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Expressão regular para validar o formato de um e-mail.
            var regex = new System.Text.RegularExpressions.Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            return regex.IsMatch(email);
        }
    }
}
