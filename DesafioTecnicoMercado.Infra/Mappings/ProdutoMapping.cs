using DesafioTecnicoMercado.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioTecnicoMercado.Infra.Mappings
{    
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTO"); 
            builder.HasKey(p => p.Id);   
                        
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)                
                .IsRequired();

            builder.HasIndex(p => p.Nome)
                .IsUnique(); // Garante o índice UNIQUE para o nome

            builder.Property(p => p.Preco)
                .HasColumnName("PRECO")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.QuantidadeEmEstoque)
                .HasColumnName("ESTOQUE")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.CategoriaId)
                .HasColumnName("CATEGORIA_ID")
                .HasColumnType("uniqueidentifier")
                .IsRequired();
                        
            builder.HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}