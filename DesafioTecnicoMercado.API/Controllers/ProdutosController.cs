using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnicoMercado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateProduto()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduto(Guid id)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllProdutos()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetProdutoById(Guid id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(Guid id)
        {
            return Ok();
        }
    }
}
