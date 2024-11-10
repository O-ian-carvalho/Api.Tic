using ApiTic.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTic.Business.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterClientePedidos(Guid clienteId);
        Task<IEnumerable<Cliente>> ObterClientesPedidos();

    }
}
