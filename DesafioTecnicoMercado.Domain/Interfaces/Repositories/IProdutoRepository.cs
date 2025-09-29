using DesafioTecnicoMercado.Domain.Entities;

namespace DesafioTecnicoMercado.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        void Add(Produto produto);
        void Update(Produto produto);   
        void Delete(Produto produto);   
        List<Produto> GetAll();
        bool GetByNome(string nome, Guid? exclusaoId = null);
        Produto? GetById(Guid id);
    }
}
