using ApiTic.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTic.Business.Interfaces
{
    public interface IClienteService : IDisposable
    {
        Task Adicionar(Cliente cliente);
        Task Atualizar(Cliente cliente);
        Task Remover(Guid id);

    }
}
