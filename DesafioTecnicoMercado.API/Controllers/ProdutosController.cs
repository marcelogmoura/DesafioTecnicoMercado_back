using DesafioTecnicoMercado.Domain.Dtos.Request;
using DesafioTecnicoMercado.Domain.Interfaces.Services;
using FluentValidation;
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
        public IActionResult UpdateProduto(Guid id, [FromBody] ProdutoRequestDto request)
        {
            try
            {
                var produtoAtualizado = _produtoService.AtualizarProduto(id, request);   
                return Ok(produtoAtualizado);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { mensagem = "Produto não encontrado." });
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { erro = "Ocorreu um erro ao atualizar o produto.", detalhes = ex.Message });
            }
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
            try
            {
                var produto = _produtoService.ObterProdutoPorId(id); 

                if (produto == null)
                {
                    return NotFound(new { Message = "Produto não encontrado." });
                }

                if (produto.QuantidadeEmEstoque > 0)
                {
                    var mensagem = $"Não foi possível deletar '{produto.Nome}', atualmente com {produto.QuantidadeEmEstoque} unidades em estoque.";
                    return BadRequest(new { Message = mensagem });
                }

                _produtoService.ExcluirProduto(id);

                return Ok(new
                {
                    Message = "Produto removido com sucesso.",
                    Produto = 
                        produto.Id, 
                        produto .Nome
                });
            }
            catch (DomainValidationException e)
            {
                return NotFound(new { Message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Erro inesperado ao deletar o produto." });
            }            
        }
    }
}
