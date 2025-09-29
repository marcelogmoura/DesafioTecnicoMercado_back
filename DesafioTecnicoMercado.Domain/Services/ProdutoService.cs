using DesafioTecnicoMercado.Domain.Dtos.Request;
using DesafioTecnicoMercado.Domain.Dtos.Response;
using DesafioTecnicoMercado.Domain.Entities;
using DesafioTecnicoMercado.Domain.Interfaces.Repositories;
using DesafioTecnicoMercado.Domain.Interfaces.Services;
using DesafioTecnicoMercado.Domain.Validations;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DesafioTecnicoMercado.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ProdutoValidator _validator;

        public ProdutoService(IProdutoRepository _produtoRepository, 
            ICategoriaRepository _categoriaRepository, 
            ProdutoValidator _validator)
        {
            _produtoRepository = _produtoRepository;
            _categoriaRepository = _categoriaRepository;
            _validator = _validator;
        }

        public ProdutoResponseDto CadastrarProduto(ProdutoRequestDto dto)
        {
            var categoria = _categoriaRepository.GetById(dto.CategoriaId);

            if(categoria == null)
            {
                throw new DomainValidationException("Categoria não encontrada.");
            }

            if(_produtoRepository.GetByNome(dto.Nome))
            {
                throw new DomainValidationException($"Já existe um produto com o nome '{dto.Nome}' cadastrado.");
            }

            var produto = new Produto(
                nome: dto.Nome,
                preco: dto.Preco,
                quantidadeEmEstoque: dto.QuantidadeEmEstoque,
                categoriaId: dto.CategoriaId
            );



            _produtoRepository.Add(produto);

            var responseDto = new ProdutoResponseDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                QuantidadeEmEstoque = produto.QuantidadeEmEstoque,
                CategoriaId = produto.CategoriaId,                
                CategoriaNome = categoria.Nome
            };

            return responseDto;

        }

        public ProdutoResponseDto Update(Guid id, ProdutoRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public List<ProdutoResponseDto> GetAll()
        {
            var produtos = _produtoRepository.GetAll();

            if(produtos == null || !produtos.Any())
            {
                throw new DomainValidationException("Nenhum produto cadastrado.");
            }

            var responseList = produtos.Select(p => new ProdutoResponseDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                QuantidadeEmEstoque = p.QuantidadeEmEstoque,
                CategoriaId = p.CategoriaId,
                CategoriaNome = p.Categoria?.Nome ?? "N/D"
            }).ToList();

            return responseList;
        }

        public ProdutoResponseDto GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }


    }
}