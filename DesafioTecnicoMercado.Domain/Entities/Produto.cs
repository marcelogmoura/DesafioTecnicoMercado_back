using DesafioTecnicoMercado.Domain.Enums;

namespace DesafioTecnicoMercado.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }

        public Guid CategoriaId { get; set; }
        public Categoria? Categoria { get; set; } = new();

    }
}
