using ApiTic.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTic.Business.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<IEnumerable<Pedido>> ObterPedidoPorCliente(Guid clinteId);
        Task AdicionarProdutoAoPedido(Guid pedidoId, Produto produto);
    }
}
