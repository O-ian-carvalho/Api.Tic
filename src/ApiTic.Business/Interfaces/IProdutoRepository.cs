using ApiTic.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTic.Business.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorTipo(Guid TipoId);
        Task<IEnumerable<Produto>> ObterProdutosTipo();
        Task<Produto> ObterProdutoTipo(Guid id);
        Task<IEnumerable<Produto>> ListarProdutosPorPedido(Guid pedidoId);
    }
}
