using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApiTic.Business.Models;

namespace ApiTic.Data.Mapping
{
    public class TipoDeProdutoMapping : IEntityTypeConfiguration<TipoDeProduto>
    {
        public void Configure(EntityTypeBuilder<TipoDeProduto> builder)
        {
           
            builder.ToTable("TiposDeProduto");

            
            builder.HasKey(tp => tp.Id);

           
            builder.Property(tp => tp.Titulo)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Titulo"); 

            
        }
    }
}
