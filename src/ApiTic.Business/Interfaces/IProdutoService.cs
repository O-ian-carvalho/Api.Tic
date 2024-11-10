using ApiTic.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTic.Business.Interfaces
{
    public interface IProdutoService
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Guid id);
        Task AdicionarProdutoPedido(Produto produto, Guid pedidoId);
        Task RemoverProdutoPedido(Produto prodduto, Guid pedidoId);
    }
}
