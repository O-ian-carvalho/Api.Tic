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
    public class TipoDeProdutoRepository : Repository<TipoDeProduto>, ITipoDeProdutoRepository
    {
        public TipoDeProdutoRepository(MeuDbContext db) : base(db)
        {
        }

        public async Task<TipoDeProduto> ObterTipoDeProdutoProdutos(Guid tipoDePRodutoid)
        {
            return await Db.TiposDeProduto.AsNoTracking().Include(p => p.Produtos).FirstOrDefaultAsync(p => p.Id == tipoDePRodutoid);
        }
    }
}
