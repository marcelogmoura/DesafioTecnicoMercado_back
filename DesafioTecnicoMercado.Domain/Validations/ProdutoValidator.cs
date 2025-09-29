using DesafioTecnicoMercado.Domain.Entities;
using FluentValidation;

namespace DesafioTecnicoMercado.Domain.Validations
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            // 1. Regra de Negócio: Nome Obrigatório e Tamanho Mínimo
            RuleFor(produto => produto.Nome)
                .NotEmpty()
                .WithMessage("O nome do produto é obrigatório.")
                .MaximumLength(100)
                .WithMessage("O nome do produto não pode exceder 100 caracteres.");

            // 2. Regra de Negócio: O preço do produto não pode ser negativo.
            RuleFor(produto => produto.Preco)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O preço do produto não pode ser negativo.");

            // 3. Validação Básica para Estoque
            RuleFor(produto => produto.QuantidadeEmEstoque)
                .GreaterThanOrEqualTo(0)
                .WithMessage("A quantidade em estoque não pode ser negativa.");

            // 4. Regra de Negócio: Ao cadastrar ou editar um produto, é obrigatório informar uma categoria.
            RuleFor(produto => produto.CategoriaId)
                .NotEmpty()
                .WithMessage("A categoria do produto é obrigatória.");
        }
    }
}