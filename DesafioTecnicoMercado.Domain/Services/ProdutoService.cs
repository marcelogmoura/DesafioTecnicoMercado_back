using DesafioTecnicoMercado.Domain.Dtos.Request;
using DesafioTecnicoMercado.Domain.Dtos.Response;
using DesafioTecnicoMercado.Domain.Entities;
using DesafioTecnicoMercado.Domain.Interfaces.Repositories;
using DesafioTecnicoMercado.Domain.Interfaces.Services;
using DesafioTecnicoMercado.Domain.Validations;
using FluentValidation;  

namespace DesafioTecnicoMercado.Domain.Services
{   
    public class ProdutoService(
        IProdutoRepository produtoRepository,
        ICategoriaRepository categoriaRepository,
        ProdutoValidator validator
    ) : IProdutoService
    {
        public ProdutoResponseDto CadastrarProduto(ProdutoRequestDto dto)
        {
            
            var categoria = categoriaRepository.GetById(dto.CategoriaId);
            if (categoria == null)
            {
                throw new DomainValidationException("Categoria não encontrada. Verifique o ID informado.");
            }

          
            var produto = new Produto(
                nome: dto.Nome,
                preco: dto.Preco,
                quantidadeEmEstoque: dto.QuantidadeEmEstoque,
                categoriaId: dto.CategoriaId
            );

          
            var validationResult = validator.Validate(produto);
            if (!validationResult.IsValid)
            {
          
                throw new ValidationException(validationResult.Errors);
            }

          
            if (produtoRepository.GetByNome(produto.Nome, null)) 
            {
                throw new DomainValidationException($"Já existe um produto com o nome '{produto.Nome}' cadastrado.");
            }

            
            produtoRepository.Add(produto);

            
            return new ProdutoResponseDto
            {
                Id = produto.Id,
                Nome = produto.Nome ?? string.Empty,
                Preco = produto.Preco,
                QuantidadeEmEstoque = produto.QuantidadeEmEstoque,
                CategoriaId = produto.CategoriaId,
                CategoriaNome = categoria.Nome 
            };
        }

        public ProdutoResponseDto AtualizarProduto(Guid id, ProdutoRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public List<ProdutoResponseDto> ListarProdutos()
        {
            var produtos = produtoRepository.GetAll();

            if (produtos == null)
                throw new DomainValidationException("Nenhum produto cadastrado.");

            var responseList = produtos.Select(produto =>
            {
                var categoria = categoriaRepository.GetById(produto.CategoriaId);
                return new ProdutoResponseDto
                {
                    Id = produto.Id,
                    Nome = produto.Nome ?? string.Empty,
                    Preco = produto.Preco,
                    QuantidadeEmEstoque = produto.QuantidadeEmEstoque,
                    CategoriaId = produto.CategoriaId,
                    CategoriaNome = categoria?.Nome ?? "Categoria não encontrada"
                };
            }).ToList();

            return responseList;

        }

        public ProdutoResponseDto ObterProdutoPorId(Guid id)
        {
            var produto = produtoRepository.GetById(id);

            if(produto == null)
                throw new DomainValidationException("Produto não encontrado. Verifique o ID informado.");

            return new ProdutoResponseDto
            {
                Id = produto.Id,
                Nome = produto.Nome ?? string.Empty,
                Preco = produto.Preco,
                QuantidadeEmEstoque = produto.QuantidadeEmEstoque,
                CategoriaId = produto.CategoriaId,
                CategoriaNome = categoriaRepository.GetById(produto.CategoriaId)?.Nome ?? "Categoria não encontrada"
            };
        }

        public void ExcluirProduto(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}