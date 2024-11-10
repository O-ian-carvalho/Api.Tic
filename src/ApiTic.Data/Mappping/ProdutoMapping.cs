using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApiTic.Business.Models;

namespace ApiTic.Data.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
           
            builder.ToTable("Produtos");

            
            builder.HasKey(p => p.Id);

            
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            
            builder.Property(p => p.Valor)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); 
            

            builder.HasOne(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.PedidoId)
                .IsRequired(false);

           
        }
    }
}
