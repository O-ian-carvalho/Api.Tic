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
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(MeuDbContext db) : base(db)
        {
        }

        public async Task<Cliente> ObterClientePedidos(Guid clienteId)
        {
            return await Db.Cliente.AsNoTracking().Include(p => p.Pedidos).FirstOrDefaultAsync(p => p.Id == clienteId);

        }

        public async Task<IEnumerable<Cliente>> ObterClientesPedidos()
        {
            return await Db.Cliente.AsNoTracking().Include(p => p.Pedidos).ToListAsync();
        }
    }
}
