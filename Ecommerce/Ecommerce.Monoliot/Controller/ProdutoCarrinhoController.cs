using Ecommerce.Migrations.Entities;
using Ecommerce.Monolito.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Monolito.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoCarrinhoController : ControllerBase
    {
        private readonly IProdutoCarrinhoService _service;

        public ProdutoCarrinhoController(IProdutoCarrinhoService service)
        {
            _service = service;
        }

        [HttpGet("{idCarrinho}/{idProduto}")]
        public async Task<IActionResult> Get(int idCarrinho, int idProduto)
        {
            var produtoCarrinho = await _service.GetByIdAsync(idCarrinho, idProduto);
            if (produtoCarrinho == null)
                return NotFound();

            return Ok(produtoCarrinho);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var produtosCarrinho = await _service.GetAllAsync();
            return Ok(produtosCarrinho);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProdutoCarrinho produtoCarrinho)
        {
            await _service.AddAsync(produtoCarrinho);
            return CreatedAtAction(nameof(Get), new { idCarrinho = produtoCarrinho.IdCarrinho, idProduto = produtoCarrinho.IdProduto }, produtoCarrinho);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProdutoCarrinho produtoCarrinho)
        {
            await _service.UpdateAsync(produtoCarrinho);
            return NoContent();
        }

        [HttpDelete("{idCarrinho}/{idProduto}")]
        public async Task<IActionResult> Delete(int idCarrinho, int idProduto)
        {
            await _service.DeleteAsync(idCarrinho, idProduto);
            return NoContent();
        }
    }
}
