using DesafioTecnicoMercado.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using DesafioTecnicoMercado.Infra.Mappings;

namespace DesafioTecnicoMercado.Infra.Contexts
{
    public class DataContext : DbContext
    {        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
             
        public DataContext()
        {
        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {       
        
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDMercado;Integrated Security=True;");
            }
        }
                
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMapping());
            modelBuilder.ApplyConfiguration(new CategoriaMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}