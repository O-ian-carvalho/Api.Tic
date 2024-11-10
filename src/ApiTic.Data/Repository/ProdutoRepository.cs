using ApiTic.Business.Interfaces;
using ApiTic.Business.Models;
using ApiTic.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTic.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MeuDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Produto>> ListarProdutosPorPedido(Guid pedidoId)
        {
            return await Buscar(p=> p.PedidoId == pedidoId);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorTipo(Guid TipoId)
        {
            return await Buscar(p => p.CategoriaId == TipoId);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosTipo()
        {
            return await Db.Produtos.Include(f => f.Categoria).OrderBy(f => f.Nome).ToListAsync();
        }

        public async Task<Produto> ObterProdutoTipo(Guid id)
        {
            return await Db.Produtos.AsNoTracking().Include(f => f.Categoria).FirstOrDefaultAsync(p => p.Id == id);
        }

      
    }
}
