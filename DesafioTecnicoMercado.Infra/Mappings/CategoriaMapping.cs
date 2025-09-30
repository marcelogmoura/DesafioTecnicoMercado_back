using DesafioTecnicoMercado.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioTecnicoMercado.Infra.Mappings
{    
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("CATEGORIA"); 
            builder.HasKey(c => c.Id);    
             
            builder.Property(c => c.Id)
                .HasColumnName("ID")
                .HasColumnType("uniqueidentifier") 
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(c => c.Produtos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);  
        }
    }
}