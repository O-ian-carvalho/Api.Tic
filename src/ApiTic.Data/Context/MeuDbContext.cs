using ApiTic.Business.Models;
using ApiTic.Data.Mapping;
using ApiTic.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApiTic.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options) 
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = true;
        }


        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<TipoDeProduto> TiposDeProduto { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var stringProperties = entityType.GetProperties()
                    .Where(p => p.ClrType == typeof(string) && p.GetColumnType() == null);

                foreach (var property in stringProperties)
                {
                    property.SetColumnType("varchar(200)");
                }
            }
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
