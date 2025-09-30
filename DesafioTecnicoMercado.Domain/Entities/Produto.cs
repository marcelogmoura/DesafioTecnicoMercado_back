using DesafioTecnicoMercado.Domain.Enums;

namespace DesafioTecnicoMercado.Domain.Entities
{
    public class Produto
    {
        public Produto(string nome, decimal preco, int quantidadeEmEstoque, Guid categoriaId)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Preco = preco;
            QuantidadeEmEstoque = quantidadeEmEstoque;
            CategoriaId = categoriaId;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }

        public Guid CategoriaId { get; set; }
        public Categoria? Categoria { get; set; } = new();

    }
}