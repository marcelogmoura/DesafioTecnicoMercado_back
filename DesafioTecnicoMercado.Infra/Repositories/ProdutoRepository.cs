using DesafioTecnicoMercado.Domain.Entities;
using DesafioTecnicoMercado.Domain.Interfaces.Repositories;
using DesafioTecnicoMercado.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DesafioTecnicoMercado.Infra.Repositories
{    
    public class ProdutoRepository(DataContext context) : IProdutoRepository
    {
        private readonly DataContext _context = context;

        public void Add(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Update(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }

        public void Delete(Produto produto)
        {
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }

        public List<Produto> GetAll()
        {            
            return _context.Produtos.Include(p => p.Categoria).ToList();
        }

        public Produto? GetById(Guid id)
        {            
            return _context.Produtos.Include(p => p.Categoria).SingleOrDefault(p => p.Id == id);
        }

        // Regra de Negócio: Não pode cadastrar produtos com o mesmo nome.
        public bool GetByNome(string nome, Guid? exclusaoId = null)
        {
            // Busca por nome (case-insensitive)
            var query = _context.Produtos.Where(p => p.Nome.ToLower().Equals(nome.ToLower()));

            // Se estiver editando, ignora o próprio ID na busca por duplicidade
            if (exclusaoId.HasValue)
            {
                query = query.Where(p => p.Id != exclusaoId.Value);
            }

            return query.Any();
        }
    }
}