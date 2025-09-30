using DesafioTecnicoMercado.Domain.Entities;
using DesafioTecnicoMercado.Domain.Interfaces.Repositories;
using DesafioTecnicoMercado.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DesafioTecnicoMercado.Infra.Repositories
{    
    public class CategoriaRepository(DataContext context) : ICategoriaRepository
    {
        private readonly DataContext _context = context;

        public List<Categoria> GetAll()
        { 
            return _context.Categorias.OrderBy(c => c.Nome).ToList();
        }

        public Categoria? GetById(Guid id)
        {
            return _context.Categorias.SingleOrDefault(c => c.Id == id);
        }
    }
}