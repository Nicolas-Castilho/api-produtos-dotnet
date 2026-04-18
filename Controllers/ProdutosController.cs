using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApi.Models;
using MinhaPrimeiraApi.Services;
using MInhaPrimeiraApi.DTOs;

namespace MinhaPrimeiraApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _service;

        public ProdutosController(ProdutoService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> GetById(int id)
        {
            var produto = _service.GetById(id);

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult Post(ProdutoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var produto = _service.Create(dto.Nome, dto.Preco);

            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProdutoDto dto)
        {
            var atualizado = _service.Update(id, dto.Nome, dto.Preco);

            if (!atualizado)
                return NotFound();

            return NoContent();
        }

    }
}