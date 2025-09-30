using DesafioTecnicoMercado.Domain.Dtos.Request;
using DesafioTecnicoMercado.Domain.Interfaces.Services;
using DesafioTecnicoMercado.Domain.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnicoMercado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService=produtoService;
        }

        [HttpPost]
        public IActionResult CreateProduto([FromBody] ProdutoRequestDto dto)
        {
            try
            {
                var response = _produtoService.CadastrarProduto(dto);
                return StatusCode(201, dto);
            }
            catch(ValidationException e)
            {
                var errors = e.Errors.Select(error => error.ErrorMessage);
                return BadRequest(errors);
            }
            catch (DomainValidationException e)
            {                
                return UnprocessableEntity(new { Message = e.Message });
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduto(Guid id)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllProdutos()
        {
            try
            {
                var produtos = _produtoService.ListarProdutos();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProdutoById(Guid id)
        {

            try
            {                
                var produto = _produtoService.ObterProdutoPorId(id);                             
                return Ok(produto);
            }            
            catch (DomainValidationException e)
            {             
                return NotFound(new { Message = e.Message });
            }
            catch (Exception e)
            {             
                return StatusCode(500, new { Message = "Erro inesperado ao buscar o produto." });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(Guid id)
        {
            return Ok();
        }
    }
}
