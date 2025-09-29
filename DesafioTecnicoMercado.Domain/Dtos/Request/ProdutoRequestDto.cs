namespace DesafioTecnicoMercado.Domain.Dtos.Request
{
    public class ProdutoRequestDto
    {        
        public string Nome { get; set; } = string.Empty;               
        public decimal Preco { get; set; }                
        public int QuantidadeEmEstoque { get; set; }                
        public Guid CategoriaId { get; set; }
    }
}
