using DesafioTecnicoMercado.Domain.Dtos.Request;
using DesafioTecnicoMercado.Domain.Dtos.Response;

namespace DesafioTecnicoMercado.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        ProdutoResponseDto CadastrarProduto(ProdutoRequestDto dto);
        ProdutoResponseDto AtualizarProduto(Guid id, ProdutoRequestDto dto);
        List<ProdutoResponseDto> ListarProdutos();
        ProdutoResponseDto ObterProdutoPorId(Guid id);
        void ExcluirProduto(Guid id);
    }
}