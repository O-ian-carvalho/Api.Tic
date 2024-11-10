using ApiTic.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTic.Business.Interfaces
{
    public interface ITipoDeProdutoRepository : IRepository<TipoDeProduto>
    {
        Task<TipoDeProduto> ObterTipoDeProdutoProdutos(Guid tipoDePRodutoid);
    }
}
