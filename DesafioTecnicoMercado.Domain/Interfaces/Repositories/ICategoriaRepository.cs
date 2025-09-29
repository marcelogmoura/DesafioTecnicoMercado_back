using DesafioTecnicoMercado.Domain.Entities;

namespace DesafioTecnicoMercado.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository
    {
        List<Categoria> GetAll();
               
        Categoria? GetById(Guid id);
    }
}
