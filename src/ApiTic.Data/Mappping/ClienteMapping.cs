using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApiTic.Business.Models;

namespace ApiTic.Data.Mapping
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.NumeroContato)
                .HasMaxLength(15);

            builder.Property(c => c.DataDeNascimento)
                .IsRequired();

            builder.HasMany(c => c.Pedidos)
                .WithOne(p => p.Cliente) 
                .HasForeignKey(p => p.ClienteId) 
                .OnDelete(DeleteBehavior.Cascade); 

           
        }
    }
}