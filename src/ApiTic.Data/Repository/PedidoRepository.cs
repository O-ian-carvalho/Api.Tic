using ApiTic.Business.Interfaces;
using ApiTic.Business.Models;
using ApiTic.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTic.Data.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(MeuDbContext db) : base(db)
        {
        }

        public async Task AdicionarProdutoAoPedido(Guid pedidoId, Produto produto)
        {
            produto.PedidoId = pedidoId;
            Db.Update(produto);
            await SaveChanges();
        }

        public async Task<IEnumerable<Pedido>> ObterPedidoPorCliente(Guid clinteId)
        {
            return await Buscar( p => p.ClienteId == clinteId);
        }
    }
}
