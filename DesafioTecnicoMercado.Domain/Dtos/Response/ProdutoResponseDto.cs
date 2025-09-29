namespace DesafioTecnicoMercado.Domain.Dtos.Response
{
    public class ProdutoResponseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
                
        public Guid CategoriaId { get; set; }
        public string CategoriaNome { get; set; } = string.Empty;
    }
}
