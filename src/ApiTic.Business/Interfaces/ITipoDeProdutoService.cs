using ApiTic.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTic.Business.Interfaces
{
    public interface ITipoDeProdutoService 
    {
        Task Adicionar(TipoDeProduto tipoDeProduto);
        Task Atualizar(TipoDeProduto tipoDeProduto);
        Task Remover(Guid id);

    }
}
