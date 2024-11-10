using ApiTic.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTic.Business.Interfaces
{
    public interface IPedidoService
    {
        Task Adicionar(Pedido pedido);
        Task FinalizarPedido(Pedido pedido);
        Task Remover(Guid id);
    }
}
