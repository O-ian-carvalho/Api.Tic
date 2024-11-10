using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApiTic.Business.Models;

namespace ApiTic.Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            
            builder.ToTable("Pedidos");

            
            builder.HasKey(p => p.Id);

            
            builder.HasOne(p => p.Cliente)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Cascade); 

            
            builder.Property(p => p.Status)
                .IsRequired()
                .HasConversion<int>(); 

           
            builder.HasMany(p => p.Produtos)
                .WithOne() 
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
