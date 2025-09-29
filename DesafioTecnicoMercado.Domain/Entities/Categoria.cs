namespace DesafioTecnicoMercado.Domain.Entities
{
    public class Categoria
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;

        public List<Produto> Produtos { get; set; } = new();
    }
}
