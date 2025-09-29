using DesafioTecnicoMercado.Domain.Enums;

namespace DesafioTecnicoMercado.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public Categoria? Categoria { get; set; }

    }
}
